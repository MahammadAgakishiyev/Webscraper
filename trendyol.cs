namespace WebScraperDemo.Models.Webscraper.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
public class Trendyol : WebScraper
{
    //ChromeOptions options = new ChromeOptions();
    //options.AddArguments("headless");
    //driver.Manage().Window.Maximize();
    public override void Navigating()
    {
        this.driver.Navigate().GoToUrl("https://www.trendyol.com/uk");
    }
    public override void searching(string item)
    {
        //IWebElement selection = this.driver.FindElement(By.XPath("//option[@value='GB']"));
        //selection.Click();
        //IWebElement button = this.driver.FindElement(By.XPath("//*[@id=\"country-selection\"]/div/div/div[2]"));
        //button.Click();
        //Thread.Sleep(2000);
        IWebElement searchbox = this.driver.FindElement(By.XPath("//*[@id=\"search\"]"));
        searchbox.SendKeys(item);
        searchbox.Submit();
        Thread.Sleep(1000);

    }
    public override List<WebData> SavingOutput()
    {
        int itemcount=0;
        //var prices = driver.FindElements(By.ClassName("prc-box-dscntd"));
        //var ratings = driver.FindElements(By.ClassName("p-total-rating-count"));

        List<WebData> list = new List<WebData> ();
        
        for (int i=2;i<30;i++){
            if (itemcount==10){
                break;
            }
            try{
                TrendyolData webdata = new TrendyolData();
                webdata.title=driver.FindElement(By.XPath("//*[@id=\"search-app\"]/div/div[1]/div[2]/div[3]/div/div[" + i + "]/div[1]/a/div[2]/div[1]/div/span[2]")).Text;
                webdata.price=Convert.ToInt32(driver.FindElement(By.XPath("//*[@id=\"search-app\"]/div/div[1]/div[2]/div[3]/div/div["+ i + "]/div[1]/a/div[2]/div[2]/div[1]/div/text()[1]")).Text.Split(",")[0]);
                webdata.Currency=driver.FindElement(By.XPath("//*[@id=\"search-app\"]/div/div[1]/div[2]/div[3]/div/div["+ i +"]/div[1]/a/div[2]/div[2]/div[1]/div/text()[2]")).Text;
                //webdata.rating=Convert.ToInt32(ratings[i].Text);
                itemcount++;
                list.Add(webdata);
            }
            catch{
            }
        }
        driver.Quit();
        return list;
    }
}
