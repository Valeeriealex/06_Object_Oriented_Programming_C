//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Tasks_IJunior_02._06_OOP
//{
//    internal class Classes
//    {
//        static void Main(string[] args)
//        {
//            Player[] players = { new Player("Alex", 40, Rank.Expert), new Player("", 100, Rank.Master), new Player("Max", -1, Rank.Newbie) };

//            Console.WriteLine("Информация об игроках");

//            for (int i = 0; i < players.Length; i++) 
//            {
//                players[i].PrintPlayer();
//            }
//        }
//    }

//   public enum Rank
//    {
//        Newbie,
//        Expert,
//        Master
//    }

//    public class Player
//    {
//        private string _name;
//        private int _level;
//        private Rank _rank;

//        public Player(string name, int level, Rank rank) 
//        {  
//            if (name == "")
//            {
//                _name = "Player not installed";
//            }
//            else 
//            { 
//                _name = name; 
//            }
           
//            if (level <= 0)
//            {
//                _level = 0;
//            }
//            else 
//            {
//                _level = level; 
//            }

//            _rank = rank;
//        }

//        public void PrintPlayer ()
//        {
//            Console.WriteLine($"Имя игрока: {_name}\nУровень игрока: {_level}\nЗвание игрока: {_rank}");
//        }
//    }
//}
