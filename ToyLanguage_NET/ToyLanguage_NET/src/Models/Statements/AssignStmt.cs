using System;

namespace ToyLanguage_NET {
	[Serializable] public class AssignStmt : IStmt {
		private String id;
		private Exp exp;

		public String Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}

		public Exp Exp {
			get {
				return exp;
			}
			set {
				exp = value;
			}
		}

		public AssignStmt (String id, Exp exp) {
			this.id = id;
			this.exp = exp;
		}

		#region IStmt implementation

		public override string ToString () {
			return id.ToString () + " = " + exp.ToString ();
		}

		public PrgState execute (PrgState state) {
			MapInterface<String, int> symTbl = state.SymTable;
			HeapInterface<int> heap = state.HeapTable;
			int val = exp.eval (symTbl, heap);
			symTbl [id] = val;
			return state;
		}

		#endregion

	}
}

