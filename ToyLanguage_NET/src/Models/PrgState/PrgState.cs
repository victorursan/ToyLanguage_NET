using System;

namespace ToyLanguage_NET {
	[Serializable] public class PrgState {
		private static int generator = 0;
		private int id;
		private StackInterface<IStmt> exeStack;
		private MapInterface<String, int> symTable;
		private HeapInterface<int> heapTable;
		private ListInterface<int> output;
		private IStmt originalProgram;
		//optional field, but good to have

		public PrgState (StackInterface<IStmt> stack, MapInterface<String, int> dictionary, HeapInterface<int> heap, ListInterface<int> list, IStmt prg) {
			id = generator++;
			exeStack = stack;
			symTable = dictionary;
			heapTable = heap;
			output = list;
			originalProgram = prg;
			exeStack.Push (originalProgram);
		}
			
		public StackInterface<IStmt> ExeStack {
			get {
				return exeStack;
			}
		}

		public MapInterface<String, int> SymTable {
			get {
				return symTable;
			}
		}

		public HeapInterface<int> HeapTable {
			get {
				return heapTable;
			}
		}

		public ListInterface<int> Output {
			get {
				return output;
			}
		}

		public int Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}

		public bool isNotCompleted() {
			return exeStack.Count != 0;
		}
			
		public PrgState oneStep() {
			try {
				IStmt crtStmt = exeStack.Pop();
				return crtStmt.execute(this);
			} catch (EmptyStackException) {
				throw new MyStmtExecException();
			}
		}

		public override string ToString () {
			return "--------------------------------\n" + "id: " + id +
				"\nExec Stack:\n" + exeStack.ToString() +
				"\nSymbol table\n" + symTable.ToString() + "\nHeap table\n" + heapTable.ToString() +
				"\n\nOutput List\n" + output.ToString() + "\n\n--------------------------------\n";
		}

		public string PrintState () {
			return "--------------------------------\n" + "id: " + id +
				"\nExec Stack:\n" + exeStack.ToString() +
				"\nSymbol table\n" + symTable.ToString() + "\nHeap table\n" + heapTable.ToString() +
				"\n\nOutput List\n" + output.ToString() + "\n\n--------------------------------\n";
		}
	}
}

