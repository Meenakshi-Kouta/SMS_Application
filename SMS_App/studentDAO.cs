using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SMS_Entities;
using SMS_Exceptions;
using System.CodeDom;
using System.Security.Cryptography;

namespace SMS_DAO
{
    public class Student_DAO
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;
        DataTable mydt;
        List<Student> myStudents = null;
        public Student_DAO()
        {
            con = new SqlConnection();
            con.ConnectionString = "server=.\\SQLEXPRESSSERVER;User Id = sa; Password = Sweety123; Database=School";
        }

        public List<Student> ShowAllStudent()
        {
            //write logic here
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "select * from student_info";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                sdr = cmd.ExecuteReader();
                mydt = new DataTable();
                mydt.Load(sdr);
                if (mydt.Rows.Count > 0)
                {
                    myStudents = new List<Student>();
                    foreach (DataRow item in mydt.Rows)
                    {
                        Student s1 = new Student();
                        s1.student_id = Int32.Parse(item[0].ToString());
                        s1.student_first_name = item[1].ToString();
                        s1.student_last_name = item[2].ToString();
                        s1.street_address = item[3].ToString();
                        s1.zip_code = item[4].ToString();

                        myStudents.Add(s1);

                    }
                }
            }

            catch (SqlException e)
            {
                throw new StudentException(e.Message);
            }
            catch (Exception e)
            {
                throw new StudentException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return myStudents;
        }
        public List<Student> SearchStudentByID(int id)
        {
            try
            {

                con.Open();
                //creating param
                SqlParameter p1 = new SqlParameter("@rollno", id);
                cmd = new SqlCommand();
                cmd.CommandText = "select * from student_info where student_id=@rollno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                //adding param to command

                cmd.Parameters.Add(p1);
                sdr = cmd.ExecuteReader();
                mydt = new DataTable();
                mydt.Load(sdr);
                if (mydt.Rows.Count > 0)
                {
                    myStudents = new List<Student>();
                    foreach (DataRow item in mydt.Rows)
                    {
                        Student s1 = new Student();

                        //s1.student_first_name = item[0].ToString();
                        //s1.student_id = Int32.Parse(item[1].ToString());
                        //s1.student_address = item[2].ToString();
                        s1.student_id = Int32.Parse(item[0].ToString());
                        s1.student_first_name = item[1].ToString();
                        s1.student_last_name = item[2].ToString();
                        s1.street_address = item[3].ToString();
                        s1.zip_code = item[4].ToString();

                        myStudents.Add(s1);

                    }
                    //return myStudents;
                }
                else
                {
                    throw new StudentException("RollNumber doesn't exits");
                }
            }

            catch (SqlException e)
            {
                throw new StudentException(e.Message);
            }
            catch (Exception e)
            {
                throw new StudentException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return myStudents;
            //return new List<Student>();
        }
        public bool AddStudent(Student s1)
        {
            int recCount = 0;
            try
            {

                con.Open();
                //Init Command Parameter
                SqlParameter p1, p2, p3, p4, p5;
                p1 = new SqlParameter("@rollno", s1.student_id);
                p2 = new SqlParameter("@fname", s1.student_first_name);
                p3 = new SqlParameter("@lname", s1.student_last_name);
                p4 = new SqlParameter("@addr", s1.street_address);
                p5 = new SqlParameter("@pin", s1.zip_code);


                //Init cmd Object
                cmd = new SqlCommand();
                cmd.CommandText = "Insert into student_info(student_id,student_first_name,student_last_name,street_address,zip_code) values(@rno,@fname,@lname,@addr,@pin)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                //Adding Parameter to command
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                //execute command
                recCount = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException e)
            {
                throw new StudentException(e.Message);
            }
            catch (Exception e)
            {
                throw new StudentException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            //  System.Windows.Forms.MessageBox.Show(recCount.ToString() + " record Added ");

            if (recCount == 0)
                return false;
            else
                return true;
        }

        public bool UpdateStudent(Student s1)
        {
            int recCount = 0;
            try
            {
                //con.Close();
                con.Open();

                cmd = new SqlCommand("Update student_info set student_first_name=@fname,student_last_name=@lname,street_address=@addr,zip_code=@pin where student_id=@rollno", con);

                cmd.Parameters.AddWithValue("@rollno", s1.student_id);
                cmd.Parameters.AddWithValue("@fname", s1.student_first_name);
                cmd.Parameters.AddWithValue("@lname", s1.student_last_name);
                cmd.Parameters.AddWithValue("@addr", s1.street_address);
                cmd.Parameters.AddWithValue("@pin", s1.zip_code);
                recCount = cmd.ExecuteNonQuery();


            }
            catch (SqlException e)
            {
                throw new StudentException(e.Message);
            }
            catch (Exception e)
            {
                throw new StudentException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return true;
        }

        public bool DropStudent(int id)
        {
            int recCount = 0;
            try
            {
                con.Open();

                cmd = new SqlCommand();
                SqlParameter p1 = new SqlParameter("@rollno", id);
                cmd.CommandText = "Delete from student_info where student_id=@rollno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.Parameters.Add(p1);
                recCount = cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new StudentException(e.Message);
            }
            catch (Exception e)
            {
                throw new StudentException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            if (recCount == 0)
                return false;
            else
                return true;

        }
        public List<Student> DropDownList()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "select Name from Student";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                //RUN THE COMMAND
                sdr = cmd.ExecuteReader();

                //CREATING TEMPORARY TABLE
                DataTable dt = new DataTable();
                dt.Load(sdr);
                if (dt.Rows.Count > 0)
                {
                    myStudents = new List<Student>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Student s1 = new Student();
                        s1.student_first_name = dr[1].ToString();
                        s1.student_last_name = dr[1].ToString();
                        myStudents.Add(s1);

                    }
                }
            }

            catch (SqlException se)
            {
                throw new StudentException(se.Message);
            }
            catch (Exception e)
            {
                throw new StudentException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return myStudents;
        }

    }
}
