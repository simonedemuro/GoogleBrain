using GoogleBrain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleBrain.Utils
{
    class VisualUtils
    {
        public static void PrintHeader()
        {
            Console.WriteLine(@"

       _---~~(~~-_.      ___
     _{        )   )       _______
   ,   ) -~~- ( ,-' )_
  (  `-,_..`., )-- '_,)          ---------------------------
 ( ` _)  (  -~( -_ `,  }              -------------------------
 (_-  _  ~_-~~~~`,  ,' )                    ----------------------------- GBrain Alpha
   `~ -^(    __;-,((()))              -------------------------
         ~~~~ {_ -_(())           --------------------
                `\  }       ___
                  { }

------------------------------------------------
Play with the simplest AI, type a question and some potential answers.
");
        }
        public static void WriteCorrectAnswer(IGAnswer CorrectAns)
        {
            Console.Write("\nthe correct Answer is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(CorrectAns.CorrectAnswer);
            Console.ResetColor();
        }

    }
}
