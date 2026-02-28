using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ExaminationSystem.Utilities
{
    public class Helper
    {
       static public bool IsStringValid(string? value)
        {
             return !string.IsNullOrEmpty(value);
        }
        static public void setText(string? _text, ref string? text, string msg)
        {

            if (Helper.IsStringValid(_text))
            {
                text = _text;
            }
            else
            {
                text = string.Empty;
                Console.WriteLine(msg);
            }// how to better implement this & do i need to log here

        }
        static public void LogError(string msg)
        {
            try
            {
                StreamWriter sw = new StreamWriter(Constants.ErrorLogFile, true);
                sw.WriteLine(msg);
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);//?? how to implement it better
            }
        }
    }
}
