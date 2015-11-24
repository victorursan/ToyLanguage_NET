using System;

namespace ToyLanguage_NET {
	[Serializable] public class RelationalExp: Exp {
		private Exp e1;
		private Exp e2;
		private String op;

		public RelationalExp (Exp e1, String op, Exp e2) {
			this.e1 = e1;
			this.e2 = e2;
			this.op = op;
		}

		public int eval (MapInterface<String, int> tbl, HeapInterface<int> heap) {
			if (op.Equals ("<"))
				return (e1.eval (tbl, heap) < e2.eval (tbl, heap)) ? 1 : 0;
			if (op.Equals ("<="))
				return (e1.eval (tbl, heap) <= e2.eval (tbl, heap)) ? 1 : 0;
			if (op.Equals ("=="))
				return (e1.eval (tbl, heap).Equals (e2.eval (tbl, heap))) ? 1 : 0;
			if (op.Equals ("!="))
				return (!e1.eval (tbl, heap).Equals (e2.eval (tbl, heap))) ? 1 : 0;
			if (op.Equals (">"))
				return (e1.eval (tbl, heap) > e2.eval (tbl, heap)) ? 1 : 0;
			if (op.Equals (">="))
				return (e1.eval (tbl, heap) >= e2.eval (tbl, heap)) ? 1 : 0;
			return 0;
		}

		public override string ToString () {
			return "(" + e1 + " " + op + " " + e2 + ")";
		}
	}
}

