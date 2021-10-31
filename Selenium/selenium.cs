using NUnit.Framework;
using System;
using BPCalculator;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium
{
    public class selenium
    {
        IWebDriver webDriver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            webDriver.Navigate().GoToUrl("https://bpcalculatorca-dev.azurewebsites.net/");
        }

        [Test]
        public void LowBloodPressure()
        {
            webDriver.Navigate().GoToUrl("https://bpcalculatorca-dev.azurewebsites.net/");
            webDriver.FindElement(By.Name("BP.Systolic")).Clear();
            webDriver.FindElement(By.Name("BP.Systolic")).SendKeys("70");
            webDriver.FindElement(By.Name("BP.Diastolic")).Clear();
            webDriver.FindElement(By.Name("BP.Diastolic")).SendKeys("60");
            webDriver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(webDriver.FindElement(By.TagName("body")).Text.Contains("Low Blood Pressure"));
        }

        [Test]
        public void IdealBloodPressure()
        {
            webDriver.Navigate().GoToUrl("https://bpcalculatorca-dev.azurewebsites.net/");
            webDriver.FindElement(By.Name("BP.Systolic")).Clear();
            webDriver.FindElement(By.Name("BP.Systolic")).SendKeys("95");
            webDriver.FindElement(By.Name("BP.Diastolic")).Clear();
            webDriver.FindElement(By.Name("BP.Diastolic")).SendKeys("60");
            webDriver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(webDriver.FindElement(By.TagName("body")).Text.Contains("Ideal Blood Pressure"));
        }

        [Test]
        public void PreHighBloodPressure()
        {
            webDriver.Navigate().GoToUrl("https://bpcalculatorca-dev.azurewebsites.net/");
            webDriver.FindElement(By.Name("BP.Systolic")).Clear();
            webDriver.FindElement(By.Name("BP.Systolic")).SendKeys("125");
            webDriver.FindElement(By.Name("BP.Diastolic")).Clear();
            webDriver.FindElement(By.Name("BP.Diastolic")).SendKeys("80");
            webDriver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(webDriver.FindElement(By.TagName("body")).Text.Contains("Pre-High Blood Pressure"));
        }

        [Test]
        public void HighBloodPressure()
        {
            webDriver.Navigate().GoToUrl("https://bpcalculatorca-dev.azurewebsites.net/");
            webDriver.FindElement(By.Name("BP.Systolic")).Clear();
            webDriver.FindElement(By.Name("BP.Systolic")).SendKeys("190");
            webDriver.FindElement(By.Name("BP.Diastolic")).Clear();
            webDriver.FindElement(By.Name("BP.Diastolic")).SendKeys("100");
            webDriver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(webDriver.FindElement(By.TagName("body")).Text.Contains("High Blood Pressure"));
        }

        [Test]
        public void UnkownBloodPressure()
        {

            webDriver.Navigate().GoToUrl("https://bpcalculatorca-dev.azurewebsites.net/");
            webDriver.FindElement(By.Name("BP.Systolic")).Clear();
            webDriver.FindElement(By.Name("BP.Systolic")).SendKeys("100");
            webDriver.FindElement(By.Name("BP.Diastolic")).Clear();
            webDriver.FindElement(By.Name("BP.Diastolic")).SendKeys("90");
            webDriver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(webDriver.FindElement(By.TagName("body")).Text.Contains("No Blood Pressure Found"));
        }

        [Test]
        public void SystolicMustbeGreater()
        {
            webDriver.Navigate().GoToUrl("https://bpcalculatorca-dev.azurewebsites.net/");
            webDriver.FindElement(By.Name("BP.Systolic")).Clear();
            webDriver.FindElement(By.Name("BP.Systolic")).SendKeys("70");
            webDriver.FindElement(By.Name("BP.Diastolic")).Clear();
            webDriver.FindElement(By.Name("BP.Diastolic")).SendKeys("90");
            webDriver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(webDriver.FindElement(By.TagName("body")).Text.Contains("Systolic must be greater than Diastolic"));
        }

        [Test]
        public void InvalidDiastolicValue()
        {


            webDriver.Navigate().GoToUrl("https://bpcalculatorca-dev.azurewebsites.net/");
            webDriver.FindElement(By.Name("BP.Systolic")).Clear();
            webDriver.FindElement(By.Name("BP.Systolic")).SendKeys("90");
            webDriver.FindElement(By.Name("BP.Diastolic")).Clear();
            webDriver.FindElement(By.Name("BP.Diastolic")).Click();
            webDriver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(webDriver.FindElement(By.TagName("body")).Text.Contains("The Diastolic field is required"));
        }

        [Test]
        public void WrongSystolicValue()
        {


            webDriver.Navigate().GoToUrl("https://bpcalculatorca-dev.azurewebsites.net/");
            webDriver.FindElement(By.Name("BP.Systolic")).Clear();
            webDriver.FindElement(By.Name("BP.Systolic")).SendKeys("200");
            webDriver.FindElement(By.Name("BP.Diastolic")).Clear();
            webDriver.FindElement(By.Name("BP.Diastolic")).SendKeys("60");
            webDriver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(webDriver.FindElement(By.TagName("body")).Text.Contains("Invalid Systolic Value"));
        }


        [Test]
        public void WrongDiastolicValue()
        {

            webDriver.Navigate().GoToUrl("https://bpcalculatorca-dev.azurewebsites.net/");
            webDriver.FindElement(By.Name("BP.Systolic")).Clear();
            webDriver.FindElement(By.Name("BP.Systolic")).SendKeys("70");
            webDriver.FindElement(By.Name("BP.Diastolic")).Clear();
            webDriver.FindElement(By.Name("BP.Diastolic")).SendKeys("200");
            webDriver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(webDriver.FindElement(By.TagName("body")).Text.Contains("Invalid Diastolic Value"));

        }

        [Test]
        public void InvalidSystolicValue()
        {
            webDriver.Navigate().GoToUrl("https://bpcalculatorca-dev.azurewebsites.net/");
            webDriver.FindElement(By.Name("BP.Systolic")).Clear();
            webDriver.FindElement(By.Name("BP.Systolic")).Click();
            webDriver.FindElement(By.Name("BP.Diastolic")).Clear();
            webDriver.FindElement(By.Name("BP.Diastolic")).SendKeys("60");
            webDriver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(webDriver.FindElement(By.TagName("body")).Text.Contains("The Systolic field is required"));
        }
    }
}
