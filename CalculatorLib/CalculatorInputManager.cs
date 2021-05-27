using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib
{
    public static class CalculatorInputManager
    {
        public static string ManageInput(this string infixExpression, int mode)
        {
            string result = "";

            if (mode == 1)
            {
                result = infixExpression.ConvertInfixToPostfix().CalculatePostfixUsingStack().ToString();

            }
            if (mode == 2)
            {
                result = infixExpression.ConvertInfixToPostfix().CalculatePostfixUsingTree().ToString();
            }

            return result;
        }
    }
}
