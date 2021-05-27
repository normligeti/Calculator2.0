using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    static class InputConverter
    {
        /// <summary>
        /// Converts an infix algebraic expression to a postfix algebraic expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>The resulting postfix expression.</returns>
        public static List<string> ConvertInfixToPostfix(this string expression)
        {
            Stack<string> opStack = new Stack<string>();
            List<string> tokenList = expression.Split().ToList();
            List<string> outputPostfix = new List<string>();

            Dictionary<string, int> prec = new Dictionary<string, int>();
            prec.Add("*", 3);
            prec.Add("/", 3);
            prec.Add("+", 2);
            prec.Add("-", 2);
            prec.Add("(", 1);

            foreach (string token in tokenList)
            {
                if (double.TryParse(token, out double result))
                {
                    outputPostfix.Add(token);
                }
                else if (token == "(")
                {
                    opStack.Push(token);
                }
                else if (token == ")")
                {
                    string tempToken = opStack.Pop();

                    while (tempToken != "(")
                    {
                        outputPostfix.Add(tempToken);
                        tempToken = opStack.Pop();
                    }
                }
                else
                {
                    while (opStack.Count != 0 && (prec[opStack.Peek()] >= prec[token]))
                    {
                        outputPostfix.Add(opStack.Pop());
                    }
                    opStack.Push(token);
                }
            }

            while (opStack.Count != 0)
            {
                outputPostfix.Add(opStack.Pop());
            }
            return outputPostfix;
        }
    }
}
