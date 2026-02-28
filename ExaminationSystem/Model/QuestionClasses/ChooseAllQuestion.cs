using ExaminationSystem.Model.AnswerClasses;
using ExaminationSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model.QuestionClasses
{
    internal class ChooseAllQuestion : Question
    {
        public override bool checkAnswer(IAnswer answer)
        {
            if (answer is null||CorrectAnswer is null)
                return false;
            if (answer is AnswerList answer2 && CorrectAnswer is AnswerList answer1)
            {
                for (int i = 0; i < answer2?.Count; i++)
                {
                    if (!answer1.contains(answer2[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override void Display()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
