using System;
using Lucene.Net.Support;

namespace ToyLanguage_NET {
	[Serializable] public class MyLibraryHeap<T>: HeapInterface<T> {
		private HashMap<int, T> elements;
		private int nextFree;

		public MyLibraryHeap () {
			elements = new HashMap<int, T>();
			nextFree = 1;
		}

		public int Add(T e) {
			elements [nextFree] = e;
			return nextFree++;
		}
			
		public T Get(int address) {
			if (elements[address] == null) {
				throw new HashIndexOutOfBoundsException();
			}
			return elements[address];
		}
			
		public void Update(int address, T value) {
			if (elements[address] == null) {
				throw new HashIndexOutOfBoundsException();
			}
			elements[address] = value;
		}
			
		public override string ToString() {
			String toPrint = "";
			foreach (int elem in elements.Keys) {
				toPrint = elem.ToString() + " -> " + elements[elem]  + "\n" + toPrint;
			}
			return toPrint;
		}
	}
}

