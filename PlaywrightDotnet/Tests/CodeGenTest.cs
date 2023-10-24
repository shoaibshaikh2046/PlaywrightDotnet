using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{
    [TestFixture]
    public class CodeGenTest
    {

        [Test]
        public async Task TestCodeGen()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();

            var page = await context.NewPageAsync();

            await page.GotoAsync("https://demo.playwright.dev/todomvc/#/");

            await page.GetByPlaceholder("What needs to be done?").ClickAsync();

            await page.GetByPlaceholder("What needs to be done?").FillAsync("CodeGeneration");

            await page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");

            await page.GetByPlaceholder("What needs to be done?").ClickAsync();

            await page.GetByPlaceholder("What needs to be done?").FillAsync("Recording");

            await page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");

            await page.GetByPlaceholder("What needs to be done?").ClickAsync();

            await page.GetByPlaceholder("What needs to be done?").FillAsync("Playwright");

            await page.GetByPlaceholder("What needs to be done?").PressAsync("Enter");

            await page.Locator("li").Filter(new() { HasText = "CodeGeneration" }).GetByLabel("Toggle Todo").CheckAsync();

            await page.GetByRole(AriaRole.Link, new() { Name = "Completed" }).ClickAsync();

            await page.GetByRole(AriaRole.Link, new() { Name = "Active" }).ClickAsync();

            await page.GetByRole(AriaRole.Link, new() { Name = "All" }).ClickAsync();
        }
    }
}
