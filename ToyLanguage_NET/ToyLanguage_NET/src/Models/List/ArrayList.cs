using System;
using System.Collections;

namespace ToyLanguage_NET {
	public class ArrayList: ListInterface {
		private int[] elements;
		private int nrElements;

		public ArrayList() {
			elements = new int[10];
			nrElements = 0;
		}

		private void resize() {
			int[] tmpKeys = new int[elements.Length * 2];
			System.Array.Copy (elements, tmpKeys, elements.Length);
			elements = tmpKeys;
		}

		#region ListInterface implementation
		public void Add (int e) {
			if (nrElements == elements.Length) {
				resize();
			}
			elements[nrElements++] = e;
		}

		public bool Find (int e) {
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

		public int this[int index] {
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
			private ArrayList al;
			public ALEnumerator(ArrayList al) {
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

