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

        //bfs belum ditest
        public string explorefriendsbfs(string a, string b)
        {
            Queue<string> antrian = new Queue<string>();
            HashSet<string> dikunjungi = new HashSet<string>();
            antrian.Enqueue(a);
            dikunjungi.Add(a);

            while (antrian.Count > 0)
            {
                string friend = antrian.Dequeue();
                if (friend == b) return friend;

                List<string> friends = new List<string>();
                int i = 0;
                foreach (Edges connection in this.edge)
                {
                    if (connection.getNode1() == friend) friends.Insert(i, connection.getNode2());
                }

                foreach (string friend1 in friends)
                {
                    if (!dikunjungi.Contains(friend1))
                    {
                        antrian.Enqueue(friend1);
                        dikunjungi.Add(friend1);
                    }
                }
            }
            return null;
        }

        //DFS not tested for any possible bug yet
        public List<string> ExploreFriendsDFS(string a, string b)
        {
            int size = this.getVertice().Count;
            bool[] dikunjungi = new Boolean[size];
            Stack<string> test = new Stack<string>();
            bool found = false;
            List<string> result = new List<string>();

            for (int i = 0; i < size; i++)
            {
                dikunjungi[i] = false;
            }

            test.Push(a);
            dikunjungi[binSearch(this.getVertice(), a, 0, this.getVertice().Count)] = true;

            if (notInVertice(a) || notInVertice(b))
            {
                return result;
            }
            else
            {
                while (test.Count != 0 && found == false)
                {
                    int i = 0;
                    bool found1 = false;
                    while (i < this.getEdges().Count && found1 == false)
                    {
                        string node1 = this.getEdges()[i].getNode1();
                        string node2 = this.getEdges()[i].getNode2();
                        //Console.WriteLine(node1 + " " + node2);
                        //Console.WriteLine(this.getEdges().Count);
                        if (node1 == test.Peek() && !dikunjungi[binSearch(this.getVertice(), node2, 0, this.getVertice().Count)])
                        {
                            //  Console.WriteLine("WEW");
                            test.Push(node2);
                            dikunjungi[binSearch(this.getVertice(), node2, 0, this.getVertice().Count)] = true;
                            found1 = true;
                        }
                        else
                        {
                            i++;
                        }
                    }

                    if(test.Peek() == b)
                    {
                        found = true;
                    }

                    //sudah sampai simpul daun
                    if (found1 == false)
                    {
                        test.Pop();
                    }
                }

                if(found == false)
                {
                    //Console.WriteLine("Ga ketemu");
                    return result;
                }
                else
                {
                    int count = 0;
                    while(test.Count > 0)
                    {
                        //Console.WriteLine(count);
                        result.Insert(0, test.Peek());
                        test.Pop();
                        count++;
                    }
                    return result;
                }
                
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
                Edges temp1 = new Edges(Char.ToString(line[0]), Char.ToString(line[2]));
                Edges temp2 = new Edges(Char.ToString(line[2]), Char.ToString(line[0]));
                this.edge.Add(temp1);
                this.edge.Add(temp2);
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

        public int binSearch(List<string> vertice, string x, int beginning, int end)
        {
            int k = beginning + ((end - beginning) / 2);
            //Console.WriteLine(end);

            if (end-beginning == 0)
            {
                return -1;
            }
            else if (end-beginning == 1)
            {
                if(vertice[0] == x)
                {
                    return (end-beginning) - 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                //Console.WriteLine(k);
                //Console.WriteLine(string.Compare(x, vertice[k]));
                if (string.Compare(x,vertice[k]) == 0)
                {
                    return k;
                }
                else if (string.Compare(x,vertice[k]) == -1)
                {
                    return binSearch(vertice, x, beginning,k);
                }
                else
                {
                    return binSearch(vertice, x, k, end);
                }
            }
        }

        //Not tested to many test case
        public void mutualFriends(string a, string b)
        {
            int i = 0;
            List<string> tmp = new List<string>();
            List<Edges> thisEdge = this.getEdges();
            List<string> res = new List<string>();
            while (i < thisEdge.Count)
            {
                string node1 = thisEdge[i].getNode1();
                string node2 = thisEdge[i].getNode2();
                if (node1 == a)
                {
                    if (tmp.Count == 0 || binSearch(tmp,node2, 0, tmp.Count) == -1)
                    {
                        tmp.Add(node2);
                        
                    }
                    
                }

                i++;
            }
            int k = 0;
            while (k < thisEdge.Count)
            {
                string node1 = thisEdge[k].getNode1();
                string node2 = thisEdge[k].getNode2();
                if (node1 == b)
                {
                    if (binSearch(tmp, node2, 0, tmp.Count) != -1)
                    {
                        res.Add(node2);

                    }

                }

                k++;
            }
            if (res.Count > 0)
            {
                Console.WriteLine(b);
                Console.WriteLine("Mutual friends : "+res.Count);
                for (int j = 0; j < res.Count; j++)
                {
                    if (j == res.Count - 1)
                    {
                        Console.WriteLine(res[j]);
                    }
                    else
                    { 
                        Console.Write(res[j]);
                        Console.Write(",");
                    }
                }
                Console.WriteLine("");
            }
            else if (res.Count == 0)
            {
                Console.WriteLine("No mutual friends");
            }
        }

        public void getAllMutualFriends(string a)
        {
            List<string> currentFriends = new List<string>();
            foreach (Edges i in this.getEdges())
            {
                if (i.getNode1() == a)
                {
                    currentFriends.Add(i.getNode2());
                }
            }

            foreach (String i in currentFriends)
            {
                // Console.WriteLine(i);
                this.mutualFriends(a, i);
            }
        }


    }
}

