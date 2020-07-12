using CH06_SpecFlow.Implementation;
using NUnit.Framework;
using TechTalk.SpecFlow;
namespace CH06_SpecFlow
{
    [Binding]
    public class CalculatorSteps
    {
        private Calculator _calculator = new Calculator();
        private int _result;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            _calculator.FirstNumber = number;
        }

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int number)
        {
            _calculator.SecondNumber = number;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            _result = _calculator.Add();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedResult)
        {
            Assert.AreEqual(expectedResult, _result);
        }
    }
}
