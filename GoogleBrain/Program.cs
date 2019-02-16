using System;
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
            SimpleResultsGBrain SimplestBrain = new SimpleResultsGBrain();
            Utils.VisualUtils.PrintHeader();
        
            while (true)
            {
                Console.Write("Type a question > ");
                string question = Console.ReadLine();
                Console.Write("Type possible answers comma separed > ");
                string[] answers = Console.ReadLine().Split(',');

                IGAnswer CorrectAns = SimplestBrain.AnswerQuestion(question, answers);
                Utils.VisualUtils.WriteCorrectAnswer(CorrectAns);
            }

            Console.Read();
        }
    }
}
