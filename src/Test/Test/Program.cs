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
            string location = "D:\\Semester 4\\Stigma\\Tubes-2-Stima\\Test\\Test\\";
            string fileName = "Test.txt";
            string[] lines = x.readFile(location + fileName);

            Edges[] newEdges = new Edges[lines.Length];
            List<string> newString = new List<string>();
            Graph testGraph = new Graph(lines.Length, newString, newEdges);

            Edges[] testo = testGraph.getEdges();

            testGraph.isiEdges(lines);

            testo[0].printEdge();

            Console.WriteLine("Success");

            Console.WriteLine(testo[0].getNode2());

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();

        }
    }
}
    