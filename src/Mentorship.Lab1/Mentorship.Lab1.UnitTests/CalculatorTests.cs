using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Mentorship.Lab1.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [TestCase(2, 5, 7)]
        [TestCase(10, -1, 9)]
        public void given_two_operands_when_adding_then_should_return_sum_of_two_operands(int operand1, int operand2, int expected)
        {
            //act
            var calculator = new Calculator("Add Results:  {0}");
            var result = calculator.Add(operand1, operand2);

            var result2 = calculator.Add(1, 2, "");
            //assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void given_two_operands_when_subtracting_then_should_return_difference_of_two_operands()
        {
            //arrange
            var operand1 = 5;
            var operand2 = 2;

            //act
            var calculator = new Calculator("");
            var result = calculator.Subtract(operand1, operand2);

            //assert
            Assert.That(result, Is.EqualTo(operand1-operand2));
        }
    }
}
