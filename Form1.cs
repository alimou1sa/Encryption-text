using Guna.UI2.WinForms;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_9_Encryption_Text
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string EncryptionText(string text, int key)
        {
            char[] temp = new char[text.Length]; // مصفوفة لتخزين الأحرف المشفرة  

            for (int i = 0; i < text.Length; i++)
            {
                // تشفير كل حرف وإضافته إلى المصفوفة  
                temp[i] = Convert.ToChar((int)text[i] + key);
            }

   
            // تحويل المصفوفة إلى سلسلة نصية وإرجاعها  
            return new string(temp);
        }

        string DecryptionText(string text, int key)
        {
            char[] temp = new char[text.Length]; // مصفوفة لتخزين الأحرف المشفرة  

            for (int i = 0; i < text.Length; i++)
            {
                // تشفير كل حرف وإضافته إلى المصفوفة  
                temp[i] = Convert.ToChar((int)text[i] - key);
            }


            // تحويل المصفوفة إلى سلسلة نصية وإرجاعها  
            return new string(temp);
        }

        string ReadTextfromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Open a Text File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the file path  
                string filePath = openFileDialog.FileName;

                // Read the content of the file  
                string content = File.ReadAllText(filePath);

            
              return content;
          
             }

            return null;
        }

        void Savetextinfile(string texttosave)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Title = "Save a Text File",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                FileName = "default.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the file path  
                string filePath = saveFileDialog.FileName;
                string d = Path.Combine(filePath, "Encryptjjjion.txt");
                // Write some text to the file  
                File.WriteAllText(filePath, texttosave);
                MessageBox.Show("File saved successfully!");
            }
        }
   
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ErrorProvider noty = new ErrorProvider();

            if (string.IsNullOrEmpty(guna2TextBox1.Text))
            {

                noty.SetError(guna2TextBox1, "Text Should have a value!");

                guna2TextBox1.Focus();

            }
            else
            {
                guna2TextBox3.Text = EncryptionText(guna2TextBox1.Text, 3);
            }

        }

         private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TextBox1.Text=ReadTextfromFile();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox2.SelectedIndex = 0;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ErrorProvider noty = new ErrorProvider();

            if (string.IsNullOrEmpty(guna2TextBox2.Text))
            {

                noty.SetError(guna2TextBox2, "Text Should have a value!");

                guna2TextBox2.Focus();

            }
            else
            {
                guna2TextBox4.Text = DecryptionText(guna2TextBox2.Text, 3);

            }

        }

         private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2TextBox2.Text=ReadTextfromFile();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(guna2ComboBox1.SelectedIndex==1)
            {
                guna2TextBox2.TextAlign = HorizontalAlignment.Right;
                guna2TextBox4.TextAlign = HorizontalAlignment.Right;

            }
            if (guna2ComboBox1.SelectedIndex == 0)
            {
                guna2TextBox2.TextAlign = HorizontalAlignment.Left;
                guna2TextBox4.TextAlign = HorizontalAlignment.Left;
            }

        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox2.SelectedIndex == 1)
            {
                guna2TextBox1.TextAlign = HorizontalAlignment.Right;
                guna2TextBox3.TextAlign = HorizontalAlignment.Right;

            }
            if (guna2ComboBox2.SelectedIndex == 0)
            {
                guna2TextBox1.TextAlign = HorizontalAlignment.Left;
                guna2TextBox3.TextAlign = HorizontalAlignment.Left;
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
                 Savetextinfile(guna2TextBox3.Text);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
                Savetextinfile(guna2Button4.Text);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty( guna2TextBox3.Text))
            {
                Clipboard.SetText(guna2TextBox3.Text);

                MessageBox.Show("The text has been copied.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(guna2TextBox4.Text))
            {
                Clipboard.SetText(guna2TextBox4.Text);

                MessageBox.Show("The text has been copied.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
