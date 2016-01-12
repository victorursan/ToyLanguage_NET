
// This file has been generated by the GUI designer. Do not modify.
namespace ToyLanguage_NET
{
	public partial class MainWindow
	{
		private global::Gtk.VBox vbox1;
		
		private global::Gtk.Label lblChooseOption;
		
		private global::Gtk.VBox vbox3;
		
		private global::Gtk.Button btnInputProgram;
		
		private global::Gtk.Button btnOneStep;
		
		private global::Gtk.Button btnAllStep;
		
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.Button BtnDeserialize;
		
		private global::Gtk.Button btnSerialize;
		
		private global::Gtk.CheckButton checkLog;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget ToyLanguage_NET.MainWindow
			this.Name = "ToyLanguage_NET.MainWindow";
			this.Title = global::Mono.Unix.Catalog.GetString ("MainWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child ToyLanguage_NET.MainWindow.Gtk.Container+ContainerChild
			this.vbox1 = new global::Gtk.VBox ();
			this.vbox1.Name = "vbox1";
			this.vbox1.Spacing = 6;
			// Container child vbox1.Gtk.Box+BoxChild
			this.lblChooseOption = new global::Gtk.Label ();
			this.lblChooseOption.Name = "lblChooseOption";
			this.lblChooseOption.LabelProp = global::Mono.Unix.Catalog.GetString ("Choose option:");
			this.vbox1.Add (this.lblChooseOption);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.lblChooseOption]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.vbox3 = new global::Gtk.VBox ();
			this.vbox3.Name = "vbox3";
			this.vbox3.Spacing = 6;
			// Container child vbox3.Gtk.Box+BoxChild
			this.btnInputProgram = new global::Gtk.Button ();
			this.btnInputProgram.CanFocus = true;
			this.btnInputProgram.Events = ((global::Gdk.EventMask)(256));
			this.btnInputProgram.Name = "btnInputProgram";
			this.btnInputProgram.UseUnderline = true;
			this.btnInputProgram.Label = global::Mono.Unix.Catalog.GetString ("Input Program");
			this.vbox3.Add (this.btnInputProgram);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.btnInputProgram]));
			w2.Position = 0;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.btnOneStep = new global::Gtk.Button ();
			this.btnOneStep.CanFocus = true;
			this.btnOneStep.Events = ((global::Gdk.EventMask)(256));
			this.btnOneStep.Name = "btnOneStep";
			this.btnOneStep.UseUnderline = true;
			this.btnOneStep.Label = global::Mono.Unix.Catalog.GetString ("One step");
			this.vbox3.Add (this.btnOneStep);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.btnOneStep]));
			w3.Position = 1;
			w3.Expand = false;
			w3.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.btnAllStep = new global::Gtk.Button ();
			this.btnAllStep.CanFocus = true;
			this.btnAllStep.Events = ((global::Gdk.EventMask)(256));
			this.btnAllStep.Name = "btnAllStep";
			this.btnAllStep.UseUnderline = true;
			this.btnAllStep.Label = global::Mono.Unix.Catalog.GetString ("All step");
			this.vbox3.Add (this.btnAllStep);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this.vbox3 [this.btnAllStep]));
			w4.Position = 2;
			w4.Expand = false;
			w4.Fill = false;
			this.vbox1.Add (this.vbox3);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.vbox3]));
			w5.Position = 1;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox1.Gtk.Box+BoxChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			this.vbox2.Spacing = 6;
			// Container child vbox2.Gtk.Box+BoxChild
			this.BtnDeserialize = new global::Gtk.Button ();
			this.BtnDeserialize.CanFocus = true;
			this.BtnDeserialize.Events = ((global::Gdk.EventMask)(256));
			this.BtnDeserialize.Name = "BtnDeserialize";
			this.BtnDeserialize.UseUnderline = true;
			this.BtnDeserialize.Label = global::Mono.Unix.Catalog.GetString ("Deserialize");
			this.vbox2.Add (this.BtnDeserialize);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.BtnDeserialize]));
			w6.Position = 0;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.btnSerialize = new global::Gtk.Button ();
			this.btnSerialize.CanFocus = true;
			this.btnSerialize.Events = ((global::Gdk.EventMask)(256));
			this.btnSerialize.Name = "btnSerialize";
			this.btnSerialize.UseUnderline = true;
			this.btnSerialize.Label = global::Mono.Unix.Catalog.GetString ("Serialize");
			this.vbox2.Add (this.btnSerialize);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.btnSerialize]));
			w7.Position = 1;
			w7.Expand = false;
			w7.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.checkLog = new global::Gtk.CheckButton ();
			this.checkLog.CanFocus = true;
			this.checkLog.Events = ((global::Gdk.EventMask)(256));
			this.checkLog.Name = "checkLog";
			this.checkLog.Label = global::Mono.Unix.Catalog.GetString ("Log");
			this.checkLog.DrawIndicator = true;
			this.checkLog.UseUnderline = true;
			this.vbox2.Add (this.checkLog);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.checkLog]));
			w8.Position = 2;
			w8.Expand = false;
			w8.Fill = false;
			this.vbox1.Add (this.vbox2);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this.vbox1 [this.vbox2]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;
			this.Add (this.vbox1);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.DefaultWidth = 400;
			this.DefaultHeight = 300;
			this.Show ();
			this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
			this.btnInputProgram.Clicked += new global::System.EventHandler (this.inputProgramTouched);
			this.btnOneStep.Clicked += new global::System.EventHandler (this.oneStepTouched);
			this.btnAllStep.Clicked += new global::System.EventHandler (this.allStepTouched);
			this.BtnDeserialize.Clicked += new global::System.EventHandler (this.deserializeTouched);
			this.btnSerialize.Clicked += new global::System.EventHandler (this.SerializeTouched);
			this.checkLog.Clicked += new global::System.EventHandler (this.logCheckTouched);
		}
	}
}
