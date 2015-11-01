using System;
using System.Collections;

namespace ToyLanguage_NET {
	public interface ListInterface<T>: IEnumerable {
		void Add (T e);

		bool Find (T e);

		int Length{ get; }

		T this [int index]{ get; set; }
	}

}

