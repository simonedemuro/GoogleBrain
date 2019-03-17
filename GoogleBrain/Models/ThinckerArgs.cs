using GoogleBrain.Brains;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleBrain.Models
{
    public class ThinckerArgs
    {
        public Dictionary<string, IBrains> Brains { get; set; }
        public string Question { get; set; }
        public string[] Answers { get; set; }
        public bool EnableConsoleOutput = false;
    }
}
