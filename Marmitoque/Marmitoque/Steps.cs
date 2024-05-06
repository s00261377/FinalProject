using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marmitoque
{
    public class Steps
    {
        public string description { get; set; }

        public int stepNumber { get; }

        public float duration;

        public string StepNumberFormatted => "Step " + stepNumber + ":\n";

        public Steps(string Description, float Duration, int StepNumber) 
        { 
            description = Description;
            duration = Duration;
            stepNumber = StepNumber;
        }
    }
}
