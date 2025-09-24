using NUnit;
using LeetCode.Medium.StringToIntegerAtoi;
using LeetCode.Medium.ContainerWithMostWater;
using LeetCode.Medium.IntegerToRoman;
using LeetCode.Medium._3Sum;
using LeetCode.Medium.LetterCombinationPhoneNumber;
using LeetCode.Medium._3SumCloset;

namespace LeetCode.Tests.Medium
{
    public class MediumTestCases
    {
        private StringToIntegerAtoi _stringToInteger;
        private ContainerWater _containerWater;
        private IntegerToRoman _integerToRoman;
        private ThreeSumClass _threeSum;
        private LetterConbinationPhoneNumber _letterConbinationPhoneNumber;
        private threeSumClosetSolution _threeSumClosetSolution;


        [SetUp]
        public void SetUp()
        {
            _stringToInteger = new StringToIntegerAtoi();
            _containerWater = new ContainerWater();
            _integerToRoman = new IntegerToRoman();
            _threeSum = new ThreeSumClass();
            _letterConbinationPhoneNumber = new LetterConbinationPhoneNumber();
            _threeSumClosetSolution = new threeSumClosetSolution();
        }

        [Test]
        [TestCase("42", ExpectedResult = 42)]
        [TestCase("   -042", ExpectedResult = -42)]
        [TestCase("1337c0d3", ExpectedResult = 1337)]
        [TestCase("0-1", ExpectedResult = 0)]
        [TestCase("words and 987", ExpectedResult = 0)]
        [TestCase("+98", ExpectedResult = +98)]
        [TestCase("+-12", ExpectedResult = 0)]
        [TestCase("-", ExpectedResult = 0)]
        [TestCase("--", ExpectedResult = 0)]
        [TestCase("21474836460", ExpectedResult = 2147483647)]
        [TestCase("  -0012a42", ExpectedResult = -12)]
        public int CheckStringToIntegerConversion(string stringToConvert)
        {
            return _stringToInteger.MyAtoi(stringToConvert);
        }

        [Test]
        [TestCase(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, ExpectedResult = 49)]
        [TestCase(new int[] { 1, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { }, ExpectedResult = 0)]
        public int CheckWithTheMostWater(params int[] height) {
            return _containerWater.MaxArea(height);
        }

        [Test]
        [TestCase(4, ExpectedResult = "IV")]
        [TestCase(3749, ExpectedResult = "MMMDCCXLIX")]
        [TestCase(58, ExpectedResult = "LVIII")]
        [TestCase(1994, ExpectedResult = "MCMXCIV")]
        [TestCase(44, ExpectedResult = "XLIV")]
        [TestCase(493, ExpectedResult = "CDXCIII")]
        [TestCase(1, ExpectedResult = "I")]
        [TestCase(10, ExpectedResult = "X")]
        [TestCase(605, ExpectedResult = "DCV")]
        [TestCase(20, ExpectedResult = "XX")]
        public string CheckIntegerToRoman(int num)
        {
            return _integerToRoman.IntToRoman(num);
        }

        [Test]
        [TestCase(new[] { -1, 2, 1, -4 }, 1, ExpectedResult = 2)]
        [TestCase(new[] { 0, 0, 0 }, 0, ExpectedResult = 0)]
        [TestCase(new[] { 4, 0, 5, -5, 3, 3, 0, -4, -5 }, -2, ExpectedResult = -2)]
        [TestCase(new[] { 0, 3, 97, 102, 200 },300, ExpectedResult = 300)]
        [TestCase(new[] { -84, 92, 26, 19, -7, 9, 42, -51, 8, 30, -100, -13, -38 },78, ExpectedResult =77)]
        public int Check3SumClosest(int[] nums, int target)
        {
            return _threeSumClosetSolution.ThreeSumClosestImproved(nums,target);
        }

        [Test]
        public void Check3sum(){
            //arrange
            int[] num = [-1, 0, 1, 2, -1, -4];
            List<List<int>> expectedResult = new List<List<int>>()
            {
                new List<int>() { -1, -1, 2 },
                new List<int>() { -1, 0, 1 },
            };

            //Act
            var result = _threeSum.ThreeSumRight(num);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void Check3sumCeroValues()
        {
            //arrange
            int[] num = [0,0,0];
            List<List<int>> expectedResult = new List<List<int>>()
            {
                new List<int>() {0,0,0},
            };

            //Act
            var result = _threeSum.ThreeSumRight(num);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void Check3sumNotValues()
        {
            //arrange
            int[] num = [0, 1, 1];
            List<List<int>> expectedResult = new List<List<int>>()
            {
            };

            //Act
            var result = _threeSum.ThreeSumRight(num);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void Check3sumDifferent()
        {
            //arrange
            int[] num = [-1, 0, 1, 0];
            List<List<int>> expectedResult = new List<List<int>>()
            {
                new List<int> {-1,0,1},
            };

            //Act
            var result = _threeSum.ThreeSumRight(num);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        public void Check3BigNumbers()
        {
            //arrange
            int[] num = [2, -3, 0, -2, -5, -5, -4, 1, 2, -2, 2, 0, 2, -4, 5, 5, -10];
            List<List<int>> expectedResult = new List<List<int>>()
            {
                new List<int> {-10,5,5},
                new List<int> {-5,0,5},
                new List<int> {-4,2,2},
                new List<int> {-3,-2,5},
                new List<int> {-3,1,2},
                new List<int> {-2,0,2},
            };

            //Act
            var result = _threeSum.ThreeSumRight(num);

            //Assert
            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [Test]
        [TestCase("23", ExpectedResult = new string[] { "ad","ae", "af", "bd","be","bf", "cd", "ce","cf" })]
        public IList<string> LetterCompinationMethod(string digits)
        {
            return _letterConbinationPhoneNumber.LetterCombinations(digits);
        }


        //[Test]
        //[TestCase("23", ExpectedResult = new string[] {"ad", "ae", ""})]
        //public IList<string> SuccessLetterCombinations(string digits)
        //{

        //}

    }
}
