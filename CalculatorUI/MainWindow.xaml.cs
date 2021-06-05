using CalculatorLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string inputExpression = "";
        string result = "";
        bool commaClicked = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = ((Button)sender).Content.ToString();

            if (int.TryParse(buttonContent, out int result))
            {
                inputExpression += buttonContent;
            }
            else
            {
                if (inputExpression == "" || inputExpression.Last() == ' ')
                {
                    inputExpression += buttonContent + " ";
                }
                else
                {
                    inputExpression += " " + buttonContent + " ";
                }
                commaClicked = false;
            }
            totalInputTextBlock.Text = inputExpression;
        }

        private void buttonResult_Click(object sender, RoutedEventArgs e)
        {
            result = "";

            try
            {
                // 1 stack, 2 tree, 3 infix tree
                if (stackModeRadioButton.IsChecked == true)
                {
                    result = inputExpression.Trim().ManageInput(1);
                }
                else if (treeModeRadioButton.IsChecked == true)
                {
                    result = inputExpression.Trim().ManageInput(2);
                }
                else if (altTreeModeRadioButton.IsChecked == true)
                {
                    result = inputExpression.Trim().ManageInput(3);
                }

                totalInputTextBlock.Text = inputExpression + "=";
                currentInputTextBlock.Text = "";
                currentInputTextBlock.Text = result;
            }
            catch (NullReferenceException)
            {
                buttonClearAll_Click(this, null);
                currentInputTextBlock.Text = "syntax error";
            }
            catch (InvalidOperationException)
            {
                buttonClearAll_Click(this, null);
                currentInputTextBlock.Text = "syntax error";
            }
        }

        private void buttonComma_Click(object sender, RoutedEventArgs e)
        {
            if (commaClicked == false && int.TryParse(inputExpression[inputExpression.Length - 1].ToString(), out int result))
            {
                inputExpression = inputExpression.Trim() + ",";
                totalInputTextBlock.Text = inputExpression;
                commaClicked = true;
            }
        }

        private void buttonClearAll_Click(object sender, RoutedEventArgs e)
        {
            totalInputTextBlock.Text = "";
            currentInputTextBlock.Text = "0";
            inputExpression = "";
            commaClicked = false;
        }

        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {
            if (inputExpression.Length > 0)
            {
                inputExpression = inputExpression.Remove(inputExpression.Length - 1);
                totalInputTextBlock.Text = inputExpression;
            }
        }

        private void buttonLastAnswer_Click(object sender, RoutedEventArgs e)
        {
            inputExpression = result;
            totalInputTextBlock.Text = inputExpression;
        }
    }
}
