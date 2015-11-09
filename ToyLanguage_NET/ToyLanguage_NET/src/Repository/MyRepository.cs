using System;

namespace ToyLanguage_NET {
	public class MyRepository: Repository {
		private PrgState[] prgStates;
		private int prgNumber = 0;

		public MyRepository (PrgState[] prgStates) {
			this.prgStates = prgStates;
			this.prgNumber = prgStates.Length;
		}

		public PrgState getCrtProgram () {
			try {
				if (prgNumber > 0)
					return this.prgStates [0];
			} catch (IndexOutOfBoundsException) {
				throw new EmptyRepositoryException ();
			}
			throw new EmptyRepositoryException ();
		}
	}
}

