using System;

namespace ToyLanguage_NET {
	public class PrintStmt: IStmt {
		public Exp exp;

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

		public override string ToString () {
			return "print( " + exp.ToString () + " )";
		}

	}
}

