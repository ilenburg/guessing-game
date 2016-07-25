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
using System.Windows.Shapes;

namespace GuessingGame
{
    /// <summary>
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window
    {

        private TextBox textBox;
        private TextBlock questionBlock;

        public InputWindow()
        {
            InitializeComponent();
            questionBlock = (TextBlock)FindName("QuestionBlock");
            textBox = (TextBox)FindName("InputBox");
            textBox.KeyDown += new KeyEventHandler(tb_KeyDown);
        }

        public string QueryInput(string questionText)
        {
            questionBlock.Text = questionText;
            textBox.Text = String.Empty;
            ShowDialog();
            return textBox.Text;
        }

        private void Button_Submit(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Hide();
            }
        }
    }
}
