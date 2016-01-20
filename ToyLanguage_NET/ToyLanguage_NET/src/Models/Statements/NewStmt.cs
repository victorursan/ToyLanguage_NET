using System;

namespace ToyLanguage_NET {
	[Serializable] public class NewStmt: IStmt {
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
			
		public NewStmt(String id, Exp exp) {
			this.id = id;
			this.exp = exp;
		}

		public override string ToString() {
			return "new( " + id + ", " + exp.ToString() + ") ";
		}
			
		public PrgState execute(PrgState state) {
			MapInterface<String, int> symTbl = state.SymTable;
			HeapInterface<int> heap =  state.HeapTable;
			symTbl [id] = heap.Add(Exp.eval(symTbl, heap));
			return state;
		}
	}
}

