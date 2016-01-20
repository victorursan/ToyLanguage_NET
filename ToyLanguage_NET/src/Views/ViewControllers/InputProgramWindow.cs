using System;
using Gtk;
using System.IO;
using System.Collections.Generic;

namespace ToyLanguage_NET {
	public partial class InputProgramWindow : Gtk.Window {
		private Controller ctrl;
		private int position;
		private String myString;
	

		public Controller Ctrl {
			set {
				ctrl = value;
			}
		}

		public InputProgramWindow () :
			base (Gtk.WindowType.Toplevel) {
			this.Build ();
		}

		public int Position {
			set {
				position = value;
			}
		}


		public String MyString {
			set{
				myString = value;
			}
		}
			
		protected void newTouched (object sender, EventArgs e) {
			
			IStmt st1 = new AssignStmt("v", new ConstExp(10));
			IStmt st2 = new NewStmt("a", new ConstExp(22));
			IStmt st3 = new AssignStmt("v", new ConstExp(32));
			IStmt st4 = new PrintStmt(new VarExp("v"));
			IStmt st5 = new PrintStmt(new ReadHeapExp("a"));
			IStmt st8 = new ForkStmt(new CompStmt(new WriteHeapStmt("a", new ConstExp(30)), new CompStmt(st3, new CompStmt(st4, st5))));
			IStmt st6 = new PrintStmt(new VarExp("v"));
			IStmt st7 = new PrintStmt(new ReadHeapExp("a"));
			IStmt prgStatement = new CompStmt(st1, new CompStmt(st2, new CompStmt(st8, new CompStmt(st6,new CompStmt (st7, new CompStmt(new SkipStmt(), new CompStmt(new SkipStmt(), new SkipStmt() )))))));

			IStmt stmt = prgStatement;
				//newStatement("First Statement:");
			List<PrgState> programs = new List<PrgState>();
			programs.Add(new PrgState(new MyLibraryStack<IStmt>(), new MyLibraryDictionary<string, int>(), new MyLibraryHeap<int>(), new MyLibraryList<int>(), stmt));
			ctrl.PrgList = programs;
			textview.Buffer.Text = stmt.ToString ();
		}

		private Exp newExpression(String content) {
			String[] expressionsStrings = {"Arithmetic Expression", "Constant Expression",
				"Variable Expression", "Binary Logical Expression", "Not Expression", "Relational Expression",
				"Read value", "Read Heap"};
			MyDialogBox expressionsBox = new MyDialogBox ();
			expressionsBox.MainLabel = content;
			expressionsBox.MyDelegate = this;
			expressionsBox.Elements = expressionsStrings;
			expressionsBox.Run ();
			int selected = position;
			switch (selected) {
				case 0:
					String aoperator = newString("Enter operator (+, -, *): ");
					Exp left = newExpression("Left Expression: ");
					Exp right = newExpression("Right Expression: ");
					return new ArithExp(left, aoperator, right);
				case 1:
					int value = Convert.ToInt32 (newString ("Enter constant value: "));
					return new ConstExp(value);
				case 2:
					String name = newString("Name: ");
					return new VarExp(name);
				case 3:
					String loperator = newString ("Enter operator (&&, ||): ");
					Exp lleft = newExpression ("Left Expression: ");
					Exp lright = newExpression("Right Expression: ");
					return new LogicalExp(lleft, loperator,lright);
				case 4:
					Exp eright = newExpression("Expression: ");
					return new NotExp(eright);
				case 5:
					String roperator = newString("Enter operator (<, <=, !=, ==, >=, >): ");
					Exp rleft = newExpression("Left Expression: ");
					Exp rright = newExpression("Right Expression: ");
					return new RelationalExp(rleft, roperator, rright);
				case 6:
					return new ReadExp();
				case 7:
					String rhname = newString("Name: ");
					return new ReadHeapExp(rhname);
				default:
					break;
			}
			return null;
		}

		private IStmt newStatement(String content) {
			String[] statementsStrings = {"Compound Statement", "Assign Statement", "Print Statement",
				"If Statement", "While Statement", "IfThen Statement", "Switch Statement", "Skip Statement",
				"New Statement", "Write Heap", "Fork"};
			MyDialogBox statementsBox = new MyDialogBox ();
			statementsBox.MyDelegate = this;
			statementsBox.MainLabel = content;
			statementsBox.Elements = statementsStrings;
			statementsBox.Run ();
			int selected = position;
			switch (selected) {
				case 0:
					IStmt first = newStatement("First Statement:");
					IStmt second = newStatement("Second Statement:");
					return new CompStmt(first, second);
				case 1:
					String name = newString("Name: ");
					Exp value = newExpression("Assigned value: ");
					return new AssignStmt(name, value);
				case 2:
					Exp expression = newExpression("Expression: ");
					return new PrintStmt(expression);
				case 3:
					Exp condition = newExpression ("Condition: ");
					IStmt thenStatement = newStatement ("Then branch: ");
					IStmt elseStatement = newStatement ("Else branch: ");
					return new IfStmt (condition, thenStatement, elseStatement);
				case 4:
					Exp wcondition = newExpression("Condition: ");
					IStmt body = newStatement("Body: ");
					return new WhileStmt(wcondition, body);
				case 5:
					Exp ifcondition = newExpression("Condition: ");
					IStmt ifthenStatement = newStatement("Then branch: ");
					return new IfThenStmt(ifcondition, ifthenStatement);
				case 6:
					Exp scondition = newExpression("Condition: ");
					Exp case1Expression = newExpression("Case 1 Expression:");
					IStmt case1Statement = newStatement("Case 1 Statement:");
					Exp case2Expression = newExpression("Case 2 Expression:");
					IStmt case2Statement = newStatement("Case 2 Statement:");
					IStmt defaultStatement = newStatement("Default Statement:");
					return new SwitchStmt(scondition, case1Expression, case1Statement, case2Expression, case2Statement, defaultStatement);
				case 7:
					return new SkipStmt();
				case 8:
					String ename = newString("Name: ");
					Exp eexpression = newExpression("Expression: ");
					return new NewStmt(ename, eexpression);
				case 9:
					String wname = newString("Name: ");
					Exp eeexpression = newExpression("Expression: ");
					return new WriteHeapStmt(wname, eeexpression);
				case 10:
					return new ForkStmt(newStatement("Statement: "));	
				default:
					break;
			}
			throw new IOException();
		}

		private String newString(String content) {
			MyDialogText textInputDialog = new MyDialogText();
			textInputDialog.MyDelegate = this;
			textInputDialog.MainLabel = content;
			textInputDialog.Run ();
			return myString;
		}


		protected void backTouched (object sender, EventArgs e) {
			this.Hide ();
		}
	}
}

