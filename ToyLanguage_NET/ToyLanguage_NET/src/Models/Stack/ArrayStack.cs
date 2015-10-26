using System;

namespace ToyLanguage_NET {
	public class ArrayStack: StackInterface {
		private IStmt[] elements;
		private int nrElements;

		public ArrayStack () {
			nrElements = 0;
			elements = new IStmt[10];
		}

		private void resize () {
			IStmt[] tmp = new IStmt[elements.Length * 2];
			System.Array.Copy (elements, 0, tmp, 0, elements.Length);
			elements = tmp;
		}

		#region StackInterface implementation

		public IStmt Pop () {
			if (nrElements > 0) {
				return  elements [--nrElements];
			}
			return null;
		}

		public IStmt Peek () {
			if (nrElements > 0) {
				return elements [nrElements - 1];
			}
			return null;
		}

		public void Push (IStmt obj) {
			if (nrElements == elements.Length) {
				resize ();
			}
			elements [nrElements++] = obj;
		}

		public int Count {
			get {
				return nrElements;
			}
		}

		#endregion

	}
}

