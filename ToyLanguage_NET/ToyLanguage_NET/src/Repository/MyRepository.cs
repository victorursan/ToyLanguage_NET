using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;

namespace ToyLanguage_NET {
	public class MyRepository: Repository {
		private ListInterface<PrgState> prgStates;

		public MyRepository (ListInterface<PrgState> prgStates) {
			this.prgStates = prgStates;
		}

		public MyRepository () {
			this.prgStates = new MyLibraryList<PrgState>();
		}


		public ListInterface<PrgState> PrgStates {
			get {
				return prgStates;
			}
			set {
				prgStates = value;
			}
		}

		public PrgState getCrtProgram () {
			try {
				if (prgStates.Count > 0)
					return this.prgStates [0];
			} catch (IndexOutOfBoundsException) {
				throw new EmptyRepositoryException ();
			}
			throw new EmptyRepositoryException ();
		}

		public void logPrgState() {
			using (StreamWriter w = File.AppendText("logProgramState.txt")) {
				w.WriteLine(this.getCrtProgram().printState());
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
				this.prgStates = (ListInterface<PrgState>) formatter.Deserialize (s);
			}
		}
	}
}

