using System;

namespace ToyLanguage_NET {
	[Serializable] public class WriteHeapStmt: IStmt {
		private String id;
		private Exp exp;

		public WriteHeapStmt (String id, Exp exp) {
			this.id = id;
			this.exp = exp;
		}

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

		#region IStmt implementation

		public override string ToString () {
			return "writeHeap( " + id + ", " + exp.ToString () + ")";
		}

		public PrgState execute (PrgState state) {
			MapInterface<String, int> symTbl = state.SymTable;
			HeapInterface<int> heap = state.HeapTable;
			heap.Update (symTbl [Id], Exp.eval (symTbl, heap));
			return null;
		}

		#endregion
	}
}

