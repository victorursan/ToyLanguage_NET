using System;

namespace ToyLanguage_NET {
	[Serializable] public class ReadExp: Exp {
		private void print (String message) {
			Console.WriteLine (message);
		}

		private String readString (String message) {
			try {
				print (message);
				return Console.ReadLine ();
			} catch {
				print ("something went wrong while reading string");
			}
			return "";
		}

		private int readInteger (String message) {
			try {
				return Convert.ToInt32 (readString (message));
			} catch {
				throw new UnexpectedTypeException ();
			}
		}

		public ReadExp() {
		}
			
		public int eval(MapInterface<String, int> tbl) {
			try {
				return readInteger("");
			} catch (UnexpectedTypeException) {
				return eval(tbl);
			}
		}
			
		public override string ToString() {
			return "read()";
		}
	}
}

