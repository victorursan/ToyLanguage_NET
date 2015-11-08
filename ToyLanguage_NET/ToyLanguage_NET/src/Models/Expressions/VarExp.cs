using System;

namespace ToyLanguage_NET {
	public class VarExp: Exp {
		private String id;

		public VarExp (String id) {
			this.id = id;
		}

		public String Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}

		#region Exp implementation

		public int eval (MapInterface<String, int> tbl) {
			if (tbl.ContainsKey (id)) {
				return tbl [id];
			} else {
				throw new UninitializedVariableException ();
			}
		}
			
		#endregion

		public override string ToString () {
			return " " + id + " ";
		}

	}
}

