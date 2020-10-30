using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Entities
{
    public class Student
    {

        #region Variables
        int rollno;
        string fname;
        string lname;
        string addr;
        string pin;
        #endregion

        #region Properties

        public int student_id
    { get => rollno; set => rollno = value; }
        public string student_first_name
        { get => fname; set => fname = value; }
        public string student_last_name
        { get => lname; set => lname = value; }
        public string street_address
        { get => addr; set => addr = value; }
        public string zip_code
        { get => pin; set => pin = value; }
        #endregion
        /// <summary>
        /// Param Constructor for Student Entity
        /// </summary>

        #region Constructors
        public Student()
        {

        }

        //public Student(int rollno, string name, string address)
        //{
        //    this.rollno = rollno;
        //    this.name = name;
        //    this.address = address;
        //}



        #endregion

    }
}




//namespace SMS_Entities
//{
//    public class Student
//    {
//        #region Variables 
//        int id;
//        string first_name;
//        string address;
//        #endregion

//        # region properties
//        public int student_id
//        {
//            get => id;
//            set => id = value;
//        }
//        public string student_first_name
//        {
//            get => first_name;
//            set => first_name = value;
//        }
//        public string street_address
//        {
//            get => address;
//            set => address = value;
//        }
//        #endregion

//        # region Constructors

//        public Student()
//        {

//        }
//        /// <summary>
//        /// Param constructor for Student Entities
//        /// </summary>
//        /// <param name="rno">Roll Number</param>
//        /// <param name="nm">Name of the Candidate</param>
//        /// <param name="adr">Permanant Address</param>
//        public Student(int rno, string nm, string adr)
//        {
//            id = rno;
//            first_name = nm;
//            address = adr;
//        }
//        #endregion
//    }
//}