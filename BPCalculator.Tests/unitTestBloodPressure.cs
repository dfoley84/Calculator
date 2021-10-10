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
                AgeType = 1,
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
                AgeType = 1,
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
                AgeType = 1,
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
                AgeType = 1,
                Systolic = 140,
                Diastolic = 91
            };
            BPCategory category = bloodpressure.Category;
            Assert.AreEqual(BPCategory.High, category);
        }


        [Test]
        public void TeenLowBloodPressure()
        {
            BloodPressure bloodpressure = new BloodPressure()
            {
                AgeType = 2,
                Systolic = 71,
                Diastolic = 41
            };
            BPCategory category = bloodpressure.Category;
            Assert.AreEqual(BPCategory.Low, category);
        }

        [Test]
        public void TeenNormalBloodPressure()
        {
            BloodPressure bloodpressure = new BloodPressure()
            {
                AgeType = 2,
                Systolic = 106,
                Diastolic = 78
            };
            BPCategory category = bloodpressure.Category;
            Assert.AreEqual(BPCategory.Ideal, category);
        }

        [Test]
        public void TeenHBloodPressure()
        {
            BloodPressure bloodpressure = new BloodPressure()
            {
                AgeType = 2,
                Systolic = 118,
                Diastolic = 80
            };
            BPCategory category = bloodpressure.Category;
            Assert.AreEqual(BPCategory.High, category);
        }
    }
}

    