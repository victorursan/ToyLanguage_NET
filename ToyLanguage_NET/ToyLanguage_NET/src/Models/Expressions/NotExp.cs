using System;

namespace ToyLanguage_NET {
	[Serializable] public class NotExp: Exp {
		private Exp exp;

		public NotExp (Exp exp) {
			this.exp = exp;
		}

		public int eval (MapInterface<String, int> tbl, HeapInterface<int> heap) {
			return exp.eval (tbl, heap) == 0 ? 1 : 0;
		}

		public override string ToString () {
			return "!(" + exp + ")";
		}
	}
}

