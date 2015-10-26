using System;

namespace ToyLanguage_NET {
	public class AssignStmt : IStmt{
		public String id;
		public Exp exp;

		public AssignStmt(String id, Exp exp) {
			this.id = id;
			this.exp = exp;
		}
			
		#region IStmt implementation

		public string toStr () {
			return id + " = " + exp.toStr();
		}

		#endregion
	}
}

