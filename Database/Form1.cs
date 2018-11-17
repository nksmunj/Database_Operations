using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;


namespace Database
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            MySqlConnection cnn;
            string MySqlCommand;
            string output = string.Empty;
            MySqlDataReader datareader;




            connetionString = @"server=localhost;database=studentdetailsdb;user=root;password=root";
            cnn = new MySqlConnection(connetionString);
            cnn.Open();



            //MySqlCommand = "update student set FMarks = 50 where FStudentName='Nks'";          
            //MySqlCommand = "insert into student(FStudentID, FStudentName, FSubject, FMarks)value('101','Nks2','Chem2','100')";
            MySqlCommand = "Delete from student where FStudentID=101";


            MySqlCommand command = new MySqlCommand(MySqlCommand, cnn);
            MySqlDataAdapter dadapt = new MySqlDataAdapter();
            dadapt.InsertCommand = new MySqlCommand(MySqlCommand, cnn);
            dadapt.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            cnn.Close();







        }

        private void button2_Click(object sender, EventArgs e)
        {

            List<student> list = new List<student>();

            IList<Student> studentList = new List<Student>() {
        new Student() { StudentID = 1, StudentName = "John", Age = 13} ,
        new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
        new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
        new Student() { StudentID = 4, StudentName = "Ram" , Age = 20} ,
        new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
    };

            var filteredResult = studentList.Where(s => s.Age > 12 && s.Age < 20);

            string connetionString = @"server=localhost;database=studentdetailsdb;user=root;password=root";
            MySqlConnection cnn = new MySqlConnection(connetionString);
            cnn.Open();
            string SQLCommand = "select distinct FStudentName from student";
            MySqlCommand command = new MySqlCommand(SQLCommand, cnn);
            MySqlDataReader dadapt = command.ExecuteReader();

            while (dadapt.Read())
            {
                student studentobj = new student();
                studentobj.StudentName = dadapt["FStudentName"].ToString();



                list.Add(studentobj);
            }
        }
    }
}
