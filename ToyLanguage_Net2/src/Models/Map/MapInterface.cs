using System;
using System.Collections;
using System.Collections.Generic;

namespace ToyLanguage_NET {
	 public interface MapInterface<K, V> {
		int Count { get; }

		Dictionary<K, V>.KeyCollection Keys { get; }

		void Add (K key, V value);

		bool ContainsKey (K key);

		V this [K key] { get; set; }
	}
}
