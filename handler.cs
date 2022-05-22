namespace WebScraperDemo.Models.Webscraper.Utils;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public abstract class Handler
{

    public Handler? next_handler;

    public Handler()
    {
        this.next_handler = null;

    }
    public void SetSuccessor(Handler next)
    {
        this.next_handler = next;
    }

    public abstract void handle(List<WebData> webdatas);



}



