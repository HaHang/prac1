using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace prac1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Reset
        private void btnReset_Click(object sender, EventArgs e)
        {
            tbName.ResetText();
            tbTime.ResetText();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            rtb_nd.Clear();
            listBox1.Items.Add("КГ");
            listBox1.Items.Add("База данных");
            listBox1.Items.Add("Сети");
            listBox1.Items.Add("ПЛОС");
            listBox1.Items.Add("ТПР");
            listBox1.Items.Add("ОСПО");
            listBox1.Items.Add("Методы оптимизация");
            listBox1.Items.Add("Защита Инф");
            listBox1.Items.Add("Проектирование и разработка");
     
        }
        // 
        private void Form1_Load(object sender, EventArgs e)
        {
            tbTime.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }
        // добавить всех список
        private void btn_addall_Click(object sender, EventArgs e)
        {
            int i;
            int n = listBox1.Items.Count;
            for (i = 0; i < n; i++ )
            {
                listBox1.SelectedIndex = i;
                listBox2.Items.Add(listBox1.SelectedItem.ToString());
            }
            while (n > 0)
            {
                listBox1.SelectedIndex = n - 1;
                listBox1.Items.Remove(listBox1.SelectedItem.ToString());
                n = listBox1.Items.Count;
            }
        }
        // добавить одельный предмет
        private void btn_add_Click(object sender, EventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem.ToString());
            listBox1.Items.Remove(listBox1.SelectedItem.ToString());
        }
        // 

        private void btn_delall_Click(object sender, EventArgs e)
        {
            int i;
            int n = listBox2.Items.Count;
            for (i = 0; i < n; i++)
            {
                listBox2.SelectedIndex = i;
                listBox1.Items.Add(listBox2.SelectedItem.ToString());
            }
            while (n > 0)
            {
                listBox2.SelectedIndex = n - 1;
                listBox2.Items.Remove(listBox2.SelectedItem.ToString());
                n = listBox2.Items.Count;
            }
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(listBox2.SelectedItem.ToString());
            listBox2.Items.Remove(listBox2.SelectedItem.ToString());
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            int n = listBox2.Items.Count;
            rtb_nd.Text ="студент: " + tbName.Text + "  \r\n группа " + cb_group.Text + "\r\n дата регистрации" + tbTime.Text + "\r\n выбраны предметы";
            for (int i = 0; i < n; i++ )
            {
                listBox2.SelectedIndex = i;
                rtb_nd.Text += listBox2.Text + " ; ";
            }

        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Rich File(*.rtf)|*.rtf|All File(*.*)|*.*";
            openFileDialog1.InitialDirectory = "D:\\";
            openFileDialog1.Title = "Open File";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtb_nd.LoadFile(openFileDialog1.FileName);
            }
            //else
            //    DialogResult.
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Save File";
            saveFileDialog1.DefaultExt = ".rtf";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Filter = "Rich File(*.rtf)|*.rtf|All File(*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                rtb_nd.SaveFile(saveFileDialog1.FileName);
            }
        }




    }
}
