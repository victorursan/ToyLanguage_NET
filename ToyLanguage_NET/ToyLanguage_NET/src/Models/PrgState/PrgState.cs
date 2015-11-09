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

		public string printState () {
//			StackInterface<IStmt> tmpStack = new MyLibraryStack<IStmt> ();
			return "--------------------------------\n" + "Exec Stack:\n" + exeStack + "\n\nSymbol table\n" +
				symTable + "\n\nOutput\n" + output + "\n\n" + "\n\n--------------------------------\n";
		}
	}
}

