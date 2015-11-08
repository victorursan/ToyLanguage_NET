using System;

namespace ToyLanguage_NET {
	public class PrgState {
		private StackInterface<IStmt> exeStack;
		private MapInterface<String, int> symTable;
		private ListInterface<int> output;
		private IStmt originalProgram;
		//optional field, but good to have

		public PrgState (StackInterface<IStmt> stack, MapInterface<String, int> dictionary, ListInterface<int> list, IStmt prg) {
			exeStack = stack;
			symTable = dictionary;
			output = list;
			originalProgram = prg;
			exeStack.Push (originalProgram);
		}

		public StackInterface<IStmt> getExeStack () {
			return exeStack;
		}

		public MapInterface<String, int> getSymTable () {
			return symTable;
		}

		public ListInterface<int> getOut () {
			return output;
		}

		public void printState () {
			StackInterface<IStmt> tmpStack = new MyLibraryStack<IStmt> ();
			Console.WriteLine ("Exec Stack:");
			while (exeStack.Count > 0) {
				IStmt element = exeStack.Pop ();
				tmpStack.Push (element);
				Console.WriteLine (element.ToString ());
			}
			while (tmpStack.Count > 0) {
				exeStack.Push (tmpStack.Pop ());
			}

			Console.WriteLine ("\nSymbol table");

			for (int i = 0; i < symTable.Count; i++) {
				Console.WriteLine (symTable.Keys [i] + " = " + symTable [symTable.Keys [i]].ToString ());
					
			}

			Console.WriteLine ("\nOutput");

			foreach (int outp in output) {
				Console.WriteLine (outp);
			}
			Console.WriteLine ("\n");

		}
	}
}

