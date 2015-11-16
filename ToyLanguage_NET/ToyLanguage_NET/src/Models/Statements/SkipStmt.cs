using System;

namespace ToyLanguage_NET {
	[Serializable] public class SkipStmt: IStmt {
		public SkipStmt () {
		}

		public override string ToString() {
			return " SKIP ";
		}
	}
}

