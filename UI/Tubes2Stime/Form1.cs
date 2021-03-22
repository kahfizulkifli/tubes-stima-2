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
            // Add item dropdown
            secondUser.Items.Add("Tokyo");
            firstUser.Items.Add("Eek");

            // Output Label
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
            MessageBox.Show("Work");
            Object userA = firstUser.SelectedItem;
            Object userB = secondUser.SelectedItem;
            string user = userA.ToString();
            MessageBox.Show(user);

        }

        private void secondUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void friendsOutput_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gViewer1_Load(object sender, EventArgs e)
        {
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            //bind the graph to the viewer 
            gViewer1.Graph = graph;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog filePath = new OpenFileDialog();
            if (filePath.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                MessageBox.Show(filePath.FileName);
            }
        }
    }
}
