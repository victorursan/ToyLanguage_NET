using System;

namespace ToyLanguage_NET {
	public partial class MyDialogBox : Gtk.Dialog {
		private InputProgramWindow myDelegate;
		private int currentPosition;
		private String[] elements;

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

		public String[] Elements {
			set {
				elements = value;
				foreach (String s in elements) {
					comboBox.AppendText (s);
				}
			}
		}
			
		public MyDialogBox () {
			this.Build ();
		}

		protected void changedValue (object sender, EventArgs e) {
			currentPosition = comboBox.Active;
		}

		protected void okButtonTouched (object sender, EventArgs e) {
			myDelegate.Position = currentPosition;
			this.Hide ();
		}
	}
}

