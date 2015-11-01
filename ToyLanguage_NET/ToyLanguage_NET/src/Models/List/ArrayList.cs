using System;
using System.Collections;

namespace ToyLanguage_NET {
	public class ArrayList<T>: ListInterface<T> {
		private T[] elements;
		private int nrElements;

		public ArrayList() {
			elements = new T[10];
			nrElements = 0;
		}

		private void resize() {
			T[] tmpKeys = new T[elements.Length * 2];
			System.Array.Copy (elements, tmpKeys, elements.Length);
			elements = tmpKeys;
		}

		#region ListInterface implementation
		public void Add (T e) {
			if (nrElements == elements.Length) {
				resize();
			}
			elements[nrElements++] = e;
		}

		public bool Find (T e) {
			for (int i = 0; i < nrElements; i++) {
				if (elements[i].Equals (e)) {
					return true;
				}
			}
			return false;
		}
		public int Length {
			get {
				return nrElements;
			}
		}

		public T this[int index] {
			get { if (index < nrElements && index >= 0) {
					return elements [index];
				}
				throw new AccessViolationException ();
			}
			set {  if (index < nrElements && index >= 0) {
					elements [index] = value;
			} else {
				elements [nrElements++] = value;
			}
		}
		}

		#endregion

		#region IEnumerable implementation
		public IEnumerator GetEnumerator() {
			return new ALEnumerator(this);
		}

		private class ALEnumerator: IEnumerator {
			private int cursor;
			private ArrayList<T> al;
			public ALEnumerator(ArrayList<T> al) {
				this.al = al;
				cursor = -1;
			}
			public bool MoveNext() {
				cursor++;
				return cursor < al.nrElements;
			}
			public Object Current {
				get { return al.elements [cursor]; }
			}
			public void Reset() {
				cursor = -1;
			}
		}	
		#endregion
	}
}

