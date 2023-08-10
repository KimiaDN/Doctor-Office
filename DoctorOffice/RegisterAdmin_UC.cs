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
using BE;
using BLL;

namespace DoctorOffice
{
    public partial class RegisterAdmin_UC : UserControl
    {
        public RegisterAdmin_UC()
        {
            InitializeComponent();
        }

        MSG msg = new MSG();
        UserGroup_BLL ug_bll = new UserGroup_BLL();
        Admin_BLL admin_bll = new Admin_BLL();

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            KeyManager km = new KeyManager(textBoxX1.Text);
            string productKey = textBoxX2.Text;
            if (km.ValidKey(ref productKey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productKey, ref kv))
                {
                    LicenseInfo lic = new LicenseInfo();
                    lic.ProductKey = productKey;
                    lic.FullName = "Personal accounting";
                    if (kv.Type == LicenseType.TRIAL)
                    {
                        lic.Day = kv.Expiration.Day;
                        lic.Month = kv.Expiration.Month;
                        lic.Year = kv.Expiration.Year;
                    }

                    km.SaveSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), lic);
                    label6.Visible = true;
                    panel2.Visible = true;
                }
            }
            else
            {
                msg.Show("لایسنس تایید نشد", false);
            }
            
            //label6.Visible = true;
            //panel2.Visible = true;
        }

        private void RegisterAdmin_UC_Load(object sender, EventArgs e)
        {
            textBoxX1.Text = ComputerInfo.GetComputerId();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Admin a = new Admin();
            a.Name = textBoxX6.Text;
            a.UserName = textBoxX4.Text;
            a.RegDate = DateTime.Now;   
            if (textBoxX3.Text == textBoxX5.Text)
            {
                a.Password = textBoxX5.Text;
            }
            UserGroup ug = new UserGroup();
            ug.Title = "مدریت";
            ug.UserAccessRoles.Add(Fill_UserGroup("مدریت کاربران", true, true, true, true, 1));
            ug.UserAccessRoles.Add(Fill_UserGroup("مدریت بیماران", true, true, true, true, 2));
            ug.UserAccessRoles.Add(Fill_UserGroup("نوبت دهی بیماران", true, true, true, true, 7));
            ug.UserAccessRoles.Add(Fill_UserGroup("ویزیت بیماران", false, false, false, false, 3));
            ug.UserAccessRoles.Add(Fill_UserGroup("تاریخچه ویزیت ها", true, true, false, true, 4));
            ug.UserAccessRoles.Add(Fill_UserGroup("تست و آزمایش", true, true, true, true, 5));
            ug.UserAccessRoles.Add(Fill_UserGroup("امور پرداخت", true, true, true, true, 6));
            ug.UserAccessRoles.Add(Fill_UserGroup("یادآور ها", true, true, true, true, 9));
            ug.UserAccessRoles.Add(Fill_UserGroup("پنل پیامکی", true, true, true, true, 12));
            ug.UserAccessRoles.Add(Fill_UserGroup("امور مالی", true, true, true, true, 8));
            ug.UserAccessRoles.Add(Fill_UserGroup("گزارشات", true, true, true, true, 10));
            ug.UserAccessRoles.Add(Fill_UserGroup("تنظیمات", true, true, true, true, 11));
            ug_bll.Create(ug);
            string str = admin_bll.Create(a, ug);
            msg.Show(str, false);
            this.Visible = false;
            ((UploadForm)Application.OpenForms["UploadForm"]).LoginUC_Load();


        }


    }
}
