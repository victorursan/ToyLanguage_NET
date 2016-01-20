using System;

namespace ToyLanguage_NET {
	[Serializable] public class SwitchStmt: IStmt {
		private Exp exp;
		private Exp expCase1;
		private IStmt case1;
		private Exp expCase2;
		private IStmt case2;
		private IStmt defaultCase;

		public SwitchStmt (Exp exp, Exp opCase1, IStmt case1, Exp opCase2, IStmt case2, IStmt defaultCase) {
			this.exp = exp;
			this.expCase1 = opCase1;
			this.case1 = case1;
			this.case2 = case2;
			this.expCase2 = opCase2;
			this.defaultCase = defaultCase;
		}

		public Exp Exp {
			get {
				return exp;
			}
		}

		public Exp ExpCase1 {
			get {
				return expCase1;
			}
		}

		public IStmt Case1 {
			get {
				return case1;
			}
		}

		public Exp ExpCase2 {
			get {
				return expCase2;
			}
		}

		public IStmt Case2 {
			get {
				return case2;
			}
		}

		public IStmt DefaultCase {
			get {
				return defaultCase;
			}
		}

		#region IStmt implementation

		public override string ToString () {
			return "SWITCH(" + exp.ToString () + ") " + " case " + expCase1.ToString () + ": " + case1.ToString ()
			+ " case " + expCase2.ToString () + ": " + case2.ToString () + " default: " + defaultCase.ToString ();
		}

		public PrgState execute (PrgState state) {
			Exp difSwitch = new ArithExp (Exp, "-", ExpCase2);
			Exp difSwitch2 = new ArithExp (Exp, "-", ExpCase1);
			IStmt ifSwitch = new IfStmt (difSwitch2, DefaultCase, Case1);
			IStmt switchStmt = new IfStmt (difSwitch, ifSwitch, Case2);
			state.ExeStack.Push (switchStmt);
			return state;
		}

		#endregion
	}
}

