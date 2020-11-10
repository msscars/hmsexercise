using System;
using System.Collections.Generic;
using System.Text;

namespace Hms.Exercise.Domain.Services
{
    public interface ITransform
    {
        public int CyclesNeeded { get; }

        int Palindrome(int n);
    }
}
