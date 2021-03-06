using System;
using System.Collections.Generic;
using System.Text;

namespace Tubes2Stime
{
    public class Graph
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

        public List<string> ExploreFriendsBFS(string a, string b)
        {
            Queue<List<string>> antrian = new Queue<List<string>>();
            List<string> test = new List<string>();
            int size = this.getVertice().Count;
            bool found = false;
            bool[] dikunjungi = new Boolean[size];

            for (int i = 0; i < size; i++)
            {
                dikunjungi[i] = false;
            }

            test.Add(a);
            antrian.Enqueue(test);
            dikunjungi[binSearch(this.getVertice(), a, 0, this.getVertice().Count)] = true;

            if (notInVertice(a) || notInVertice(b))
            {
                //Console.WriteLine("checkNull1");
                return null;
            }

            else
            {
                while (antrian.Count > 0 && found == false)
                {
                    //Console.WriteLine(antrian.Count);
                    List<string> tmp = antrian.Dequeue();

                    string last = tmp[tmp.Count - 1];
                    int i = 0;
                    if (last == b)
                    {
                        test = tmp;
                        found = true;
                    }
                    else
                    {
                        while (i < this.getEdges().Count)
                        {
                            string node1 = this.getEdges()[i].getNode1();
                            string node2 = this.getEdges()[i].getNode2();
                            List<string> tmp1 = new List<string>();
                            for (int y = 0; y < tmp.Count; y++)
                            {
                                tmp1.Add(tmp[y]);
                            }
                            if (node1 == last && !dikunjungi[binSearch(this.getVertice(), node2, 0, this.getVertice().Count)])
                            {
                                tmp1.Add(node2);
                                dikunjungi[binSearch(this.getVertice(), node2, 0, this.getVertice().Count)] = true;
                                antrian.Enqueue(tmp1);
                            }

                            i++;
                        }
                    }

                }
                if (found == true)
                {
                    //Console.WriteLine("check");
                    return test;
                }
                else
                {
                    //Console.WriteLine("CheckNull2");
                    return null;
                }

            }

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

        //Isi edges tapi gada yang bolak-balik
        public void isiEdgesver2(string[] newString)
        {
            //int i = 0;
            //this.edge = new Edges[newString.Length];
            foreach (string line in newString)
            {
                Edges temp1 = new Edges(Char.ToString(line[0]), Char.ToString(line[2]));

                this.edge.Add(temp1);

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

        public Boolean notInList(string x, List<string> arrayString)
        {
            Boolean found = true;

            foreach (string node in arrayString)
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


        public string outputOfMutual = "";

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
                    if (tmp.Count == 0 || binSearch(tmp, node2, 0, tmp.Count) == -1)
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
                outputOfMutual += ("Nama akun : " + b);
                outputOfMutual += ("\nMutual friends : " + res.Count);
                outputOfMutual += " (";
                for (int j = 0; j < res.Count; j++)
                {
                    if (j == res.Count - 1)
                    {
                        outputOfMutual += (res[j]);
                        outputOfMutual += (")\n");
                    }
                    else
                    {
                        outputOfMutual += (res[j]);
                        outputOfMutual += (", ");
                    }
                }
                outputOfMutual += ("\n");
            }
            // else if (res.Count == 0)
            //{
            //    Console.WriteLine("No mutual friends");
            //}
        }


        public void getAllMutualFriends(string a)
        {
            List<string> currentFriends = new List<string>();
            List<string> recommendedFriends = new List<string>();

            foreach (Edges i in this.getEdges())
            {
                if (i.getNode1() == a)
                {
                    currentFriends.Add(i.getNode2());
                }
            }

            foreach (Edges j in this.getEdges())
            {
                if (j.getNode1() != a && this.notInList(j.getNode1(), currentFriends))
                {
                    if (this.notInList(j.getNode1(), recommendedFriends))
                    {
                        recommendedFriends.Add(j.getNode1());
                    }

                }
            }

            foreach (String i in recommendedFriends)
            {
                // Console.WriteLine(i);
                this.mutualFriends(a, i);
            }
        }




    }
}

