using ExaminationSystem.Model.AnswerClasses;
using ExaminationSystem.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ExaminationSystem.Model.QuestionClasses
{
    internal abstract class Question
    {
        protected int mark;
        protected const int DEFAULT_MARK = 1;
        protected const int MAX_MARK = 5;
        public string? Header { get; set { Helper.setText(value, ref field, "Error, the question header is Empty"); } }
        public string? Body { get; set { Helper.setText(value, ref field, "Error, the question Body is Empty"); } }
        public int Mark { get { return mark; } set { if (value > 0 && value <= MAX_MARK) mark = value; else mark = DEFAULT_MARK; } }
        public AnswerList answers;
        public IAnswer? CorrectAnswer;
        //public Question(string _header, string _body, int _mark, AnswerList _answers, Answer answer)
        //{
        //    answers = _answers;
        //    Header = _header;
        //    Body = _body;
        //    Mark = _mark;
        //    CorrectAnswer = answer;
        //}
        public Question()
        {
            answers = new AnswerList();
            Mark = DEFAULT_MARK;
           
        }
        public abstract void Display();
        public override string ToString()
        {
            return $"{Header ?? string.Empty}\n\n{Body?? string.Empty}\n  Mark:{mark} \n\n{answers?.ToString()}\n\n";
        }

        public  virtual bool checkAnswer(IAnswer answer)
        {
            if (answer is null|| CorrectAnswer is null)
                return false;
            if (answer is Answer answer2 && CorrectAnswer is Answer answer1)
            {
                if(answer2.Equals(answer1))    
                    return true;
            }
            return false;
        }
        
    }
}
