using System;

namespace ToyLanguage_NET {
	public class PrgState {
		private StackInterface exeStack;
		private MapInterface symTable;
		private ListInterface output;
		private IStmt originalProgram;
		//optional field, but good to have

		public PrgState (StackInterface stack, MapInterface dictionary, ListInterface list, IStmt prg) {
			exeStack = stack;
			symTable = dictionary;
			output = list;
			originalProgram = prg;
			exeStack.Push (originalProgram);
		}

		public StackInterface getExeStack () {
			return exeStack;
		}

		public MapInterface getSymTable () {
			return symTable;
		}

		public ListInterface getOut () {
			return output;
		}

		public void printState () {
			StackInterface tmpStack = new ArrayStack ();
			Console.WriteLine ("Exec Stack:");
			while (exeStack.Count > 0) {
				IStmt element = exeStack.Pop ();
				tmpStack.Push (element);
				Console.WriteLine (element.toStr ());
			}
			while (tmpStack.Count > 0) {
				exeStack.Push (exeStack.Pop ());
			}

			Console.WriteLine ("\nSymbol table");

			foreach (String key in symTable.Keys) {
				Console.WriteLine (key + " = " + symTable [key].ToString ());
					
			}

			Console.WriteLine ("\nSymbol table");

			foreach (int outp in output) {
				Console.WriteLine (outp);
			}
			Console.WriteLine ("\n");

		}
	}
}

