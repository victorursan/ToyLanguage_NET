using System;

namespace ToyLanguage_NET {
	public class IfStmt: IStmt {
		public Exp exp;
		public IStmt thenS;
		public IStmt elseS;

		public IfStmt(Exp e, IStmt t, IStmt el) {
			exp = e;
			thenS = t;
			elseS = el;
		}

		#region IStmt implementation

		public string toStr () {
			return "IF( " +  exp.toStr() + " )THEN( " + thenS.toStr()  + " )ELSE( " + elseS.toStr() + " )";
		}

		#endregion
	}
}

