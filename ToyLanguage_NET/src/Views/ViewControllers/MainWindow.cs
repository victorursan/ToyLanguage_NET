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
