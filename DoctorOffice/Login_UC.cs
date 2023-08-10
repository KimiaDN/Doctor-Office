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
using BE;
using System.Windows;

namespace DoctorOffice
{
    public partial class Login_UC : UserControl
    {
        public Login_UC()
        {
            InitializeComponent();
        }

        User_BLL bll = new User_BLL();
        MSG msg = new MSG();
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            User u = bll.Login(textBoxX1.Text, textBoxX2.Text);
            if (u != null)
            {
                msg.Show("ورود با موفقیت انجام شد", false);
                this.Hide();
                MainWindow w = (MainWindow)System.Windows.Application.Current.Windows.OfType<Window>().FirstOrDefault();
                w.u = u;
                w.Refresh_Page();
                ((UploadForm)System.Windows.Forms.Application.OpenForms["UploadForm"]).Close();
            }
            else
            {
                msg.Show("نام کاربری یا رمز عبور صحیح نمی باشد", false);
            }
        }
    }
}
