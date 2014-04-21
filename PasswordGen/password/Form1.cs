using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace password
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            try
            {
                genKey(Convert.ToInt32(textBox2.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a number into the password length");
            }
        }

        public void genKey(int digits)
        {
            char[] lLetters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 
                                 'u', 'v', 'w', 'x', 'y', 'z'};
            
            char[] cLetters = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 
                                 'U', 'V', 'W', 'X', 'Y', 'Z'};

            char[] symbols = {'%', '@', '!', ';', '^', '[', ']', '{', '}', ',', ':', '+', '-', '/', '<', '>', '?', '*', '=', '_', 
                                 '#', '$', '&', '~', '`'};


            for (int i = 0; i < digits; i++)
            {
                if (checkBox1.Checked && !checkBox2.Checked && !checkBox3.Checked)
                {
                    if (rand.Next(0, 9) % 2 == 0)
                        textBox1.Text += rand.Next(0, 9).ToString();
                    else
                        textBox1.Text += lLetters[rand.Next(lLetters.Length)];
                }

                else if (checkBox1.Checked && checkBox2.Checked && !checkBox3.Checked)
                {
                    if (rand.Next(0, 9) % 2 == 0)
                        textBox1.Text += rand.Next(0, 9).ToString();
                    else
                        textBox1.Text += cLetters[rand.Next(cLetters.Length)];
                }

                else if (checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
                {
                    if (rand.Next(0, 9) % 2 == 0)
                        textBox1.Text += rand.Next(0, 9).ToString();
                    else if (rand.Next(0, 9) % 3 == 0)
                        textBox1.Text += cLetters[rand.Next(cLetters.Length)];
                    else
                        textBox1.Text += symbols[rand.Next(symbols.Length)];
                }

                else if (checkBox1.Checked && !checkBox2.Checked && checkBox3.Checked)
                {
                    if (rand.Next(0, 9) % 2 == 0)
                        textBox1.Text += rand.Next(0, 9).ToString();
                    else if (rand.Next(0, 9) % 3 == 0)
                        textBox1.Text += lLetters[rand.Next(lLetters.Length)];
                    else
                        textBox1.Text += symbols[rand.Next(symbols.Length)];                    
                }

                else if (!checkBox1.Checked && checkBox2.Checked && checkBox3.Checked)
                {
                    if (rand.Next(0, 9) % 2 == 0)
                        textBox1.Text += cLetters[rand.Next(cLetters.Length)];
                    else
                        textBox1.Text += symbols[rand.Next(symbols.Length)];
                }

                else if (!checkBox1.Checked && !checkBox2.Checked && checkBox3.Checked)
                {
                     textBox1.Text += symbols[rand.Next(symbols.Length)];
                }

                else if (!checkBox1.Checked && checkBox2.Checked && !checkBox3.Checked)
                {
                    textBox1.Text += cLetters[rand.Next(cLetters.Length)];
                }

                else
                    textBox1.Text += lLetters[rand.Next(lLetters.Length)];

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by FJam\nhttp://eTechForum.com");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //USED FOR HWID PROTECTION. 
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == "")
                {
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            System.Net.WebClient Wc = new System.Net.WebClient();
            string hwid = Wc.DownloadString("http://troll-meme.com/Hwid.txt");
            if (hwid.Contains(cpuInfo))
            {
            }
            else
            {
                MessageBox.Show("Your HWID Doesn't exist in our database");
                Environment.Exit(-1);
            }
            Wc.Dispose();
        }
    }
}
