namespace WebScraperDemo.Models.Webscraper.Utils;


public class SortingManager
{
    public Handler handler;

    public void CreateService(string type)
    {
        if (type.ToLower() == "sortbypriceasc")
        {
            this.handler = new SorterByPriceAsc();
        }
        else if (type.ToLower() == "sortbypricedesc")
        {
            this.handler = new SorterByPriceDesc();
        }
        else if (type.ToLower() == "sortbyratingasc")
        {
            this.handler = new SorterByRatingAsc();
        }
        else if (type.ToLower() == "sortbyratingdesc")
        {
            this.handler = new SorterByRatingDesc();
        }

        else
        {
            throw new Exception("type error");
        }
    }
    public void AddService(string type)
    {
        Handler temp = this.handler;
        while (temp.next_handler != null)
        {
            temp = temp.next_handler;
        }
        if (type.ToLower() == "sortbypriceasc")
        {
            temp.SetSuccessor(new SorterByPriceAsc());
        }
        else if (type.ToLower() == "sortbypricedesc")
        {
            this.handler = new SorterByPriceDesc();
        }
        else if (type.ToLower() == "sortbyratingasc")
        {
            temp.SetSuccessor(new SorterByRatingAsc());
        }
        else if (type.ToLower() == "sortbypricedesc")
        {
            this.handler = new SorterByRatingDesc();
        }
        else
        {
            throw new Exception("type error");
        }
    }
    public void handle(List<WebData> webdatas)
    {
        this.handler.handle(webdatas);
    }
}
