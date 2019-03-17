using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleBrain;
using GoogleBrain.BrainPool;
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
                string usrQuestion = Console.ReadLine();
                Console.Write("Type possible answers comma separed > ");
                string[] usrAnswers = Console.ReadLine().Split(',');

                ThinckerArgs thinckerArgs = new ThinckerArgs()
                {
                    Question = usrQuestion,
                    Answers = usrAnswers,
                    Brains = Brains,
                    EnableConsoleOutput = false
                };
                ConcurrentlyTinker concurrentlyTinker = new ConcurrentlyTinker(thinckerArgs);
                List<IGAnswer> brainsAnswers = concurrentlyTinker.GetAnswers();

                foreach (var answer in brainsAnswers)
                {
                    Console.WriteLine(answer.Interlocutor + 
                        " Says: " + " the correct answer is: "  + answer.CorrectAnswer);
                }
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
