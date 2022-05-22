namespace WebScraperDemo.Models.Webscraper.Utils;

public abstract class User
{

    public WebScraper myscraper;
    public List<WebData> myproduct;
    public User()
    {
        this.myproduct = new List<WebData>();
    }
    public abstract void Attach(WebScraper webscraper);
    public abstract void Find(string item);
    
}
