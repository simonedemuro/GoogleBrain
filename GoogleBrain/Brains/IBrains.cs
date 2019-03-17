using System;
using System.Collections.Generic;
using System.Text;
using GoogleBrain.Models;

namespace GoogleBrain.Brains
{
    public interface IBrains
    {
        /// <summary>
        /// This Method performs its calculation to determine the correct answer given:
        ///     - Question 
        ///     - List of possible Answers 
        /// </summary>
        /// <param name="Question">The question to be submetted to the engine</param>
        /// <param name="Answers">Potential Answer to the previus question</param>
        /// <returns></returns>
        IGAnswer AnswerQuestion(string Question, params string[] Answers);
    }
}
