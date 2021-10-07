using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Selenium
{
    public class selenium
    {
        //IWebDriver webDriver = new ChromeDriver();


        [SetUp]
        public void Setup()
        {
            // this.webAppUri = testContextInstance.Properties["webAppUri"].ToString();
            //webDriver.Navigate().GoToUrl
        }

        [Test]
        public void LowBloodPressure()
        {

            String chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver");
            if (chromeDriverPath is null)
            {
                chromeDriverPath = ".";                 // for IDE
            }

            using (IWebDriver driver = new ChromeDriver(chromeDriverPath))
            {

                driver.Navigate().GoToUrl("https://bloodpressure-ca-staging.azurewebsites.net");
                driver.FindElement(By.Name("BP.Systolic")).Clear();
                driver.FindElement(By.Name("BP.Systolic")).SendKeys("70");
                driver.FindElement(By.Name("BP.Diastolic")).Clear();
                driver.FindElement(By.Name("BP.Diastolic")).SendKeys("60");
                driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
                Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("Low Blood Pressure"));
            }
        }

        [Test]
        public void IdealBloodPressure()
        {
            String chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver");
            if (chromeDriverPath is null)
            {
                chromeDriverPath = ".";                 // for IDE
            }

            using (IWebDriver driver = new ChromeDriver(chromeDriverPath))
            {
                driver.Navigate().GoToUrl("https://bloodpressure-ca-staging.azurewebsites.net");
                driver.FindElement(By.Name("BP.Systolic")).Clear();
                driver.FindElement(By.Name("BP.Systolic")).SendKeys("95");
                driver.FindElement(By.Name("BP.Diastolic")).Clear();
                driver.FindElement(By.Name("BP.Diastolic")).SendKeys("60");
                driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
                Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("Ideal Blood Pressure"));
            }
        }

        [Test]
        public void PreHighBloodPressure()
        {
            String chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver");
            if (chromeDriverPath is null)
            {
                chromeDriverPath = ".";                 // for IDE
            }

            using (IWebDriver driver = new ChromeDriver(chromeDriverPath))
            {
                driver.Navigate().GoToUrl("https://bloodpressure-ca-staging.azurewebsites.net");
                driver.FindElement(By.Name("BP.Systolic")).Clear();
                driver.FindElement(By.Name("BP.Systolic")).SendKeys("125");
                driver.FindElement(By.Name("BP.Diastolic")).Clear();
                driver.FindElement(By.Name("BP.Diastolic")).SendKeys("80");
                driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
                Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("Pre-High Blood Pressure"));
            }
        }

        [Test]
        public void HighBloodPressure()
        {
            String chromeDriverPath = Environment.GetEnvironmentVariable("ChromeWebDriver");
            if (chromeDriverPath is null)
            {
                chromeDriverPath = ".";                 // for IDE
            }

            using (IWebDriver driver = new ChromeDriver(chromeDriverPath))
            {
                driver.Navigate().GoToUrl("https://bloodpressure-ca-staging.azurewebsites.net");
                driver.FindElement(By.Name("BP.Systolic")).Clear();
                driver.FindElement(By.Name("BP.Systolic")).SendKeys("190");
                driver.FindElement(By.Name("BP.Diastolic")).Clear();
                driver.FindElement(By.Name("BP.Diastolic")).SendKeys("100");
                driver.FindElement(By.XPath("//input[@value='Submit']")).Submit();
                Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("High Blood Pressure"));

                driver.Quit();
            }
        }
    }
}
