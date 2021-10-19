using BPCalculator;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Spec.Steps
{

    [Binding]
    class StepDefinition1
    {
        private BloodPressure bloodpressure;

        [When(@"I fill out the mandartory details (.*), (.*) and (.*)")]
        public void WhenIFillOutTheMandartoryDetailsAnd(int p0, int p1, int p2)
        {
            bloodpressure = new BloodPressure()
            {
                AgeType = p0,
                Systolic = p1,
                Diastolic = p2
            };
        }

        [Then(@"the message should be (.*)")]
        public void ThenTheMessageShouldBeLowBloodPressure(string Result)
        {
            BPCategory category = bloodpressure.Category;
            Assert.AreEqual(category, Result);
        }

    }
}