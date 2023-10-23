using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{

    [TestFixture]
    public class AuthenticationTest
    {
        IBrowserContext context;

        [Test]
        public async Task Authenticate()
        {

            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // runs with chrome open
                SlowMo = 50, // slows the execution 
                Channel = "chrome" // msedge, chromium

            });

            context = await browser.NewContextAsync();

            var page = await context.NewPageAsync();
            await page.GotoAsync("https://opensource-demo.orangehrmlive.com/");
            await page.GetByPlaceholder("UserName").FillAsync("Admin");
            await page.GetByPlaceholder("Password").FillAsync("admin123");

            await page.Locator("//button[@type='submit']").ClickAsync();

            // Save storage state into the file.
            await context.StorageStateAsync(new()
            {
                Path = "state.json"
            });

            var context2 = await browser.NewContextAsync(new()
            {
                StorageStatePath = "state.json"
            });

            var page2 = await context2.NewPageAsync();

            await page2.GotoAsync("https://opensource-demo.orangehrmlive.com/");

        }


     
    }
}
