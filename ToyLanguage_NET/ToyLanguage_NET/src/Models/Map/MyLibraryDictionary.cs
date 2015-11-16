using System;
using System.Collections;
using System.Collections.Generic;

namespace ToyLanguage_NET {
	[Serializable] public class MyLibraryDictionary<K, V>: MapInterface<K, V> {
		private Dictionary<K, V> elements;

		public MyLibraryDictionary () {
			elements = new Dictionary<K, V> ();
		}

		#region MapInterface implementation

		public void Add (K key, V value) {
			elements.Add (key, value);
		}

		public bool ContainsKey (K key) {
			return elements.ContainsKey (key);
		}

		public int Count {
			get {
				return elements.Count;
			}
		}

		public Dictionary<K, V>.KeyCollection Keys {
			get {
				return elements.Keys;
			}
		}

		public V this [K key] {
			get {
				if (!ContainsKey (key))
					throw new NoSuchKeyException ();
				return elements [key];
			}
			set {
				if (!ContainsKey (key))
					throw new NoSuchKeyException ();
				elements [key] = value;
			}
		}

		#endregion

		#region IEnumerable implementation

		public IEnumerator GetEnumerator () {
			return elements.GetEnumerator ();
		}

		#endregion

		public override string ToString () {
			string toString = "";
			foreach (K key in elements.Keys) {
				toString += key + " -> " + elements [key] + "\n";
			}
			return toString;
		}

	}
}

