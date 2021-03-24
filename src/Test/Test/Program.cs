using System;
using System.Collections;
using System.Collections.Generic;
namespace Test
{
    class MainProgram
    {
        public string[] readFile(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(@path);

            return lines;
        }

        public Graph output(string[] lines)
        {
            //Inisiasi Graph
            Graph testGraph = new Graph();

            //Isi testGraph
            testGraph.isiEdges(lines);
            testGraph.isiVertice(lines);
            List<string> temp = testGraph.getVertice();
            temp.Sort();
            testGraph.setVertice(temp);
            testGraph.sortEdges();
            return testGraph;
        }
        static void Main(string[] args)
        {
            MainProgram x = new MainProgram();

            //ReadFile From test.txt
            string location = "D:/Semester 4/Stigma/tubes-stima-2/src/Test/Test/";
            //string location = "D:\\Code\\tubes-stima-2\\src\\Test\\Test\\";

            string fileName = "Test.txt";
            string[] lines = x.readFile(location + fileName);
            List<string> exploreFriend = new List<string>();

            Graph testGraph = x.output(lines);

            Console.WriteLine("======================");
            Console.WriteLine("getVertice()");
            foreach (string i in testGraph.getVertice())
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("======================");
            Console.WriteLine("getEdges()");
            foreach (Edges i in testGraph.getEdges())
            {
                i.printEdge();
            }
            Console.WriteLine("======================");
            // Keep the console window open in debug mode.
            Console.WriteLine("exploreDFS()");
            exploreFriend = testGraph.ExploreFriendsDFS("C", "H");

            Console.WriteLine("Panjang : " + exploreFriend.Count);

            for (int i = 0; i < exploreFriend.Count-1; i++)
            {
                Console.WriteLine(exploreFriend[i]+" "+ exploreFriend[i+1]);
            }

            Console.WriteLine("exploreBFS()");
            exploreFriend = testGraph.ExploreFriendsBFS("A", "H");
            if (exploreFriend != null)
            {
                Console.WriteLine("Panjang : " + exploreFriend.Count);

                for (int i = 0; i < exploreFriend.Count - 1; i++)
                {
                    Console.WriteLine(exploreFriend[i] + " " + exploreFriend[i + 1]);
                }
            }
            

            /* foreach (string test in exploreFriend)
            {
                Console.WriteLine(test);
            } */
            Console.WriteLine("======================");

            testGraph.mutualFriends("A", "G");

            Console.WriteLine("======================");
            Console.WriteLine("getAllMutual()");
            testGraph.getAllMutualFriends("A");
            Console.WriteLine("======================");

            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }
    }
}
    