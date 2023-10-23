using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{

    [TestFixture]
    public class BrowserContextChromium
    {


        [Test]
        public async Task Test_ChromiumAsync()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync();

            var browserContext = await browser.NewContextAsync();

            var page = await browserContext.NewPageAsync(); // Default page timeout is 30000ms

            await page.GotoAsync("https://qualitytestinghub.com/");

        }

    }
}
