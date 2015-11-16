using System;

namespace ToyLanguage_NET {
	[Serializable] public class CompStmt: IStmt {
		private IStmt first;
		private IStmt second;

		public IStmt First {
			get {
				return first;
			}
			set {
				first = value;
			}
		}

		public IStmt Second {
			get {
				return second;
			}
			set {
				second = value;
			}
		}

		public CompStmt (IStmt left, IStmt right) {
			first = left;
			second = right;
		}

		#region IStmt implementation

		public override string ToString () {
			return "(" + first.ToString () + "; " + second.ToString () + ")";
		}

		#endregion
	}
}

