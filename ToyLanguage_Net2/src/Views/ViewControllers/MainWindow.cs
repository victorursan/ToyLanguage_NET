using System;
using Gtk;
using System.Collections.Generic;

namespace ToyLanguage_NET {
	public partial class MainWindow: Gtk.Window {
		private Controller ctrl;

		public Controller Ctrl {
			set {
				ctrl = value;
			}
		}


		public MainWindow () : base (Gtk.WindowType.Toplevel) {
			Build ();
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a) {
			Application.Quit ();
			a.RetVal = true;
		}

		protected void inputProgramTouched (object sender, EventArgs e) {
			InputProgramWindow win = new InputProgramWindow ();
			win.Ctrl = ctrl;
			win.Show ();
		}

		protected void SerializeTouched (object sender, EventArgs e) {
			IStmt st1 = new AssignStmt("v", new ConstExp(10));
			IStmt st2 = new NewStmt("a", new ConstExp(22));
			IStmt st3 = new AssignStmt("v", new ConstExp(32));
			IStmt st4 = new PrintStmt(new VarExp("v"));
			IStmt st5 = new PrintStmt(new ReadHeapExp("a"));
			IStmt st8 = new ForkStmt(new CompStmt(new WriteHeapStmt("a", new ConstExp(30)), new CompStmt(st3, new CompStmt(st4, st5))));
			IStmt st6 = new PrintStmt(new VarExp("v"));
			IStmt st7 = new PrintStmt(new ReadHeapExp("a"));
			IStmt prgStatement = new CompStmt(st1, new CompStmt(st2, new CompStmt(st8, new CompStmt(st6,new CompStmt (st7, new CompStmt(new SkipStmt(), new CompStmt(new SkipStmt(), new SkipStmt() )))))));

			List<PrgState> programs = new List<PrgState> ();
			programs.Add (new PrgState (new MyLibraryStack<IStmt> (), new MyLibraryDictionary<String, int> (), new MyLibraryHeap<int> (), new MyLibraryList<int> (), prgStatement));

			ctrl.PrgList = programs;
			ctrl.serializeProgramState ();
		}

		protected void deserializeTouched (object sender, EventArgs e) {

		

			DeserializeWindow win = new DeserializeWindow ();
			win.Ctrl = ctrl;
			win.Show ();
		}

		protected void allStepTouched (object sender, EventArgs e) {
			AllStepWindowWindow win = new AllStepWindowWindow ();
			win.Ctrl = ctrl;
			win.Show ();
		}


		protected void oneStepTouched (object sender, EventArgs e) {
			OneStepWindow win = new OneStepWindow ();
			win.Ctrl = ctrl;
			win.Show ();
		}

		protected void logCheckTouched (object sender, EventArgs e) {
			ctrl.LogFlag = checkLog.Active;
		}
	}
}
