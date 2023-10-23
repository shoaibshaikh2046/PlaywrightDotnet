using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{
    [TestFixture]
    public class BrowserContextFirefox
    {
        [Test]
        public async Task Test_FirefoxAsync()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // runs with chrome open
                SlowMo = 50, // slows the execution 
                Channel = "firefox"
            });
            var browserContext = await browser.NewContextAsync();
            var page = await browserContext.NewPageAsync(); // Default page timeout is 30000ms
            await page.GotoAsync("https://qualitytestinghub.com/");


        }
    }
}
