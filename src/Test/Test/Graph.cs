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

        //BFS belum ditest
        public void ExploreFriendsBFS(string a, string b) 
        {
            Queue<string> antrian = new Queue<string>();
            HashSet<string> dikunjungi = new HashSet<string>();
            antrian.Enqueue(a);
            dikunjungi.Add(a);
            
            while (antrian.count > 0)
            {
                string friend = antrian.Dequeue();
                if (friend == b) return friend;

                List<string> friends = new List<string>();
                int i = 0;
                foreach (Edges connection in this.edge)
                {
                    if (connection.getNode1() == friend) friends.Insert(i, connection.getNode2()); 
                }

                foreach (string friend in friends)
                {
                    if (!dikunjungi.Contains(friend))
                    {
                        antrian.Enqueue(friend);
                        dikunjungi.Add(friend);
                    }
                }
            }
            return null;
        }

        //DFS belum kelar
        public void ExploreFriendsDFS(int root, int search) 
        {
            
            bool[] dikunjungi = new Boolean[edgeSize];
            bool[v] = true;

            for (int i = 0; i < edgeSize; i++)
            {
                if (edge[v].getNode1() = vertice[v] &&)
            }
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

