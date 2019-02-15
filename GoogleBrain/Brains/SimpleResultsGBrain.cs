using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using GoogleBrain.Models;

namespace GoogleBrain.Brains
{
    class SimpleResultsGBrain : IBrains
    {
        public IGAnswer AnswerQuestion(string Question, params string[] Answers)
        {
            throw new NotImplementedException();
        }
    }

}
