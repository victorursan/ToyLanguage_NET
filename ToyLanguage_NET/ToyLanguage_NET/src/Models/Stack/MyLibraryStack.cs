using System;

namespace ToyLanguage_NET {
	public class MyLibraryStack<T>: StackInterface<T> { 
		private T[] elements;
		private int nrElements;

		public MyLibraryStack () {
			nrElements = 0;
			elements = new T[10];
		}

		private void resize () {
			T[] tmp = new T[elements.Length * 2];
			System.Array.Copy (elements, 0, tmp, 0, elements.Length);
			elements = tmp;
		}

		#region StackInterface implementation

		public T Pop () {
			if (nrElements > 0) {
				return  elements [--nrElements];
			}
			throw new FieldAccessException ();
		}

		public T Peek () {
			if (nrElements > 0) {
				return elements [nrElements - 1];
			}
			throw new FieldAccessException ();
		}

		public void Push (T obj) {
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

