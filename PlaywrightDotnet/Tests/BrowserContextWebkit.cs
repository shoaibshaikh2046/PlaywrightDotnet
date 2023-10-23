using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{
    [TestFixture]
    public class BrowserContextWebkit
    {

        [Test]
        public async Task Test_WebKitAsync()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // runs with chrome open
                SlowMo = 50, // slows the execution 
                Channel = "webkit"
            });
            var browserContext = await browser.NewContextAsync();

            var page = await browserContext.NewPageAsync(); // Default page timeout is 30000ms

            await page.GotoAsync("https://qualitytestinghub.com/");



        }

    }
}
