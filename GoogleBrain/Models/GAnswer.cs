using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleBrain.Models
{
    public class GAnswer : IGAnswer
    {
        public string CorrectAnswer { get; set; }
        public int CorrectAnswerConfidence { get; set; }
        public List<GOptions> WrongAnswers { get; set; }

        public GAnswer()
        {

        }

        public GAnswer(string correctAnswer, int correctAnswerConfidence)
        {
            CorrectAnswer = correctAnswer;
            CorrectAnswerConfidence = correctAnswerConfidence;
        }
    }
}
