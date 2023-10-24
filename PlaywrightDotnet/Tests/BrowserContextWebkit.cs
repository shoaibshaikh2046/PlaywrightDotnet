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
                Headless = false,
                Channel = "webkit"
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
