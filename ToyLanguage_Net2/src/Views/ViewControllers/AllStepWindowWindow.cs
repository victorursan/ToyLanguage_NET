using System;
using Gtk;

namespace ToyLanguage_NET {
	public partial class AllStepWindowWindow : Gtk.Window {
		private Controller ctrl;

		public Controller Ctrl {
			set {
				ctrl = value;
				ctrl.allStep ();
				textView.Buffer.Text = ctrl.ProgramsOutput;
			}
		}

		public AllStepWindowWindow () :
			base (Gtk.WindowType.Toplevel) {
			this.Build ();
		}

		protected void backTouched (object sender, EventArgs e) {
			this.Hide ();
		}
	}
}

