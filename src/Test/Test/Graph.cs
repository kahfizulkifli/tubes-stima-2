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

        public void BFS(string simpul) 
        {
            string w;
            List<string> antrian = new List<string>();
            List<bool> dikunjungi = new List<bool>();
            
            
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

