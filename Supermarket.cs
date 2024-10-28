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
            const string CommandBuyProduct = "1";
            const string CommandExit = "2";

            CreateProducts();
            CreateClients();

            while (_clients.Count > 0)
            {
                ShowInfo();
                Client client = _clients.Dequeue();

                bool isWork = true;

                while (isWork)
                {
                    Console.WriteLine($"\nМАГАЗИН: Покупатель с балансом {client.Money} руб.");
                    Console.WriteLine("\nМАГАЗИН: Желаете преобрести какой-то товар?");
                    Console.WriteLine($"ПОКУПАТЕЛЬ: {CommandBuyProduct} - Да, желаю купить товар {CommandExit} - Нет, я ухожу ");
                    Console.Write("ПОКУПАТЕЛЬ: ");

                    switch (Console.ReadLine())
                    {
                        case CommandBuyProduct:
                            TransferProduct(client);
                            break;

                        case CommandExit:
                            isWork = Exit();
                            break;

                        default:
                            ShowError();
                            break;
                    }
                }
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

        private bool Exit()
        {
            Console.WriteLine("\nМАГАЗИН: Спасибо, что посетили наc, ждем Вас снова. Досвидания!");
            Console.WriteLine("ПОКУПАТЕЛЬ: Спасибо! Досвидания!");
            return false;
        }

        private void ShowError()
        {
            Console.WriteLine("\nОШИБКА: Неккоректный ввод\n");
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

        private void TransferProduct(Client client)
        {
            PutProductInBasket(client);
            Console.WriteLine("ПОКУПАТЕЛЬ: ");
            client.ShowInfo();
        }

        private void PutProductInBasket(Client client)
        {
            Console.WriteLine("\nМАГАЗИН: Название товара? ");
            Console.Write("ПОКУПАТЕЛЬ: ");
            string productSell = Console.ReadLine();

            Product product = TryGetProduct(productSell, _products);

            if (product != null)
            {
                client.AddProduct("корзина", product);
                Console.WriteLine($"\nПОКУПАТЕЛЬ: Положил в корзину: {product.Name}");

                int totalCost = IncreaseCost(client);
                Console.WriteLine($"Общая сумма: {totalCost}");
            }

            ContinueShopping(client);
        }

        private void ContinueShopping(Client client)
        {
            const string CommandPutProductInBasket = "1";
            const string CommandBuy = "2";
            const string CommandRemove = "3";

            client.ShowInfo();
            PrintProducts();
            Console.WriteLine($"\nМАГАЗИН: {CommandPutProductInBasket} - выбрать еще какой-то товар {CommandBuy} - купить то, что в корзине {CommandRemove} - удалить какой-то товар?");
            Console.Write("ПОКУПАТЕЛЬ: ");
            string clientChose = Console.ReadLine();

            switch (clientChose)
            {
                case CommandPutProductInBasket:
                    PutProductInBasket(client);
                    break;
                case CommandBuy:
                    PutProductInBag(client);
                    break;
                case CommandRemove:
                    DeleteFromBag(client);
                    break;
                default:
                    ContinueShopping(client);
                    break;
            }
        }

        private void PutProductInBag(Client client)
        {
            int totalCost = IncreaseCost(client);

            while (client.Money < totalCost)
            {
                client.ShowInfo();
                Console.WriteLine($"\nМАГАЗИН: Покупателю не хватает денег для покупки. Общая сумма: {totalCost} руб.");
                DeleteFromBag(client);
                totalCost = IncreaseCost(client);
            }

            foreach (Product productClient in client.Basket)
            {
                if (client.SpendMoney(productClient.Price))
                {
                    client.AddProduct("сумка", productClient);
                    _money += productClient.Price;
                }
            }

            client.ClearBasket();
        }
        private void DeleteFromBag(Client client)
        {
            Console.WriteLine("Введите название товара, который хотите убрать из корзины: ");
            Console.Write("ПОКУПАТЕЛЬ: ");
            string productDell = Console.ReadLine();

            Product product = TryGetProduct(productDell, client.Basket);

            if (product != null)
            {
                client.DeleteProductFromBasket(product);
                Console.WriteLine($"\nПОКУПАТЕЛЬ: Убрал из корзины {product.Name}");
            }

            ContinueShopping(client);
        }
        private Product TryGetProduct(string productName, List<Product> products)
        {
            if (products.Count > 0)
            {
                foreach (Product element in products)
                {
                    if (element.Name.ToLower() == productName.ToLower())
                    {
                        return element;
                    }
                }

                Console.WriteLine("\nМАГАЗИН: Данного товара нет");
                return null;
            }
            else
            {
                Console.WriteLine("\nМАГАЗИН: Закончились все товары");
                return null;
            }
        }
        private int IncreaseCost(Client client)
        {
            int totalCost = 0;

            foreach (Product clientProduct in client.Basket)
            {
                totalCost += clientProduct.Price;
            }

            return totalCost;
        }
    }

    public class Client
    {
        private List<Product> _basket = new List<Product>();
        private List<Product> _bag = new List<Product>();
        private int _money;

        public Client(int money)
        {
            if (money < 0)
            {
                throw new InvalidOperationException("ОШИБКА: Сумма денег не может быть отрицательной");
            }
            
            _money = money;
        }
        
        public int Money => _money;
        public List<Product> Basket => new List<Product>(_basket);

        public void ShowInfo()
        {
            Console.WriteLine($"Кошелек: {Money}");
            Console.WriteLine($"Корзина: ");
            PrintListProducts(Basket);
            Console.WriteLine($"Сумка: ");
            PrintListProducts(_bag);
        }

        private void PrintListProducts(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                products[i].ShowInfo();
            }
        }

        public void AddProduct(string listType, Product product)
        {
            if (listType.ToLower() == "корзина")
            {
                _basket.Add(product);
            }
            else if (listType.ToLower() == "сумка")
            {
                _bag.Add(product);
            }
        }

        public void DeleteProductFromBasket(Product product)
        {
            _basket.Remove(product);
        }

        public void ClearBasket()
        {
            _basket.Clear();
        }

        public bool SpendMoney(int amount)
        {
            if (_money >= amount)
            {
                _money -= amount;
                return true;
            }
            else
            {
                Console.WriteLine("ОШИБКА: Недостаточно средств.");
                return false;
            }
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
