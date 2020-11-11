using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conversions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i;
        string[,] conversionTable = {
            {"Miles to kilometers", "Miles", "Kilometers", "1.6093"},
            {"Kilometers to miles", "Kilometers", "Miles", "0.6214"},
            {"Feet to meters", "Feet", "Meters", "0.3048"},
            {"Meters to feet", "Meters", "Feet", "3.2808"},
            {"Inches to centimeters", "Inches", "Centimeters", "2.54"},
            {"Centimeters to inches", "Centimeters", "Inches", "0.3937"}
        };

        private void Form1_Load(object sender, EventArgs e)
        {
            //adds conversion options into dropdown
            cboConversions.Items.Add(conversionTable[0, 0]);
            cboConversions.Items.Add(conversionTable[1, 0]);
            cboConversions.Items.Add(conversionTable[2, 0]);
            cboConversions.Items.Add(conversionTable[3, 0]);
            cboConversions.Items.Add(conversionTable[4, 0]);
            cboConversions.Items.Add(conversionTable[5, 0]);
            cboConversions.SelectedIndex = 0; //displays the first option by default
        }

        private void cboConversions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLength.Clear(); //clears the entry box
            lblCalculatedLength.Text = "";
            i = cboConversions.SelectedIndex;
            lblFromLength.Text = conversionTable[i, 1]; //changes the from label
            lblToLength.Text = conversionTable[i, 2]; //changes the to label
            txtLength.Focus(); //returns focus to entry box
        }
       
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            bool p = IsDecimal(txtLength, "Length"); //calls for decimal check
            if (p == true)
            {
                double a = Convert.ToDouble(txtLength.Text);
                double unit = Convert.ToDouble(conversionTable[i, 3]);
                double ans = a * unit;
                lblCalculatedLength.Text = ans.ToString(); //loads conversion into label
            }
        }

        public bool IsDecimal(TextBox textBox, string name)
        {
            try 
            {
                Convert.ToDecimal(textBox.Text); //validates entry
                return true; 
            }
            catch (FormatException) //throws format exception and error message
            { 
                MessageBox.Show(name + " must be a decimal number.", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
            {
                this.Close(); //closes application
            }
            
        }
    }