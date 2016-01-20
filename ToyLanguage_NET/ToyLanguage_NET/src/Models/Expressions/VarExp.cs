using System;

namespace ToyLanguage_NET {
	[Serializable] public class VarExp: Exp {
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

		public int eval (MapInterface<String, int> tbl, HeapInterface<int> heap) {
			if (tbl.ContainsKey (id))
				return tbl [id];
			throw new UninitializedVariableException ();
		}

		#endregion

		public override string ToString () {
			return " " + id + " ";
		}

	}
}

