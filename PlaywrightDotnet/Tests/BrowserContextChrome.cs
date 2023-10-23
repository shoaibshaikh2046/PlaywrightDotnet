using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{
    [TestFixture]
    public class BrowserContextChrome
    {
        [Test]
        public async Task Test_ChromeAsync()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // runs with chrome open
                SlowMo = 50, // slows the execution 
                Channel = "chrome" // msedge, chromium
            });

            var browserContext = await browser.NewContextAsync();

            var page = await browserContext.NewPageAsync(); // Default page timeout is 30000ms

            await page.GotoAsync("https://qualitytestinghub.com/");


        }
    }
}
