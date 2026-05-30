using EconnexionTestAuto.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconnexionTestAuto.Actions.ApplicationActions
{
    public class EconnexionAppActions
    {
        private readonly IWebDriver _driver;
        private readonly LoginActions _loginPage;

        public EconnexionAppActions(
            IWebDriver driver,
            LoginActions loginPage)
        {
            _driver = driver;
           _loginPage = loginPage;
        }

        public void StartApplication()
        {
            _driver.Navigate().GoToUrl(TestConfig.BaseUrl);

            _loginPage.EnterUsername(TestConfig.Username);
            _loginPage.EnterPassword(TestConfig.Password);
            _loginPage.ClickLogin();
        }
    }
}
