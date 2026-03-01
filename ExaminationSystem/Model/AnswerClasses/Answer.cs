using ExaminationSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ExaminationSystem.Model.AnswerClasses
{
    internal class Answer:IComparable<Answer>, IAnswer
    {
        string text= string.Empty;
        MCQAnswer id;
        public MCQAnswer ID { get { return id; } set { id =value; } }
        public string Text { get { return text; } set
            {
                if (string.IsNullOrEmpty(value))
                    text = string.Empty;
                else text = value;
            }
        }// can answer change after setting?
        public Answer(int _id,  string _text)
        {
            Text = _text;
            setID(_id);
           
        }
        
        void setID(int _id)
        {
            if (CheckID(_id))
            {
                id = (MCQAnswer)_id;
            }
            else
                id = MCQAnswer.NA;
           
        }
        public static bool CheckID(int _id)//check if the id number is valid
        {
            if (Enum.TryParse<MCQAnswer>(_id.ToString(), out MCQAnswer _))
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{(int)id}: {text} \n";
        }
        public override bool Equals(object? obj)
        {
            if (obj is null|| obj is not Answer)
                return false ;
            Answer temp = (Answer)obj;
            return id.Equals(temp.id) || text.ToLower().Equals(temp.text.ToLower()) ;
        }
        public int CompareTo(Answer? other)
        {
            if(other is null) 
                return 1 ;
            return id.CompareTo(other.id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(text, id, ID, Text);
        }
    }
}
