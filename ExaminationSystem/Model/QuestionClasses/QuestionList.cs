using ExaminationSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ExaminationSystem.Model.QuestionClasses
{
    internal class QuestionList
    {
        List<Question> questions;
        string LogFileName;
        public QuestionList(string filename,int num)// the file name should be unique for each list (instance)
        {
            questions = new List<Question>(num);
            LogFileName = filename;
        }
        public Question? this[int index]
        {
            get { if (index < questions.Count && index > -1) return questions[index]; else return null; }
            set
            {
                if (index < questions.Count && index > -1) questions[index] = value;
            }
        }
        public int Length {  get { return questions.Count; } }
        public void add(Question question)
        {
            if (question == null)
                return;
            questions.Add(question);
            try
            {
                StreamWriter sw = new StreamWriter(LogFileName, true);
                sw.WriteLine(question.ToString());
                sw.Close();
            }
            catch ( Exception ex)
            {
                Helper.LogError($"Error while adding question to list:{ex.Message}");
            }

        }
    }
}
