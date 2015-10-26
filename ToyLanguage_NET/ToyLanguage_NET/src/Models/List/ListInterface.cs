using System;
using System.Collections;

namespace ToyLanguage_NET {
	public interface ListInterface: IEnumerable {
		void Add (int e);

		bool Find (int e);

		int Length{ get; }

		int this [int index]{ get; set; }
	}

}

