using System;

namespace ToyLanguage_NET {
	public partial class OneStepWindow : Gtk.Window {
		private Controller ctrl;

		public Controller Ctrl {
			set {
				ctrl = value;
				ctrl.oneStep ();
				textView.Buffer.Text = ctrl.printPrgList();
			}
		}

		public OneStepWindow () :
			base (Gtk.WindowType.Toplevel) {
			this.Build ();
		}

		protected void oneStepTouched (object sender, EventArgs e) {
			ctrl.oneStep ();
			textView.Buffer.Text = ctrl.printPrgList();
		}

		protected void backTouched (object sender, EventArgs e) {
			this.Hide ();
		}
	}
}

