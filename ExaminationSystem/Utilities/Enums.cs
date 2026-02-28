using System;
using System.Collections.Generic;
using System.Text;

namespace ExaminationSystem.Utilities
{
    enum MCQAnswer:Byte { NA=0,a=1,b,c,d,e }
    enum ExamMode:Byte {
        Starting,
        Queued,
        Finished
    }
}
