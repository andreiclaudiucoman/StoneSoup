using StoneSoupAssessment.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneSoupAssessment
{
    public class StringCalculator : IStringCalculator
    {
        public int Add(string numbers)
        {
            IList<int> validNumbers = StringCalculatorHelper.GetListNumbersAsInt(numbers);

            return validNumbers.Sum();
        }
    }
}
