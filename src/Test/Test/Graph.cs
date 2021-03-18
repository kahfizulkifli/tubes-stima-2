using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Graph
    {
        int edgeSize;
        List<string> vertice;
        protected Edges[] edge;

        public Graph(int ukuranSisi, List<string> simpul, Edges[] sisi)
        {
            this.edgeSize = ukuranSisi;
            this.vertice = new List<string>();
            this.edge = new Edges[this.edgeSize];
        }

        public void BFS(string simpul) 
        {
            string w;
            List<string> antrian = new List<string>();
            List<bool> dikunjungi = new List<bool>();
            
            
        } 

        public Edges[] getEdges()
        {
            return this.edge;
        }

        public void isiEdges(string[] newString)
        {
            int i = 0;
            //this.edge = new Edges[newString.Length];
            foreach (string line in newString)
            {
                this.edge[i] = new Edges(Char.ToString(line[0]), Char.ToString(line[2]));
                //this.edge[i].setNode1("test");
                //this.edge[i].setNode2(Char.ToString(line[2]));
            }

        }
    }
}

