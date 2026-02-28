using ExaminationSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model
{
    public class Student
    {
        static int IDCounter = 1;
        string name;
        public string Name { get { return name; } }
        public int ID { get; private set; }
        public Student(string _name)
        {
            ID = IDCounter++;
            Helper.setText(_name, ref name, "Error, Please enter Your name");
            
        }
        //void OnExamStarted(object sender, ExamEventArgs e) { }


    }
}
