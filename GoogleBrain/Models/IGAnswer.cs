using System.Collections.Generic;

namespace GoogleBrain.Models
{
    public interface IGAnswer
    {
        string CorrectAnswer { get; set; }
        int CorrectAnswerConfidence { get; set; }
        List<GOptions> WrongAnswers { get; set; }
    }
}