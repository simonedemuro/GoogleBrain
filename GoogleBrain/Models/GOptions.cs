using System;
using System.Collections.Generic;
using System.Text;

namespace GoogleBrain.Models
{
    public class GOptions
    {
        private string value;
        private int likelihood;

        public string Value { get => value; set => this.value = value; }
        public int Likelihood { get => likelihood; set => likelihood = value; }
    }
}
