using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hms.Exercise.Domain.Services
{
    public class Transform : ITransform
    {
        private int cyclesNeeded = 0;

        public int CyclesNeeded { get => cyclesNeeded; }

        public int Palindrome(int n)
        {
            if (n < 1 || n > 10000)
            {
                throw new ArgumentOutOfRangeException("n", "input must be greather than 1 and smaller than 10000.");
            }
            this.cyclesNeeded = 0;
            var result = -1;

            if (this.IsPalindrome(n))
            {
                return n;
            }

            var isPalindrome = false;
            var temp = n;

            while(!isPalindrome)
            {
                this.cyclesNeeded++;
                temp += this.ReverseInt(temp);
                if(this.IsPalindrome(temp))
                {
                    result = temp;
                    isPalindrome = true;
                }

                if (temp > 1000000)
                {
                    return -1;
                }
            }

            return result;
        }



        private int ReverseInt(int input)
        {
            return int.Parse(string.Join(string.Empty, input.ToString().Reverse()));
        }

        private bool IsPalindrome(int input)
        {
            var n = input;
            var rev = 0;
            while (input > 0)
            {
                var dig = input % 10;
                rev = rev * 10 + dig;
                input /= 10;
            }

            return n == rev;
        }
    }
}
