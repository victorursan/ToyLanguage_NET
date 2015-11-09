using System;
using System.Collections;
using System.Collections.Generic;


namespace ToyLanguage_NET {
	public class MyLibraryList<T>: ListInterface<T> {
		private List<T> elements;

		public MyLibraryList () {
			elements = new List<T> ();
		}

		#region ListInterface implementation

		public void Add (T e) {
			elements.Add (e);
		}

		public bool Contains (T e) {
			return elements.Contains (e);
		}

		public int Count {
			get {
				return elements.Count;
			}
		}

		public T this [int index] {
			get {
				if (index < elements.Count && index >= 0) {
					return elements [index];
				}
				throw new IndexOutOfBoundsException ();
			}
			set {
				if (index < elements.Count && index >= 0) {
					elements [index] = value;
				} else {
					elements.Add (value);
				}
			}
		}

		#endregion

		#region IEnumerable implementation

		public IEnumerator GetEnumerator () {
			return elements.GetEnumerator ();
		}

		#endregion

		public override string ToString () {
			return " [" + string.Join(", ", elements) + " ]";
		}
	}
}

