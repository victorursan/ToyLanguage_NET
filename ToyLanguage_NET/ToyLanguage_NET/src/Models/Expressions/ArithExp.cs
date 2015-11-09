using System;

namespace ToyLanguage_NET {
	public class ArithExp: Exp {
		private Exp e1;
		private Exp e2;
		private String op;

		public ArithExp (Exp e1, String op, Exp e2) {
			this.e1 = e1;
			this.e2 = e2;
			this.op = op;
		}

		public Exp E1 {
			get {
				return e1;
			}
			set {
				e1 = value;
			}
		}

		public Exp E2 {
			get {
				return e2;
			}
			set {
				e2 = value;
			}
		}

		public String Op {
			get {
				return op;
			}
			set {
				op = value;
			}
		}

		#region Exp implementation

		public int eval (MapInterface<String, int> tbl) {
			if (op == "+") return (e1.eval (tbl) + e2.eval (tbl));
			if (op == "-") return (e1.eval (tbl) - e2.eval (tbl));
			if (op == "*") return (e1.eval (tbl) * e2.eval (tbl));
			if (op == "/") {
				if (e2.eval (tbl) == 0)
					throw new DivisionByZeroException ();
				return (e1.eval (tbl) / e2.eval (tbl));
			}
			return 0;
		}

		#endregion

		public override string ToString () {
			return "(" + e1.ToString () + " " + op + " " + e2.ToString () + ")";
		}

	}
}

