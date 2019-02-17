using System;
using System.Collections.Generic;
using System.Text;
using GoogleBrain.Models;
using System.Linq;

namespace GoogleBrain.Brains
{
    class FindResultGBrain : IBrains
    {
        IGbrainAPI GApi;

        public FindResultGBrain()
        {
            GApi = new GbrainAPI();
        }

        public FindResultGBrain(IGbrainAPI gApi)
        {
            GApi = gApi;
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
                OptionNumberResults.Add(ans, GApi.GetNumberOfOccourrences(Question, ans));
            }
            KeyValuePair<string, long> CorrectAns = OptionNumberResults
                .FirstOrDefault(x => x.Value == OptionNumberResults.Values.Max());

            return new GAnswer(CorrectAns.Key, 10);
        }
    }
}
