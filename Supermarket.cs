using System;
using System.Collections.Generic;
using static Tasks_IJunior_02._06_OOP.Market;

namespace Tasks_IJunior_02._06_OOP
{
    internal class Supermarket
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
        private List<Product> _listProductsSale = new List<Product>();
        private Queue<Client> _queueClients = new Queue<Client>();

        public void Work()
        {
            const string CommandBuyProduct = "1";
            const string CommandExit = "2";

            CreateProductsForMarket();
            CreateClientsForMarket();

            while (_queueClients.Count > 0)
            {
                ShowInfo();
                Client client = _queueClients.Dequeue();

                bool isWork = true;

                while (isWork)
                {
                    Console.WriteLine($"\nМАГАЗИН: Покупатель с балансом {client.Money} руб.");
                    Console.WriteLine("\nМАГАЗИН: Желаете преобрести какой-то товар?");
                    Console.WriteLine($"ПОКУПАТЕЛЬ: \n{CommandBuyProduct} - Да, желаю купить товар\n{CommandExit} - Нет, я ухожу ");
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

            Console.WriteLine("МАГАЗИН: Нет покупателей в очереди");
        }

        private void ShowInfo()
        {
            Console.WriteLine($"\nМАГАЗИН: Заработанные деньги: {_money} руб.");
            PrintListProductsSale();
            PrintQueueClients();
        }

        private void PrintListProductsSale()
        {
            Console.WriteLine("Все товары в магазине: ");

            for (int i = 0; i < _listProductsSale.Count; i++)
            {
                _listProductsSale[i].ShowInfo();
            }
        }

        private void PrintQueueClients()
        {
            Console.WriteLine("Покупатели в очереди: ");
            int countClient = 1;

            foreach (Client client in _queueClients.ToArray())
            {
                Console.WriteLine($"Покупатель {countClient}: ");
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

        private void CreateProductsForMarket()
        {
            _listProductsSale.Add(new Product("Жевачка", "Dirol", 30));
            _listProductsSale.Add(new Product("Шоколад", "Kinder", 50));
            _listProductsSale.Add(new Product("Молоко", "Prostokvashino", 100));
            _listProductsSale.Add(new Product("Вино", "Kabirne", 600));
            _listProductsSale.Add(new Product("Криветки", "Restoria", 1000));
        }

        private void CreateClientsForMarket()
        {
            List<int> clientsMoney = new List<int> { 1000, 300, 150 };

            foreach (int money in clientsMoney)
            {
                _queueClients.Enqueue(new Client(money));
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

            Product product = TryGetProduct(productSell, _listProductsSale);

            if (product != null)
            {
                client.Basket.Add(product);
                Console.WriteLine($"Покупатель положил в корзину: {product.Name}");

                int totalCost = IncreaseCost(client);
                Console.WriteLine($"Общая сумма: {totalCost}");
            }

            ContinueShopping(client);
        }

        private void ContinueShopping(Client client)
        {
            const string CommandPutProductInBasket = "1";
            const string CommandBuy = "2";

            PrintListProductsSale();
            Console.WriteLine($"МАГАЗИН: {CommandPutProductInBasket} - выбрать еще какой-то товар {CommandBuy} - купить то, что в корзине?");
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
                default:
                    ShowError();
                    break;
            }
        }

        private void PutProductInBag(Client client)
        {
            int totalCost = IncreaseCost(client);

            while (client.Money < totalCost)
            {
                if (client.Basket.Count == 0)
                {
                    Console.WriteLine("\nКорзина пуста");
                    break;
                }

                Console.WriteLine($"\nМАГАЗИН: Покупателю не хватает денег купить выбранные продукты\nНазвание товара, который убрать: ");
                Console.Write("ПОКУПАТЕЛЬ: ");
                string productDell = Console.ReadLine();

                Product product = TryGetProduct(productDell, client.Basket);

                if (product != null)
                {
                    client.Basket.Remove(product);
                    Console.WriteLine($"Покупатель убрал из корзины {product.Name}");

                    totalCost = IncreaseCost(client);
                    Console.WriteLine($"Общая сумма: {totalCost}");
                }

                if (client.Money >= totalCost)
                {
                    foreach (Product productClient in client.Basket)
                    {
                        if (client.SpendMoney(productClient.Price))
                        {
                            client.Bag.Add(productClient);
                            _money += productClient.Price;
                        }
                        else
                        {
                            Console.WriteLine("У клиента не хватает денег для покупки");
                        }
                    }

                    client.Basket.Clear();
                }
            }
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

                Console.WriteLine("\nМАГАЗИН: Данного товара нет\n");
                return null;
            }
            else
            {
                Console.WriteLine("\nМАГАЗИН: Закончились все товары\n");
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
            _money = money;
            Money = money;
        }

        public int Money { get; private set; }
        public List<Product> Basket = new List<Product>(_basket);
        public List<Product> Bag = new List<Product>(_bag);

        public void ShowInfo()
        {
            Console.WriteLine($"Кошелек: {Money}");
            Console.WriteLine($"Корзина: ");
            PrintListProducts(Basket);
            Console.WriteLine($"Сумка: ");
            PrintListProducts(Bag);
        }

        private void PrintListProducts(List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                products[i].ShowInfo();
            }
        }

        public bool SpendMoney(int amount)
        {
            if (_money >= amount)
            {
                _money -= amount;
                Money = _money;
                return true;
            }
            else
            {
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
