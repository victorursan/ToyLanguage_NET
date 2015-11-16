using System;

namespace ToyLanguage_NET {
	public class Controller {
		private Repository repo;
		private PrgState crtPrgState;
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
			crtPrgState = repo.getCrtProgram ();
		}

		public void serializeProgramState () {
			repo.serializePrgStatet ();
		}

		public void oneStep () {
			StackInterface<IStmt> stk = crtPrgState.getExeStack ();
			try {
				
				IStmt crtStmt = stk.Pop ();
				if (crtStmt is CompStmt) {
					CompStmt crtStmt1 = (CompStmt)crtStmt;
					stk.Push (crtStmt1.Second);
					stk.Push (crtStmt1.First);
				} else if (crtStmt is AssignStmt) {
					AssignStmt crtStmt1 = (AssignStmt)crtStmt;
					Exp exp = crtStmt1.Exp;
					String id = crtStmt1.Id;
					MapInterface<String, int> symTbl = repo.getCrtProgram ().getSymTable ();
					int val = exp.eval (symTbl);
					if (symTbl.ContainsKey (id)) {
						symTbl [id] = val;
					} else {
						symTbl.Add (id, val);
					}
				} else if (crtStmt is IfStmt) {
					IfStmt crtStmt1 = (IfStmt)crtStmt;
					MapInterface<String, int> symTbl = crtPrgState.getSymTable ();
					if (crtStmt1.Exp.eval (symTbl) != 0) {
						stk.Push (crtStmt1.ThenS);
					} else {
						stk.Push (crtStmt1.ElseS);
					}
				} else if (crtStmt is PrintStmt) {
					PrintStmt crtStmt1 = (PrintStmt)crtStmt;
					ListInterface<int> output = crtPrgState.getOut ();
					output.Add (crtStmt1.Exp.eval (crtPrgState.getSymTable ()));
				} else if (crtStmt is WhileStmt) {
					WhileStmt crtStmt1 = (WhileStmt)crtStmt;
					MapInterface<String, int> symTbl = crtPrgState.getSymTable ();
					if (crtStmt1.getExp ().eval (symTbl) != 0) {
						stk.Push (crtStmt1);
						stk.Push (crtStmt1.getStmt ());
					}
				} else if (crtStmt is SkipStmt) {
					//nothing
				} else if (crtStmt is SwitchStmt) {
					SwitchStmt crtStmt1 = (SwitchStmt)crtStmt;
					Exp difSwitch = new ArithExp (crtStmt1.getExp (), "-", crtStmt1.getExpCase2 ());
					Exp difSwitch2 = new ArithExp (crtStmt1.getExp (), "-", crtStmt1.getExpCase1 ());
					IStmt ifSwitch = new IfStmt (difSwitch2, crtStmt1.getDefaultCase (), crtStmt1.getCase1 ());
					IStmt switchStmt = new IfStmt (difSwitch, ifSwitch, crtStmt1.getCase2 ());
					stk.Push (switchStmt);
				} else if (crtStmt is IfThenStmt) {
					IfThenStmt crtStmt1 = (IfThenStmt)crtStmt;
					stk.Push (new IfStmt (crtStmt1.getExp (), crtStmt1.getThenS (), new SkipStmt ()));
				}


			} catch (EmptyStackException) {
				throw new MyStmtExecException ();
			}
			if (printFlag) {
				Console.WriteLine (crtPrgState.printState ());
			}
			if (logFlag) {
				repo.logPrgState ();
			}
		}

		public void allStep () {
			while (crtPrgState.getExeStack ().Count > 0) {
				oneStep ();
			}
		}

	}
}

