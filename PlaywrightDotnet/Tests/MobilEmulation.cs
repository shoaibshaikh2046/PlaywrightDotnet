using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{
    [TestFixture]
    public class MobilEmulation
    {
        [Test]
        public async Task Test_MobilEmulationWebkit()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // runs with chrome open
                SlowMo = 50, // slows the execution 
                Channel = "webkit"
            });

            var iphone13 = playwright.Devices["iPhone 13"];

            var browserContext = await browser.NewContextAsync(iphone13);

            var page = await browserContext.NewPageAsync(); // Default page timeout is 30000ms

            await page.GotoAsync("https://qualitytestinghub.com/");



        }

        [Test]
        public async Task Test_MobilEmulationGoogleChrome()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // runs with chrome open
                SlowMo = 50, // slows the execution 
                Channel = "chrome"
            });

            var iphone13 = playwright.Devices["iPhone 13"];

            var browserContext = await browser.NewContextAsync(iphone13);

            var page = await browserContext.NewPageAsync(); // Default page timeout is 30000ms

            await page.GotoAsync("https://qualitytestinghub.com/");



        }

    }
}
