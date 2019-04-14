using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace McDaniel_PA6
{
    public partial class Form1 : Form
    {

        private string filepath;
        public string line;


        public Form1()
        {
            InitializeComponent();

            filepath = "";

            label1.Text = "no file selected";

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                filepath = openFileDialog1.FileName;
                label1.Text = filepath;
            }
            else
            {

                filepath = "";
                label1.Text = "no file selected";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (filepath == "")
            {

                MessageBox.Show("Please select file");
                return;
            }


            string userInput = textBox1.Text;
            int count = 0;

            using (var sr = new StreamReader(filepath))
            {

                while (sr.EndOfStream != true)
                {

                    line = sr.ReadLine();

                    if (line.StartsWith("datetime"))
                    {
                        continue;
                    }


                    string[] data = line.Split(',');

                    string state = data[1];

                    if (state == userInput)
                    {
                        count++;
                        richTextBox1.Text = string.Format("Counted {0} UFO sightings in {1}", count, userInput);

                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {



            if (filepath == "")
            {

                MessageBox.Show("Please select file");
                return;
            }


            string userInput = textBox2.Text;
          
            List<int> scores = new List<int>();
          

            using (var sr = new StreamReader(filepath))
            {
              
                while (sr.EndOfStream != true)
                {

                    line = sr.ReadLine();

                    if (line.StartsWith("datetime"))
                    {
                        continue;
                    }


                    string[] data = line.Split(',');

                    string shape = data[3];
                    int duration;
                    bool parseOkay = int.TryParse(data[4], out duration);
                    
                    double count = 0;
                    if (shape == userInput)
                    {
                       
                            count++;
                            scores.Add(duration);
                        
                    }

                }

                double scorecnt = 0;
                foreach (double val in scores)
                {
                   
                    if (val != 0)
                    {
                        scorecnt += val;
                    }
                    

                }



                double avg = Math.Round((double)scorecnt / scores.Count,2);
                double timecnvrt = Math.Round(avg / 3600,2); // converts to hours 
                
                richTextBox2.Text = string.Format(" The average sighting duration for a {0}-shaped UFO is {1} hours ({2} seconds)",userInput, timecnvrt, avg);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (filepath == "")
            {

                MessageBox.Show("Please select file");
                return;
            }
            
            int count = 0;
            string usermonth = textBox3.Text;
            string useryear = textBox4.Text;
            using (var sr = new StreamReader(filepath))
            {
                if (usermonth == "" || useryear == "")
                {
                    MessageBox.Show("must enter data into both fields");
                }

                while (sr.EndOfStream != true)
                {

                    line = sr.ReadLine();

                    if (line.StartsWith("datetime"))
                    {
                        continue;
                    }

                    string[] data = line.Split(',', '/',' ');

                   

                    string datayear = data[2];
                    string datamonth = data[0];

                    string country = data[5];
                    string shape = data[6];
                    string state = data[4];
                    string datetime = string.Format("{0}/{1}/{2} {3}",data[0],data[1],data[2],data[3]);
                 
                      if (usermonth == datamonth && useryear == datayear)
                    {
                        count++;
                           
                        richTextBox3.AppendText(string.Format("{0} {1} {2} {3}, {4}\n ", count, datetime, state, country, shape));

                       }
                        

                    {

                    }
             

                }


            }
        }
    }
}

