using System;

namespace ToyLanguage_NET {
	public class Controller {
		private Repository repo;
//		private PrgState crtPrgState;
		private bool printFlag;
		private bool logFlag;

		public PrgState CrtPrgState {
			get {
				return repo.getCrtProgram ();
			}
		}

		public bool PrintFlag {
			get {
				return printFlag;
			}
			set {
				printFlag = value;
			}
		}

		public bool LogFlag {
			get {
				return logFlag;
			}
			set {
				logFlag = value;
			}
		}


		public Controller (Repository thisRepo) {
			printFlag = true;
			logFlag = true;
			repo = thisRepo;
//			crtPrgState = repo.getCrtProgram ();
		}

		public void serializeProgramState () {
			repo.serializePrgStatet ();
		}

		public PrgState oneStep (PrgState state) {
			StackInterface<IStmt> stk = state.ExeStack;
			if (printFlag) {
				Console.WriteLine (state.PrintState ());
			}
			if (logFlag) {
				repo.logPrgState ();
			}
			try {
				IStmt crtStmt = stk.Pop ();
				return crtStmt.execute (state);
			} catch (EmptyStackException) {
				throw new MyStmtExecException ();
			}
		}

		public void allStep (PrgState state) {
			while (true) { //(crtPrgState.getExeStack ().Count > 0) {
				oneStep (state);
			}
		}

	}
}

