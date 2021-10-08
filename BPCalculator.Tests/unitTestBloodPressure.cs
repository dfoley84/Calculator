using NUnit.Framework;
using BPCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace BPCalculator.Tests
{
    [TestFixture]
    public class UnitTestBloodPressure
    {
        [Test]
        public void LowBloodPressure()
        {
            BloodPressure bloodpressure = new BloodPressure()
            {
                Systolic = 70,
                Diastolic = 40
            };
            BPCategory category = bloodpressure.Category;
            Assert.AreEqual(BPCategory.Low, category);
        }
        [Test]
        public void IdealBloodPressure()
        {
            BloodPressure bloodpressure = new BloodPressure()
            {
                Systolic = 90,
                Diastolic = 70
            };
            BPCategory category = bloodpressure.Category;
            Assert.AreEqual(BPCategory.Ideal, category);
        }

        [Test]
        public void PreHighBloodPressure()
        {
            BloodPressure bloodpressure = new BloodPressure()
            {
                Systolic = 120,
                Diastolic = 81
            };
            BPCategory category = bloodpressure.Category;
            Assert.AreEqual(BPCategory.PreHigh, category);
        }

        [Test]
        public void HighBloodPressure()
        {
            BloodPressure bloodpressure = new BloodPressure()
            {
                Systolic = 140,
                Diastolic = 91
            };
            BPCategory category = bloodpressure.Category;
            Assert.AreEqual(BPCategory.High, category);
        }
    }
}
