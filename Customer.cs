namespace Webshop
{
    internal class Customer : User
    {
        public Address Address { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public Customer()
        {
            Id = Interlocked.Increment(ref nextId);
        }

        public Customer(string firstName, string email, string password, Address address)
        {
            Id = Interlocked.Increment(ref nextId);
            Name = firstName;
            Email = email;
            Password = password;
            Address = address;
        }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public void CreateCustomer()
        {
            Console.Write("Navn: ");
            Name = Console.ReadLine();
            Console.Write("Email: ");
            Email = Console.ReadLine();
            Console.Write("Password: ");
            Password = Console.ReadLine();
            Console.Write("Gade: ");
            string street = Console.ReadLine();
            Console.Write("Husnummer: ");
            string houseNumber = Console.ReadLine();
            Console.Write("Postnummer: ");
            string zipCode = Console.ReadLine();
            Console.Write("By: ");
            string city = Console.ReadLine();
            Console.Write("Land: ");
            string country = Console.ReadLine();
            Address = new Address(street, houseNumber, zipCode, city, country);
            Console.Clear();
            CustomerMain();
        }

        public void CustomerMain()
        {
            int input = 0;
            do
            {
                Console.WriteLine("[1] Ny ordre | [2] Vis gamle ordre");
            } while (!int.TryParse(Console.ReadLine(), out input) && input != 1 && input != 2);
            
            switch (input)
            {
                case 1:
                    Order order = new Order();
                    order.CreateOrder();
                    AddOrder(order);
                    AddMore(order);
                    break;
                case 2:
                    if (Orders.Count > 0)
                    {
                        foreach (var item in Orders)
                        {
                            item.ShowOrder();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{Name} har ingen tidligere ordre.");
                    }

                    CustomerMain();
                    break;
            }
        }

        public void AddMore(Order order)
        {
            int input = 0;
            do
            {
                Console.WriteLine("[1] Tilføj mere | [2] Slet fra kurv | [3] Gå til betaling | [4] Vis nuværende ordre");
            } while (!int.TryParse(Console.ReadLine(), out input));

            switch (input)
            {
                case 1:
                    order.CreateOrder();
                    AddMore(order);
                    break;
                case 2:
                    order.RemoveProduct();
                    AddMore(order);
                    break;
                case 3:
                    order.CheckOut(this);
                    break;
                case 4:
                    order.ShowOrder();
                    AddMore(order);
                    break;
            }   
        }
    }
}
