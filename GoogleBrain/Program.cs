using System;
using System.Collections.Generic;
using GoogleBrain;
using GoogleBrain.Brains;
using GoogleBrain.Models;

namespace GoogleBrain
{
    class Program
    {
        static void Main(string[] args)
        {
            GbrainAPI g = new GbrainAPI();
            Dictionary<string, IBrains> Brains = new Dictionary<string, IBrains>
            {
                { "Simplest", new SimpleResultsGBrain() },
                { "FindInSearch", new FindResultGBrain()}
            };

            Utils.VisualUtils.PrintHeader();

            while (true)
            {
                Console.Write("Type a question > ");
                string question = Console.ReadLine();
                Console.Write("Type possible answers comma separed > ");
                string[] answers = Console.ReadLine().Split(',');

                foreach (var Brain in Brains)
                {
                    IGAnswer correctAnswer = Brain.Value.AnswerQuestion(question, answers);
                    Utils.VisualUtils.WriteCorrectAnswer(correctAnswer, Brain.Key);
                }
                Console.WriteLine();
            }

            Console.Read();
        }
    }
}
