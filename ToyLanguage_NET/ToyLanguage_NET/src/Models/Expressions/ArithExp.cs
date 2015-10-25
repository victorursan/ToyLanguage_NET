using System;

namespace ToyLanguage_NET {
	public class ArithExp: Exp{
		public Exp e1;
		public Exp e2;
		public String op;

		public ArithExp(Exp e1, String op, Exp e2) {
			this.e1 = e1;
			this.e2 = e2;
			this.op = op;
		}
			
		public int eval(MapInterface tbl) {
			if (op == "+") {
				return (e1.eval(tbl) + e2.eval(tbl));
			}
			if (op == "-") {
				return (e1.eval(tbl) - e2.eval(tbl));
			}
			if (op == "*") {
				return (e1.eval(tbl) * e2.eval(tbl));
			}
			if (op == "/") {
				return (e1.eval(tbl) / e2.eval(tbl));
			}
			return 0;
		}
			
		public String toStr() {
			return "(" + e1.toStr() + " " + op + " " + e2.toStr() + ")" ;
		}

	}
}

