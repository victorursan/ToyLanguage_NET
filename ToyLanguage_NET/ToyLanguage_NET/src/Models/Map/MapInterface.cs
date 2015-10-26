using System;
using System.Collections;

namespace ToyLanguage_NET {
	public interface MapInterface {
		int Count { get; }

		String[] Keys { get; }

		void Add (String key, int value);

		bool ContainsKey (String key);

		int this [String key] { get; set; }
	}
}
