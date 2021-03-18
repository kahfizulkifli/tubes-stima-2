using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Edges
    {
        string node1;
        string node2;

        public Edges(string test1, string test2)
        {
           
            this.node1 = test1;
            this.node2 = test2;

        }

        public void printEdge()
        {
            Console.WriteLine(this.node1 + "," + this.node2);
        }

        public string getNode1()
        {
            return this.node1;
        }

        public string getNode2()
        {
            return this.node2;
        }

        public void setNode1(string node)
        {
            this.node1 = node;
        }

        public void setNode2(string node)
        {
            this.node2 = node;
        }
    }
}
