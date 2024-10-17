//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection.Emit;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;
//using static Tasks_IJunior_02._06_OOP.PlayerDatabase;

//namespace Tasks_IJunior_02._06_OOP
//{
//    internal class Database
//    {
//        static void Main(string[] args)
//        {
//            PlayerDatabase playerDatabase = new PlayerDatabase();
//            playerDatabase.StartWork();
//        }
//    }

//    public class PlayerDatabase
//    {
//        private List<Player> _players = new List<Player>();
//        private List<Player> _bannedPlayer = new List<Player>();

//        public void StartWork()
//        {
//            const string MenuPrintDatabase = "1";
//            const string MenuAddPlayer = "2";
//            const string MenuBanPlayer = "3";
//            const string MenuUnbanPlayer = "4";
//            const string MenuDeletePlayer = "5";
//            const string MenuExitCommand = "6";

//            bool isWork = true;

//            while (isWork)
//            {
//                Console.WriteLine("База данных игроков");

//                Console.WriteLine($"Выберете действие:\n {MenuPrintDatabase} - напечатать игроков\n {MenuAddPlayer} - добавить игрока" +
//                    $"\n {MenuBanPlayer} - забанить игрока\n {MenuUnbanPlayer} - разбанить игрока\n {MenuDeletePlayer} - удалить игрока\n {MenuExitCommand} - выйти");

//                string _userChoice = Console.ReadLine();

//                switch (_userChoice)
//                {
//                    case MenuPrintDatabase:
//                        PrintPlayerDatabase();
//                        break;

//                    case MenuAddPlayer:
//                        AddPlayer();
//                        break;

//                    case MenuBanPlayer:
//                        BanPlayer();
//                        break;

//                    case MenuUnbanPlayer:
//                        UnbanPlayer();
//                        break;

//                    case MenuDeletePlayer:
//                        DeletePlayer();
//                        break;

//                    case MenuExitCommand:
//                        isWork = false;
//                        break;

//                    default:
//                        Console.WriteLine("Ошибка ввода");
//                        break;
//                }
//            }
//        }

//        private int SearchID( List<Player> players, out Player player)
//        {
//            Console.WriteLine("Введите ID игрока: ");
//            int id = ConvertNumber();

//            for (int i = 0; i < players.Count; i++)
//            {
//                if (players[i].PlayerId == id)
//                {
//                    player = players[i];
//                    return id;
//                }
//            }

//            player = null;

//            return 0;
//        }

//        private int ConvertNumber()
//        {
//            int number;

//            while (int.TryParse(Console.ReadLine(), out number) == false)
//            {
//                Console.WriteLine("Ошибка: введено не число\nПопробуйте еще раз");
//            }

//            return number;
//        }

//        private void AddPlayer()
//        {
//            Console.WriteLine("Введите никнейм игрока: ");
//            string playerNickname = Console.ReadLine();
//            Console.WriteLine("Укажите уровень игрока: ");
//            int playerLevel = SetLevel();

//            _players.Add(new Player(playerNickname, playerLevel));

//            Console.WriteLine($"Игрок с именем {playerNickname} и уровнем {playerLevel} добавлен " +
//                $"Присвоено ID: {_players[_players.Count - 1].PlayerId}.");
//        }

//        private int SetLevel()
//        {
//            int minimumLevel = 0;
//            int maximumLevel = 100;

//            int level = ConvertNumber();

//            if (level <= minimumLevel || level > maximumLevel)
//            {
//                Console.WriteLine($"Уровень не может быть меньше {minimumLevel} и больше {maximumLevel}\nПопробуйте еще раз");
//                level = SetLevel();
//            }

//            return level;
//        }

//        private void BanPlayer()
//        {
//            int i = SearchID(_players, out Player player);

//            if (i == 0)
//            {
//                Console.WriteLine("Игрока с таким ID не найдено");
//            }
//            else
//            {
//                player.Ban();
//                _bannedPlayer.Add(_players[i - 1]);
//                _players.RemoveAt(i - 1);
//            }
//        }

//        private void UnbanPlayer()
//        {
//            int i = SearchID(_bannedPlayer, out Player player);

//            if (i == 0)
//            {
//                Console.WriteLine("Игрока с таким ID не найдено");
//            }
//            else
//            {
//                player.Unban();
//                _players.Add(_bannedPlayer[i - 1]);
//                _bannedPlayer.RemoveAt(i - 1);
//            }
//        }

//        private void DeletePlayer()
//        {
//            int playerIDRemoved;
//            playerIDRemoved = SearchID(_players, out Player player);

//            if (playerIDRemoved == 0)
//            {
//                Console.WriteLine("Игрока с таким ID не найдено");
//            }
//            else
//            {
//                _players.Remove(player);
//                Console.WriteLine($"Игрок с идентификатором {playerIDRemoved} удален") ;
//            }
//        }

//        private void PrintPlayerDatabase()
//        {
//            Console.WriteLine("Игроки: ");

//            for (int i = 0; i < _players.Count; i++)
//            {
//                _players[i].ShowInfo();
//            }

//            Console.WriteLine("Черный список: ");

//            for (int i = 0; i < _bannedPlayer.Count; i++)
//            {
//                _bannedPlayer[i].ShowInfo();
//            }
//        }
//    }

//    public class Player
//    {
//        private static int s_counter = 1;

//        public Player(string nickname, int level)
//        {
//            PlayerId = s_counter++;
//            Nickname = nickname;
//            Level = level;
//            IsBan = false;
//        }

//        public int PlayerId { get; private set; }
//        public string Nickname { get; private set; }
//        public int Level { get; private set; }
//        public bool IsBan { get; private set; }

//        public void ShowInfo()
//        {
//            string informationForBan;

//            if (IsBan)
//            {
//                informationForBan = "бан";
//            }
//            else
//            {
//                informationForBan = "не бан";
//            }

//            Console.WriteLine($"ИД: {PlayerId} Никнейм: {Nickname} Уровень: {Level} Статус бана: {informationForBan}");
//        }

//        public void Ban()
//        {
//                IsBan = true;
//                Console.WriteLine($"Игрок {Nickname} с идентификатором {PlayerId} забанен");     
//        }

//        public void Unban()
//        {
//                IsBan = false;
//                Console.WriteLine($"Игрок {Nickname} с идентификатором {PlayerId} разабанен");  
//        }
//    }
//}
