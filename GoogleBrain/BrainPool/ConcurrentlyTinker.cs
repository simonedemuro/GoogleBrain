using GoogleBrain.Brains;
using GoogleBrain.ExtensionMethods;
using GoogleBrain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoogleBrain.BrainPool
{
    class ConcurrentlyTinker
    {
        public List<IGAnswer> GetAnswers(ThinckerArgs thinkerArgs)
        {
            int brainsNumber = thinkerArgs.Brains.Count;
            Task<IGAnswer>[] answersFromTasks = new Task<IGAnswer>[brainsNumber];

            int brainCtr = 0;
            // TODO: start task in order from the slower to the faster
            foreach (var Brain in thinkerArgs.Brains)
            {
                answersFromTasks[brainCtr] = Task.Factory
                    .StartNew(() => Brain.Value.AnswerQuestion(thinkerArgs.Question, thinkerArgs.Answers));

                if (thinkerArgs.EnableConsoleOutput)
                {
                    answersFromTasks[brainCtr]
                        .ContinueWith((t) => Utils.VisualUtils.WriteCorrectAnswer(t.Result, Brain.Key));
                }
                brainCtr++;
            }
            Task.WaitAll(answersFromTasks);
            return answersFromTasks.ToGAnswerList();
        }
    }
}
