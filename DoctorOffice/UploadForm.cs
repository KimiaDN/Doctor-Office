using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FoxLearn.License;
using BLL;
using System.Runtime.InteropServices;

namespace DoctorOffice
{
    public partial class UploadForm : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
         (
             int nLeftRect,     // x-coordinate of upper-left corner
             int nTopRect,      // y-coordinate of upper-left corner
             int nRightRect,    // x-coordinate of lower-right corner
             int nBottomRect,   // y-coordinate of lower-right corner
             int nWidthEllipse, // width of ellipse
             int nHeightEllipse // height of ellipse
         );
        public UploadForm()
        {
            InitializeComponent();
            label1.Visible = true;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
        }

        Timer t1 = new Timer();
        Timer t2 = new Timer();
        Timer t3 = new Timer();
        bool _IsRegitered = false;
        User_BLL bll = new User_BLL();
        RegisterAdmin_UC reg = new RegisterAdmin_UC();
        Login_UC login = new Login_UC();
        private void UploadForm_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            pictureBox1.Visible = false;
            label1.Visible = true;
            t1.Enabled = true;
            t1.Interval = 15;
            t1.Tick += Timer1_Tick;
            t1.Start();
            this.Controls.Add(reg);
            this.Controls.Add(login);
            this.Controls["RegisterAdmin_UC"].Location = new Point(536,1000);
            this.Controls["Login_UC"].Location = new Point(536, 1000);
        }

        public void LoginUC_Load()
        {
            t3.Enabled = true;
            t3.Interval = 15;
            t3.Tick += Timer3_Tick;
            t3.Start();
        }

        private void Timer1_Tick(Object sender, EventArgs e)
        {
            if (progressBarX1.Value >= 100)
            {
                t1.Stop();
                progressBarX1.Visible = false;
                label3.Visible = true;
                label1.Visible = false;
                pictureBox1.Visible = true;

                t2.Enabled = true;
                t2.Interval = 1;
                t2.Tick += Timer2_Tick;
                t2.Start();
            }
            else if (progressBarX1.Value == 45)
            {
                _IsRegitered = bll.IsRegistered();
                progressBarX1.Value++;
            }
            else
            {
                progressBarX1.Value++;
            }
        }
        int y1 = 1000;
        int y2 = 1000;
        private void Timer2_Tick(Object sender, EventArgs e)
        {
            if (y1 > 100)
            {
                y1 = y1 - 30;
               if (_IsRegitered)
                {
                    this.Controls["Login_UC"].Location = new Point(536, y1);
                }
                else
                {
                    
                    this.Controls["RegisterAdmin_UC"].Location = new Point(536, y1);
                }
                //this.Controls["RegisterAdmin_UC"].Location = new Point(536, y1);
            }
            else
            {
                t2.Stop();
            }
        }

        private void Timer3_Tick(Object sender, EventArgs e)
        {
            if (this.Controls["Login_UC"].Location.Y > 100)
            {
                y2 = y2 - 30;
                this.Controls["Login_UC"].Location = new Point(536, y2);
            }
            else
            {
                t3.Stop();
            }
        }

    }
}
