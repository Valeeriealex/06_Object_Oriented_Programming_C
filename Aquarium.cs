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

        public AquariumFish()
        {
            _fishs = new List<Fish>();
        }

        public void Create()
        {
            CreateStartStateAquarium();
            bool isAlive = true;

            while (isAlive)
            {
                const string CommandAddFish = "1";
                const string CommandTakeFish = "2";
                const string CommandExit = "3";

                PrintFishes();

                Console.WriteLine($"{CommandAddFish} - Добавить рыбку {CommandTakeFish} - Вытащить рыбку {CommandExit} - Выйти");
                string userChose = Console.ReadLine();

                switch (userChose)
                {
                    case CommandAddFish:
                        AddFish();
                        break;

                    case CommandTakeFish:
                        TakeFish();
                        break;

                    case CommandExit:
                        isAlive = false;
                        break;

                    default:
                        Console.WriteLine("Ошибка: Неверный ввод");
                        break;
                }

                MakeFishOld();
            }
        }

        private void MakeFishOld()
        {
            int maxAge = 10;
            int ageIncrement = 1;

            for (int i = _fishs.Count - 1; i >= 0; i--)
            {
                _fishs[i].IncreaseAge(ageIncrement);

                if (_fishs[i].Age > maxAge)
                {
                    Console.WriteLine($"\nРыбка {_fishs[i].Type} умерла");
                    _fishs.RemoveAt(i);
                }
            }
        }

        private void AddFish()
        {
            int maximumFish = 10;

            Console.WriteLine("Введите название рыбки: ");
            string nameFish = Console.ReadLine();
            Console.WriteLine("Укажите возраст рыбки: ");
            int ageFish;

            while (!int.TryParse(Console.ReadLine(), out ageFish) || ageFish < 0 && ageFish > 10)
            {
                Console.WriteLine("Ошибка: Введите корректный возраст рыбки");
            }

            if (_fishs.Count < maximumFish)
            {
                _fishs.Add(new Fish(nameFish, ageFish));
            }
            else
            {
                Console.WriteLine("Ошибка: Аквариум переполнен");
            }
        }

        private void TakeFish()
        {
            Console.WriteLine("Введите номер рыбки: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int fishNumber))
            {
                int indexToRemove = fishNumber - 1;

                if (indexToRemove >= 0 && indexToRemove < _fishs.Count)
                {
                    _fishs.RemoveAt(indexToRemove);
                    Console.WriteLine("Вы убрали рыбку из аквариума");
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

        private void PrintFishes()
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

        private void CreateStartStateAquarium()
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

        public void IncreaseAge(int ageIncrement)
        {
            Age += ageIncrement;
        }
    }
}
