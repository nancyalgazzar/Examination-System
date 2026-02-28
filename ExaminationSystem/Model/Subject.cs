using ExaminationSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ExaminationSystem.Model
{
    internal class Subject:ICloneable
    {

        string name;
        public string Name { get { return name; } set { SetName(value); } }
        List<Student>EnrolledStudents;
        public Subject(string _name)
        {
            EnrolledStudents = new List<Student>();
            SetName(_name);
          }
        void SetName(string _name)
        {
            Helper.setText(_name, ref name, "Error, Please enter subject name");
            
        }
        public void Enroll(Student student)
        {
            if(student is not null)
                 EnrolledStudents.Add(student);
            else
            {
                Helper.LogError($"Failed to Enroll student in subject {Name} at {DateTime.Now}");
            }
        }

        public object Clone()
        {
            
           return new Subject(name);
        }
    }
}
