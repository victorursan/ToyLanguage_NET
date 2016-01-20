using System;
using Gtk;

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
			if (!txtField.Text.Equals ("")) {
				myDelegate.MyString = txtField.Text;
				this.Hide ();
			} else {
				MessageDialog md = new MessageDialog (this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, "Invalid input");
				md.Run();
				md.Destroy();
			}
		}
	}
}

