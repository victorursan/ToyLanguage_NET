using System;

namespace ToyLanguage_NET {
	[Serializable] public class SkipStmt: IStmt {
		public SkipStmt () {
		}

		#region IStmt implementation

		public override string ToString () {
			return " SKIP ";
		}

		public PrgState execute (PrgState state) {
			return null;
		}

		#endregion
	}
}

