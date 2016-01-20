using System;

namespace ToyLanguage_NET {
	[Serializable] public class MyArrayDictionary: MapInterface<String, int> {
		private String[] keys;
		private int[] values;
		private int nrElements;

		public MyArrayDictionary() {
			keys = new String[10];
			values = new int[10];
			nrElements = 0;
		}
			
		public void clear() {
			keys = new String[10];
			values = new int[10];
			nrElements = 0;
		}

		public void Add (string key, int value) {
			throw new NotImplementedException ();
		}

		public int Count {
			get {
				return nrElements;
			}
		}


		public int this [string key] {
			get {
				return this [key];
			}
			set {
				this [key] = value;
			}
		}
			
		public bool ContainsKey(String key) {
			for (int i = 0; i < nrElements; i++) {
				if (keys[i].Equals(key)) {
					return true;
				}
			}
			return false;
		}
			
		public bool ContainsValue(int value) {
			for (int i = 0; i < nrElements; i++) {
				if (values[i].Equals(value)) {
					return true;
				}
			}
			return false;
		}
			
		public int get(String key) {
			for (int i = 0; i < nrElements; i++) {
				if (keys[i].Equals(key)) {
					return values[i];
				}
			}
			return 0;
		}
			
		public bool isEmpty() {
			return nrElements == 0;
		}

		private void resize() {
			String[] tmpKeys = new String[keys.Length * 2];
			int[] tmpValues = new int[values.Length * 2];
			System.Array.Copy(keys, 0, tmpKeys, 0, keys.Length);
			System.Array.Copy(values, 0, tmpValues, 0, values.Length);
			keys = tmpKeys;
			values = tmpValues;
		}
			
		public void put(String key, int value) {
			if (!this.ContainsKey(key)) {
				if(keys.Length >= nrElements) {
					resize();
				}
				keys[nrElements] = key;
				values[nrElements] = value;
				nrElements++;
			}
		}
			
		public bool remove(String key) {
			for (int i = 0; i < nrElements; i++) {
				if (keys[i].Equals(key)) {
					System.Array.Copy(keys, i + 1, keys, i, keys.Length - i - 1);
					System.Array.Copy(values, i + 1, values, i, values.Length - i - 1);
					nrElements--;
					return true;
				}
			}
			return false;
		}
			
		public System.Collections.Generic.Dictionary<string, int>.KeyCollection Keys {
			get {
				throw new NotImplementedException ();
			}
		}


	}
}

