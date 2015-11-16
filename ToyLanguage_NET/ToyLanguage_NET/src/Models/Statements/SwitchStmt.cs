using System;

namespace ToyLanguage_NET {
	[Serializable] public class SwitchStmt: IStmt {
		private Exp exp;
		private Exp expCase1;
		private IStmt case1;
		private Exp expCase2;
		private IStmt case2;
		private IStmt defaultCase;

		public SwitchStmt(Exp exp, Exp opCase1, IStmt case1, Exp opCase2, IStmt case2, IStmt defaultCase) {
			this.exp = exp;
			this.expCase1 = opCase1;
			this.case1 = case1;
			this.case2 = case2;
			this.expCase2 = opCase2;
			this.defaultCase = defaultCase;
		}

		public Exp getExp() {
			return exp;
		}

		public Exp getExpCase1() {
			return expCase1;
		}

		public IStmt getCase1() {
			return case1;
		}

		public IStmt getCase2() {
			return case2;
		}

		public Exp getExpCase2() {
			return expCase2;
		}

		public IStmt getDefaultCase() {
			return defaultCase;
		}

		public override string ToString() {
			return "SWITCH(" + exp.ToString() + ") " + " case " + expCase1.ToString() + ": " + case1.ToString()
				+ " case " + expCase2.ToString() + ": " + case2.ToString() + " default: " + defaultCase.ToString();
		}
	}
}

