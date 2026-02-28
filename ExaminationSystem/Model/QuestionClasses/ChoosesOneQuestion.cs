using ExaminationSystem.Model.AnswerClasses;
using ExaminationSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Model.QuestionClasses
{
    internal class ChoosesOneQuestion : Question
    {
     

        public override bool checkAnswer(IAnswer answer)
        {
            return base.checkAnswer(answer);
        }

        public override void Display()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
