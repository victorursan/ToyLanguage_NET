using System;

namespace ToyLanguage_NET {
	public class ArrayDictionary<K, V>: MapInterface<K, V> {
		private K[] keys;
		private V[] values;
		private int nrElements;

		public ArrayDictionary () {
			keys = new K[10];
			values = new V[10];
			nrElements = 0;
		}

		private void resize () {
			K[] tmpKeys = new K[keys.Length * 2];
			V[] tmpValues = new V[values.Length * 2];
			System.Array.Copy (keys, 0, tmpKeys, 0, keys.Length);
			System.Array.Copy (values, 0, tmpValues, 0, values.Length);
			keys = tmpKeys;
			values = tmpValues;
		}

		#region MapInterface implementation

		public void Add (K key, V value) {
			if (!this.ContainsKey (key)) {
				if (keys.Length >= nrElements) {
					resize ();
				}
				keys [nrElements] = key;
				values [nrElements] = value;
				nrElements++;
			}
		}

		public bool ContainsKey (K key) {
			for (int i = 0; i < nrElements; i++) {
				if (keys [i].Equals (key)) {
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

		public K[] Keys {
			get {
				return keys;
			}
		}

		public V this [K key] {
			get {
				for (int i = 0; i < nrElements; i++) {
					if (keys[i].Equals(key)) {
						return values[i];
					}
				}
				throw new AccessViolationException ();
			}
			set {
				for (int i = 0; i < nrElements; i++) {
					if (keys[i].Equals(key)) {
						values[i] = value;
						return;
					}
				}
			}
		}

		#endregion

	}
}

