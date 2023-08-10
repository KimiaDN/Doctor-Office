using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace DoctorOffice
{
    internal class MSG
    {
        public DialogResult Show( string info,  bool icon)
        {
            // icon : true -> Question, false -> Alert
            MsgBoxForm form = new MsgBoxForm();
            form.label2.Text = info;
            if (icon)
            {
                form.pictureBox2.Visible = false;
            }
            else
            {
                form.button1.Visible = false;
                form.button2.Visible = false;
                form.label3.Visible = false;
                form.label1.Visible = false;
                form.pictureBox1.Visible = false;
                if (info.Contains("موفقیت"))
                {
                    form.pictureBox2.Image = Properties.Resources.yes;
                }
                else
                {
                    form.pictureBox2.Image= Properties.Resources.no;    
                }
            }
            form.ShowDialog();
            return form.DialogResult;
        }
    }
}
