using System;

namespace ToyLanguage_NET {
	public class ArrayDictionary: MapInterface {
		private String[] keys;
		private int[] values;
		private int nrElements;

		public ArrayDictionary () {
			keys = new String[10];
			values = new int[10];
			nrElements = 0;
		}

		private void resize () {
			String[] tmpKeys = new String[keys.Length * 2];
			int[] tmpValues = new int[values.Length * 2];
			System.Array.Copy (keys, 0, tmpKeys, 0, keys.Length);
			System.Array.Copy (values, 0, tmpValues, 0, values.Length);
			keys = tmpKeys;
			values = tmpValues;
		}

		#region MapInterface implementation

		public void Add (string key, int value) {
			if (!this.ContainsKey (key)) {
				if (keys.Length >= nrElements) {
					resize ();
				}
				keys [nrElements] = key;
				values [nrElements] = value;
				nrElements++;
			}
		}

		public bool ContainsKey (string key) {
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

		public string[] Keys {
			get {
				return keys;
			}
		}

		public int this [string key] {
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

