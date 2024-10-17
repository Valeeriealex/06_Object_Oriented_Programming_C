//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Tasks_IJunior_02._06_OOP
//{
//    //Есть крупье(или игральный стол), который содержит колоду карт и игрока.
//    //Пользователь задает количество карт, которое надо получить игроку и крупье передает из колоды в игрока данное количество карт. 
//    //После выводится вся информация о картах игрока.

//    internal class CardDeck
//    {
//        static void Main(string[] args)
//        {
//            Croupier croupier = new Croupier();
//            croupier.Work();
//        }
//    }

//    public class Croupier
//    {
//        private Player _player;
//        public Deck _deck; 

//        public Croupier()
//        {
//            _player = new Player();
//            _deck = new Deck();
//        }

//        public void Work()
//        {
//            const string CommandTakeCard = "1";
//            const string CommandMenuExist = "2";

//            bool isWork = true;

//            while (isWork)
//            {
//                Console.WriteLine($"{CommandTakeCard} - взять карту(получить предсказание)" +
//                    $"\n{CommandMenuExist} - выйти");
//                string userChose = Console.ReadLine();

//                switch (userChose)
//                {
//                    case CommandTakeCard:
//                        TransferCard();
//                        break;

//                    case CommandMenuExist:
//                        isWork = false;
//                        break;

//                    default:
//                        Console.WriteLine("Ошибка");
//                        break;
//                }
//            }
//        }

//        private void TransferCard()
//        {
//            Console.WriteLine("Введите количество карт для получения: ");
//            int countCard = GetNumber();

//            for (int i = 0; i < countCard; i++)
//            {
//                Card card = _deck.GiveCard();
//                _player.AddCard(card);
//            }

//            _player.ShowCards();
//        }

//        private int GetNumber()
//        {
//            int number;

//            while (int.TryParse(Console.ReadLine(), out number) == false)
//            {
//                Console.WriteLine("Ошибка: введено не число\nПопробуйте еще раз");
//            }

//            return number;
//        }
//    }

//    public class Player
//    {
//        private List<Card> _cards;

//        public Player()
//        {
//            _cards = new List<Card>();
//        }

//        public void AddCard(Card card)
//        {
//            if (card != null)
//            {
//                _cards.Add(card);
//                Console.WriteLine($"Ваша карта: {card}");
//            }
//            else
//            {
//                Console.WriteLine("Карты в колоде закончились");
//            }
//        }

//        public void ShowCards()
//        {
//            Console.WriteLine("Все ваши карты: ");

//            foreach (var card in _cards)
//            {
//                Console.WriteLine(card.Suit + " " + card.Rank + card.Preds);
//            }
//        }
//    }

//    public class Deck
//    {
//        private List<Card> _cards;

//        public Deck()
//        {
//            _cards = new List<Card>();

//            Fill();

//            Shuffle();
//        }

//        public Card GiveCard()
//        {
//            if (_cards.Count > 0)
//            {
//                Card card = _cards[0];
//                _cards.RemoveAt(0);
//                return card;
//            }
//            else
//            {
//                return null;
//            }
//        }

//        private void Fill()
//        {
//            Console.OutputEncoding = Encoding.UTF8;
//            string[] suits = { "♣", "♦", "♥", "♠" };
//            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
//            string[] preds = { "Так оно и будет", "Будет иначе", "Все свершится, как задумано", "Лучше откажись от задуманного" };

//            for (int i = 0; i < suits.Length; i++)
//            {
//                for (int j = 0; j < ranks.Length; j++)
//                {
//                    for (int k = 0; k < preds.Length; k++)
//                    {
//                        _cards.Add(new Card(suits[i], ranks[j], preds[k]));
//                    }
//                }
//            }
//        }

//        private void Shuffle()
//        {
//            Console.WriteLine("Перемешиваю карты..");
//            Random random = new Random();
//            int count = _cards.Count - 1;

//            for (int i = count; i > 0; i--)
//            {
//                int nextCard = random.Next(_cards.Count);
//                Card tempCard = _cards[i];
//                _cards[i] = _cards[nextCard];
//                _cards[nextCard] = tempCard;
//            }
//        }
//    }

//    public class Card
//    {
//        public Card(string suit, string rank, string preds)
//        {
//            Suit = suit;
//            Rank = rank;
//            Preds = preds;
//        }

//        public string Suit { get; private set; }
//        public string Rank { get; private set; }
//        public string Preds { get; private set; }

//        public override string ToString()
//        {
//            return $"{Suit} {Rank} {Preds}";
//        }
//    }
//}
