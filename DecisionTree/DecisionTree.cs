using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    public class DecisionTree
    {
        private Node _root;
        private Node _current;
        private Node _parent;
        private bool _lastDecision;
        private bool _executing;

        public bool Executing {
            get { return _executing; }
            set { _executing = value;  }
        }

        public string CurrentQuestion
        {
            get {
                if (!_current.isLeaf())
                    return String.Format("Does the Pokemon that you thought about {0}?", _current.Data);
                return String.Format("Is the Pokemon that you thought about {0}?", _current.Data);
            }
        }

        public string CurrentData
        {
            get
            {
                return _current.Data;
            }
        }

        public DecisionTree(string decisionData, string positiveAnswer, string negativeAnswer)
        {
            _root = new Node(decisionData);
            _root.Left = new Node(positiveAnswer);
            _root.Right = new Node(negativeAnswer);
            _executing = true;
            resetTravel();
        }

        private void resetTravel()
        {
            _current = _root;
            _parent = null;
        }

        public bool travel(bool decision)
        {

            bool expand = false;

            if(_current.isLeaf())
            {
                if(decision)
                {
                    resetTravel();
                }
                else
                {
                    expand = true;
                }

                _executing = false;
            }
            else
            {
                _parent = _current;
                _lastDecision = decision;

                if (decision)
                {
                    _current = _current.Left;
                }
                else
                {
                    _current = _current.Right;
                }

            }

            return expand;
        }

        public void expandNode(string decisionData, string answerData)
        {
            Node decisionNode = new Node(decisionData);

            if (_lastDecision)
                _parent.Left = decisionNode;
            else
                _parent.Right = decisionNode;

            decisionNode.Right = _current;
            decisionNode.Left = new Node(answerData);

            resetTravel();
            
        }
    }
}
