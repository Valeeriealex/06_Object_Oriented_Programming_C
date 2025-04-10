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
            List<Animal> lionAviary = new List<Animal>();
            List<Animal> pandaAviary = new List<Animal>();
            List<Animal> duckAviary = new List<Animal>();
            List<Animal> deerAviary = new List<Animal>();
            List<Animal> snakeAviary = new List<Animal>();
            List<Animal> foxAviary = new List<Animal>();

            foreach (Animal animal in animals)
            {
                if (animal.Type.StartsWith("лев") || animal.Type.StartsWith("львица") || animal.Type.StartsWith("львенок"))
                {
                    lionAviary.Add(animal);
                }
                else if (animal.Type.StartsWith("панда"))
                {
                    pandaAviary.Add(animal);
                }
                else if (animal.Type.StartsWith("утка") || animal.Type.StartsWith("селезень") || animal.Type.StartsWith("утенок"))
                {
                    duckAviary.Add(animal);
                }
                else if (animal.Type.StartsWith("олень") || animal.Type.StartsWith("олениха") || animal.Type.StartsWith("олененок"))
                {
                    deerAviary.Add(animal);
                }
                else if (animal.Type.StartsWith("змей") || animal.Type.StartsWith("змея"))
                {
                    snakeAviary.Add(animal);
                }
                else if (animal.Type.StartsWith("лис") || animal.Type.StartsWith("лисица") || animal.Type.StartsWith(""))
                {
                    foxAviary.Add(animal);
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
