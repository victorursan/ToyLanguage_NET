
// This file has been generated by the GUI designer. Do not modify.
namespace ToyLanguage_NET
{
	public partial class MyDialogText
	{
		private global::Gtk.VBox vbox7;
		
		private global::Gtk.Label mainLabel;
		
		private global::Gtk.Entry txtField;
		
		private global::Gtk.Button btnOk;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget ToyLanguage_NET.MyDialogText
			this.Name = "ToyLanguage_NET.MyDialogText";
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Internal child ToyLanguage_NET.MyDialogText.VBox
			global::Gtk.VBox w1 = this.VBox;
			w1.Name = "dialog1_VBox";
			w1.BorderWidth = ((uint)(2));
			// Container child dialog1_VBox.Gtk.Box+BoxChild
			this.vbox7 = new global::Gtk.VBox ();
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			// Container child vbox7.Gtk.Box+BoxChild
			this.mainLabel = new global::Gtk.Label ();
			this.mainLabel.Name = "mainLabel";
			this.mainLabel.LabelProp = global::Mono.Unix.Catalog.GetString ("label2");
			this.vbox7.Add (this.mainLabel);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.mainLabel]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this.txtField = new global::Gtk.Entry ();
			this.txtField.CanFocus = true;
			this.txtField.Name = "txtField";
			this.txtField.IsEditable = true;
			this.txtField.InvisibleChar = '●';
			this.vbox7.Add (this.txtField);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this.txtField]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			w1.Add (this.vbox7);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(w1 [this.vbox7]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Internal child ToyLanguage_NET.MyDialogText.ActionArea
			global::Gtk.HButtonBox w5 = this.ActionArea;
			w5.Name = "dialog1_ActionArea";
			w5.Spacing = 10;
			w5.BorderWidth = ((uint)(5));
			w5.LayoutStyle = ((global::Gtk.ButtonBoxStyle)(4));
			// Container child dialog1_ActionArea.Gtk.ButtonBox+ButtonBoxChild
			this.btnOk = new global::Gtk.Button ();
			this.btnOk.CanDefault = true;
			this.btnOk.CanFocus = true;
			this.btnOk.Name = "btnOk";
			this.btnOk.UseStock = true;
			this.btnOk.UseUnderline = true;
			this.btnOk.Label = "gtk-ok";
			w5.Add (this.btnOk);
			global::Gtk.ButtonBox.ButtonBoxChild w6 = ((global::Gtk.ButtonBox.ButtonBoxChild)(w5 [this.btnOk]));
			w6.Expand = false;
			w6.Fill = false;
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
			this.btnOk.Clicked += new global::System.EventHandler (this.okTouched);
		}
	}
}
