using System;

namespace ToyLanguage_NET {
	public class ArrayDictionary: MapInterface {
		public ArrayDictionary () {
		}

		#region MapInterface implementation

		public void Add (string key, int value) {
			throw new NotImplementedException ();
		}

		public bool ContainsKey (string key) {
			throw new NotImplementedException ();
		}

		public int Count {
			get {
				throw new NotImplementedException ();
			}
		}

		public string[] Keys {
			get {
				throw new NotImplementedException ();
			}
		}

		public int this [string key] {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		#endregion

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator () {
			throw new NotImplementedException ();
		}
	}
}

