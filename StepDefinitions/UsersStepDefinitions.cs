using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V125.DOM;
using OpenQA.Selenium.Support.UI;

namespace Teladoc.StepDefinitions
{
    [Binding]
    public sealed class UsersStepDefinitions
    {
        private IWebDriver driver;

        public UsersStepDefinitions(IWebDriver driver) { this.driver = driver; }
        
        [Given(@"Open the browser")]
        public void GivenOpenTheBrowser()
        {
        }

        [When(@"Enter the URL")]
        public void WhenEnterTheURL()
        {
            driver.Url = "http://www.way2automation.com/angularjs-protractor/webtables/";
        }

        [Then(@"Add a new User")]
        public void ThenAddANewUser()
        {
            driver.FindElement(By.XPath("//button[@type='add']")).Click();
            driver.FindElement(By.XPath("//input[@name='FirstName']")).SendKeys("TestPri");
            driver.FindElement(By.XPath("//input[@name='UserName']")).SendKeys("TestUser");
            driver.FindElement(By.XPath("//input[@name='Password']")).SendKeys("pass1");
            driver.FindElement(By.XPath("//input[@value='15']")).Click();

            var role = driver.FindElement(By.XPath("//select[@name='RoleId']"));
            var selectElement = new SelectElement(role);
            selectElement.SelectByText("Sales Team");

            driver.FindElement(By.XPath("//input[@name='Email']")).SendKeys("test@test.cz");
            driver.FindElement(By.XPath("//input[@name='Mobilephone']")).SendKeys("1234567890");

            driver.FindElement(By.XPath("//button[normalize-space()='Save']")).Click();

            var elemTable = driver.FindElement(By.XPath("//tbody"));

            // Fetch all Row of the table
            List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));

            List<IWebElement> lstTdElem = new List<IWebElement>(lstTrElem[0].FindElements(By.TagName("td")));

            //Validate if the user is added
            Assert.AreEqual("TestUser", lstTdElem[2].Text, "Error adding a new user");
        }

        [Then(@"Delete a User")]
        public void ThenDeleteAUser()
        {
            int count = 0;

            var elemTable = driver.FindElement(By.XPath("//tbody"));

            // Fetch all Rows of the table
            List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));

            foreach (var elemTr in lstTrElem)
            {
                // Fetch the columns from a particuler row
                List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));

                count++;
                string td = lstTdElem[2].Text.ToString();
                if (lstTdElem[1].Text.Equals("Novak"))
                {
                    var button = driver.FindElement(By.XPath("//body[1]/table[1]/tbody[1]/tr[" + count + "]/td[11]/button[1]"));
                    button.Click();
                    driver.FindElement(By.XPath("//button[@class='btn ng-scope ng-binding btn-primary']")).Click();

                    var actual = driver.FindElement(By.XPath("//body[1]/table[1]/tbody[1]/tr[" + count + "]/td[11]/button[1]"));
                    Assert.AreNotEqual("Novak", actual, "Error deleting the user");
                    break;
                }
            }        
            
        }
    }
}
