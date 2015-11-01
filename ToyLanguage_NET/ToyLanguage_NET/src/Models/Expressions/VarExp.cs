using System;

namespace ToyLanguage_NET {
	public class VarExp: Exp {
		private String id;

		public VarExp (String id) {
			this.id = id;
		}

		#region Exp implementation

		public int eval (MapInterface<String, int> tbl) {
			if (tbl.ContainsKey (id)) {
				return tbl [id];
			} else {
				throw new UninitializedVariableException ();
			}
		}

		public string toStr () {
			return " " + id + " ";
		}

		#endregion
	}
}

