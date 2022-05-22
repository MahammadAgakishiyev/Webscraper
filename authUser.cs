namespace WebScraperDemo.Models.Webscraper.Utils;

public class AuthUser : User
{
    public AuthUser() : base()
    {
    }
    public override void Attach(WebScraper webscraper)
    {
        this.myscraper = webscraper;
    }
    public override void Find(string item)
    {
        List<WebData> webdatas= this.myscraper.WebScraping(item);
        for (int i = 0; i < webdatas.Count; i++)
        {
            this.myproduct.Add(webdatas[i]);
        }

        
    }
    
}
