using LeetCode.Easy;
using NUnit;

namespace LeetCode.Tests.Easy
{
    public class EasyTest
    {
        private readonly TwoSum _twoSum;
        private readonly ValidateParentheses _validParenthsClass;

        public EasyTest()
        {
            _twoSum = new TwoSum();
            _validParenthsClass = new ValidateParentheses();
        }

        [Test]
        [TestCase(9, new int[] { 2, 7, 11, 15 })]
        public void TwoSum_Success(int target, params int[] nums)
        {
            //Arrange
            int[] exectedResult = new int[] { };

            //Act
            var result = _twoSum.TwoSum_case(nums, target);

            //Assert

        }

        [Test]
        [TestCase("()[]{}", ExpectedResult = true)]
        [TestCase("(]", ExpectedResult = false)]
        [TestCase("([])", ExpectedResult = true)]
        [TestCase("(){}}{", ExpectedResult = false)]
        public bool ValidaParamaters_test(string s)
        {

            // Act
            var validParamathers = _validParenthsClass.IsValid(s);

            // Assert
            return validParamathers;
        }
    }
}
