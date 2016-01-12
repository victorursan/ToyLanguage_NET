using System;
using Gtk;
using System.Collections.Generic;

namespace ToyLanguage_NET {
	class MainClass {
		public static void Main (string[] args) {
			Application.Init ();
			MainWindow win = new MainWindow ();

			Repository repo = new MyRepository();
			Controller ctrl = new Controller(repo);
			List<PrgState> programs = new List<PrgState>();
			ctrl.PrgList = programs;
			win.Ctrl = ctrl;

			win.Show ();
			Application.Run ();
		}
	}
}