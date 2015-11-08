using System;
using System.Collections.Generic;

namespace ToyLanguage_NET {
	public class MyConsole {
		private Controller ctrl;
		private PrgState currentProgram;

		public MyConsole () {
		}

		private void print (String message) {
			Console.WriteLine (message);
		}

		private String readString (String message) {
			try {
				print (message);
				return Console.ReadLine ();
			} catch {
				print ("something went wrong while reading string");
			}
			return "";
		}

		private int readInteger (String message) {
			try {
				return Convert.ToInt32 (readString (message));
			} catch {
				print ("That is not a number");
			}
			return 0;
		}

		private void oneStep () {
			try {
				ctrl.oneStep ();
			} catch (MyStmtExecException) {
				print ("Finished");
				currentProgram = null;
			} catch (UninitializedVariableException) {
				print ("A variable is not initialized");
			}
		}

		private void allStep () {
			try {
				ctrl.allStep ();
			} catch (MyStmtExecException) {
				print ("Finished");
				currentProgram = null;
			} catch (UninitializedVariableException) {
				print ("A variable is not initialized");
			}
		}

		private void setPrintFlag () {
			print ("Currently it is:");
			if (ctrl.printFlag) {
				print ("On");
				print ("1. Set Off");
			} else {
				print ("Off");
				print ("1. Set On");
			}
			print ("2. Back");
			int opt = readInteger ("Option: ");
			switch (opt) {
				case 1:
					ctrl.printFlag = !ctrl.printFlag;
					break;
				case 2:
					break;
				default:
					print ("Invalid option, please try again");
					setPrintFlag ();
					break;
			}

		}

		private ArithExp arithmeticalExpression () {
			print ("Available operands: +, -, *, /");
			String opperand = readString ("Operand: ");
			List<String> elements = new List<String> ();
			elements.Add ("+");
			elements.Add ("-");
			elements.Add ("*");
			elements.Add ("/");

			if (elements.Contains (opperand)) {
				print ("Left:");
				Exp left = inputExpression ();
				print ("Right:");
				Exp right = inputExpression ();
				return new ArithExp (left, opperand, right);
			}
			print ("invalid operand");
			return arithmeticalExpression ();

		}

		private ConstExp constantExpression () {
			int number = readInteger ("Number: ");
			return new ConstExp (number);
		}

		private VarExp variableExpression () {
			String id = readString ("Variable id: ");
			return new VarExp (id);
		}


		private Exp inputExpression () {
			print ("1. Arithmetical expression");
			print ("2. Constant expression");
			print ("3. Var expression");
			Exp expr;
			int opt = readInteger ("Option: ");
			switch (opt) {
				case 1:
					expr = arithmeticalExpression ();
					break;
				case 2:
					expr = constantExpression ();
					break;
				case 3:
					expr = variableExpression ();
					break;
				default:
					print ("Invalid option, please try again");
					expr = inputExpression ();
					break;

			}
			return expr;
		}

		private CompStmt compoundStatement () {
			print ("Left side:");
			IStmt left = inputStatement ();
			print ("Right side:");
			IStmt right = inputStatement ();
			return new CompStmt (left, right);
		}

		private AssignStmt assignmentStatement () {
			String name = readString ("Var name:");
			print ("Right side:");
			Exp exp = inputExpression ();
			return new AssignStmt (name, exp);
		}

		private IfStmt ifStatement () {
			print ("Expression:");
			Exp expression = inputExpression ();
			print ("Then Statement:");
			IStmt thenS = inputStatement ();
			print ("Else Statement:");
			IStmt elseS = inputStatement ();
			return new IfStmt (expression, thenS, elseS);
		}

		private PrintStmt printStatement () {
			print ("Expression:");
			Exp expression = inputExpression ();
			return new PrintStmt (expression);
		}

		private IStmt inputStatement () {
			print ("1. Compound statement");
			print ("2. Assignment statement");
			print ("3. If statement");
			print ("4. Print statement");
			int opt = readInteger ("Option: ");
			IStmt prg;
			switch (opt) {
				case 1:
					prg = compoundStatement ();
					break;
				case 2:
					prg = assignmentStatement ();
					break;
				case 3:
					prg = ifStatement ();
					break;
				case 4:
					prg = printStatement ();
					break;
				default:
					print ("Invalid option, please try again");
					prg = inputStatement ();
					break;
			}
			return prg;
		}

		private void inputProgram () {
			IStmt prgStatement = new CompStmt(new AssignStmt("a", new ArithExp(new ConstExp(2), "-", new ConstExp(2))),new CompStmt(new IfStmt(new VarExp("a"),new AssignStmt("v",new ConstExp(2)), new AssignStmt("v", new ConstExp(3))), new PrintStmt(new VarExp("v"))));
			//new CompStmt(new AssignStmt("a", new ArithExp(new ConstExp(2), "-", new ConstExp(2))),new CompStmt(new IfStmt(new VarExp("a"),new AssignStmt("v",new ConstExp(2)), new AssignStmt("v", new ConstExp(3))), new PrintStmt(new VarExp("v"))));
			currentProgram = new PrgState (new MyLibraryStack<IStmt> (), new MyLibraryDictionary<String, int> (), new MyLibraryList<int> (), prgStatement);
			PrgState[] programs = { currentProgram };
			currentProgram.printState ();
			ctrl = new Controller (new MyRepository (programs));
		}

		private void firstMenu () {
			print ("1. Input program");
			print ("2. One Step");
			print ("3. All Step");
			print ("4. Set printFlag");
			int opt = readInteger ("Option: ");

			if (opt != 1 && currentProgram == null) {
				print ("There is no program, please insert a program");
			} else {
				switch (opt) {
					case 1:
						inputProgram ();
						break;
					case 2:
						oneStep ();
						break;
					case 3:
						allStep ();
						break;
					case 4:
						setPrintFlag ();
						break;
					default:
						print ("Invalid option, please try again");
						break;
				}
			}
			firstMenu ();
		}

		public void run () {
			firstMenu ();
		}
	}
}

