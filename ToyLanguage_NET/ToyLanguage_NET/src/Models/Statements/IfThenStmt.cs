using System;

namespace ToyLanguage_NET {
	[Serializable] public class IfThenStmt: IStmt {
		private Exp exp;
		private IStmt thenS;

		public Exp getExp() {
			return exp;
		}

		public IStmt getThenS() {
			return thenS;
		}

		public void setExp(Exp exp) {
			this.exp = exp;
		}

		public void setThenS(IStmt thenS) {
			this.thenS = thenS;
		}

		public IfThenStmt(Exp e, IStmt t) {
			exp = e;
			thenS = t;
		}
			
		public override string ToString() {
			return "IF(" + exp.ToString() + ")THEN(" + thenS.ToString() + ")";
		}
	}
}

