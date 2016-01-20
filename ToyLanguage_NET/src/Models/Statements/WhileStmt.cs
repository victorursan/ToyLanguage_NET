using System;

namespace ToyLanguage_NET {
	[Serializable] public class WhileStmt: IStmt {
		private Exp exp;
		private IStmt stmt;

		public WhileStmt (Exp e, IStmt stmt) {
			this.exp = e;
			this.stmt = stmt;
		}

		public Exp Exp {
			get {
				return exp;
			}
			set {
				exp = value;
			}
		}

		public IStmt Stmt {
			get {
				return stmt;
			}
			set {
				stmt = value;
			}
		}

		#region IStmt implementation

		public override string ToString () {
			return "While( " + exp.ToString () + ") { " + stmt.ToString () + " }";
		}

		public PrgState execute (PrgState state) {
			MapInterface<String, int> symTbl = state.SymTable;
			HeapInterface<int> heap = state.HeapTable;
			if (Exp.eval (symTbl, heap) != 0) {
				state.ExeStack.Push (this);
				state.ExeStack.Push (this.Stmt);
			}
			return null;
		}

		#endregion
	}
}

