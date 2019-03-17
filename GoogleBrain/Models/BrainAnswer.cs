using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleBrain.Models
{
    public class BrainAnswer
    {
        public List<IGAnswer> brainsAnswers;
        public string brainIdentifier;

        public BrainAnswer(List<IGAnswer> brainsAnswers, string brainIdentifier)
        {
            this.brainsAnswers = brainsAnswers;
            this.brainIdentifier = brainIdentifier;
        }
    }
}
