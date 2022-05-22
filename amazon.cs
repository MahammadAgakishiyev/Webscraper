namespace WebScraperDemo.Models.Webscraper.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class Amazon : WebScraper
{
    //ChromeOptions options = new ChromeOptions();
    //options.AddArguments("headless");
    //this.driver.Manage().Window.Maximize();
    public override void Navigating()
    {
        this.driver.Navigate().GoToUrl("https://www.amazon.com/");
    }
    public override void searching(string item)
    {
        IWebElement searchbox = driver.FindElement(By.XPath("//input[@id='twotabsearchtextbox']"));
        searchbox.SendKeys(item);
        searchbox.Submit();
        Thread.Sleep(1000);
    }
    public override List<WebData> SavingOutput()
    {
        int itemcount=0;
        var prices= driver.FindElements(By.ClassName("a-price-whole"));
        var currencies = driver.FindElements(By.ClassName("a-price-symbol"));
        List<WebData> list= new List<WebData> ();
        
        for (int i=1;i<30;i++){
            if (itemcount==10){
                break;
            }
            try{
                AmazonData webdata= new AmazonData();
                webdata.title=driver.FindElement(By.XPath("//*[@id=\"search\"]/div[1]/div[1]/div/span[3]/div[2]/div[" + i +"]/div/div/div/div/div/div[2]/div/div/div[1]/h2")).Text;
                webdata.price=Convert.ToInt32(prices[i].Text);
                webdata.Currency=currencies[i].Text;
                //webdata.rating=Convert.ToInt32(driver.FindElement(By.XPath("//*[@id=\"search\"]/div[1]/div[1]/div/span[3]/div[2]/div["+i+"]/div/div/div/div/div[2]/div[2]/div/span[2]/a/span")).Text);
                list.Add(webdata);
                itemcount++;
            }
            catch{
            }
            
        }
        driver.Quit();
        return list;
    }
}
