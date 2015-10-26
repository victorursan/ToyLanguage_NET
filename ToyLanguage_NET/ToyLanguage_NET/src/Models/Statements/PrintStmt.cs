using System;

namespace ToyLanguage_NET {
	public class PrintStmt: IStmt {
		public Exp exp;

		public PrintStmt(Exp expression) {
			exp =  expression;
		}

		#region IStmt implementation

		public string toStr () {
			return "print( " + exp.toStr() + " )";
		}

		#endregion
	}
}

