using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//Adding references 
using SMS_BL;
using SMS_Entities;
using SMS_Exceptions;
using System.Windows.Forms;

namespace SMS_WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Student_BL sbl = null;
        Student sObj = null;

        public MainWindow()
        {
            InitializeComponent();
            sbl = new Student_BL();

        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Init Entity Object
                sObj = new Student();
                //Assigning data to sObj Properties
                sObj.student_id = Convert.ToInt32(txtRoll.Text);
                sObj.student_first_name = txtFName.Text;
                sObj.student_last_name = txtLName.Text;
                sObj.street_address = txtAddr.Text;
                sObj.zip_code = txtpin.Text;
                //Calling BL
                bool res = sbl.AddStudent(sObj);
                if (res)
                {
                    System.Windows.Forms.MessageBox.Show("Record Added!!");

                }
            }
            catch (StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message, "Student Management System");
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management System");
            }


        }

        private void btnAlter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Init Entity Object
                sObj = new Student();
                //Assigning data to sObj Properties
                sObj.student_id = Convert.ToInt32(txtRoll.Text);
                sObj.student_first_name = txtFName.Text;
                sObj.student_last_name = txtLName.Text;
                sObj.street_address = txtAddr.Text;
                sObj.zip_code = txtpin.Text;
                //Calling BL
                bool res = sbl.UpdateStudent(sObj);
                if (res)
                {
                    System.Windows.Forms.MessageBox.Show("Record Updated!!");

                }
            }
            catch (StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message, "Student Management System");
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management System");
            }

        }

        private void btnDrop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Init Entity Object
                sObj = new Student();
                //Assigning data to sObj Properties
                sObj.student_id = Convert.ToInt32(txtRoll.Text);
                // sObj.Name = txtName.Text;
                // sObj.Address = txtAddress.Text;
                //Calling BL
                bool res = sbl.DropStudent(sObj.student_id);
                if (res)
                {
                    System.Windows.Forms.MessageBox.Show("Record Deleted!!");

                }
            }
            catch (StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message, "Student Management System");
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management System");
            }

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Init Entity Object
                List<Student> mystudents;
                sObj = new Student();
                //Assigning data to sObj Properties
                sObj.student_id = Convert.ToInt32(txtRoll.Text);
                // sObj.Name = txtName.Text;
                // sObj.Address = txtAddress.Text;
                //Calling BL
                mystudents = sbl.SearchStudentByID(sObj.student_id);
                dataGrid.ItemsSource = mystudents;
                //System.Windows.Forms.MessageBox.Show("Roll No is: " + sb.Rollno + "Name is: " + sObj.Name + " Address is: " + sObj.Address);
            }
            catch (StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message, "Student Management System");
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management System");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Student> mystudents;
                //sObj = new Student();
                //Assigning data to sObj Properties
                // sObj.Rollno = Convert.ToInt32(txtRollNo.Text);
                // sObj.Name = txtName.Text;
                // sObj.Address = txtAddress.Text;
                //Calling BL
                mystudents = sbl.ShowAllStudent();
                dataGrid.ItemsSource = mystudents;
                //System.Windows.Forms.MessageBox.Show("Roll No is: " + sb.Rollno + "Name is: " + sObj.Name + " Address is: " + sObj.Address);
            }
            catch (StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message, "Student Management System");
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message, "Student Management System");
            }

        }
        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<Student> myStudents;
            myStudents = sbl.DropDownList();
            ComboBox1.DisplayMemberPath = "student_first_name";
            ComboBox1.ItemsSource = myStudents;
            ComboBox2.DisplayMemberPath = "student_last_name";
            ComboBox2.ItemsSource = myStudents;

        }
    }
}
