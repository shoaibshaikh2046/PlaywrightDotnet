using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{
    [TestFixture]
    public class FileDownload
    {
        [Test]
        public async Task TestFileDownloadAsync()
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

            await page.GotoAsync("https://www.lambdatest.com/selenium-playground/download-file-demo");

            // Using Wait For download async

            var waitForDownloadTask = page.WaitForDownloadAsync();
            await page.Locator("//button[.='Download File']").ClickAsync();

            var download = await waitForDownloadTask;

            await download.SaveAsAsync("Data/" + download.SuggestedFilename);





        }
    }
}
