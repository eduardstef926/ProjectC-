using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        static SqlConnection conn = new SqlConnection("Data Source=DESKTOP-VUU0K4S;Database=Tutorial;Integrated Security=True");
        SqlDataAdapter adapter;
        
        public Form1()
        {
            InitializeComponent();
  
        }

        private void Add_Click(object sender, EventArgs e)
        {   
            conn.Open();
            XmlDocument document = new XmlDocument();
            document.Load(@"C:\Users\eddis\source\repos\WindowsFormsApp3\WindowsFormsApp3\A.xml");
            string insertStatement = document["PatientClinic"]["First"]["InsertChildTable"].InnerText;
            var command = new SqlCommand(insertStatement + textBox2.Text + "','" + textBox1.Text + "')",conn);
            command.ExecuteNonQuery();
            MessageBox.Show("Data added");
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"C:\Users\eddis\source\repos\WindowsFormsApp3\WindowsFormsApp3\A.xml");
            string selectParentTable = document["PatientClinic"]["First"]["SelectParentTable"].InnerText;
            adapter = new SqlDataAdapter(selectParentTable, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"C:\Users\eddis\source\repos\WindowsFormsApp3\WindowsFormsApp3\A.xml");
            string selectChildTable = document["PatientClinic"]["First"]["SelectChildTable"].InnerText;
            adapter = new SqlDataAdapter(selectChildTable, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load(@"C:\Users\eddis\source\repos\WindowsFormsApp3\WindowsFormsApp3\A.xml");
            string searchChildTable = document["PatientClinic"]["First"]["SearchChildTable"].InnerText;
            var adapter = new SqlDataAdapter(searchChildTable + textBox1.Text + "'", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource= dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            XmlDocument document = new XmlDocument();
            document.Load(@"C:\Users\eddis\source\repos\WindowsFormsApp3\WindowsFormsApp3\A.xml");
            string deleteChildTable = document["PatientClinic"]["First"]["DeleteChildTable"].InnerText;
            var command = new SqlCommand(deleteChildTable + textBox3.Text + "'", conn);
            command.ExecuteNonQuery();
            MessageBox.Show("Data deleted");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            XmlDocument document = new XmlDocument();
            document.Load(@"C:\Users\eddis\source\repos\WindowsFormsApp3\WindowsFormsApp3\A.xml");
            string updatedChildTable = document["PatientClinic"]["First"]["UpdateChildTable"].InnerText;
            string firstPart = updatedChildTable.Substring(0, 30);
            string secondPart = updatedChildTable.Substring(31, 11);
            string thirdPart = updatedChildTable.Substring(43, 16);
            int start = 0;
            while(start < updatedChildTable.Length)
            {
                if(Char.ToString(updatedChildTable[start]) != "'")
                {
                    start++;
                }
                else
                {
                    break;
                }
            }
            start++;
            string firstString = updatedChildTable.Substring(0,start);
            int copy = start;
            while(copy < updatedChildTable.Length)
            {
                if (Char.ToString(updatedChildTable[copy]) != "'")
                {
                    copy++;
                }
                else
                {
                    break;
                }
            }
            copy -= start;
            string secondString = updatedChildTable.Substring(start+1,copy);
            start += copy;
            int dif = updatedChildTable.Length - start - 2;
            string thirdString = updatedChildTable.Substring(start+2,dif);  
            var command = new SqlCommand(firstString + textBox2.Text + "'," + secondString + textBox1.Text + "'" + thirdString + textBox3.Text + "'", conn);
            command.ExecuteNonQuery();
            MessageBox.Show("Data updated");
            conn.Close();
        }
    }
}
