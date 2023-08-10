using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace DoctorOffice
{
    public partial class FinantialForm : Form
    {
        public FinantialForm()
        {
            InitializeComponent();
        }

        public User user;
        User Employes_User = new User();
        User_BLL user_bll = new User_BLL();
        Deposit_BLL deposit_bll = new Deposit_BLL();
        MSG msg = new MSG();

        private void Clean()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void Fill_DateGridView()
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = deposit_bll.Read();
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
        }

        private void FinantialForm_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection names = new AutoCompleteStringCollection();
            foreach (var item in user_bll.Read_UsersName())
            {
                names.Add(item);
            }
            textBox1.AutoCompleteCustomSource = names;
            Fill_DateGridView();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Employes_User = user_bll.find(textBox1.Text);
            textBox2.Text = Employes_User.Cart;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Deposit d = new Deposit();
            d.Name = Employes_User.Name;
            d.Cart = Employes_User.Cart;
            d.Date = DateTime.Now.Date;
            d.Amount = Convert.ToDouble(textBox3.Text);
            string str = deposit_bll.create(d, Employes_User);
            msg.Show(str, false);

            Fill_DateGridView();
            Clean();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = deposit_bll.Search(textBox6.Text);
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
            dataGridViewX1.Columns["Name"].Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
