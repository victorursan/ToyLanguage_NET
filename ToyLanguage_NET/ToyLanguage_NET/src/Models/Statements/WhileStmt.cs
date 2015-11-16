using System;

namespace ToyLanguage_NET {
	[Serializable] public class WhileStmt: IStmt {
		private Exp exp;
		private IStmt stmt;

		public WhileStmt(Exp e, IStmt stmt) {
			this.exp = e;
			this.stmt = stmt;
		}

		public Exp getExp() {
			return exp;
		}

		public IStmt getStmt() {
			return stmt;
		}

		public void settExp(Exp exp) {
			this.exp = exp;
		}

		public void setStmt(IStmt stmt) {
			this.stmt = stmt;
		}

		public override string ToString() {
			return "While( " + exp.ToString() + ") { " + stmt.ToString() + " }";
		}
	}
}

