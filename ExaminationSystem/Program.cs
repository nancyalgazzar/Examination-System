using ExaminationSystem.Model;
using ExaminationSystem.Model.ExamClasses;
using ExaminationSystem.Model.QuestionClasses;
using ExaminationSystem.Model.AnswerClasses;
using ExaminationSystem.Utilities;

namespace ExaminationSystem
{
    internal class Program
    {
        static void inputstring(out string temp,string msg)
        {

            do { Console.WriteLine(msg); temp = Console.ReadLine(); } while (!Helper.IsStringValid(temp));

        }
        static void inputint(out int temp, string msg)
        {
            string t;
            do { Console.WriteLine(msg); t = Console.ReadLine(); } while (!int.TryParse(t, out temp)||temp<1);

        }
        static void Main(string[] args)
        {
            /////////////////Create Subject////////////////
            string temp =string.Empty;
            inputstring(out temp, "Please Enter the subject name");
            Subject sub = new Subject(temp);
            ////////////////
            //Create Student
            ////////////////
            temp = string.Empty;
            inputstring(out temp, "Please Enter the student name");
            Student st = new(temp);
            sub.Enroll(st);
            int numberofques;
            inputint(out numberofques, "Please Enter the number of questions");


            FinalExam fn = new FinalExam(numberofques,sub);
            PracticeExam pt = new(numberofques, sub);
            /////////////////add questions////////////////////////////
            for (int i = 0; i < numberofques; i++)
            {
                int type;
                inputint(out type, "Please enter\n1 for true or false question\n2 for choose one question \n3 for choose alll correct question");
                Question q;
                switch (type)
                {
                    case 1:
                        q = new TrueFalseQuestion();
                        break;
                    case 2:
                        q= new ChoosesOneQuestion();
                        break;
                    default:
                        q = new ChooseAllQuestion();
                        break;
                }
                inputstring(out temp, "Please enter the question header");
                q.Header = temp;
                inputstring(out temp, "Please enter the question body");
                q.Body = temp;
                int mark;
                inputint(out mark, "Please Enter the question mark");
                q.Mark = mark;
                //input answers???
                inputint(out mark, "Please Enter the number of choises ");
                for(int j =0; j < mark; j++)//id text
                {
                    inputstring(out temp, $"Please enter answer number {j + 1}");
                    q.answers.Add(new Answer(j+1, temp));
                   
                }
                inputint(out mark, "Please Enter the number of correct answers ");
                IAnswer ans;
                if (mark == 1)
                {
                    do
                    {
                        inputstring(out temp, $"Please enter the correct answer and its number");
                    } while (temp.Split(' ').Length < 2 || !int.TryParse(temp.Split(' ')[0],out mark));

                    ans = new Answer(mark, temp.Split(' ')[1]);
                }
                else
                {
                    ans = new AnswerList(mark);
                    for (int j = 0; j < mark; j++)//id text
                    {
                        int num;
                        do
                        {
                            inputstring(out temp, $"Please enter correct answer number {j + 1}");
                        } while (temp.Split(' ').Length < 2 || !int.TryParse(temp.Split(' ')[0], out num));

                        ((AnswerList)ans).Add(new Answer(num, temp.Split(' ')[1]));
                       
                    }
                }
                q.CorrectAnswer = ans;
                fn.add(q);
                pt.add(q);
            }
            
            //////////////////////pick question//
            while (true)
            {
                int etype;
                inputint(out etype, " Please enter 1 for FinalExam and 2 for practice exam");
                if (etype == 1)
                {
                    fn.Start();
                    fn.Finish();
                    fn.CorrectExam();
                    fn.ShowExam();
                }
                else
                {
                    pt.Start();
                    pt.Finish();
                    pt.CorrectExam();
                    pt.ShowExam();
                } 
            }
        }
    }
}
