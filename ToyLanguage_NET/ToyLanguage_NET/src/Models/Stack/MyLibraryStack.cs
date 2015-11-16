using System;
using System.Collections;
using System.Collections.Generic;

namespace ToyLanguage_NET {
	[Serializable] public class MyLibraryStack<T>: StackInterface<T> { 
		private Stack<T> elements;

		public MyLibraryStack () {
			elements = new Stack<T>();
		}


		#region StackInterface implementation

		public T Pop () {
			if (elements.Count > 0) {
				return  elements. Pop();
			}
			throw new EmptyStackException ();
		}

		public T Peek () {
			if (elements.Count > 0) {
				return elements. Peek();
			}
			throw new EmptyStackException ();
		}

		public void Push (T obj) {
			elements.Push (obj);
		}

		public int Count {
			get {
				return elements.Count;
			}
		}

		#endregion

		public IEnumerator GetEnumerator () {
			return elements.GetEnumerator ();
		}

		public override string ToString () {
			return " " + string.Join("\n", elements) + " ";
		}
	}
}

