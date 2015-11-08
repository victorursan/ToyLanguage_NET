using System;

namespace ToyLanguage_NET {
	public class Controller {
		private Repository repo;
		private PrgState crtPrgState;
		public bool printFlag;

		public Controller(Repository thisRepo) {
			printFlag = true;
			repo = thisRepo;
			crtPrgState = repo.getCrtProgram();
		}

		public void oneStep() {
			StackInterface<IStmt> stk = crtPrgState.getExeStack();
			if (stk.Count == 0) {
				throw new MyStmtExecException();
			}
			IStmt crtStmt = stk.Pop ();
			if (crtStmt is CompStmt) {
				CompStmt crtStmt1 = (CompStmt) crtStmt;
				stk.Push(crtStmt1.Second);
				stk.Push(crtStmt1.First);
			} else if (crtStmt is AssignStmt) {
				AssignStmt crtStmt1 = (AssignStmt) crtStmt;
				Exp exp = crtStmt1.Exp;
				String id = crtStmt1.Id;
				MapInterface<String, int> symTbl = repo.getCrtProgram().getSymTable();
				int val = exp.eval(symTbl);
				if (symTbl.ContainsKey(id)) {
					symTbl[id] = val;
				} else {
					symTbl.Add(id, val);
				}
			} else if (crtStmt is IfStmt) {
				IfStmt crtStmt1 = (IfStmt) crtStmt;
				MapInterface<String, int> symTbl = crtPrgState.getSymTable();
				if (crtStmt1.Exp.eval(symTbl) != 0) {
					stk.Push(crtStmt1.ThenS);
				} else {
					stk.Push(crtStmt1.ElseS);
				}
			} else if (crtStmt is PrintStmt) {
				PrintStmt crtStmt1 = (PrintStmt) crtStmt;
				ListInterface<int> output = crtPrgState.getOut();
				output.Add(crtStmt1.Exp.eval(crtPrgState.getSymTable()));
			}
			if (printFlag) {
				crtPrgState.printState();
			}
		}

		public void allStep() {
			while(crtPrgState.getExeStack().Count > 0){
				oneStep();
			}
		}

	}
}

