using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model.ExamClasses
{
    internal class FinalExam : Exam
    {
        public FinalExam(int _numberOfQuestions, Subject sub) : base(_numberOfQuestions, sub)
        {
        }

        public override object Clone()
        {
            FinalExam temp = new(NumberOfQuestions,(Subject)Subject.Clone());
            foreach(var element in QuestionAnswerDictionary)
                temp.QuestionAnswerDictionary.Add(element.Key,element.Value);//can use clone here for key and value
            for (var i = 0; i < questions.Length; i++)
                temp.questions[i] = questions[i]; //can use clone here too
            temp.Mode = Mode;
            return temp;
        }

        public override void ShowExam()
        {
            Console.WriteLine("EXAM REPORTING");
            foreach(var element in QuestionAnswerDictionary)
            {
                Console.WriteLine(element.Key.Header);
                Console.WriteLine(element.Key.Body);
                Console.WriteLine($"Mark: {element.Key.Mark}");
                Console.WriteLine($"Your Answer is {element.Value}");
                Console.WriteLine($"The Exam Grade {FinalGrade} / {TotalGrade}");
            }

        }
    }
}
