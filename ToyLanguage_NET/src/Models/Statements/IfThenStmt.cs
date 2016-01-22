using System;

namespace ToyLanguage_NET {
	[Serializable] public class IfThenStmt: IStmt {
		private Exp exp;
		private IStmt thenS;

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

		public IfThenStmt (Exp e, IStmt t) {
			exp = e;
			thenS = t;
		}

		#region IStmt implementation

		public override string ToString () {
			return "IF(" + exp.ToString () + ")THEN(" + thenS.ToString () + ")";
		}

		public PrgState execute (PrgState state) {
			state.ExeStack.Push (new IfStmt (Exp, ThenS, new SkipStmt ()));
			return null;
		}

		#endregion
	}
}

