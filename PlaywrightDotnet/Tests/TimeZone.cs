using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightDotnet.Tests
{
    public class TimeZone
    {

        // get time zone ids : https://docs.oracle.com/middleware/1221/wcs/tag-ref/MISC/TimeZones.html

        [Test]
        public async Task Test_TimeZoneLocale()
        {
            var playwright = await Playwright.CreateAsync();

            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // runs with chrome open
                SlowMo = 50, // slows the execution 
                Channel = "chrome" // msedge, chromium
               
            });

            var browserContext = await browser.NewContextAsync( new BrowserNewContextOptions
            {
                Locale = "de-DE",
                TimezoneId = "Europe/Berlin"
            });

            var page = await browserContext.NewPageAsync(); // Default page timeout is 30000ms

            await page.GotoAsync("https://google.com/");


        }
    }
}
