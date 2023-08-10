using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Data;

namespace BLL
{
    public class Patient_BLL
    {
        Patient_DAL dal = new Patient_DAL();

        public string Create(Patient p, int id)
        {
            if (dal.Check(p))
            {
                return dal.Create(p, id);
            }
            else
            {
                return "شماره چرونده یا شماره تماس بیمار تکراری می باشد";
            }
        }

        public DataTable Read()
        {
            return dal.Read();
        }

        public Patient Find(int id)
        {
            return dal.Find(id);
        }

        public DataTable Search(string s)
        {
            return dal.Search(s);
        }

        public DataTable Search_ByDoctorName(string s, int id)
        {
            return dal.Search_ByDoctorName(s, id);
        }

        public List<Visit> Read_Visit(int id)
        {
            return dal.Read_Visits(id);
        }

        public string Update(int id, Patient p)
        {
            return dal.Update(id, p);
        }

        public string Delete(int id)
        {
            return dal.Delete(id);
        }
    }
}
