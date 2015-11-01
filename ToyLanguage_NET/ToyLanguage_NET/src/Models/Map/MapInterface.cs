using System;
using System.Collections;

namespace ToyLanguage_NET {
	public interface MapInterface<K, V> {
		int Count { get; }

		K[] Keys { get; }

		void Add (K key, V value);

		bool ContainsKey (K key);

		V this [K key] { get; set; }
	}
}
