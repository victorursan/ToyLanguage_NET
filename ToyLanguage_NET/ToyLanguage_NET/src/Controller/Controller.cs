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
			StackInterface stk = crtPrgState.getExeStack();
			if (stk.Count == 0) {
				throw new MyStmtExecException();
			}
			IStmt crtStmt = stk.Pop ();
			if (crtStmt is CompStmt) {
				CompStmt crtStmt1 = (CompStmt) crtStmt;
				stk.Push(crtStmt1.second);
				stk.Push(crtStmt1.first);
			} else if (crtStmt is AssignStmt) {
				AssignStmt crtStmt1 = (AssignStmt) crtStmt;
				Exp exp = crtStmt1.exp;
				String id = crtStmt1.id;
				MapInterface symTbl = repo.getCrtProgram().getSymTable();
				int val = exp.eval(symTbl);
				if (symTbl.ContainsKey(id)) {
					symTbl[id] = val;
				} else {
					symTbl.Add(id, val);
				}
			} else if (crtStmt is IfStmt) {
				IfStmt crtStmt1 = (IfStmt) crtStmt;
				MapInterface symTbl = crtPrgState.getSymTable();
				if (crtStmt1.exp.eval(symTbl) != 0) {
					stk.Push(crtStmt1.thenS);
				} else {
					stk.Push(crtStmt1.elseS);
				}
			} else if (crtStmt is PrintStmt) {
				PrintStmt crtStmt1 = (PrintStmt) crtStmt;
				ListInterface output = crtPrgState.getOut();
				output.Add(crtStmt1.exp.eval(crtPrgState.getSymTable()));
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

