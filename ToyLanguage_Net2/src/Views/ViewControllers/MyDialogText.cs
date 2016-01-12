using System;

namespace ToyLanguage_NET {
	public partial class MyDialogText : Gtk.Dialog {
		private InputProgramWindow myDelegate;

		public InputProgramWindow MyDelegate {
			set {
				myDelegate = value;
			}
		}

		public String MainLabel {
			set {
				mainLabel.Text = value;	
			}
		}
			
		public MyDialogText () {
			this.Build ();
		}

		protected void okTouched (object sender, EventArgs e) {
			myDelegate.MyString = txtField.Text;
			this.Hide ();
		}
	}
}

