using System;

namespace ToyLanguage_NET {
	[Serializable] public class ForkStmt: IStmt {
		private IStmt stmt;

		public ForkStmt(IStmt stmt) {
			this.stmt = stmt;
		}

		public IStmt Stmt {
			get {
				return stmt;
			}
			set {
				stmt = value;
			}
		}
			
		public PrgState execute(PrgState state) {
			StackInterface<IStmt> newStack = new MyLibraryStack<IStmt>();
			MapInterface<String, int> cloneSymTbl = new MyLibraryDictionary<String, int>((MyLibraryDictionary<String, int>)state.SymTable);
			return new PrgState(newStack, cloneSymTbl, state.HeapTable, state.Output, stmt);
		}

		public override string ToString() {
			return "fork (" + stmt + ")";
		}
	}
}

