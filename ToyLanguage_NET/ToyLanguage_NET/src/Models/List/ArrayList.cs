using System;

namespace ToyLanguage_NET {
	public class ArrayList: ListInterface {
		public ArrayList () {
		}

		#region ListInterface implementation

		void ListInterface.Add (object e) {
			throw new NotImplementedException ();
		}

		void ListInterface.Remove (object e) {
			throw new NotImplementedException ();
		}

		bool ListInterface.Find (object e) {
			throw new NotImplementedException ();
		}

		int ListInterface.Length {
			get {
				throw new NotImplementedException ();
			}
		}

		object ListInterface.this [int index] {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		#endregion

		#region IEnumerable implementation

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator () {
			throw new NotImplementedException ();
		}

		#endregion
	}
}

