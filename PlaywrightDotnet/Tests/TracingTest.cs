using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{
    [TestFixture]
    public class TracingTest
    {

        [Test]
        public async Task TestTracing()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                Channel = "chrome"
            });

            // one browser context
            var context = await browser.NewContextAsync();

            await context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true,

            });


            // page 
            var page = await context.NewPageAsync();

            await page.GotoAsync("https://demo.playwright.dev/todomvc/");

            List<string> expected = new List<string>() { "Shoaib", "Testing", "Playwright" };

            for (int i = 0; i < expected.Count; i++)
            {
                await page.GetByPlaceholder("What needs to be done?").FillAsync(expected[i]);
                await page.Keyboard.PressAsync("Enter");
            }

            await page.Locator("//label[.='" + expected.FirstOrDefault() + "']/parent::div/input").ClickAsync();


            await context.Tracing.StopAsync(new()
            {
                Path = "traces/trace.zip"

            });
        }
    }
}
