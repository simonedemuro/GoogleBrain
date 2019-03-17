using GoogleBrain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace GoogleBrain.ExtensionMethods
{
    public static class TaskOfGAnswesExtensions
    {
        public static List<IGAnswer> ToGAnswerList(this Task<IGAnswer>[] BrainTasks)
        {
            List<IGAnswer> answers = new List<IGAnswer>();

            foreach (var answerFromTask in BrainTasks)
            {
                answers.Add(answerFromTask.Result);
            }
            return answers;
        }
    }
}
