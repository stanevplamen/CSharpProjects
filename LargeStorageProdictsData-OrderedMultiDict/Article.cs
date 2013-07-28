using System;

class Article : IComparable<Article>
{
    private string title;
    private decimal price;
    private string vendor;
    private string barcode;

    public string Title
    {
        get { return this.title; }
        private set { }
    }

    public decimal Price
    {
        get { return this.price; }
        private set { }
    }

    public string Vendor
    {
        get { return this.vendor; }
        private set { }
    }

    public string Barcode
    {
        get { return this.barcode; }
        private set { }
    }

    public Article(string title, decimal price, string vendor, string barcode)
    {
        this.title = title;
        this.price = price;
        this.vendor = vendor;
        this.barcode = barcode;
    }

    public int CompareTo(Article oderArticle)
    {
        return this.price.CompareTo(oderArticle.price);
    }
}

