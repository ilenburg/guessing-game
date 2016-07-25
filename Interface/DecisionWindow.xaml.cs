using System.Windows;
using System.Windows.Controls;

namespace GuessingGame
{
    /// <summary>
    /// Interaction logic for DecisionWindow.xaml
    /// </summary>
    public partial class DecisionWindow : Window
    {

        private bool choice;

        private TextBlock questionBox;

        public DecisionWindow()
        {
            InitializeComponent();
            questionBox = (TextBlock)this.FindName("QuestionBlock");
        }

        private void Button_Decide(object sender, RoutedEventArgs e)
        {
            string tag = (string)((Button)sender).Tag;

            choice = tag == "true" ? true : false;

            Hide();
        }

        public bool DisplayQuestion(string questionText)
        {
            questionBox.Text = questionText;
            ShowDialog();
            return choice;
        }

    }
}
