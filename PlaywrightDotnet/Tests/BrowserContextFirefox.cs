using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{
    [TestFixture]
    public class BrowserContextFirefox
    {

        // Issue opening page in same browser context : https://github.com/microsoft/playwright/issues/3696

        [Test]
        public async Task Test_FirefoxAsync()
        {

            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Channel = "firefox"
            });

            // one browser context
            var context = await browser.NewContextAsync();

            // page 1
            var page = await context.NewPageAsync();
            page.GotoAsync("https://qualitytestinghub.com/");


            // second browser context
            var context2 = await browser.NewContextAsync();

            // page 1
            var page2 = await context2.NewPageAsync();
            page2.GotoAsync("https://google.com/");


        }
    }
}
