using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{
    [TestFixture]
    public class FileUpload
    {

        [Test]
        public async Task TestFileUploadAsync()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // runs with chrome open
                SlowMo = 50, // slows the execution 
                Channel = "chrome" // msedge, chromium

            });

            var context = await browser.NewContextAsync();

            var page = await context.NewPageAsync();

            await page.GotoAsync("https://www.lambdatest.com/selenium-playground/upload-file-demo");

            await page.Locator("//input[@type='file']").SetInputFilesAsync("dummy.pdf");

        //    await page.Locator("//input[@type='file']").SetInputFilesAsync(new[] { "dummy.pdf","second.pdf" });

        }
    }
}
