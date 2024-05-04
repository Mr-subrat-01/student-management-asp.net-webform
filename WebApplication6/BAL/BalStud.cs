using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using WebApplication6.Models;
using WebApplication6.DAL;

namespace WebApplication6.BAL
{
    public class BalStud
    {
        public int InsertStud(Student stud)
        {
            try
            {
               DalStud obj = new DalStud();
                return obj.InsertStud(stud);
            }
            catch
            {
                return 0;
            }
        }


        public int UpdateStud(Student stud)
        {
            try
            {
                DalStud obj = new DalStud();
                return obj.UpdateStud(stud);
            }
            catch
            {
                return 0;
            }
        }

        public int UpdateStudWithOutImg(Student stud)
        {
            try
            {
                DalStud obj = new DalStud();
                return obj.UpdateStudWithOutImg(stud);
            }
            catch
            {
                return 0;
            }
        }

        public int DeleteStud(int sid)
        {
            try
            {
                DalStud obj = new DalStud();
                return obj.DeleteStud(sid);
            }
            catch
            {
                return 0;
            }
        }

        public List<Student> GetStudents()
        {
            try
            {
                DalStud obj = new DalStud();
                return obj.GetStudents();
            }
            catch
            {
                return null;
            }
        }

        public int CheckDuplicateEmail(string semail)
        {
            try
            {
                DalStud obj = new DalStud();
                return obj.CheckDuplicateEmail(semail);
            }
            catch
            {
                return -1;
            }
        }
        public int CheckDuplicateRegNo(string sregno)
        {
            try
            {
                DalStud obj = new DalStud();
                return obj.CheckDuplicateRegNo(sregno);
            }
            catch
            {
                return -1;
            }
        }
    }
}