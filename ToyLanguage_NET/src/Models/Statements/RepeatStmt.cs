using System;

namespace ToyLanguage_NET {
	[Serializable ]public class RepeatStmt: IStmt{
		private Exp exp;
		private IStmt stmt;

		public RepeatStmt (IStmt statement, Exp expr) {
			exp = expr;
			stmt = statement;
		}

		#region IStmt implementation

		public override string ToString () {
			return "repeat (" + stmt.ToString () + ") until " + exp.ToString () + "";
		}

		public PrgState execute (PrgState state) {
			state.ExeStack.Push (new CompStmt (stmt, new WhileStmt (new NotExp (exp), stmt)));
			return null;
		}

		#endregion
	}
}

