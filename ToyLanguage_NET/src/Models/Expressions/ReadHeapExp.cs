using System;

namespace ToyLanguage_NET {
	[Serializable] public class ReadHeapExp: Exp {
		private String id;

		public ReadHeapExp (String id) {
			this.id = id;
		}


		public String Id {
			get {
				return id;
			}
		}

		public int eval (MapInterface<String, int> tbl, HeapInterface<int> heap) {
			int address = tbl [id];
			return heap.Get (address);
		}

		public override string ToString () {
			return "readHeap( " + id + ")";
		}

	}
}

