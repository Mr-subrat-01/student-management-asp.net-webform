using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using WebApplication6.Models;
using System.Configuration;
using Dapper;
using System.Linq;

namespace WebApplication6.DAL
{
    public class DalStud
    {
        public SqlConnection con;

        public DalStud()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
            con.Open();
        }

        public int InsertStud(Student stud)
        {
            try
            {
                if(con.State != ConnectionState.Open)
                {
                    con.Open();
                }

                DynamicParameters parms = new DynamicParameters();
                parms.Add("@studId", stud.studId);
                parms.Add("@studRegNo", stud.studRegNo);
                parms.Add("@studName", stud.studName);
                parms.Add("@studFName", stud.studFName);
                parms.Add("@studAdd", stud.studAdd);
                parms.Add("@studPhone", stud.studPhone);
                parms.Add("@studEmail", stud.studEmail);
                parms.Add("@studGen", stud.studGen);
                parms.Add("@studAge", stud.studAge);
                parms.Add("@studDoj", stud.studDoj);
                parms.Add("@studClass", stud.studClass);
                parms.Add("@studSec", stud.studSec);
                parms.Add("@studPhoto", stud.studPhoto);
                parms.Add("@status", stud.status);
                parms.Add("@operation", "Insert");
                int r = con.Execute("sp_manage_student",parms,commandType:CommandType.StoredProcedure);
                con.Close();
                return r;
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
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                DynamicParameters parms = new DynamicParameters();
                parms.Add("@studId", stud.studId);
                parms.Add("@studRegNo", stud.studRegNo);
                parms.Add("@studName", stud.studName);
                parms.Add("@studFName", stud.studFName);
                parms.Add("@studAdd", stud.studAdd);
                parms.Add("@studPhone", stud.studPhone);
                parms.Add("@studEmail", stud.studEmail);
                parms.Add("@studGen", stud.studGen);
                parms.Add("@studAge", stud.studAge);
                parms.Add("@studDoj", stud.studDoj);
                parms.Add("@studClass", stud.studClass);
                parms.Add("@studSec", stud.studSec);
                parms.Add("@studPhoto", stud.studPhoto);
                parms.Add("@status", stud.status);
                parms.Add("@operation", "Update");
                int r = con.Execute("sp_manage_student", parms, commandType: CommandType.StoredProcedure);
                con.Close();
                return r;
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
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                DynamicParameters parms = new DynamicParameters();
                parms.Add("@studId", stud.studId);
                parms.Add("@studRegNo", stud.studRegNo);
                parms.Add("@studName", stud.studName);
                parms.Add("@studFName", stud.studFName);
                parms.Add("@studAdd", stud.studAdd);
                parms.Add("@studPhone", stud.studPhone);
                parms.Add("@studEmail", stud.studEmail);
                parms.Add("@studGen", stud.studGen);
                parms.Add("@studAge", stud.studAge);
                parms.Add("@studDoj", stud.studDoj);
                parms.Add("@studClass", stud.studClass);
                parms.Add("@studSec", stud.studSec);
                parms.Add("@status", stud.status);
                parms.Add("@operation", "UpdateWithoutImg");
                int r = con.Execute("sp_manage_student", parms, commandType: CommandType.StoredProcedure);
                con.Close();
                return r;
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
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                DynamicParameters parms = new DynamicParameters();
                parms.Add("@studId", sid);
                parms.Add("@operation", "Delete");
                int r = con.Execute("sp_manage_student", parms, commandType: CommandType.StoredProcedure);
                con.Close();
                return r;
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
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                DynamicParameters parms = new DynamicParameters();
                parms.Add("@operation", "Select");
                List<Student> list  = con.Query<Student>("sp_manage_student", parms, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                return list;
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
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                DynamicParameters parms = new DynamicParameters();
                parms.Add("@studEmail", semail);
                parms.Add("@operation", "CheckEmail");
                List<Student> list = con.Query<Student>("sp_manage_student", parms, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                if(list.Count > 0)
                {
                    return 1;
                }
                return 0;
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
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                DynamicParameters parms = new DynamicParameters();
                parms.Add("@studEmail", sregno);
                parms.Add("@operation", "CheckRegNo");
                List<Student> list = con.Query<Student>("sp_manage_student", parms, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                if (list.Count > 0)
                {
                    return 1;
                }
                return 0;
            }
            catch
            {
                return -1;
            }
        }
    }
}