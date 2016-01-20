using System;

namespace ToyLanguage_NET {
	[Serializable] public class PrintStmt: IStmt {
		private Exp exp;

		public PrintStmt (Exp expression) {
			exp = expression;
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
			return "print( " + exp.ToString () + " )";
		}

		public PrgState execute (PrgState state) {
			ListInterface<int> output = state.Output;
			MapInterface<String, int> symTbl = state.SymTable;
			HeapInterface<int> heap = state.HeapTable;
			output.Add (Exp.eval (symTbl, heap));
			return null;
		}

		#endregion
	}
}

