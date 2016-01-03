using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ToyLanguage_NET {
	public class MyRepository: Repository {
		private List<PrgState> prgStates;

		public MyRepository (List<PrgState> prgStates) {
			this.prgStates = prgStates;
		}

		public MyRepository () {
			this.prgStates = new List<PrgState>();
		}


		public List<PrgState> PrgStates {
			get {
				return prgStates;
			}
			set {
				prgStates = value;
			}
		}

		public void logPrgState() {
			using (StreamWriter w = File.AppendText("logProgramState.txt")) {
				w.WriteLine(this.prgStates.ToString());
			}

		}
		public void serializePrgStatet () {
			IFormatter formatter = new BinaryFormatter(  );
			using (FileStream s = File.Create ("serialized.bin")) {
				formatter.Serialize (s, prgStates);
			}
		}

		public void deserializePrgStatet () {
			IFormatter formatter = new BinaryFormatter(  );
			using (FileStream s = File.OpenRead ("serialized.bin")) {
				this.prgStates = (List<PrgState>) formatter.Deserialize (s);
			}
		}
	}
}

