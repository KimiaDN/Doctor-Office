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
using System.Windows.Interop;
using System.Windows.Media.Animation;

namespace DoctorOffice
{
    public partial class UserGroup2_UC : UserControl
    {
        public UserGroup2_UC()
        {
            InitializeComponent();
        }

        public UserGroup ug = new UserGroup();
        UserGroup_BLL bll = new UserGroup_BLL();
        MSG msg = new MSG();
        int id;

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

        private void Load_UserGroup()
        {
            foreach (UserAccessRole g in ug.UserAccessRoles)
            {
                if (g.Code == 9)
                {
                    if (g.CanEnter)
                    {
                        checkBox13.Checked = true;
                    }
                    if (g.CanCreate)
                    {
                        checkBox24.Checked = true;
                    }
                    if (g.CanUpdate)
                    {
                        checkBox33.Checked = true;
                    }
                    if (g.CanUpdate)
                    {
                        checkBox43.Checked = true;
                    }
                }
                if (g.Code == 10)
                {
                    if (g.CanEnter)
                    {
                        checkBox14.Checked = true;
                    }
                    if (g.CanCreate)
                    {
                        checkBox23.Checked = true;
                    }
                    if (g.CanUpdate)
                    {
                        checkBox34.Checked = true;
                    }
                    if (g.CanUpdate)
                    {
                        checkBox44.Checked = true;
                    }
                }
                if (g.Code == 11)
                {
                    if (g.CanEnter)
                    {
                        checkBox45.Checked = true;
                    }
                    if (g.CanCreate)
                    {
                        checkBox46.Checked = true;
                    }
                    if (g.CanUpdate)
                    {
                        checkBox47.Checked = true;
                    }
                    if (g.CanUpdate)
                    {
                        checkBox48.Checked = true;
                    }
                }
                if (g.Code == 12)
                {
                    if (g.CanEnter)
                    {
                        checkBox8.Checked = true;
                    }
                    if (g.CanCreate)
                    {
                        checkBox7.Checked = true;
                    }
                    if (g.CanUpdate)
                    {
                        checkBox6.Checked = true;
                    }
                    if (g.CanUpdate)
                    {
                        checkBox5.Checked = true;
                    }
                }
            }
        }

        private void Refresh_UserGroup()
        {
            if (ug.Title != "")
            {
                foreach (UserAccessRole item in ug.UserAccessRoles.ToList())
                {
                    if (item.Code == 9)
                    {
                        ug.UserAccessRoles.Remove(item);
                    }
                    if (item.Code == 10)
                    {
                        ug.UserAccessRoles.Remove(item);
                    }
                    if (item.Code == 11)
                    {
                        ug.UserAccessRoles.Remove(item);
                    }
                    if (item.Code == 12)
                    {
                        ug.UserAccessRoles.Remove(item);
                    }

                }
            }
            
        }

        private void Fill_DataGridView()
        {
            dataGridViewX1.DataSource = null;
            dataGridViewX1.DataSource = bll.Read();
            dataGridViewX1.Columns["id"].Visible = false;
            dataGridViewX1.Columns["DeleteStatus"].Visible = false;
            dataGridViewX1.Columns["Title"].HeaderText = "عنوان گروه کاربری";

        }

        private void Clean()
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox43.Checked = false;
            checkBox44.Checked = false;
            checkBox5.Checked = false;
            checkBox33.Checked = false;
            checkBox34.Checked = false;
            checkBox47.Checked = false;
            checkBox6.Checked = false;
            checkBox23.Checked = false;
            checkBox24.Checked = false;
            checkBox46.Checked = false;
            checkBox7.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox45.Checked = false;
            checkBox8.Checked = false;
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox13.Checked = true;
                checkBox14.Checked = true;
                checkBox45.Checked = true;
                checkBox8.Checked = true;
            }
            else
            {
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox45.Checked = false;
                checkBox8.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox23.Checked = true;
                checkBox24.Checked = true;
                checkBox46.Checked = true;
                checkBox7.Checked = true;
            }
            else
            {
                checkBox23.Checked = false;
                checkBox24.Checked = false;
                checkBox46.Checked = false;
                checkBox7.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox33.Checked = true;
                checkBox34.Checked = true;
                checkBox47.Checked = true;
                checkBox6.Checked = true;
            }
            else
            {
                checkBox33.Checked = false;
                checkBox34.Checked = false;
                checkBox47.Checked = false;
                checkBox6.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox43.Checked = true;
                checkBox44.Checked = true;
                checkBox48.Checked = true;
                checkBox5.Checked = true;
            }
            else
            {
                checkBox43.Checked = false;
                checkBox44.Checked = false;
                checkBox5.Checked = false;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Refresh_UserGroup();
            ug.UserAccessRoles.Add(Fill_UserGroup(label11.Text, checkBox13.Checked, checkBox23.Checked, checkBox33.Checked, checkBox43.Checked, 9));
            ug.UserAccessRoles.Add(Fill_UserGroup(label12.Text, checkBox14.Checked, checkBox24.Checked, checkBox34.Checked, checkBox44.Checked, 10));
            ug.UserAccessRoles.Add(Fill_UserGroup(label14.Text, checkBox45.Checked, checkBox46.Checked, checkBox47.Checked, checkBox48.Checked, 11));
            ug.UserAccessRoles.Add(Fill_UserGroup(label1.Text, checkBox8.Checked, checkBox7.Checked, checkBox6.Checked, checkBox5.Checked, 12));
            
            if (label13.Text == "ویرایش اطلاعات")
            {
                bll.Delete(ug.id);
                string str = bll.Create(ug);
                msg.Show("ویرایش گروه کاربری با موفقیت انجام شد", false);
                label13.Text = "ثبت اطلاعات";
                ug = new UserGroup();
                ((UserForm)Application.OpenForms["UserForm"]).isEdit = false;
                ((UserForm)Application.OpenForms["UserForm"]).ug = ug;
            }
            else
            {
                string str = bll.Create(ug);
                msg.Show(str, false);
            }
            Fill_DataGridView();
            Clean();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Refresh_UserGroup();
            ug.UserAccessRoles.Add(Fill_UserGroup(label11.Text, checkBox13.Checked, checkBox23.Checked, checkBox33.Checked, checkBox43.Checked, 9));
            ug.UserAccessRoles.Add(Fill_UserGroup(label12.Text, checkBox14.Checked, checkBox24.Checked, checkBox34.Checked, checkBox44.Checked, 10));
            ug.UserAccessRoles.Add(Fill_UserGroup(label14.Text, checkBox45.Checked, checkBox46.Checked, checkBox47.Checked, checkBox48.Checked, 11));
            ug.UserAccessRoles.Add(Fill_UserGroup(label1.Text, checkBox8.Checked, checkBox7.Checked, checkBox6.Checked, checkBox5.Checked, 12));

            ((UserForm)Application.OpenForms["UserForm"]).ug = ug;
            ((UserForm)Application.OpenForms["UserForm"]).Load_UserGroupForm1();

        }

        private void UserGroup2_UC_Load(object sender, EventArgs e)
        {
            Fill_DataGridView();
            Load_UserGroup();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            string str = bll.Delete(id);
            msg.Show(str, false);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = Convert.ToInt16(dataGridViewX1.Rows[dataGridViewX1.CurrentRow.Index].Cells["id"].Value.ToString());
            ug = new UserGroup();
            ug = bll.Find(id);
            label13.Text = "ویرایش اطلاعات";
            ((UserForm)Application.OpenForms["UserForm"]).isEdit = true;
            Load_UserGroup();
           
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
        }
    }
}
