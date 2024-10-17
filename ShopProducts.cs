//using System;
//using System.Collections.Generic;

//namespace Tasks_IJunior_02._06_OOP
//{
//    internal class ShopProducts
//    {
//        static void Main(string[] args)
//        {
//            Shop shop = new Shop();
//            shop.Work();
//        }
//    }

//    public class Shop
//    {
//        private Seller _seller;
//        private Buyer _buyer;

//        public Shop()
//        {
//            _seller = new Seller();
//            _buyer = new Buyer();
//        }

//        public void Work()
//        {
//            const string CommandBuyProduct = "1";
//            const string CommandExit = "2";

//            ShowInfo();

//            bool isWork = true;

//            while (isWork)
//            {
//                Console.WriteLine("\nПРОДАВЕЦ: Здравсвуйте! Желаете преобрести какой-то товар?");
//                Console.WriteLine($"ПОКУПАТЕЛЬ: Здравсвуйте!\n{CommandBuyProduct} - Да, желаю купить товар\n{CommandExit} - Нет, я ухожу ");
//                Console.Write("ПОКУПАТЕЛЬ: ");

//                switch (Console.ReadLine())
//                {
//                    case CommandBuyProduct:
//                        TransferProduct();
//                        break;

//                    case CommandExit:
//                        isWork = Exit();
//                        break;

//                    default:
//                        ShowError();
//                        break;
//                }
//            }
//        }

//        private void ContinueShopping()
//        {
//            const string CommandBuyProduct = "1";
//            const string CommandShowProducts = "2";
//            const string CommandExit = "3";

//            ShowInfo();

//            bool isWork = true;

//            while (isWork)
//            {
//                Console.WriteLine("\nПРОДАВЕЦ: Возможно, Вам нужно что-то еще?");
//                Console.WriteLine($"ПОКУПАТЕЛЬ:\n{CommandBuyProduct} - Да, купить товар\n{CommandShowProducts} - Посмотреть, что уже купилено\n{CommandExit} - Нет, выйти");
//                Console.Write("ПОКУПАТЕЛЬ: ");

//                switch (Console.ReadLine())
//                {
//                    case CommandBuyProduct:
//                        TransferProduct();
//                        break;

//                    case CommandShowProducts:
//                        ViewPurchasedProducts();
//                        break;

//                    case CommandExit:
//                        isWork = Exit();
//                        break;

//                    default:
//                        ShowError();
//                        break;
//                }
//            }
//        }

//        private void ShowInfo()
//        {
//            Console.WriteLine($"\nКошелек покупателя: {_buyer.Money} руб.\nВыручка продовца: {_seller.Money} руб.\nТовары в магазине: \n");
//            _seller.ShowAllProducts();
//        }

//        private void TransferProduct()
//        {
//            Console.WriteLine("\nПРОДАВЕЦ: Название товара: ");
//            Console.Write("ПОКУПАТЕЛЬ: ");
//            string productSell = Console.ReadLine();

//            Product product;

//            if (_seller.TryGetProduct(productSell, out product))
//            {
//                if (_buyer.CanBuyProduct(product.Price))
//                {
//                    _seller.SellProduct(product);
//                    _buyer.BuyProduct(product);
//                }
//                else
//                {
//                    Console.WriteLine("\nПРОДАВЕЦ: К сожалению, у Вас недостаточного денег для покупки товара\n");
//                }
//            }

//            ShowInfo();
//            ContinueShopping();
//        }

//        private void ViewPurchasedProducts()
//        {
//            Console.WriteLine("\nТовары у покупателя: ");
//            _buyer.ShowAllProducts();
//            ShowInfo();
//        }

//        private bool Exit()
//        {
//            Console.WriteLine("\nПРОДАВЕЦ: Спасибо, что посетили наш магазин, ждем Вас снова. Досвидания!");
//            Console.WriteLine("ПОКУПАТЕЛЬ: Спасибо! Досвидания!");
//            return false;
//        }

//        private void ShowError()
//        {
//            Console.WriteLine("\nОшибка: Неккоректный ввод\n");
//        }
//    }

//    public class Product
//    {
//        public Product(string name, string brand, int price)
//        {
//            Name = name;
//            Brand = brand;
//            Price = price;
//        }

//        public string Name { get; private set; }
//        public string Brand { get; private set; }
//        public int Price { get; private set; }

//        public void ShowInfo()
//        {
//            Console.WriteLine($"Товар: {Name}, Производитель: {Brand}, Стоимость: {Price}");
//        }
//    }

//    public class Human
//    {
//        protected List<Product> ProductList = new List<Product>();

//        public Human(int money)
//        {
//            Money = money;
//        }

//        public int Money { get; protected set; }

//        public void ShowAllProducts()
//        {
//            foreach (Product product in ProductList)
//            {
//                product.ShowInfo();
//            }
//        }
//    }

//    public class Seller : Human
//    {
//        public Seller() : base(0)
//        {
//            AddProducts();
//        }

//        public bool TryGetProduct(string productName, out Product product)
//        {
//            product = null;

//            if (ProductList.Count > 0)
//            {
//                foreach (Product element in ProductList)
//                {
//                    if (element.Name.ToLower() == productName.ToLower())
//                    {
//                        product = element;
//                        return true;
//                    }
//                }

//                Console.WriteLine("\nПРОДАВЕЦ: Данного товара нет в магазине\n");
//                return false;
//            }
//            else
//            {
//                Console.WriteLine("\nПРОДАВЕЦ: В магазине закончились все товары\n");
//                return false;
//            }
//        }

//        public void SellProduct(Product product)
//        {
//            if (product != null)
//            {
//                ProductList.Remove(product);
//                Money += product.Price;
//            }
//        }

//        private void AddProducts()
//        {
//            ProductList.Add(new Product("Шоколад", "Kinder", 100));
//            ProductList.Add(new Product("Печеньки", "Milka", 150));
//            ProductList.Add(new Product("Пирожные", "Choco Pie", 200));
//        }
//    }

//    public class Buyer : Human
//    {
//        public Buyer() : base(1000) { }

//        public void BuyProduct(Product product)
//        {
//            ProductList.Add(product);
//            Money -= product.Price;
//        }

//        public bool CanBuyProduct(int productPrice)
//        {
//            return Money >= productPrice;
//        }
//    }
//}
