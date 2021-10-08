using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Selenium
{
    public class Selenium
    {
        public String chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver");
        private const string URL = "https://bloodpressure-ca-staging.azurewebsites.net";
        //IWebDriver webDriver = new ChromeDriver();


        [SetUp]
        public void Setup()
        {
            //webDriver.Navigate().GoToUrl
            if (chromeDriverPath is null)
            {
                chromeDriverPath = ".";                 // for IDE
            }
        }

        [Test]
        public void WebTitle()
        {
            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            driver.Navigate().GoToUrl(URL);
            string pageTitle = driver.Title;
            Assert.AreEqual("BP Category Calculator - BPCalculator", pageTitle);
        }

        [Test]
        public void LowBloodPressure()
        {
            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Name("BP.Systolic")).Clear();
            driver.FindElement(By.Name("BP.Systolic")).SendKeys("70");
            driver.FindElement(By.Name("BP.Diastolic")).Clear();
            driver.FindElement(By.Name("BP.Diastolic")).SendKeys("60");
            driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("Low Blood Pressure"));
        }

        [Test]
        public void IdealBloodPressure()
        {
            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Name("BP.Systolic")).Clear();
            driver.FindElement(By.Name("BP.Systolic")).SendKeys("95");
            driver.FindElement(By.Name("BP.Diastolic")).Clear();
            driver.FindElement(By.Name("BP.Diastolic")).SendKeys("60");
            driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("Ideal Blood Pressure"));
        }

        [Test]
        public void PreHighBloodPressure()
        {
            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Name("BP.Systolic")).Clear();
            driver.FindElement(By.Name("BP.Systolic")).SendKeys("125");
            driver.FindElement(By.Name("BP.Diastolic")).Clear();
            driver.FindElement(By.Name("BP.Diastolic")).SendKeys("80");
            driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("Pre-High Blood Pressure"));
        }

        [Test]
        public void HighBloodPressure()
        {
            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Name("BP.Systolic")).Clear();
            driver.FindElement(By.Name("BP.Systolic")).SendKeys("190");
            driver.FindElement(By.Name("BP.Diastolic")).Clear();
            driver.FindElement(By.Name("BP.Diastolic")).SendKeys("100");
            driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("High Blood Pressure"));
        }

        [Test]
        public void UnkownBloodPressure()
        {
            using IWebDriver driver = new ChromeDriver(chromeDriverPath);
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.Name("BP.Systolic")).Clear();
            driver.FindElement(By.Name("BP.Systolic")).SendKeys("100");
            driver.FindElement(By.Name("BP.Diastolic")).Clear();
            driver.FindElement(By.Name("BP.Diastolic")).SendKeys("90");
            driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
            Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("No Blood Pressure Found"));
        }


        [Test]
        public void SystolicMustbeGreater()
        {
           
                using IWebDriver driver = new ChromeDriver(chromeDriverPath);
                driver.Navigate().GoToUrl(URL);
                driver.FindElement(By.Name("BP.Systolic")).Clear();
                driver.FindElement(By.Name("BP.Systolic")).SendKeys("70");
                driver.FindElement(By.Name("BP.Diastolic")).Clear();
                driver.FindElement(By.Name("BP.Diastolic")).SendKeys("90");
                driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
                Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("Systolic must be greater than Diastolic"));
            

        }

        [Test]
        public void InvalidDiastolicValue()
        {
            
                using IWebDriver driver = new ChromeDriver(chromeDriverPath);
                driver.Navigate().GoToUrl(URL);
                driver.FindElement(By.Name("BP.Systolic")).Clear();
                driver.FindElement(By.Name("BP.Systolic")).SendKeys("90");
                driver.FindElement(By.Name("BP.Diastolic")).Clear();
                driver.FindElement(By.Name("BP.Diastolic")).Click();
                driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
                Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("The Diastolic field is required"));

            

        }

        [Test]
        public void WrongSystolicValue()
        {
            
                using IWebDriver driver = new ChromeDriver(chromeDriverPath);
                driver.Navigate().GoToUrl(URL);
                driver.FindElement(By.Name("BP.Systolic")).Clear();
                driver.FindElement(By.Name("BP.Systolic")).SendKeys("200");
                driver.FindElement(By.Name("BP.Diastolic")).Clear();
                driver.FindElement(By.Name("BP.Diastolic")).SendKeys("60");
                driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
                Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("Invalid Systolic Value"));

            

        }

        [Test]
        public void WrongDiastolicValue()
        {
            
                using IWebDriver driver = new ChromeDriver(chromeDriverPath);
                driver.Navigate().GoToUrl(URL);
                driver.FindElement(By.Name("BP.Systolic")).Clear();
                driver.FindElement(By.Name("BP.Systolic")).SendKeys("70");
                driver.FindElement(By.Name("BP.Diastolic")).Clear();
                driver.FindElement(By.Name("BP.Diastolic")).SendKeys("200");
                driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
                Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("Invalid Diastolic Value"));

            

        }

        [Test]
        public void InvalidSystolicValue()
        {
            
                using IWebDriver driver = new ChromeDriver(chromeDriverPath);
                driver.Navigate().GoToUrl(URL); 
                driver.FindElement(By.Name("BP.Systolic")).Clear();
                driver.FindElement(By.Name("BP.Systolic")).Click();
                driver.FindElement(By.Name("BP.Diastolic")).Clear();
                driver.FindElement(By.Name("BP.Diastolic")).SendKeys("60");
                driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
                Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("The Systolic field is required"));
            

        }

        [TearDown]
        public void Teardown()
        {
                using IWebDriver driver = new ChromeDriver(chromeDriverPath);
                driver.Quit();  
        }

    }
}