using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalsAdvisor
{
	public partial class TestForm : Form
	{
		public TestForm()
		{
			InitializeComponent();
		}

		private void TestForm_Load(object sender, EventArgs e)
		{

		}

		private void button_Create_Profile_Click(object sender, EventArgs e)
		{

			Profile person = new Profile(TextBox_Creation_FirstName.Text, textBox_Creation_LastName.Text,int.Parse(textBox_Creation_AGE.Text), int.Parse(textBox_Creation_HeightFoot.Text ), int.Parse(textBox_Creation_HeightFeets.Text ), radioButton_Gender_Male.Checked, double.Parse(textBox_Creation_Weight.Text), 1.2);

			
			person.Update();
			textBox1.Text += person.ToString();
			textBox1.Text += System.Environment.NewLine; textBox1.Text += System.Environment.NewLine;

			for (int i = 0; i <=60; i++)
			{
				person.m_Current_Calories_Consumed = 600;
				person.Update();
				textBox1.Text += person.ToString();
				textBox1.Text += System.Environment.NewLine; textBox1.Text += System.Environment.NewLine;
			}



		}


	}
}
