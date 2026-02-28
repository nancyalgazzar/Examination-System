using ExaminationSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExaminationSystem.Model.AnswerClasses
{
    internal class AnswerList: IAnswer
    {
        int count = 0;
        Answer[] answers;
        public const int NUMBER_OF_QUESTIONS = 4;
        public int Count {  get { return count; } }
        public AnswerList(int numberOfAnswers = NUMBER_OF_QUESTIONS)
        {
            answers = new Answer[numberOfAnswers];
        }
        public void Add(Answer answer) {
            setAnswer(answer, count++);
        }
        void setAnswer(Answer? answer, int index)
        {
            if (answer == null)
                Helper.LogError($"Error Trying to add null answer for a question at {DateTime.Now}");
            else
            {
                if (index < answers.Length && index > -1)
                {
                    answers[index] = answer;
                }
                else
                    Helper.LogError($"Error Trying to add Extra answer for a question at {DateTime.Now}");
            }
        }
        public Answer? this [int index] {
            get
            {
                if (index > -1 && index <= count)
                    return answers[index];
                Helper.LogError($"Error Trying to access invalid answer at {DateTime.Now}");
                return null;
            }
            set { setAnswer(value,index); }
    }
        public Answer? GetById(int id) {
            if (Answer.CheckID(id))// if id in 0...4
            {
                for(int i = 0; i < count; i++)
                {
                    if (answers[i].ID.Equals( (MCQAnswer)id))
                    {
                        return answers[i];
                    }
                }
            }
            return null;
        }
        public bool contains(Answer? a)
        {
            if (a == null)
                return false;
            return answers.Contains(a);// use equals for compare
        }
        public override string ToString()
        {
            string temp = string.Empty;
            for (int i = 0; i < count; i++)
            {
                temp += answers[i].ToString();
            }
            return temp;
        }
    }
}
