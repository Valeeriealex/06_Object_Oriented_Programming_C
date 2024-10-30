using System;
using System.Collections.Generic;
using static Tasks_IJunior_02._06_OOP.Market;

namespace Tasks_IJunior_02._06_OOP
{
    internal class ProductMarker
    {
        public static void Main(string[] args)
        {
            Market supermarket = new Market();
            supermarket.Work();
        }
    }

    public class Market
    {
        private int _money = 0;
        private List<Product> _products = new List<Product>();
        private Queue<Client> _clients = new Queue<Client>();

        public void Work()
        {
            CreateProducts();
            CreateClients();

            while (_clients.Count > 0)
            {
                ShowInfo();
                Client client = _clients.Dequeue();
                System.Threading.Thread.Sleep(5000);
                TakeRandomProduct(client);
                BuyRandomProduct(client);
                System.Threading.Thread.Sleep(5000);
            }

            Console.WriteLine("\nМАГАЗИН: Нет покупателей в очереди");
        }

        private void ShowInfo()
        {
            Console.WriteLine($"\nМАГАЗИН: Заработанные деньги: {_money} руб.");
            PrintProducts();
            PrintClients();
        }

        private void PrintProducts()
        {
            Console.WriteLine("\nМАГАЗИН: Все товары: \n");

            for (int i = 0; i < _products.Count; i++)
            {
                _products[i].ShowInfo();
            }
        }

        private void PrintClients()
        {
            Console.WriteLine("\nМАГАЗИН: Покупатели в очереди: ");
            int countClient = 1;

            foreach (Client client in _clients.ToArray())
            {
                Console.WriteLine($"\nПокупатель {countClient}: ");
                client.ShowInfo();
                countClient++;
            }
        }

        private void CreateProducts()
        {
            _products.Add(new Product("Жевачка", "Dirol", 30));
            _products.Add(new Product("Шоколад", "Kinder", 50));
            _products.Add(new Product("Молоко", "Prostokvashino", 100));
            _products.Add(new Product("Вино", "Kabirne", 600));
            _products.Add(new Product("Криветки", "Restoria", 1000));
        }

        private void CreateClients()
        {
            List<int> clientsMoney = new List<int> { 1000, 300, 150 };

            foreach (int money in clientsMoney)
            {
                _clients.Enqueue(new Client(money));
            }
        }

        private void TakeRandomProduct(Client client)
        {
            Console.WriteLine($"\nМАГАЗИН: Пришел покупатель с балансом {client.Money} руб.");
            Random random = new Random();
            int numberOfProducts = random.Next(1, _products.Count + 1);
            HashSet<Product> selectedProducts = new HashSet<Product>();

            while (selectedProducts.Count < numberOfProducts)
            {
                int index = random.Next(_products.Count);
                selectedProducts.Add(_products[index]);
            }

            foreach (var product in selectedProducts)
            {
                client.AddProduct(product);
                Console.WriteLine($"\nПОКУПАТЕЛЬ: Положил в корзину: {product.Name}");
                client.ShowInfo();
                System.Threading.Thread.Sleep(5000);
            }
        }

        private void BuyRandomProduct(Client client)
        {
            int totalCost = client.GetTotalCost();

            while (client.Money < totalCost)
            {
                Console.WriteLine($"\nМАГАЗИН: Покупателю не хватает денег для покупки. Общая сумма: {totalCost} руб.");
                client.RemoveRandomProduct();
                totalCost = client.GetTotalCost();
                client.ShowInfo();
                System.Threading.Thread.Sleep(5000);
            }

            client.MoveProducts();
            client.ShowInfo();
            System.Threading.Thread.Sleep(5000);
        }
    }

    public class Client
    {
        private List<Product> _basket = new List<Product>();
        private List<Product> _bag = new List<Product>();

        public Client(int money)
        {
            if (money < 0)
            {
                throw new InvalidOperationException("\nОШИБКА: Сумма денег не может быть отрицательной");
            }

            Money = money;
        }

        public int Money { get; private set; }
        public List<Product> Basket => new List<Product>(_basket);

        public void ShowInfo()
        {
            Console.WriteLine($"\nКошелек: {Money}");
            Console.WriteLine($"Корзина: ");
            PrintProducts(Basket);
            Console.WriteLine($"Сумка: ");
            PrintProducts(_bag);
        }

        private void PrintProducts(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                products[i].ShowInfo();
            }
        }

        public void AddProduct(Product product)
        {
                _basket.Add(product);
        }

        public void MoveProducts()
        {
            if (_basket.Count > 0)
            {
                _bag.AddRange(_basket); 
                _basket.Clear(); 
                Console.WriteLine("\nПОКУПАТЕЛЬ: Все товары перемещены из корзины в сумку.");
            }
            else
            {
                Console.WriteLine("\nПОКУПАТЕЛЬ: Корзина пуста, нечего перемещать.");
            }
        }

        public bool SpendMoney(int amount)
        {
            if (Money >= amount)
            {
                Money -= amount;
                return true;
            }
            else
            {
                Console.WriteLine("\nОШИБКА: Недостаточно средств.");
                return false;
            }
        }

        public int GetTotalCost()
        {
            int totalCost = 0;

            foreach (Product clientProduct in _basket)
            {
                totalCost += clientProduct.Price;
            }

            return totalCost;
        }

        public void RemoveRandomProduct()
        {
            if (_basket.Count > 0)
            {
                Random random = new Random();
                int index = random.Next(_basket.Count);
                Product productToRemove = _basket[index];
                _basket.RemoveAt(index);
                Console.WriteLine($"\nПОКУПАТЕЛЬ: Убрал из корзины {productToRemove.Name}");
            }
        }

        public void ClearBasket()
        {
            _basket.Clear();
        }
    }

    public class Product
    {
        public Product(string name, string brand, int price)
        {
            Name = name;
            Brand = brand;
            Price = price;
        }

        public string Name { get; private set; }
        public string Brand { get; private set; }
        public int Price { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Товар: {Name}, Производитель: {Brand}, Стоимость: {Price}");
        }
    }
}

