using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;

namespace caronomics.services
{
    public class TankjeScraperService
    {
        public static string GetFuelData(string locationQuery)
        {
            var output = new StringBuilder();

            var options = new ChromeOptions();
            options.AddArgument("--headless"); // Don't open browser window
            options.AddArgument("--disable-gpu");
            options.AddArgument("--no-sandbox");

            using (var driver = new ChromeDriver(options))
            {
                try
                {
                    driver.Navigate().GoToUrl("https://www.tankje.nl/index.php");

                    // Find input field by ID and input the search string
                    var input = driver.FindElement(By.Id("tags"));
                    input.SendKeys(locationQuery);

                    Thread.Sleep(2000); // Wait for JS autocomplete

                    input.SendKeys(Keys.Enter); // Submit the search
                    Thread.Sleep(3000); // Wait for table to render

                    // Find all tables with width=450
                    var tables = driver.FindElements(By.XPath("//table[@width='450']"));

                    foreach (var table in tables)
                    {
                        output.AppendLine(table.Text.Trim());
                        output.AppendLine(new string('-', 40));
                    }
                }
                catch (Exception ex)
                {
                    output.AppendLine($"Error during scraping: {ex.Message}");
                }
                finally
                {
                    driver.Quit();
                }
            }

            return output.ToString();
        }
    }
}