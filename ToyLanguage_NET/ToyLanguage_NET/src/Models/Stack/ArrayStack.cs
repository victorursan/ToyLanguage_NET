using System;

namespace ToyLanguage_NET {
	public class ArrayStack: StackInterface {
		public ArrayStack () {
		}

		#region StackInterface implementation

		public IStmt Pop () {
			throw new NotImplementedException ();
		}

		public IStmt Peek () {
			throw new NotImplementedException ();
		}

		public void Push (IStmt obj) {
			throw new NotImplementedException ();
		}

		public int Count {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion

		#region IEnumerable implementation

		public System.Collections.IEnumerator GetEnumerator () {
			throw new NotImplementedException ();
		}

		#endregion
	}
}

