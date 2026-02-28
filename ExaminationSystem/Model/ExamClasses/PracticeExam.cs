using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model.ExamClasses
{
    internal class PracticeExam : Exam
    {
        public PracticeExam(int _numberOfQuestions, Subject sub) : base(_numberOfQuestions, sub)
        {
        }
        public override object Clone()
        {
            PracticeExam temp = new(NumberOfQuestions, (Subject)Subject.Clone());
            foreach (var element in QuestionAnswerDictionary)
                temp.QuestionAnswerDictionary.Add(element.Key, element.Value);//can use clone here for key and value
            for (var i = 0; i < questions.Length; i++)
                temp.questions[i] = questions[i]; //can use clone here too
            temp.Mode = Mode;
            return temp;
        }

        public override void ShowExam()// t will be betten to write in file like report ? but need connection between student and exam.
        {
            Console.WriteLine("EXAM REPORTING");
            foreach (var element in QuestionAnswerDictionary)
            {
                if (element.Key.checkAnswer(element.Value))
                    Console.WriteLine("Congratulations :)");
                else
                    Console.WriteLine("Wrong :(");
                element.Key.Display();
                Console.WriteLine(element.Value);
                Console.WriteLine($"The Exam Grade {FinalGrade} / {TotalGrade}");
            }
        }
    }
}
