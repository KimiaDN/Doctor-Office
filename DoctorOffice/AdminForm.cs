using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace DoctorOffice
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        public User user;

        private void AdminForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = user.Name;
            textBox2.Text = user.Phone;
            textBox3.Text = user.UserName;
            textBox7.Text = user.Cart;
            numericUpDown1.Value = Convert.ToDecimal(user.Age);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Admin u = new Admin();
            u.Name = textBox1.Text;
            u.Phone = textBox2.Text;
            u.UserName = textBox3.Text;
            if (textBox4.Text == textBox5.Text)
            {
                u.Password = textBox4.Text;
            }
            u.Cart = textBox7.Text;
        }
    }
}
