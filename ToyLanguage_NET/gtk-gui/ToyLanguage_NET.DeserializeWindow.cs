
// This file has been generated by the GUI designer. Do not modify.
namespace ToyLanguage_NET
{
	public partial class DeserializeWindow
	{
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.ScrolledWindow GtkScrolledWindow;
		
		private global::Gtk.TextView textview;
		
		private global::Gtk.Button btnBack;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget ToyLanguage_NET.DeserializeWindow
			this.Name = "ToyLanguage_NET.DeserializeWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("DeserializeWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child ToyLanguage_NET.DeserializeWindow.Gtk.Container+ContainerChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.GtkScrolledWindow = new global::Gtk.ScrolledWindow ();
			this.GtkScrolledWindow.Name = "GtkScrolledWindow";
			this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
			// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
			this.textview = new global::Gtk.TextView ();
			this.textview.CanFocus = true;
			this.textview.Name = "textview";
			this.GtkScrolledWindow.Add (this.textview);
			this.vbox3.Add (this.GtkScrolledWindow);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.GtkScrolledWindow]));
			w2.Position = 0;
			// Container child vbox3.Gtk.Box+BoxChild
			this.btnBack = new global::Gtk.Button ();
			this.btnBack.CanFocus = true;
			this.btnBack.Name = "btnBack";
			this.btnBack.UseUnderline = true;
			this.btnBack.Label = global::Mono.Unix.Catalog.GetString ("Back");
			this.vbox3.Add (this.btnBack);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.btnBack]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			this.Add (this.vbox3);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
			this.btnBack.Clicked += new global::System.EventHandler (this.backTouched);
		}
	}
}
