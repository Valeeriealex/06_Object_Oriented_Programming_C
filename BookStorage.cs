//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static Tasks_IJunior_02._06_OOP.Storage;

//namespace Tasks_IJunior_02._06_OOP
//{
//    //Создать хранилище книг.
//    //Каждая книга имеет название, автора и год выпуска(можно добавить еще параметры). 
//    //В хранилище можно добавить книгу, убрать книгу, показать все книги и показать найденные книги по указанному параметру(по названию, по автору, по году выпуска).
//    internal class BookStorage
//    {
//        static void Main(string[] args)
//        {
//            Menu storage = new Menu();
//            storage.Work();
//        }
//    }

//    public class Menu
//    {
//        private Storage _shop;
//        public Menu()
//        {
//            _shop = new Storage();
//        }

//        public void Work()
//        {
//            const string CommandBookSearch = "1";
//            const string CommandShowAllBooks = "2";
//            const string CommandAddBook = "3";
//            const string CommandDeleteBook = "4";
//            const string CommandExit = "5";

//            bool isWork = true;

//            while (isWork)
//            {
//                Console.WriteLine($"\n{CommandBookSearch} - поиск книги\n{CommandShowAllBooks} - показать все книги\n" +
//                    $"{CommandAddBook} - добавить книгу\n{CommandDeleteBook} - убрать книгу\n{CommandExit} - выйти");
//                string userChose = Console.ReadLine();

//                switch (userChose)
//                {
//                    case CommandBookSearch:
//                        _shop.SearchBook();
//                        break;

//                    case CommandShowAllBooks:
//                        _shop.ShowAllBooks();
//                        break;

//                    case CommandAddBook:
//                        _shop.AddBook();
//                        break;

//                    case CommandDeleteBook:
//                        _shop.DeleteBook();
//                        break;

//                    case CommandExit:
//                        isWork = false;
//                        break;

//                    default:
//                        Console.WriteLine("Ошибка");
//                        break;
//                }
//            }
//        }
//    }

//    public class Storage
//    {
//        private List<Book> _books;

//        public Storage()
//        {
//            _books = new List<Book>();
//        }

//        public void AddBook()
//        {
//            Console.WriteLine("Введите ФИО автора: ");
//            string author = Console.ReadLine();
//            Console.WriteLine("Введите название книги: ");
//            string title = Console.ReadLine();
//            Console.WriteLine("Введите год пуликации: ");
//            int yearsPublication = GetNumber();

//            _books.Add(new Book(title, author, yearsPublication));

//            Console.WriteLine("Книга добавлена");
//        }

//        public void DeleteBook()
//        {
//            ShowAllBooks();
//            Console.WriteLine("\nВведите номер книги, чтобы убрать ее: ");
//            int indexbookForDelet = GetNumber() - 1;

//                if (indexbookForDelet >= 0 && indexbookForDelet < _books.Count)
//                {
//                    _books.RemoveAt(indexbookForDelet);
//                    Console.WriteLine("Книга убрана");
//                }
//            else
//                {
//                    Console.WriteLine("Такой книги нет");
//                }
//        }

//        private int GetNumber()
//        {
//            int number;

//            while (int.TryParse(Console.ReadLine(), out number) == false)
//            {
//                Console.WriteLine("Ошибка: введено не число\nПопробуйте еще раз:");
//            }

//            return number;
//        }

//        public void ShowAllBooks()
//        {
//            int i = 1;

//            foreach (var book in _books)
//            {
//                Console.WriteLine($"{i++} ");
//                ShowBook(book);
//            }
//        }

//        public void ShowBook(Book book)
//        {
//            Console.WriteLine($"Книга: \"{book.Title}\", Автор: {book.Author}, Год: {book.YearPublication}");
//        }

//        public void SearchBook()
//        {
//            const string CommandSearchBookTitle = "1";
//            const string CommandSearchBookAuthor = "2";
//            const string CommandSearchBookYear = "3";

//            Console.WriteLine($"Параметр поиска:\n {CommandSearchBookTitle} - название, {CommandSearchBookAuthor} - автор, {CommandSearchBookYear} - год: ");
//            string searchParam = Console.ReadLine().ToLower();

//            switch (searchParam)
//            {
//                case CommandSearchBookTitle:
//                    SearchBookTitle();
//                    break;

//                case CommandSearchBookAuthor:
//                    SearchBookAuthor();
//                    break;

//                case CommandSearchBookYear:
//                    SearchBookYear();
//                    break;

//                default: 
//                    Console.WriteLine("Ошибка"); 
//                    break;
//            }
//        }

//        private void SearchBookTitle()
//        {
//            Console.WriteLine("Введите название книги: ");
//            string searchValue = Console.ReadLine().ToLower();

//            bool isFound = false;

//            foreach (var book in _books)
//            {
//                if (book.Title.ToLower().Contains(searchValue))
//                {
//                    ShowBook(book);
//                    isFound = true;
//                }
//            }

//            if (!isFound)
//            {
//                Console.WriteLine("Книги не найдены");
//            }
//        }

//        private void SearchBookAuthor()
//        {
//            Console.WriteLine("Введите автора: ");
//            string searchValue = Console.ReadLine().ToLower();

//            bool isFound = false;

//            foreach (var book in _books)
//            {
//                if (book.Author.ToLower().Contains(searchValue))
//                {
//                    ShowBook(book);
//                    isFound = true;
//                }
//            }

//            if (!isFound)
//            {
//                Console.WriteLine("Книги не найдены");
//            }
//        }

//        private void SearchBookYear()
//        {
//            Console.WriteLine("Введите год: ");
//            int searchValue = GetNumber();

//            bool isFound = false;

//            foreach (var book in _books)
//            {
//                if (book.YearPublication == (searchValue))
//                {
//                    ShowBook(book);
//                    isFound = true;
//                }
//            }

//            if (!isFound)
//            {
//                Console.WriteLine("Книги не найдены");
//            }
//        }
//    }

//    public class Book
//    {
//        public Book(string title, string author, int yearPublication)
//        {
//            Title = title;
//            Author = author;
//            YearPublication = yearPublication;
//        }

//        public string Title { get; private set; }
//        public string Author { get; private set; }
//        public int YearPublication { get; private set; }
//    }
//}
