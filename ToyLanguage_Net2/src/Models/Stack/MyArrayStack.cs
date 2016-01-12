using System;

namespace ToyLanguage_NET {
	[Serializable] public class MyArrayStack: StackInterface<IStmt> {
		private IStmt[] elements;
		private int nrElements;

		public MyArrayStack() {
			nrElements = 0;
			elements = new IStmt[10];
		}
			
		public void Push(IStmt e) {
			if (nrElements == elements.Length) {
				resize();
			}
			elements[nrElements++] = e;
		}

		private void resize() {
			IStmt[] tmp = new IStmt[elements.Length * 2];
			System.Array.Copy(elements, 0, tmp, 0, elements.Length);
			elements = tmp;
		}
			
		public IStmt Pop() {
			if (nrElements > 0){
				return  elements[--nrElements];
			}
			return null;
		}
			
		public IStmt Peek() {
			if (nrElements > 0) {
				return elements[nrElements - 1];
			}
			return null;
		}
		public int Count {
			get {
				return nrElements;
			}
		}
			
		public int search(IStmt e) {
			for(int i = 1; i <= nrElements; i++ ) if (elements[nrElements - i].Equals(e)) return i;
			return -1;
		}
			
	}
}

