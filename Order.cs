namespace Webshop
{
    internal class Order
    {
        public double TotalPrice { get; set; }
        public int Id { get; set; }
        public List<Products> Products { get; set; }

        public List<Products> CustomerProdcuts { get; set; } = new List<Products>();
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }

        private static int nextId = 0;
        public Order()
        {
            Products = new List<Products>();
            Id = Interlocked.Increment(ref nextId);
            AddProducts();
            OrderDate = DateTime.Now;
        }

        public Order(List<Products> products, Customer customer, DateTime orderDate)
        {
            Id = Interlocked.Increment(ref nextId);
            Products = products;
            Customer = customer;
            OrderDate = orderDate;
            AddProducts();
        }

        public void ShowOrder()
        {
            foreach (var item in CustomerProdcuts)
            {
                
                TotalPrice += item.ProductPrice;
                Console.WriteLine($"{item.ProductName} | {item.ProductPrice}DKK | {item.ProductStock} på lager");
            }
            Console.WriteLine($"Total pris: {TotalPrice}DKK\n\n");
            TotalPrice = 0; // Reset total price for next order :-I
        }

        public void AddProduct(Products product)
        {
            CustomerProdcuts.Add(product);
        }

        public void AddProducts()
        {
            StockData prod = new StockData();

            Products.AddRange(prod.GetProducts());
        }

        public void RemoveProduct()
        {
            for (int i = 0; i < CustomerProdcuts.Count; i++)
            {
                Console.WriteLine($"[{i}] {CustomerProdcuts[i].ProductName} | {CustomerProdcuts[i].ProductPrice}DKK | {CustomerProdcuts[i].ProductStock} på lager");
            }
            int input = 0;
            do
            {
                Console.WriteLine("Vælg produkt ID for at fjerne fra kurv");
            } while (!int.TryParse(Console.ReadLine(), out input) && input <= CustomerProdcuts.Count && input >= 0);

            // Write a method to remove the product from the list based on the input and the product id

            CustomerProdcuts.RemoveAt(input);
            Console.WriteLine($"Produktid {input} er blevet slettet fra kurven.");
        }

        public void AddCustomer(Customer customer)
        {
            Customer = customer;
        }

        public void CreateOrder()
        {
            foreach (var item in Products)
            {
                Console.WriteLine($"[{item.ProductId}] {item.ProductName} | {item.ProductPrice}DKK | {item.ProductStock} på lager");
            }

            int input = 0;
            do
            {
                Console.WriteLine("Vælg produkt ID for at tilføje til kurv");
            } while (!int.TryParse(Console.ReadLine(), out input) && input <= Products.Count && input >= 0);

            AddProduct(Products[input]);

            Console.WriteLine($"Produktid {input} tilføjet til kurv");
            Thread.Sleep(1000);
            Console.Clear();
        }

        public void CheckOut(Customer customer)
        {
            int input = 0;
            do
            {
                Console.WriteLine("[1] Betal | [2] Gå tilbage");
            } while (!int.TryParse(Console.ReadLine(), out input) && input != 1 && input != 2);

            if (input == 1)
            {
                Console.WriteLine("Betaling igang...");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Betaling gennemført\n Hav en god dag!");
                Console.ResetColor();
                Thread.Sleep(1000);
                Console.Clear();

                customer.CustomerMain(); ;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Betaling afbrudt");
                Console.ResetColor();
                customer.AddMore(this);
            }
            
        }
    }
}
