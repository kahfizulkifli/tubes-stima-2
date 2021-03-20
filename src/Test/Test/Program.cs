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
            string location = "D:\\Semester 4\\Stigma\\tubes-stima-2\\src\\Test\\Test\\";
            string fileName = "Test.txt";
            string[] lines = x.readFile(location + fileName);
            List<string> exploreFriend = new List<string>();

            Graph testGraph = x.output(lines);

            Console.WriteLine("======================");
            foreach (string i in testGraph.getVertice())
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("======================");
            foreach(Edges i in testGraph.getEdges())
            {
                i.printEdge();
            }
            Console.WriteLine("======================");
            // Keep the console window open in debug mode.

            //exploreFriend = testGraph.ExploreFriendsDFS("C", "H");

            //Console.WriteLine("Panjang : " + exploreFriend.Count);

            //foreach (string test in exploreFriend)
            //{
            //    Console.WriteLine(test);
            //}
            Console.WriteLine("======================");

            testGraph.mutualFriends("A", "G");

            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }
    }
}
    