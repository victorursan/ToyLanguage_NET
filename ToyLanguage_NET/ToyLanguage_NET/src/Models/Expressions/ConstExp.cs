using System;

namespace ToyLanguage_NET {
	[Serializable] public class ConstExp: Exp {
		private int number;

		public ConstExp(int number) {
			this.number = number;
		}

		public int Number {
			get {
				return number;
			}
			set {
				number = value;
			}
		}
			
		#region Exp implementation

		public int eval(MapInterface<String, int> tbl) {
			return number;
		}

		#endregion

		public override string ToString () {
			return " " + number + " ";
		}
	}
}

