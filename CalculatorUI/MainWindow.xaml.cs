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
        string result;
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
                totalInputTextBlock.Text = inputExpression;
            }
            else
            {
                if (inputExpression == "" || inputExpression.Last() == ' ')
                {
                    inputExpression += buttonContent + " ";
                    totalInputTextBlock.Text = inputExpression;
                }
                else
                {
                    inputExpression += " " + buttonContent + " ";
                    totalInputTextBlock.Text = inputExpression;
                }

                commaClicked = false;
            }
        }

        private void buttonResult1_Click(object sender, RoutedEventArgs e)
        {
            result = inputExpression.Trim().ManageInput(1);
            totalInputTextBlock.Text = inputExpression + "=";
            currentInputTextBlock.Text = result;
        }

        private void buttonResult2_Click(object sender, RoutedEventArgs e)
        {
            result = inputExpression.Trim().ManageInput(2);
            totalInputTextBlock.Text = inputExpression + "=";
            currentInputTextBlock.Text = result;
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
            result = "";
            inputExpression = "";
        }

        private void buttonClearCurrent_Click(object sender, RoutedEventArgs e)
        {
            currentInputTextBlock.Text = "0";
        }

        private void buttonNegate_Click(object sender, RoutedEventArgs e)
        {
            
        }
        
    }
}
