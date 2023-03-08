namespace Webshop
{
    enum ProductType
    {
        GPU,
        CPU,
        RAM,
        Motherboard,
        Storage,
        Monitor,
        PSU,
        Case
    }
    
    internal class Products
    {
        private double price;
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice {
            get { return price; }
            set 
            { 
                if (value < StockPrice)
                    throw new Exception("Price cannot be lower than stock price");
                price = value; 
            }
        }
        public double StockPrice { get; set; }
        public int ProductStock { get; set; }

        public ProductType ProductType { get; set; }

        public Products(int productId)
        {
            ProductId = productId;
        }

        public Products(int productId, string productName, double productPrice, double stockPrice, int productStock, ProductType productType)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            StockPrice = stockPrice;
            ProductStock = productStock;
            ProductType = productType;
        }

        public override string ToString()
        {
            return $"[{ProductId}] | Product Name: {ProductName}\nProduct Price: {ProductPrice} | Stock Price: {StockPrice} | Product Stock: {ProductStock} | Product Type: {ProductType}";
        }
    }
}
