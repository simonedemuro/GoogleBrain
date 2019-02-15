using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleBrain.Models
{
    public class GAnswer : IGAnswer
    {
        private string correctAnswer;
        private int correctAnswerConfidence;

        private List<GOptions> wrongAnswers;

        public string CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
        public int CorrectAnswerConfidence { get => correctAnswerConfidence; set => correctAnswerConfidence = value; }
        public List<GOptions> WrongAnswers { get => wrongAnswers; set => wrongAnswers = value; }
    }
}
