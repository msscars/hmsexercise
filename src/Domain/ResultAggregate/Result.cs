using System;
using System.Collections.Generic;
using System.Text;

namespace Hms.Exercise.Domain.ResultAggregate
{
    public class Result
    {
        public Guid Id { get; set; }

        public int Input { get; set; }

        public int Palindrome { get; set; }

        public int Cycles { get; set; }
    }
}
