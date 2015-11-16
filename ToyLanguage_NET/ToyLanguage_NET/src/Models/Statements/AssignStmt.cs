using System;

namespace ToyLanguage_NET {
	[Serializable] public class AssignStmt : IStmt {
		private String id;
		private Exp exp;

		public String Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}

		public Exp Exp {
			get {
				return exp;
			}
			set {
				exp = value;
			}
		}

		public AssignStmt (String id, Exp exp) {
			this.id = id;
			this.exp = exp;
		}


		public override string ToString () {
			return id.ToString() + " = " + exp.ToString();
		}

	}
}

