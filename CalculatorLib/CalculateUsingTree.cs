using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    static class CalculateUsingTree
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

        public static double CalculatePostfixUsingTree(this List<string> inputPostfixExpression)
        {
            return inputPostfixExpression.BuildTree().EvaluateTree();
        }

        internal static TreeNode BuildTree(this List<string> inputPostfixExpression)
        {
            TreeNode currentNode;
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();

            foreach (string item in inputPostfixExpression)
            {
                if (double.TryParse(item, out double result))
                {
                    nodeStack.Push(new TreeNode(item));
                }
                else
                {
                    currentNode = new TreeNode(item);
                    currentNode.right = nodeStack.Pop();
                    currentNode.left = nodeStack.Pop();
                    nodeStack.Push(currentNode);
                }
            }
            return nodeStack.Pop();
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
