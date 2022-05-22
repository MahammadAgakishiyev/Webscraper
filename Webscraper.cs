namespace WebScraperDemo.Models.Webscraper.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
public abstract class WebScraper
{
    public IWebDriver driver;
    public List<WebData> WebScraping(string item)
    {
        this.CreatingDriver();
        this.Navigating();
        this.searching(item);
        return this.SavingOutput();
    }
    public void CreatingDriver()
    {
        this.driver = new ChromeDriver(@"C:\Users\user\Desktop");
    }
    public abstract void Navigating();
    public abstract void searching(string item);
    public abstract List<WebData> SavingOutput();
}
