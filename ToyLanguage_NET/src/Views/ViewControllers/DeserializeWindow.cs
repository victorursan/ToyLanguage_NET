using System;

namespace ToyLanguage_NET {
	public partial class DeserializeWindow : Gtk.Window {
		private Controller ctrl;

		public Controller Ctrl {
			set {
				ctrl = value;
				ctrl.deserializePrgStatet ();
				textview.Buffer.Text = ctrl.printPrgList();
			}
		}

		public DeserializeWindow () :
			base (Gtk.WindowType.Toplevel) {
			this.Build ();
		}

		protected void backTouched (object sender, EventArgs e) {
			this.Hide ();
		}
	}
}

