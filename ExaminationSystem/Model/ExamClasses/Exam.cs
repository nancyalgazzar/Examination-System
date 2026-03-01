using ExaminationSystem.Model.AnswerClasses;
using ExaminationSystem.Model.QuestionClasses;
using ExaminationSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model.ExamClasses
{
    internal abstract class Exam:ICloneable,IComparable<Exam>
    {
        protected DateTime time;
        protected int numberOfQuestions;
        protected QuestionList questions;
        protected Dictionary<Question, IAnswer> QuestionAnswerDictionary;
        protected Subject subject;
        public Subject Subject {  get { return subject; } }
        protected ExamMode Mode;
        public DateTime Time { get { return time; } }
        public int NumberOfQuestions { get { return numberOfQuestions; } }
        protected int TotalGrade = 0;
        protected int FinalGrade = 0;
        //public Question? this[int index]
        //{
        //    get { if (index > -1 && index < numberOfQuestions) return questions[index]; else return null; }
        //    set { if (index > -1 && index < numberOfQuestions&& value is not null) questions[index] = value;  }
        //}

        public Exam(int _numberOfQuestions, Subject sub,string logFileName = Constants.LogFileName)
        {
            time = DateTime.Now;
            numberOfQuestions = _numberOfQuestions;
            questions = new QuestionList(logFileName,numberOfQuestions);
            QuestionAnswerDictionary = new Dictionary<Question, IAnswer>();
            subject = sub;
            Mode = ExamMode.Queued;

        }
        public void add(Question q)
        {
            if(q is not null)
                questions.add(q);
        }

        public abstract void ShowExam();
        public virtual void Start()
        {
            Mode = ExamMode.Starting;
            //timer exam or question.-event related-
            //move this to show function.
            for (int i = 0; i < questions.Length; i++)
            {
                if (questions[i] is not null)
                {
                    Console.WriteLine(questions[i]);
                    string? ans;
                    do
                    {
                        Console.WriteLine("Answer: Enter the answer number or text, If there is more than one correct answer separate them by \",\" ");
                        ans = Console.ReadLine();
                    } while (!Helper.IsStringValid(ans));
                    if (questions[i] is ChooseAllQuestion q&& q is not null)
                    {
                       QuestionAnswerDictionary.Add( q,multiAnswers(ans.Split(',')));//assume answers are separated by ,  
                    }
                    else
                    {
                       QuestionAnswerDictionary.Add(questions[i], oneAns(ans));
                    }
                }
            }
        }
        IAnswer multiAnswers(string[] ans)
        {
            AnswerList l=new AnswerList(ans.Length);//only take the id???
            for (int i = 0; i<ans.Length; i++) {
                if (Enum.TryParse<MCQAnswer>(ans[i], out MCQAnswer t))
                {
                    l.Add( new Answer((int)t, ""));
                }
                else
                {
                    l.Add( new Answer(0, ans[i]));

                }
            }
            return l;
        }
        IAnswer oneAns(string ans)
        {
            if (Enum.TryParse<MCQAnswer>(ans, out MCQAnswer t))
            {
                return new Answer((int)t, "");
            }
            else
            {
                return new Answer(0, ans);

            }
        }
        public virtual void Finish()
        {
            //timer
            Mode = ExamMode.Finished;
            Console.WriteLine("WITH BEST WISHES");
        }
        public void CorrectExam()
        {

            foreach (var element in QuestionAnswerDictionary)
            {
                TotalGrade += element.Key.Mark;
                if (element.Key.checkAnswer(element.Value))
                {
                    FinalGrade += element.Key.Mark;
                }
            }
        }

        public override string ToString()
        {
            return base.ToString();//what to print?
        }
        
        public override bool Equals(object? obj)
        {
            if(obj == null|| obj is not  Exam) return false;

            return time.Equals(((Exam)obj).Time)||numberOfQuestions == ((Exam)obj).NumberOfQuestions;
        }

        public abstract object Clone();

        public int CompareTo(Exam? other)
        {
            if (other == null)
                return 1;
            if(time.CompareTo(other.time)==0)
                return numberOfQuestions.CompareTo(other.numberOfQuestions);
            return time.CompareTo(other.time);
        }
    }
}
