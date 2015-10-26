using System;

namespace ToyLanguage_NET {
	public class CompStmt: IStmt {
		public IStmt first;
		public IStmt second;

		public CompStmt(IStmt left, IStmt right) {
			first = left;
			second = right;
		}

		#region IStmt implementation

		public string toStr () {
			return "(" + first.toStr() + "; " + second.toStr() + ")";
		}

		#endregion
	}
}

