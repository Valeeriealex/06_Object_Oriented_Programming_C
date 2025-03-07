using System;
using System.Collections.Generic;

namespace Tasks_IJunior_02._06_OOP
{
    internal class Aquarium
    {
        public static void Main(string[] args)
        {
            AquariumFish aquariumFish = new AquariumFish();
            aquariumFish.Create();
        }
    }

    public class AquariumFish
    {
        private List<Fish> _fishs;
        private int _maximumFish = 10;
        private const int AgeIncrement = 1;
        private const int MaxAge = 10;
        private bool _isAlive = true;

        public AquariumFish()
        {
            _fishs = new List<Fish>();
        }

        public void Create()
        {
            createStartStateAquarium();

            while (_isAlive)
            {
                const string MenuAddFish = "1";
                const string MenuTakeFish = "2";
                const string MenuExit = "3";

                printFishes();

                Console.WriteLine($"{MenuAddFish} - Добавить рыбку {MenuTakeFish} - Вытащить рыбку {MenuExit} - Выйти");
                string userChose = Console.ReadLine();

                switch (userChose)
                {
                    case MenuAddFish:
                        addFish();
                        break;

                    case MenuTakeFish:
                        takeFish();
                        break;

                    case MenuExit:
                        _isAlive = false;
                        break;

                    default:
                        Console.WriteLine("Ошибка: Неверный ввод");
                        break;
                }

                ageFish();
            }
        }

        private void ageFish()
        {
            for (int i = _fishs.Count - 1; i >= 0; i--)
            {
                _fishs[i].TakeAge(AgeIncrement);

                if (_fishs[i].Age > MaxAge)
                {
                    Console.WriteLine($"Рыбка {_fishs[i].Type} умерла");
                    _fishs.RemoveAt(i);
                }
            }
        }

        private void addFish()
        {
            Console.WriteLine("Введите название рыбки: ");
            string nameFish = Console.ReadLine();
            Console.WriteLine("Укажите возраст рыбки: ");
            int ageFish = Convert.ToInt32(Console.ReadLine());

            if (_fishs.Count < _maximumFish)
            {
                _fishs.Add(new Fish(nameFish, ageFish));
            }
            else
            {
                Console.WriteLine("Ошибка: Аквариум переполнен");
            }
        }

        private void takeFish()
        {
            Console.WriteLine("Введите номер рыбки: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int fishNumber))
            {
                int indexToRemove = fishNumber - 1;

                if (indexToRemove >= 0 && indexToRemove < _fishs.Count)
                {
                    _fishs.RemoveAt(indexToRemove);
                    Console.WriteLine("Рыбка была удалена из аквариума");
                }
                else
                {
                    Console.WriteLine("Такой рыбки нет");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Введите корректный номер рыбки");
            }
        }

        private void printFishes()
        {
            Console.WriteLine("Рыбки в аквариуме: ");

            if (_fishs.Count == 0)
            {
                Console.WriteLine("Аквариум пуст");
            }
            else
            {
                for (int i = 0; i < _fishs.Count; i++)
                {
                    _fishs[i].ShowInfo();
                }
            }
        }

        private void createStartStateAquarium()
        {
            _fishs.Add(new Fish("Золотая рыбка", 3));
            _fishs.Add(new Fish("Скалярия", 4));
            _fishs.Add(new Fish("Анциструс", 5));
            _fishs.Add(new Fish("Гуппи", 1));
        }
    }

    public class Fish
    {
        public Fish(string type, int age)
        {
            Type = type;
            Age = age;
        }

        public string Type { get; private set; }
        public int Age { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Вид: {Type}, Возраст: {Age}");
        }

        public void TakeAge(int ageIncrement)
        {
            Age += ageIncrement;
        }
    }
}
