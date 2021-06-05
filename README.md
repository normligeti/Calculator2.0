# Calculator2.0
A GUI (wpf) calculator that takes an algebraic expression and returns a result.
The length of the expression is arbitrary, the calculator respects the order of operations, handles parentheses and supports floating-point and negative numbers.
The UI code in MainWindow.cs builds the input as a string and passes it to CalculatorInputManager.cs in CalculatorLib library.
From here, for the sake of practice, i've implemented 3 ways the calculator can handle an expression - the mode selector at the bottom of the UI represents these:
- stack: converts the input infix expression to postfix, then calculates the result using a stack
- tree 1: converts the input infix expression to postfix, builds a binary expression tree and evaluates it using recursion
- tree 2 : builds a binary expression tree directly from the input infix expression and evaluates it using recursion (this mode does not support parentheses)
