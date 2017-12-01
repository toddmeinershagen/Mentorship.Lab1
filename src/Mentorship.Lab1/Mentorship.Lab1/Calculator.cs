using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mentorship.Lab1
{
    public class Calculator
    {
        private readonly string _outputFormat;

        public Calculator(string outputFormat)
        {
            _outputFormat = outputFormat;
        }

        public int Add(int operand1, int operand2)
        {
            return operand1 + operand2;
        }

        public int Subtract(int operand1, int operand2)
        {
            return operand1 - operand2;
        }

        public string Add(int operand1, int operand2, string test)
        {
            return string.Format(_outputFormat, Add(operand1, operand2));
        }
    }
}
