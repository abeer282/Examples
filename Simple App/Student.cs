using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.OleDb;

namespace Simple_App
{
    class Student
    {
        private int student_id;
        private string student_name;
        private int student_mark;
        
        public Student(int student_id, string student_name, int student_mark){
            this.student_id = student_id;
            this.student_name = student_name;
            this.student_mark = student_mark;
        }
        
        public int getStudentId(){
            return this.student_id;
        }
        public string getStudentNamed(){
            return this.student_name;
        }
        public int getStudentMark(){
            return this.student_mark;
        }
        public void setStudentId(int student_id){
            this.student_id = student_id;
        }
        public void setStudentNamed(string student_name){
            this.student_name = student_name;
        }
        public void setStudentMark(int student_mark){
            this.student_mark = student_mark;
        }

        public void addDataToDatabase()
        {
            string strDb = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:/test1/mydatabase.accdb;" + "Persist Security Info=False";
            OleDbConnection conn = new OleDbConnection(strDb);
            try
            {
                conn.Open();
                string command = "insert into students(student_id,student_name,student_mark) values(" + 
                                                     student_id+",\'"+ student_name +"\',"+ student_mark+ ");";
                OleDbCommand cmdd = new OleDbCommand(command, conn);
                cmdd.ExecuteNonQuery();
            }
            catch (Exception e)
            { }
            finally
            {
                conn.Close();
            }
        }

    }
}
