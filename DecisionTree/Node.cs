using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    public class Node
    {

        public Node Left { get; set; }

        public Node Right { get; set; }

        public string Data { get; set; }

        public Node(string newData)
        {
            Data = newData;
        }

        public bool isLeaf()
        {
            return (Left == null && Right == null);
        }

    }
}
