using BPCalculator;
using NUnit.Framework;
using TechTalk.SpecFlow;
using System;

namespace Spec.Steps
{

    [Binding]
    class StepDefinition1
    {
        private BloodPressure bloodpressure;

        [Given()]
        [When(@" the Systolic is (.*) and Diastolic is (.*)")]
        public void theSystolicis(int p0, int p1)
        {
            bloodpressure = new BloodPressure();
            {
                bloodpressure.AgeType = 1;
                bloodpressure.Systolic = p0;
                bloodpressure.Diastolic = p1;
                Console.WriteLine(p0);

            };
        } 
         
        [Then(@"the bloodpressure be (.*)")]
        public void ThenTheMessageShouldBeLowBloodPressure(string Result)
        {
            BPCategory category = bloodpressure.Category;
            Assert.AreEqual(category, Result);
            Console.WriteLine(Result);
        }

    }
}
