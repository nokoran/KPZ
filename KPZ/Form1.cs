using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPZ
{
    public partial class Form1 : Form
    {
        List<variable> vari = new List<variable>();
        List<command_num> comm = new List<command_num>();
        bool y = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void reset()
        {
            y = true;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox4.Items.Clear();
            string[] alf = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            foreach (string i in alf)
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
                comboBox4.Items.Add(i);
            }
            listBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox5.Items.Clear();
            comboBox10.Items.Clear();
            label13.Visible = false;
            textBox3.Visible = false;
            button9.Visible = false;
            vari.Clear();
            comm.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            reset();
        }

        

        private void input_refresh()
        {
            string[] alf = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            for (int i = 0; i < comboBox3.Items.Count; i++)
            {
                for (int k = 0; k < alf.Length; k++)
                {
                    string value = comboBox3.GetItemText(comboBox3.Items[i]);
                    string value2 = alf[k];
                    if (value != value2)
                    {
                        comboBox2.Items.Add(value2);
                        comboBox4.Items.Add(value2);
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int change = 0;
            string i = comboBox1.Text;
            int k = Convert.ToInt32(textBox2.Text);
            foreach (var variabl in vari)
            {
                if (comboBox1.Text == variabl.name)
                {
                    variabl.digit = k;
                    listBox2.Items.Add("|" + i + " = " + k + "|");
                    change = 1;
                    break;
                }
            }
            if(change == 0)
            {
                variable one = new variable(i, k);
                comboBox3.Items.Add(i);
                comboBox5.Items.Add(i);
                comboBox10.Items.Add(i);
                listBox2.Items.Add("|" + i + " = " + k + "|");
                vari.Add(one);
                input_refresh();
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add("print " + comboBox5.Text);
            command_num one = new command_num(1, comboBox5.Text);
            comm.Add(one);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add("*******************************************");
            listBox2.Items.Add("Вивід:");
            int ifstop = 0;
            foreach(var com in comm)
            {
                if(ifstop == 1 && com.command != 3)
                {
                    continue;
                }
                else { ifstop = 0; }
                foreach(var variabl in vari)
                {
                    switch(com.command)
                    {
                        case 1:
                            if(variabl.name == com.variable)
                            {
                                listBox2.Items.Add(variabl.digit);
                            }
                            break;
                        case 2:
                            if (variabl.name == com.variable)
                            {
                                switch (com.sign)
                                {
                                    case "<":
                                        if (variabl.digit < com.compare)
                                        {
                                            break;
                                        }
                                        else { ifstop = 1; break; }
                                        
                                    case ">":
                                        if (variabl.digit > com.compare)
                                        {
                                            break;
                                        }
                                        else { ifstop = 1; break; }
                                        
                                    case "==":
                                        if (variabl.digit == com.compare)
                                        {
                                            break;
                                        }
                                        else { ifstop = 1; break; }
                                        
                                }
                            }                            
                            break;                            
                    }
                }
                
            }
            listBox2.Items.Add("*******************************************");

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            int k = Convert.ToInt32(textBox1.Text);
            listBox2.Items.Add("<" + "if " + comboBox10.Text + " " + comboBox9.Text + " " + k + ">");
            command_num one = new command_num(2, comboBox10.Text, k, comboBox9.Text);
            comm.Add(one);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            listBox2.Items.Add("fi");
            command_num one = new command_num(3, null, 0, null);
            comm.Add(one);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add("input " + comboBox4.Text);
            command_num one = new command_num(4, comboBox4.Text, 0, null);
            comm.Add(one);
            label13.Text = "Введіть " + comboBox4.Text;
            label13.Visible = true;
            textBox3.Visible = true;
            button9.Visible = true;
            input_refresh();
            comboBox3.Items.Add(comboBox4.Text);
            comboBox5.Items.Add(comboBox4.Text);
            comboBox10.Items.Add(comboBox4.Text);
            input_refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string i = comboBox4.Text;
            int k = Convert.ToInt32(textBox3.Text);
            variable one = new variable(i, k);
            vari.Add(one);
            label13.Visible = false;
            textBox3.Visible = false;
            button9.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(comboBox2.Text + " = " + comboBox3.Text);
            foreach (var variabl in vari)
            {
                if(comboBox3.Text == variabl.name)
                {
                    variable one = new variable(comboBox2.Text, variabl.digit);
                    vari.Add(one);
                    break;
                }
            }
            comboBox3.Items.Add(comboBox2.Text);
            comboBox5.Items.Add(comboBox2.Text);
            comboBox10.Items.Add(comboBox2.Text);
            input_refresh();
        }
    }
}