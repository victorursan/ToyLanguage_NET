using System;

namespace ToyLanguage_NET {
	public class MyRepository {
		private PrgState[] prgStates;
		private int prgNumber = 0;

		public MyRepository(PrgState[] prgStates) {
			this.prgStates = prgStates;
			this.prgNumber = prgStates.Length;
		}
			
		public PrgState getCrtProgram() {
			if (prgNumber > 0)
				return this.prgStates[0];
			return null;
		}
	}
}

