using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{
    [TestFixture]
    public class Viewport
    {

        [Test]
        public async Task Test_ViewportAsync()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // runs with chrome open
                SlowMo = 50, // slows the execution 
                Channel = "chrome"
            });

            // Create context with given viewport
            var  context = await browser.NewContextAsync(new()
            {
                ViewportSize = new ViewportSize() { Width = 1280, Height = 1024 }
            });

            var page = await context.NewPageAsync();

            await page.GotoAsync("https://qualitytestinghub.com/");// Default page timeout is 30000ms

            // Resize viewport for individual page
            await page.SetViewportSizeAsync(1600, 1200);

            await page.GotoAsync("https://qualitytestinghub.com/");// Default page timeout is 30000ms

            // Emulate high-DPI
            var context2 = await browser.NewContextAsync(new()
            {
                ViewportSize = new ViewportSize() { Width = 2560, Height = 1440 },
                DeviceScaleFactor = 2
            });

            var page2 = await context2.NewPageAsync();

            await page2.GotoAsync("https://qualitytestinghub.com/");// Default page timeout is 30000ms

        }
    }
}
