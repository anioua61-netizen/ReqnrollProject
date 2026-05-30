using EconnexionTestAuto.Actions.ApplicationActions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll.BoDi;

namespace EconnexionTestAuto.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private readonly IObjectContainer _container;
        private IWebDriver _driver;
        private EconnexionAppActions _applicationActions;

        public Hooks1(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            // 1. DRIVER
            _driver = new ChromeDriver();
            _container.RegisterInstanceAs<IWebDriver>(_driver);

            // 2. REGISTER SERVICES
            _container.RegisterTypeAs<LoginActions, LoginActions>();
            _container.RegisterTypeAs<EconnexionAppActions, EconnexionAppActions>();

            // 3. RESOLVE AFTER REGISTRATION (IMPORTANT)
            _applicationActions = _container.Resolve<EconnexionAppActions>();

            // 4. USE IT
            _applicationActions.StartApplication();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}