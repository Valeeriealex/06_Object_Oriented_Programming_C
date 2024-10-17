//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Tasks_IJunior_02._06_OOP
//{
//    internal class Properties
//    {
//        static void Main(string[] args) 
//        {
//            Player player = new Player(5, 5, '@');
//            Renderer renderer = new Renderer();
//            renderer.Draw(player);
//        }
//    }

//    public class Player
//    { 
//        public Player (int playerPositionX, int playerPositionY, char playerChar)
//        {
//            PlayerPositionX = playerPositionX;
//            PlyerPositionY = playerPositionY;
//            PlayerChar = playerChar;
//        }

//        public int PlayerPositionX { get; private set; }
//        public int PlyerPositionY { get; private set; }
//        public char PlayerChar { get; private set; }
//    }

//    public class Renderer
//    {
//        public void Draw(Player player)
//        {
//            Console.CursorVisible = false;
//            Console.SetCursorPosition(player.PlayerPositionX, player.PlyerPositionY);
//            Console.WriteLine(player.PlayerChar);
//            Console.ReadKey(true);
//        }
//    }
//}
