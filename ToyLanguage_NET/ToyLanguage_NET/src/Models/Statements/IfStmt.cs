using System;

namespace ToyLanguage_NET {
	[Serializable] public class IfStmt: IStmt {
		private Exp exp;
		private IStmt thenS;
		private IStmt elseS;

		public Exp Exp {
			get {
				return exp;
			}
			set {
				exp = value;
			}
		}

		public IStmt ThenS {
			get {
				return thenS;
			}
			set {
				thenS = value;
			}
		}

		public IStmt ElseS {
			get {
				return elseS;
			}
			set {
				elseS = value;
			}
		}

		public IfStmt (Exp e, IStmt t, IStmt el) {
			exp = e;
			thenS = t;
			elseS = el;
		}

		#region IStmt implementation

		public override string ToString () {
			return "IF( " + exp.ToString () + " )THEN( " + thenS.ToString () + " )ELSE( " + elseS.ToString () + " )";
		}

		public PrgState execute (PrgState state) {
			MapInterface<String, int> symTbl = state.SymTable;
			HeapInterface<int> heap = state.HeapTable;
			if (Exp.eval (symTbl, heap) != 0) {
				state.ExeStack.Push (ThenS);
			} else {
				state.ExeStack.Push (ElseS);
			}
			return state;
		}

		#endregion
			
	}
}

