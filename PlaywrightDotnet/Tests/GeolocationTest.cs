using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{
    [TestFixture]
    public class GeolocationTest
    {

        [Test]
        public async Task Test_GeoLocation()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // runs with chrome open
                SlowMo = 50, // slows the execution 
                Channel = "chrome" // msedge, chromium

            });

            var browserContext = await browser.NewContextAsync();

            await browserContext.SetGeolocationAsync(new()
            {
                Longitude = 41.871941f,
                Latitude = 12.567380f
            });

            var page = await browserContext.NewPageAsync(); // Default page timeout is 30000ms


            page.GotoAsync("https://www.google.com");


        }
    }
}
