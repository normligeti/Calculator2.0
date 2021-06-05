using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    static class CalculateUsingTreeFromInfix
    {
        internal class TreeNode
        {
            internal string data;
            internal TreeNode left;
            internal TreeNode right;

            internal TreeNode(string data)
            {
                this.data = data;
                left = null;
                right = null;
            }
        }

        /// <summary>
        /// Calculates and returns the end result of an infix algebraic expression.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The result in double format.</returns>
        public static double CalculateInfixUsingTree(this string expression)
        {
            List<string> inputInfixExpression = expression.Split().ToList();

            return inputInfixExpression.BuildTreeFromInfix().EvaluateTree();
        }

        internal static TreeNode BuildTreeFromInfix(this List<string> inputInfixExpression)
        {
            TreeNode root = null;
            TreeNode currentNode;
            TreeNode lastNode = null;

            foreach (string item in inputInfixExpression)
            {
                currentNode = new TreeNode(item);

                if (root == null)
                {
                    root = currentNode;
                    lastNode = root;
                }
                else
                {
                    if (currentNode.data == "+" || currentNode.data == "-")
                    {
                        currentNode.left = root;
                        root = currentNode;
                        lastNode = root;
                    }
                    else if (currentNode.data == "*" || currentNode.data == "/")
                    {
                        if (lastNode.right == null)
                        {
                            currentNode.left = lastNode;
                            root = currentNode;
                            lastNode = root;
                        }
                        else
                        {
                            currentNode.left = lastNode.right;
                            lastNode.right = currentNode;
                            lastNode = currentNode;
                        }
                    }
                    else
                    {
                        lastNode.right = currentNode;
                    }
                }
            }
            return root;
        }

        internal static double EvaluateTree(this TreeNode node)
        {
            if (double.TryParse(node.data, out double number))
            {
                return number;
            }
            else
            {
                return Calculate(EvaluateTree(node.left), node.data, EvaluateTree(node.right));
            }
        }

        private static double Calculate(double operand1, string operation, double operand2)
        {
            switch (operation)
            {
                case "/":
                    return operand1 / operand2;
                case "*":
                    return operand1 * operand2;
                case "-":
                    return operand1 - operand2;
                case "+":
                    return operand1 + operand2;
                default:
                    return 0;
            }
        }
    }
}
