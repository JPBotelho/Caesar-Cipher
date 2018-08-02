using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cyphers
{
	public partial class Form1 : Form
	{
		private string text;
		public Form1()
		{
			InitializeComponent();
			comboBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 0;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			//text = textBox1.Text;
			//textBox2.Text = text;

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			bool valid;
			string encrypted = new string(CaesarCypher.Encrypt(textBox1.Text.ToLower(), comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex == 0));
			textBox2.Text = encrypted;

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}
	}

	public static class CaesarCypher
	{
		public static string ValidateInput(string text, out bool valid)
		{
			text = text.Replace(" ", string.Empty);
			text = text.ToLower();
			List<char> chars = new List<char>(text.ToCharArray());
			foreach(char character in chars)
			{
				if (!char.IsLetter(character))
				{
					valid = false;
					return null;
				}
			}
			valid = true;
			return text;
		}

		public static char[] Encrypt(string data, int key, bool forward)
		{
			char[] chars = data.ToCharArray();
			for(int i = 0; i < chars.Length; i++)
			{
				if (char.IsLetter(chars[i]))
				{
					if (forward)
						chars[i] = (char)(chars[i] + key);
					else
						chars[i] = (char)(chars[i] - key);

					if (chars[i] > 122) chars[i] = (char)(chars[i] - 26);
					if (chars[i] < 97) chars[i] = (char)(chars[i] + 26);
				}
			}
			return chars;
		}
	}
}
