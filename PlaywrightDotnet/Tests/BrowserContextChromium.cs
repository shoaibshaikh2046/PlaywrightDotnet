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

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Channel = "chromium"
            });

            // one browser context
            var context = await browser.NewContextAsync();

            // page 1
            var page = await context.NewPageAsync();
            page.GotoAsync("https://qualitytestinghub.com/");

            // page 2 
            var page12 = await context.NewPageAsync();
            page12.GotoAsync("https://opensource-demo.orangehrmlive.com/");


            // second browser context
            var context2 = await browser.NewContextAsync();

            // page 1
            var page2 = await context2.NewPageAsync();
            page2.GotoAsync("https://google.com/");

            // page 2
            var page22 = await context2.NewPageAsync();
            page22.GotoAsync("https://playwright.dev/dotnet/");

        }

    }
}
