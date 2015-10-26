using System;

namespace ToyLanguage_NET {
	public class VarExp: Exp {
		private String id;

		public VarExp (String id) {
			this.id = id;
		}

		#region Exp implementation

		int Exp.eval (MapInterface tbl) {
			if (tbl.ContainsKey (id)) {
				return tbl [id];
			} else {
				throw new UninitializedVariableException ();
			}
		}

		string Exp.toStr () {
			return " " + id + " ";
		}

		#endregion
	}
}

