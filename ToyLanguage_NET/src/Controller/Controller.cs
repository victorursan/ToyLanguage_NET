using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToyLanguage_NET {
	public class Controller {
		private Repository repo;
		//		private PrgState crtPrgState;
		private bool printFlag;
		private bool logFlag;
		private String programsOutput;

		public String ProgramsOutput {
			get {
				return programsOutput;
			}
		}

		public bool PrintFlag {
			get {
				return printFlag;
			}
			set {
				printFlag = value;
			}
		}

		public bool LogFlag {
			get {
				return logFlag;
			}
			set {
				logFlag = value;
			}
		}


		public Controller (Repository thisRepo) {
			printFlag = true;
			logFlag = true;
			repo = thisRepo;
			programsOutput = "";
//			crtPrgState = repo.getCrtProgram ();
		}

		public void serializeProgramState () {
			repo.serializePrgStatet ();
		}

		public void deserializePrgStatet () {
			repo.deserializePrgStatet ();
		}

		public List<PrgState> removeCompletedPrg (List<PrgState> inPrgList) {
			return inPrgList.Where (p => p.isNotCompleted ()).ToList ();
		}

		private void oneStepForAllPrg (List<PrgState> prgList) {

			List<Task<PrgState>> taskList = (from prg in prgList
			                                 select Task<PrgState>.Factory.StartNew (() => prg.oneStep ())).ToList ();
		
			try {
				List<PrgState> newPrgList = (from tsk in taskList
				                             where tsk.Result != null
				                             select tsk.Result).ToList ();
//				newPrgList.AddRange (prgList.Where (p => !newPrgList.Any (q => q.Id == p.Id)).ToList ());
				prgList.AddRange(newPrgList);
			
				if (logFlag) {
					repo.logPrgState ();
				}
				repo.PrgStates = prgList;

				programsOutput += printPrgList();

			} catch (Exception e) {
				Console.Write ("something" + e.StackTrace);
			}

		}

		public void oneStep () {
			List<PrgState> prgList = removeCompletedPrg (repo.PrgStates);
			oneStepForAllPrg (prgList);
		}

		public void allStep () {
			programsOutput = "";
			while (true) {
				List<PrgState> prgList = removeCompletedPrg (repo.PrgStates);
				if (prgList.Count () == 0) {
					return;
				} else {
					oneStepForAllPrg (prgList);
				}

			}
		}

		public String printPrgList() {
			String outString = "";
			repo.PrgStates.ForEach(p => outString += p.ToString());
			return outString;
		}

		public List<PrgState> PrgList {
			get {
				return repo.PrgStates;
			}
			set {
				repo.PrgStates = value;
			}
		}

	}
}

