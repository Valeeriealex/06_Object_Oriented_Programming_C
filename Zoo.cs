using System;
using System.Collections.Generic;

namespace Tasks_IJunior_02._06_OOP
{
    internal class Zoo
    {
        public static void Main(string[] args)
        {
            ZooPark zooPark = new ZooPark();
            zooPark.Work();
        }
    }

    public class ZooPark
    {
        private List<Aviary> _aviaries;

        public ZooPark()
        {
            List<Animal> animals = new List<Animal>
            {
                new Animal("лев Симба", "мужского пола", "рычит"),
                new Animal("львица Нала", "женского пола", "мурчит"),
                new Animal("львенок Муфаса", "мужского пола", "урчит"),
                new Animal("панда По", "мужского пола", "жует бамбук"),
                new Animal("селезень", "мужского пола", "кря-кря"),
                new Animal("утка", "женского пола", "кря-кря-кря"),
                new Animal("утенок", "женского пола", "кря-кря-кря-кря-кря-кря..."),
                new Animal("олень Бэмби", "мужского пола", "бодается"),
                new Animal("олениха Фэлин", "женского пола", "ревет"),
                new Animal("змей Снэг", "мужского пола", "ползет"),
                new Animal("змея Орочимару", "женского пола", "шипит"),
                new Animal("лис Курама", "мужского пола", "фыр-фыр"),
            };

            _aviaries = CreateAviaries(animals);
        }

        private List<Aviary> CreateAviaries(List<Animal> animals)
        {
            Dictionary<string, List<string>> animalTypes = new Dictionary<string, List<string>>
            {
                { "лев", new List<string> { "лев Симба", "львица Нала", "львенок Муфаса" } },
                { "панда", new List<string> { "панда По" } },
                { "утка", new List<string> { "утка", "селезень", "утенок" } },
                { "олень", new List<string> { "олень Бэмби", "олениха Фэлин" } },
                { "змей", new List<string> { "змей Снэг", "змея Орочимару" } },
                { "лис", new List<string> { "лис Курама" } }
            };

            List<Animal> lionAviary = new List<Animal>();
            List<Animal> pandaAviary = new List<Animal>();
            List<Animal> duckAviary = new List<Animal>();
            List<Animal> deerAviary = new List<Animal>();
            List<Animal> snakeAviary = new List<Animal>();
            List<Animal> foxAviary = new List<Animal>();

            foreach (var beast in animalTypes)
            {
                string type = beast.Key;
                List<string> names = beast.Value;

                foreach (var name in names)
                {
                    string sex = name.Contains("мужского пола") ? "мужского пола" : "женского пола";
                    string sound = GetAnimalSound(name);

                    Animal animal = new Animal(name, sex, sound);

                    switch (type)
                    {
                        case "лев":
                            lionAviary.Add(animal);
                            break;
                        case "панда":
                            pandaAviary.Add(animal);
                            break;
                        case "утка":
                            duckAviary.Add(animal);
                            break;
                        case "олень":
                            deerAviary.Add(animal);
                            break;
                        case "змей":
                            snakeAviary.Add(animal);
                            break;
                        case "лис":
                            foxAviary.Add(animal);
                            break;
                    }
                }
            }

            return new List<Aviary>
            {
                new Aviary("Вольер со львами", lionAviary),
                new Aviary("Вольер с пандами", pandaAviary),
                new Aviary("Вольер с утками", duckAviary),
                new Aviary("Вольер с оленями", deerAviary),
                new Aviary("Вольер со змеями", snakeAviary),
                new Aviary("Вольер с лисами", foxAviary),
            };
        }

        private string GetAnimalSound(string name)
        {
            if (name.Contains("лев") || name.Contains("львица") || name.Contains("львенок"))
                return "рычит";
            if (name.Contains("панда"))
                return "жует бамбук";
            if (name.Contains("утка") || name.Contains("селезень") || name.Contains("утенок"))
                return "кря-кря";
            if (name.Contains("олень") || name.Contains("олениха"))
                return "бодается";
            if (name.Contains("змей") || name.Contains("змея"))
                return "шипит";
            if (name.Contains("лис"))
                return "фыр-фыр";

            return "неизвестный звук";
        }

        public void Work()
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
                animal.ShowlInfo();
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

        public void ShowlInfo()
        {
            Console.WriteLine($"Вид: {Type}, Пол: {Sex}, Звук: {Sound}");
        }
    }
}
