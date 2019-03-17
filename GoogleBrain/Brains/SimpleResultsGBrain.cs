using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using GoogleBrain.Models;
using System.Linq;

namespace GoogleBrain.Brains
{
    public class SimpleResultsGBrain : IBrains
    {
        IGbrainAPI GApi;

        public SimpleResultsGBrain()
        {
            GApi = new GbrainAPI();
        }

        public SimpleResultsGBrain(IGbrainAPI APIs)
        {
            GApi = APIs;
        }

        public IGAnswer AnswerQuestion(string Question, params string[] Answers)
        {
            if (Question.IndexOfAny(@"""#$%&()*+,-./:;<=>@[\]^_`{|}~".ToCharArray()) != -1)
            {
                throw new BadRequestException("the request contains one or more forbidden characters");
            }

            Dictionary<string, long> OptionNumberResults = new Dictionary<string, long>();

            foreach (var ans in Answers)
            {
                OptionNumberResults.Add(ans, GApi.GetNumerOfResults(Question, ans));
            }
            KeyValuePair<string, long> CorrectAns = OptionNumberResults
                .FirstOrDefault(x => x.Value == OptionNumberResults.Values.Max());

            return new GAnswer(CorrectAns.Key, this.GetType().Name);
        }
    }

}
