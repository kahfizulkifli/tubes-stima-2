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
        static void Main(string[] args)
        {
            MainProgram x = new MainProgram();

            //ReadFile From test.txt
            string location = "D:\\Semester 4\\Stigma\\tubes-stima-2\\src\\Test\\Test\\";
            string fileName = "Test.txt";
            string[] lines = x.readFile(location + fileName);

            //Inisiasi Graph
            Edges[] newEdges = new Edges[lines.Length];
            List<string> newString = new List<string>();
            Graph testGraph = new Graph(lines.Length, newString, newEdges);

            //Isi testGraph
            testGraph.isiEdges(lines);
            testGraph.isiVertice(lines);
            testGraph.sortEdges();
            

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
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }
    }
}
    