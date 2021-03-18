using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    class Graph
    {
        //int edgeSize;
        List<string> vertice;
        List<Edges> edge;

        public Graph()
        {
            //this.edgeSize = ukuranSisi;
            this.vertice = new List<string>();
            this.edge = new List<Edges>();
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

        public List<Edges> getEdges()
        {
            return this.edge;
        }

        public List<string> getVertice()
        {
            return this.vertice;
        }

        public void setVertice(List<string> temp)
        {
            this.vertice = temp;
        }

        public void setEdges(List<Edges> temp)
        {
            this.edge = temp;
        }

        public void isiEdges(string[] newString)
        {
            //int i = 0;
            //this.edge = new Edges[newString.Length];
            foreach (string line in newString)
            {
                Edges temp = new Edges(Char.ToString(line[0]), Char.ToString(line[2]));
                this.edge.Add(temp);
                //i++
                //this.edge[i].setNode1("test");
                //this.edge[i].setNode2(Char.ToString(line[2]));
            }

        }

        public void isiVertice(string[] newString)
        {
            foreach (string line in newString)
            { 
                if (notInVertice(Char.ToString(line[0])))
                { 
                    this.vertice.Add(Char.ToString(line[0]));
                }
                if (notInVertice(Char.ToString(line[2])))
                { 
                    this.vertice.Add(Char.ToString(line[2]));
                }
            }
        }

        public Boolean notInVertice(string x)
        {
            Boolean found = true;
            List<string> test = this.getVertice();
            
            foreach (string node in test)
            {
                if (x == node)
                {
                    found = false;
                }
               
            }

            return found;
        }

        public void sortEdges()
        {
            int size = this.getEdges().Count;
            for (int i = 0; i< size - 1; i++)
            {
                for (int j = 0; j<size -1; j++)
                {
                    if (string.Compare(this.edge[j].getNode1(), this.edge[j+1].getNode1()) == 1)
                    { 
                        Edges temp1 = this.edge[j];
                        this.edge[j] = this.edge[j + 1];
                        this.edge[j + 1] = temp1;
                    }
                    else if (string.Compare(this.edge[j].getNode1(), this.edge[j + 1].getNode1()) == 0)
                    {
                        if (string.Compare(this.edge[j].getNode2(), this.edge[j + 1].getNode2()) == 1)
                        {
                            Edges temp1 = this.edge[j];
                            this.edge[j] = this.edge[j + 1];
                            this.edge[j + 1] = temp1;
                        }
                    }
                    
                }
            }
        }
    }
}

