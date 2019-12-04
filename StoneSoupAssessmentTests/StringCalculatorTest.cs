using NUnit.Framework;
using StoneSoupAssessment;

namespace StoneSoupAssessmentTests
{
    [TestFixture]
    public class StringCalculatorTest
    {
        private IStringCalculator _stringCalculator;

        [SetUp]
        public void Init()
        {
            _stringCalculator = new StringCalculator();
        }

        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            //set up
            string numbers = string.Empty;

            //execute
            int actualResult = _stringCalculator.Add(numbers);

            //verify
            Assert.AreEqual(0, actualResult);
        }

        [Test]
        [TestCase("1", 1)]
        [TestCase("110", 110)]
        [TestCase("27", 27)]
        public void Add_OneNumber_ReturnsTheNumber(string number, int expectedResult)
        {
            int actualResult = _stringCalculator.Add(number);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("1,2", 3)]
        [TestCase("3,4", 7)]
        [TestCase("20,56", 76)]
        [TestCase("108,58", 166)]
        public void Add_TwoNumbers_ReturnsTheSumOfThem(string numbers, int expectedResult)
        {
            int actualResult = _stringCalculator.Add(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("1,2,3", 6)]
        [TestCase("11,23,45", 79)]
        [TestCase("1,2,3,4,5,6,7,8,9,10", 55)]
        public void Add_MoreThanTwoNumbers_ReturnTheSumOfThem(string numbers, int expectedResult)
        {
            int actualResult = _stringCalculator.Add(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("1\n2,3", 6)]
        [TestCase("1,\n", 1)]
        [TestCase("1\n2,3\n4,5\n6", 21)]
        public void Add_WhenNewLineBetweenNumbers_ReturnsTheSumOfTheNumbers(string numbers, int expectedResult)
        {
            int actualResult = _stringCalculator.Add(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("//;\n1;2", 3)]
        [TestCase("//!\n3!8!10", 21)]
        [TestCase("//@\n3@8@10", 21)]
        public void Add_WhenCustomDelimiter_ReturnsTheSumOfTheNumbers(string numbers, int expectedResult)
        {
            int actualResult = _stringCalculator.Add(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("-2", "Negatives not allowed: -2")]
        [TestCase("-2, 4, 5", "Negatives not allowed: -2")]
        [TestCase("1\n-2,-6", "Negatives not allowed: -2,-6")]
        [TestCase("//;\n1;2;-7", "Negatives not allowed: -7")]
        public void Add_WhenNegatives_ShouldThrowException(string numbers, string expectedMessage)
        {
            Assert.That(() => _stringCalculator.Add(numbers), Throws.Exception.With.Message.EqualTo(expectedMessage));
        }

        [Test]
        [TestCase("1001,2", 2)]
        [TestCase("1001,100,2000", 100)]
        [TestCase("1001\n2,4,8", 14)]
        [TestCase("//:\n1001:2:90:8", 100)]
        [TestCase("1002,1004,10005", 0)]
        public void Add_WhenBiggerThan1000_ShouldNotBeAdded(string numbers, int expectedResult)
        {
            int actualResult = _stringCalculator.Add(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("//[***]\n1***2***3", 6)]
        [TestCase("//[*]\n1*2*3", 6)]
        [TestCase("//***\n1***2***3", 0)]
        [TestCase("//[[]\n1[2[3", 0)]
        public void Add_WhenDelimiterAnyLength_ReturnsTheSumOfTheNumbers(string numbers, int expectedResult)
        {
            int actualResult = _stringCalculator.Add(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("//[*][%]\n1*2%3", 6)]
        [TestCase("//[*]%\n1*2%3", 1)]
        [TestCase("//[**][%%%]\n1**2%%%3", 6)]
        [TestCase("//[[][**][&&&]\n1[2**3**3&&&4", 10)]
        public void Add_WhenMultipleDelimiters_ReturnsTheSumOfTheNumbers(string numbers, int expectedResult)
        {
            int actualResult = _stringCalculator.Add(numbers);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
