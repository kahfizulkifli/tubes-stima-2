using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes2Stime
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            // Output Label
            StaticMethod(this.friendsOutput);
            friendsOutput.Text = "No friends to recommend";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("Work");
            Object userA = firstUser.SelectedItem;
            Object userB = secondUser.SelectedItem;
            string stringUserB = userB.ToString();
            string stringUserA = userA.ToString();
            //MessageBox.Show(stringUserA);
            //MessageBox.Show(namaFile);

            if (fileBrowsed == true)
            {
                string[] lines = this.readFile(namaFile);
                Graph testGraph = this.output(lines);

                // recommended friends
                testGraph.getAllMutualFriends(stringUserA);
                friendsOutput.Text = testGraph.outputOfMutual;

                // explore friends
                if (radioButton1.Checked == true)
                {
                    // MessageBox.Show("DFS");
                    List<string> exploreFriend = new List<string>();
                    exploreFriend = testGraph.ExploreFriendsDFS(stringUserA, stringUserB);
                    // Console.WriteLine("Panjang : " + exploreFriend.Count);


                    Graph testGraph2 = this.output2(lines);
                    Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

                    foreach (Edges i in testGraph2.getEdges())
                    {
                        bool found = false;
                        for (int j = 0; j < exploreFriend.Count - 1; j++)
                        {
                            if((exploreFriend[j] == i.getNode1() && exploreFriend[j+1] == i.getNode2() || exploreFriend[j] == i.getNode2() && exploreFriend[j + 1] == i.getNode1()) && found == false)
                            {
                                graph.AddEdge(exploreFriend[j], exploreFriend[j + 1]).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                found = true;
                            }
                            // Console.WriteLine(exploreFriend[i] + " " + exploreFriend[i + 1]);
                        }
                        if (found == false)
                        {
                            graph.AddEdge(i.getNode1(), i.getNode2()).Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                        }
                        
                    }

                    
                    gViewer1.Graph = graph;
                }
                else if (radioButton2.Checked == true)
                {
                    // MessageBox.Show("BFS");
                    List<string> exploreFriend = new List<string>();
                    exploreFriend = testGraph.ExploreFriendsBFS(stringUserA, stringUserB);
                    Graph testGraph2 = this.output2(lines);
                    Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

                    if (exploreFriend != null)
                    {
                        foreach (Edges i in testGraph2.getEdges())
                        {
                            bool found = false;
                            for (int j = 0; j < exploreFriend.Count - 1; j++)
                            {
                                if ((exploreFriend[j] == i.getNode1() && exploreFriend[j + 1] == i.getNode2() || exploreFriend[j] == i.getNode2() && exploreFriend[j + 1] == i.getNode1()) && found == false)
                                {
                                    graph.AddEdge(exploreFriend[j], exploreFriend[j + 1]).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                                    found = true;
                                }
                                // Console.WriteLine(exploreFriend[i] + " " + exploreFriend[i + 1]);
                            }
                            if (found == false)
                            {
                                graph.AddEdge(i.getNode1(), i.getNode2()).Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                            }

                        }
                    }

                    gViewer1.Graph = graph;
                }

            }
            else
            {
                MessageBox.Show("Masukkan file terlebih dahulu");
            }

            


        }

        private void secondUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void friendsOutput_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gViewer1_Load(object sender, EventArgs e)
        {
            // Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            // create the graph content 
            /* graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond; */
            //bind the graph to the viewer 
            // gViewer1.Graph = graph;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // browse button
            OpenFileDialog filePath = new OpenFileDialog();
            if (filePath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // MessageBox.Show(filePath.FileName);
            }

            string[] lines = this.readFile(filePath.FileName);
            Graph testGraph = this.output(lines);
            fileBrowsed = true;
            namaFile = filePath.FileName.ToString();

            foreach (string i in testGraph.getVertice())
            {
                // Add item dropdown
                firstUser.Items.Add(i);
                secondUser.Items.Add(i);
            }

            Graph testGraph2 = this.output2(lines);

            // gambar graph
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            foreach (Edges i in testGraph2.getEdges())
            {
                graph.AddEdge(i.getNode1(), i.getNode2()).Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
            }
            gViewer1.Graph = graph;
        }

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

        public Graph output2(string[] lines)
        {
            //Inisiasi Graph
            Graph testGraph = new Graph();

            //Isi testGraph
            testGraph.isiEdgesver2(lines);
            testGraph.isiVertice(lines);
            List<string> temp = testGraph.getVertice();
            temp.Sort();
            testGraph.setVertice(temp);
            testGraph.sortEdges();
            return testGraph;
        }
        static private void StaticMethod(Label TheLabel)
        {
            TheLabel.Text = "This is from a static method";
        }

        private bool fileBrowsed = false;
        private string namaFile;

        



    }
}
