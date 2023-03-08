namespace Webshop
{
    internal class StockData
    {
        public List<Products> Products { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public StockData()
        {
            Products = new List<Products>();
            AddProducts();
        }
        public void AddProducts()
        {
            Products.Add(new Products(0, "NVIDIA RTX 4090", 17000, 12000, 10, ProductType.GPU));
            Products.Add(new Products(1, "AMD Ryzen 9 3900X", 2890, 2000, 32, ProductType.CPU));
            Products.Add(new Products(2, "Corsair Vengeance LPX 16GB", 386, 250, 125, ProductType.RAM));
            Products.Add(new Products(3, "ASUS ROG Strix B450-F", 1399, 750, 1000, ProductType.Motherboard));
            Products.Add(new Products(4, "Samsung 970 EVO 500GB", 728, 500, 2500, ProductType.Storage));
            Products.Add(new Products(5, "Seagate Barracuda 1TB", 379, 200, 5000, ProductType.Storage));
            Products.Add(new Products(6, "Samsung 27\" C27F591", 1321, 1000, 75, ProductType.Monitor));
            Products.Add(new Products(7, "Corsair RM750x", 1099, 750, 700, ProductType.PSU));
            Products.Add(new Products(8, "Corsair Carbide 275R", 1350, 850, 10000, ProductType.Case));
        }

        public List<Products> GetProducts() { return Products; }

        public List<string> ProductList()
        {
            List<string> prod = new();
            foreach (var item in Products)
            {
                prod.Add($"{item.ProductId} | {item.ProductName} | {item.ProductPrice} | {item.ProductStock} | {item.ProductType}");
            }
            return prod;
        }

        public void AddCustomers()
        {
            // Create customers with fake data
            Customers.Add(new Customer("John", "maileren@gmail.com", "john54", new Address("CPHVej", "1", "2510", "Copenhagen", "Denmark")));
            Customers.Add(new Customer("Peter", "ting@yahoo.com", "peter123", new Address("VedDiget", "48", "2825", "Copenhagen", "Denmark")));



        }
    }
}
