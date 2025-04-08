using System;
using System.Collections.Generic;

namespace Tasks_IJunior_02._06_OOP
{
    internal class Zoo
    {
        public static void Main(string[] args)
        {
            ZooPark zooPark = new ZooPark();
            zooPark.Create();
        }
    }

    public class ZooPark
    {
        private List<Aviary> _aviaries;

        public ZooPark()
        {
            _aviaries = new List<Aviary>
            {
                new Aviary("Вольер со львами", new List<Animal>
                {
                    new Animal("лев Симба", "мужского пола", "рычит"),
                    new Animal("львица Нала", "женского пола", "мурчит"),
                    new Animal("львенок Муфаса", "мужского пола", "урчит")
                }),
                new Aviary("Вольер с пандами", new List<Animal>
                {
                    new Animal("панда По", "мужского пола", "жует бамбук"),
                }),
                new Aviary("Вольер с утками", new List<Animal>
                {
                    new Animal("селезень", "мужского пола", "кря-кря"),
                    new Animal("утка", "женского пола", "кря-кря-кря"),
                    new Animal("утенок", "женского пола", "кря-кря-кря-кря-кря-кря...")
                }),
                new Aviary("Вольер с оленями", new List<Animal>
                {
                    new Animal("олень Бэмби", "мужского пола", "бодается"),
                    new Animal("олениха Фэлин", "женского пола", "ревет"),
                }),

                new Aviary("Вольер со змеями", new List<Animal>
                {
                    new Animal("змей Снэг", "мужского пола", "ползет"),
                    new Animal("змея Орочимару", "женского пола", "шипит"),
                }),

                new Aviary("Вольер с лисами", new List<Animal>
                {
                    new Animal("лис Курама", "мужского пола", "фыр-фыр"),
                }),
            };
        }        

        public void Create()
        {
            bool isInside = true;

            while (isInside)
            {
                Console.WriteLine("\nДобро пожаловать в зоопарк!\nКакой вольер желаете посетить?\n");

                for (int i = 0; i < _aviaries.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {_aviaries[i].Name}");
                }

                Console.WriteLine($"{_aviaries.Count + 1} Покинуть зоопарк\n");

                string userChose = Console.ReadLine();

                if (int.TryParse(userChose, out int choice) && choice >= 1 && choice <= _aviaries.Count + 1)
                {
                    if (choice == _aviaries.Count + 1)
                    {
                        Console.WriteLine("\nСпасибо, что посетили наш зоопарк!\nЖдем вас снова!\n");
                        isInside = false;
                    }
                    else
                    {
                        _aviaries[choice - 1].ShowAviaryInfo();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: Неверный ввод!\nСделайте выбор еще раз: ");
                }
            }
        }
    }

    public class Aviary
    {
        private List<Animal> _animals;

        public Aviary(string name, List<Animal> animals)
        {
            Name = name;
            _animals = animals;
        }

        public string Name { get; }
        public int AnimalCount => _animals.Count;

        public void ShowAnimalInfo()
        {
            foreach (Animal animal in _animals)
            {
                animal.ShowAnimalInfo();
            }
        }

        public void ShowAviaryInfo()
        {
            Console.WriteLine($"\n{Name}");
            Console.WriteLine($"Количество животных: {AnimalCount}\n");
            ShowAnimalInfo();
        }

        protected void AddAnimal(Animal animal)
        {
            _animals.Add(animal);
        }
    }

    public class Animal
    {
        public Animal(string type, string sex, string sound)
        {
            Type = type;
            Sex = sex;
            Sound = sound;
        }

        public string Type { get; }
        public string Sex { get; }
        public string Sound { get; }

        public void ShowAnimalInfo()
        {
                Console.WriteLine($"Вид: {Type}, Пол: {Sex}, Звук: {Sound}");
        }
    }
}
