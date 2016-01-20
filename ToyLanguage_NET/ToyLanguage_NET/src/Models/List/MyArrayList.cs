using System;

namespace ToyLanguage_NET {
	[Serializable] public class MyArrayList: ListInterface<int> {
		private int[] elements;
		private int nrElements;

		public MyArrayList () {
			elements = new int[10];
			nrElements = 0;
		}

		#region ListInterface implementation

		public void Add (int e) {
			elements[nrElements++] = e;

		}

		public bool Contains (int e) {
			for (int i = 0; i < nrElements; i++) {
				if (elements [i] == e) {
					return true;	
				}
			}
			return false;
		}

		public int Count {
			get {
				return nrElements;
			}
		}

		public int this [int index] {
			get {
				return elements [index];
			}
			set {
				elements [index] = value;
			}
		}

		#endregion

	}
}

