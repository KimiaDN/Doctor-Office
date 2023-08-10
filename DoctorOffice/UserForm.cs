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

namespace DoctorOffice
{
    
    public partial class UserForm : Form
    {

        
        
        public UserForm()
        {
            InitializeComponent();
        }

        public User user;
        public UserGroup ug = new UserGroup();
        public bool isEdit = false;
        public void Load_UserGroupForm1()
        {
            UserGroup1_UC usergroup1 = new UserGroup1_UC();
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            usergroup1.ug = ug;
            panel2.Controls.Add(usergroup1);
        }
        public void Load_UserGroupForm2()
        {
            UserGroup2_UC usergroup2 = new UserGroup2_UC();
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            usergroup2.ug = ug;

            if (isEdit)
            {
                usergroup2.label13.Text = "ویرایش اطلاعات";
            }
            
            panel2.Controls.Add(usergroup2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DoctorsForm_UC doctor_form = new DoctorsForm_UC();
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            panel2.Controls.Add(doctor_form);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PatientForm_UC patient_form = new PatientForm_UC();
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            panel2.Controls.Add(patient_form);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SecretaryForm_UC secretary_form = new SecretaryForm_UC();
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            panel2.Controls.Add(secretary_form);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserGroup1_UC usergroup1 = new UserGroup1_UC();
            if (panel2.Controls.Count > 0)
            {
                panel2.Controls[0].Dispose();
            }
            panel2.Controls.Add(usergroup1);
        }

        
        private void UserForm_Load(object sender, EventArgs e)
        {
            label2.Text = user.Name;
        }
    }
}
