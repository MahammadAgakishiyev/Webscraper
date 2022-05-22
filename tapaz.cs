namespace WebScraperDemo.Models.Webscraper.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class Tapaz : WebScraper
{
    public override void Navigating()
    {
        driver.Navigate().GoToUrl("https://tap.az/");
    }
    public override void searching(string item)
    {
        IWebElement searchbox = driver.FindElement(By.XPath("//input[@type='search']"));
        searchbox.SendKeys(item);
        searchbox.Submit();
        Thread.Sleep(1000);
    }
    public override List<WebData> SavingOutput()
    {
        int itemcount=0;
        var titles = driver.FindElements(By.ClassName("products-name"));
        var prices = driver.FindElements(By.ClassName("price-val"));
        var currency = driver.FindElements(By.ClassName("price-cur"));
        var dates = driver.FindElements(By.ClassName("products-created"));
        List<WebData> list= new List<WebData> ();
        
        for (int i=1;i<30;i++){
            if (itemcount==10){
                break;
            }
            try{
                TapAzData webdata = new TapAzData();
                itemcount++;
                webdata.price=Convert.ToInt32(prices[i].Text.Split(" ")[0]);
                webdata.title=titles[i].Text;
                webdata.date=dates[i].Text;
                webdata.Currency=currency[i].Text;
                list.Add(webdata);
            }
            catch{
            }
        }
        driver.Quit();
        return list;
    }
}
