using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

                Task<IGAnswer>[] answerTasks = new Task<IGAnswer>[Brains.Count];
                int brainCtr = 0;
                foreach (var Brain in Brains)
                {
                    answerTasks[brainCtr] = Task.Factory
                        .StartNew(() => Brain.Value.AnswerQuestion(question, answers));

                    answerTasks[brainCtr]
                        .ContinueWith((t) => Utils.VisualUtils.WriteCorrectAnswer(t.Result, Brain.Key));

                    brainCtr++; 
                }
                Task.WaitAll(answerTasks);
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
