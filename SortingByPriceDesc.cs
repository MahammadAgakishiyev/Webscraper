namespace WebScraperDemo.Models.Webscraper.Utils;


public class SorterByPriceDesc : Handler
{
    public SorterByPriceDesc() : base()
    {

    }
    public void quick_sort(List<WebData> webdatas, int left, int right)
    {
        int i = left;
        int j = right;
        WebData temp;
        int pivot = webdatas[left + (right - left) / 2].price;
        while (i <= j)
        {
            while (webdatas[i].price > pivot)
            {

                i++;
            }
            while (webdatas[j].price < pivot)
            {
                j--;
            }
            if (i <= j)
            {
                temp = webdatas[i];
                webdatas[i] = webdatas[j];
                webdatas[j] = temp;
                i++;
                j--;

            }
        }
        if (i < right)
        {
            quick_sort(webdatas, i, right);

        }
        if (j > left)
        {
            quick_sort(webdatas, left, j);
        }
    }
    public override void handle(List<WebData> webdatas)
    {
        Console.WriteLine(webdatas.Count);
        this.quick_sort(webdatas, 0, webdatas.Count - 1);

        if (this.next_handler != null)
        {
            this.next_handler.handle(webdatas);
        }

    }
}