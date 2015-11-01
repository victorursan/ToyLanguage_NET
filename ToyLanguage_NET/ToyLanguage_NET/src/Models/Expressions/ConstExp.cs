using System;

namespace ToyLanguage_NET {
	public class ConstExp: Exp {
		public int number;

		public ConstExp(int number) {
			this.number = number;
		}
			
		public int eval(MapInterface<String, int> tbl) {
			return number;
		}
			
		public String toStr() {
			return " " + number + " ";
		}
	}
}

