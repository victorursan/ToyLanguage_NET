using System;
using System.Collections;

namespace ToyLanguage_NET {
	public interface ListInterface: IEnumerable {
		void Add (Object e);

		void Remove (Object e);

		bool Find (Object e);

		int Length{ get; }

		Object this [int index]{ get; set; }
	}

}

