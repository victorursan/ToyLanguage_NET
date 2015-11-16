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
				throw new UnexpectedTypeException ();
			}
		}

		private void oneStep () {
			try {
				ctrl.oneStep ();
				ctrl.serializeProgramState ();
			} catch (MyStmtExecException) {
				print ("Finished");
				currentProgram = null;
			} catch (UninitializedVariableException) {
				print ("A variable is not initialized");
			} catch (NoSuchKeyException) {
				print ("No such Variable");
			} catch (DivisionByZeroException) {
				print ("Division by zero");
			} catch (EmptyRepositoryException) {
				print ("No program state ");
			}
		}

		private void allStep () {
			try {
				ctrl.allStep ();
				ctrl.serializeProgramState ();
			} catch (MyStmtExecException) {
				print ("Finished");
				currentProgram = null;
			} catch (UninitializedVariableException) {
				print ("A variable is not initialized");
			} catch (NoSuchKeyException) {
				print ("No such Variable");
			} catch (DivisionByZeroException) {
				print ("Division by zero");
			} catch (EmptyRepositoryException) {
				print ("No program state ");
			}
		}

		private void setPrintFlag () {
			print ("Currently it is:");
			if (ctrl.PrintFlag) {
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
					ctrl.PrintFlag = !ctrl.PrintFlag;
					break;
				case 2:
					break;
				default:
					print ("Invalid option, please try again");
					setPrintFlag ();
					break;
			}

		}

		private void setLogFlag () {
			print ("Currently it is:");
			if (ctrl.LogFlag) {
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
					ctrl.LogFlag = !ctrl.LogFlag;
					break;
				case 2:
					break;
				default:
					print ("Invalid option, please try again");
					setLogFlag ();
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

		private RelationalExp relationalExpression () {
			print ("Available operands: <, <=, ==, !=, >, >=");
			String opperand = readString ("Operand: ");
			List<String> elements = new List<String> ();
			elements.Add ("<");
			elements.Add ("<=");
			elements.Add ("==");
			elements.Add ("!=");
			elements.Add (">");
			elements.Add (">=");
			if (elements.Contains (opperand)) {
				print ("Left:");
				Exp left = inputExpression ();
				print ("Right:");
				Exp right = inputExpression ();
				return new RelationalExp (left, opperand, right);
			}
			print ("invalid operand");
			return relationalExpression ();
		}

		private Exp logicalExpression () {
			print ("Available operands: !, ||, &&");
			String opperand = readString ("Operand: ");
			List<String> elements = new List<String> ();
			elements.Add ("||");
			elements.Add ("&&");
			if (opperand.Equals ("!")) {
				print ("Expression:");
				Exp exp = inputExpression ();
				return new NotExp (exp);
			} else if (elements.Contains (opperand)) {
				print ("Left:");
				Exp left = inputExpression ();
				print ("Right:");
				Exp right = inputExpression ();
				return new LogicalExp (left, opperand, right);
			}
			print ("invalid operand");
			return relationalExpression ();
		}

		private ReadExp readExpression () {
			return new ReadExp ();
		}

		private Exp inputExpression () {
			print ("1. Arithmetical expression");
			print ("2. Constant expression");
			print ("3. Var expression");
			print ("4. Relational expression");
			print ("5. Logical expression");
			print ("6. Read expression");
			try {
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
					case 4:
						expr = relationalExpression ();
						break;
					case 5:
						expr = logicalExpression ();
						break;
					case 6:
						expr = readExpression ();
						break;
					default:
						print ("Invalid option, please try again");
						expr = inputExpression ();
						break;

				}
				return expr;
			} catch (UnexpectedTypeException) {
				print ("Invalid option, please try again");
				return inputExpression ();
			}
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

		private WhileStmt whileStatement () {
			print ("Expression:");
			Exp expression = inputExpression ();
			print ("Statement:");
			IStmt statement = inputStatement ();
			return new WhileStmt (expression, statement);
		}

		private SkipStmt skipStatements () {
			return new SkipStmt ();
		}


		private SwitchStmt switchStatement () {
			String variableName = readString ("Variable name");
			Exp expr = new VarExp (variableName);
			print ("Case 1 expression:");
			Exp expCase1 = inputExpression ();
			print ("Case 1 Statement:");
			IStmt case1 = inputStatement ();
			print ("Case 2 expression:");
			Exp expCase2 = inputExpression ();
			print ("Case 2 Statement:");
			IStmt case2 = inputStatement ();
			print ("Default case Statement:");
			IStmt caseDefault = inputStatement ();

			return new SwitchStmt (expr, expCase1, case1, expCase2, case2, caseDefault);
		}

		private IfThenStmt ifThenStatement () {
			print ("Expression:");
			Exp expression = inputExpression ();
			print ("Then Statement:");
			IStmt thenS = inputStatement ();
			return new IfThenStmt (expression, thenS);
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
			print ("5. While statement");
			print ("6. Skip statement");
			print ("7. Switch statement");
			print ("8. If then statement");
			try {
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
					case 5:
						prg = whileStatement ();
						break;
					case 6:
						prg = skipStatements ();
						break;
					case 7:
						prg = switchStatement ();
						break;
					case 8:
						prg = ifThenStatement ();
						break;
					default:
						print ("Invalid option, please try again");
						prg = inputStatement ();
						break;
				}

				return prg;
			} catch (UnexpectedTypeException) {
				print ("Invalid option, please try again");
				return inputStatement ();
			}
		}

		private void inputProgram () {
			IStmt prgStatement = new CompStmt (new AssignStmt ("a", new ArithExp (new ConstExp (2), "-", new ConstExp (3))), new CompStmt (new IfThenStmt (new VarExp ("a"), new AssignStmt ("v", new ConstExp (2))), new PrintStmt (new VarExp ("v"))));
			//inputStatement ();
	
			ListInterface<PrgState> programs = new MyLibraryList<PrgState> ();
			programs.Add (new PrgState (new MyLibraryStack<IStmt> (), new MyLibraryDictionary<String, int> (), new MyLibraryList<int> (), prgStatement));
			ctrl = new Controller (new MyRepository (programs));
			ctrl.serializeProgramState ();
			currentProgram = ctrl.CrtPrgState;
			print (currentProgram.printState ());

		}

		private void lastProgramState () {
			Repository repo = new MyRepository ();
			repo.deserializePrgStatet ();
			ctrl = new Controller(repo);
			currentProgram = ctrl.CrtPrgState;
			print (currentProgram.printState ());
		}

		private void firstMenu () {
			print ("1. Input program");
			print ("2. One Step");
			print ("3. All Step");
			print ("4. Set printFlag");
			print ("5. Last program state");
			print ("6. Set logFlag");

			try {
				int opt = readInteger ("Option: ");
				if (opt != 1 && opt != 5 && currentProgram == null) {
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
						case 5:
							lastProgramState ();
							break;
						case 6:
							setLogFlag ();
							break;
						default:
							print ("Invalid option, please try again");
							break;
					}
				}
				firstMenu ();
			} catch (UnexpectedTypeException) {
				print ("Invalid option, please insert a number");
				firstMenu ();
			} catch (EmptyRepositoryException) {
				print ("No program added");
			}
		}

		public void run () {
			firstMenu ();
		}
	}
}

