using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GuessingGame
{
    public static class Core
    {

        private static DecisionTree decisionTree;

        public static void start(MainWindow mainWindow)
        {

            bool sucess = true;
            bool choice;
            string answer, newRule;

            DecisionWindow decisionWindow = new DecisionWindow();
            InputWindow inputWindow = new InputWindow();

            if(decisionTree == null)
                decisionTree = new DecisionTree("lives in water", "Squirtle", "Charmander");
            else
            {
                decisionTree.Executing = true;
            }

            while (decisionTree.Executing)
            {
                choice = decisionWindow.DisplayQuestion(decisionTree.CurrentQuestion);

                if (decisionTree.travel(choice))
                {
                    answer = inputWindow.QueryInput("What was the Pokemon that you thought about?");
                    newRule = inputWindow.QueryInput(String.Format("A {0}_________but a {1} does not (Fill it with a Pokemon trait).", answer, decisionTree.CurrentData));

                    decisionTree.expandNode(newRule, answer);
                    sucess = false;
                }
            }
            
            if(sucess)
            {
                EndWindow endWindow = new EndWindow();

                endWindow.ShowDialog();
            }

            inputWindow.Close();
            decisionWindow.Close();
            mainWindow.Show();

        }
    }
}
