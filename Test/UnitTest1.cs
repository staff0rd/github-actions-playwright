using System;
using System.Threading.Tasks;
using PlaywrightSharp;
using Shouldly;
using Xunit;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync();
            var page = await browser.NewPageAsync();
            await page.GoToAsync("http://0.0.0.0:5000");
            await page.ClickAsync("text='Counter'");
            await page.ClickAsync("text='Increment'");
            await page.ClickAsync("text='Increment'");
            await page.ClickAsync("text='Increment'");
            var count = await page.GetTextContentAsync("#count");
            count.ShouldBe("3");
        }
    }
}
