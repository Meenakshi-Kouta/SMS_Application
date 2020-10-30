using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS_DAO;
using SMS_Entities;
using SMS_Exceptions;

namespace SMS_BL
{
    public class Student_BL
    {
        Student_DAO sDao = null;
        public Student_BL()
        {
            sDao = new Student_DAO();
        }
        public List<Student> ShowAllStudent()
        {
            //write logic here
            return sDao.ShowAllStudent();
        }
        public List<Student> SearchStudentByID(int id)
        {
            return sDao.SearchStudentByID(id);
        }
        public bool AddStudent(Student s1)
        {
            return sDao.AddStudent(s1);
        }
        public bool UpdateStudent(Student s1)
        {
            return sDao.UpdateStudent(s1);
        }
        public bool DropStudent(int id)
        {
            return sDao.DropStudent(id);
        }
        public List<Student> DropDownList()
        {
            return sDao.ShowAllStudent();
        }
    }
}
