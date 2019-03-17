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
        private ThinckerArgs ThinckerArgs;

        public ConcurrentlyTinker(ThinckerArgs thinckerArgs)
        {
            this.ThinckerArgs = thinckerArgs;
        }

        public List<IGAnswer> GetAnswers()
        {
            int brainsNumber = ThinckerArgs.Brains.Count;
            Task<IGAnswer>[] answersFromTasks = new Task<IGAnswer>[brainsNumber];

            int brainCtr = 0;
            // TODO: start task in order from the slower to the faster
            foreach (var Brain in ThinckerArgs.Brains)
            {
                answersFromTasks[brainCtr] = Task.Factory
                    .StartNew(() => Brain.Value.AnswerQuestion(ThinckerArgs.Question, ThinckerArgs.Answers));

                if (ThinckerArgs.EnableConsoleOutput)
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
