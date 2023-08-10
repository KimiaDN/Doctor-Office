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
    public partial class UserGroup1_UC : UserControl
    {
        public UserGroup1_UC()
        {
            InitializeComponent();
        }

        UserGroup_BLL bll = new UserGroup_BLL();
        public UserGroup ug = new UserGroup();
        MSG msg = new MSG();

        private UserAccessRole Fill_UserGroup(string section, bool CanEnter, bool CanCreate, bool CanUpdate, bool CanDelete, int code)
        {
            UserAccessRole uac = new UserAccessRole();
            uac.Section = section;  
            uac.Code = code;
            uac.CanEnter = CanEnter;
            uac.CanCreate = CanCreate;
            uac.CanUpdate = CanUpdate;
            uac.CanDelete = CanDelete;
            return uac;
        }

        private void Refresh_UserGroup()
        {
            if (ug.Title != "")
            {
                foreach (UserAccessRole item in ug.UserAccessRoles.ToList())
                {
                    if (item.Code == 1)
                    {
                        ug.UserAccessRoles.Remove(item);
                    }
                    if (item.Code == 2)
                    {
                        ug.UserAccessRoles.Remove(item);
                    }
                    if (item.Code == 3)
                    {
                        ug.UserAccessRoles.Remove(item);
                    }
                    if (item.Code == 4)
                    {
                        ug.UserAccessRoles.Remove(item);
                    }
                    if (item.Code == 5)
                    {
                        ug.UserAccessRoles.Remove(item);
                    }
                    if (item.Code == 6)
                    {
                        ug.UserAccessRoles.Remove(item);
                    }
                    if (item.Code == 7)
                    {
                        ug.UserAccessRoles.Remove(item);
                    }
                    if (item.Code == 8)
                    {
                        ug.UserAccessRoles.Remove(item);
                    }
                }
            }
            
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Refresh_UserGroup();
            ug.Title = textBox1.Text;
            ug.UserAccessRoles.Add(Fill_UserGroup(label3.Text, checkBox5.Checked, checkBox15.Checked, checkBox25.Checked, checkBox35.Checked, 1));
            ug.UserAccessRoles.Add(Fill_UserGroup(label4.Text, checkBox6.Checked, checkBox16.Checked, checkBox26.Checked, checkBox36.Checked, 2));
            ug.UserAccessRoles.Add(Fill_UserGroup(label5.Text, checkBox7.Checked, checkBox17.Checked, checkBox27.Checked, checkBox37.Checked, 3));
            ug.UserAccessRoles.Add(Fill_UserGroup(label6.Text, checkBox8.Checked, checkBox18.Checked, checkBox28.Checked, checkBox38.Checked, 4));
            ug.UserAccessRoles.Add(Fill_UserGroup(label7.Text, checkBox9.Checked, checkBox19.Checked, checkBox29.Checked, checkBox39.Checked, 5));
            ug.UserAccessRoles.Add(Fill_UserGroup(label8.Text, checkBox10.Checked, checkBox20.Checked, checkBox30.Checked, checkBox40.Checked, 6));
            ug.UserAccessRoles.Add(Fill_UserGroup(label9.Text, checkBox11.Checked, checkBox21.Checked, checkBox31.Checked, checkBox41.Checked, 7));
            ug.UserAccessRoles.Add(Fill_UserGroup(label10.Text, checkBox12.Checked, checkBox22.Checked, checkBox32.Checked, checkBox42.Checked, 8));

            ((UserForm)Application.OpenForms["UserForm"]).ug = ug;
            ((UserForm)Application.OpenForms["UserForm"]).Load_UserGroupForm2();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
                checkBox8.Checked = true;
                checkBox9.Checked = true;
                checkBox10.Checked = true;
                checkBox11.Checked = true;
                checkBox12.Checked = true;
            }
            else
            {
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox15.Checked = true;
                checkBox16.Checked = true;
                checkBox17.Checked = true;
                checkBox18.Checked = true;
                checkBox19.Checked = true;
                checkBox20.Checked = true;
                checkBox21.Checked = true;
                checkBox22.Checked = true;

            }
            else
            {
                checkBox15.Checked = false;
                checkBox16.Checked = false;
                checkBox17.Checked = false;
                checkBox18.Checked = false;
                checkBox19.Checked = false;
                checkBox20.Checked = false;
                checkBox21.Checked = false;
                checkBox22.Checked = false;

            }
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox25.Checked = true;
                checkBox26.Checked = true;
                checkBox27.Checked = true;
                checkBox28.Checked = true;
                checkBox29.Checked = true;
                checkBox30.Checked = true;
                checkBox31.Checked = true;
                checkBox32.Checked = true;

            }
            else
            {
                checkBox25.Checked = false;
                checkBox26.Checked = false;
                checkBox27.Checked = false;
                checkBox28.Checked = false;
                checkBox29.Checked = false;
                checkBox30.Checked = false;
                checkBox31.Checked = false;
                checkBox32.Checked = false;

            }
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox35.Checked = true;
                checkBox36.Checked = true;
                checkBox37.Checked = true;
                checkBox38.Checked = true;
                checkBox39.Checked = true;
                checkBox40.Checked = true;
                checkBox41.Checked = true;
                checkBox42.Checked = true;

            }
            else
            {
                checkBox35.Checked = false;
                checkBox36.Checked = false;
                checkBox37.Checked = false;
                checkBox38.Checked = false;
                checkBox39.Checked = false;
                checkBox40.Checked = false;
                checkBox41.Checked = false;
                checkBox42.Checked = false;

            }
        }

        private void UserGroup1_UC_Load(object sender, EventArgs e)
        {
            if (ug != null)
            {
                foreach (UserAccessRole g in ug.UserAccessRoles)
                {
                    if (g.Code == 1)
                    {
                        if (g.CanEnter)
                        {
                            checkBox5.Checked = true;
                        }
                        if (g.CanCreate)
                        {
                            checkBox15.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox25.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox35.Checked = true;
                        }
                    }
                    if (g.Code == 2)
                    {
                        if (g.CanEnter)
                        {
                            checkBox6.Checked = true;
                        }
                        if (g.CanCreate)
                        {
                            checkBox16.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox26.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox36.Checked = true;
                        }
                    }
                    if (g.Code == 3)
                    {
                        if (g.CanEnter)
                        {
                            checkBox7.Checked = true;
                        }
                        if (g.CanCreate)
                        {
                            checkBox17.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox27.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox37.Checked = true;
                        }
                    }
                    if (g.Code == 4)
                    {
                        if (g.CanEnter)
                        {
                            checkBox8.Checked = true;
                        }
                        if (g.CanCreate)
                        {
                            checkBox18.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox28.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox38.Checked = true;
                        }
                    }
                    if (g.Code == 5)
                    {
                        if (g.CanEnter)
                        {
                            checkBox9.Checked = true;
                        }
                        if (g.CanCreate)
                        {
                            checkBox19.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox29.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox39.Checked = true;
                        }
                    }
                    if (g.Code == 6)
                    {
                        if (g.CanEnter)
                        {
                            checkBox10.Checked = true;
                        }
                        if (g.CanCreate)
                        {
                            checkBox20.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox30.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox40.Checked = true;
                        }
                    }
                    if (g.Code == 7)
                    {
                        if (g.CanEnter)
                        {
                            checkBox11.Checked = true;
                        }
                        if (g.CanCreate)
                        {
                            checkBox21.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox31.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox41.Checked = true;
                        }
                    }
                    if (g.Code == 8)
                    {
                        if (g.CanEnter)
                        {
                            checkBox12.Checked = true;
                        }
                        if (g.CanCreate)
                        {
                            checkBox22.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox32.Checked = true;
                        }
                        if (g.CanUpdate)
                        {
                            checkBox42.Checked = true;
                        }
                    }
                }
                textBox1.Text = ug.Title;
            }
            
        }
    }
}
