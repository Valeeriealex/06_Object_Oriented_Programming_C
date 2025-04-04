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
                new AviaryCats(),
                new AviaryReptiles(),
                new AviaryBirds(),
                new AviaryHerbivores(),
                new AviaryPredator()
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

                Console.WriteLine($"{_aviaries.Count + 1}\nПокинуть зоопарк\n");

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

    public class AviaryCats : Aviary
    {
        public AviaryCats() : base("\nВольер с кошачьими\n") 
        {
            FillWithDefaultAnimals();
        }

        public override void ShowAviaryInfo()
        {
            Console.WriteLine($"\n{Name}");
            Console.WriteLine($"Количество кошек: {AnimalCount}\n");
            ShowAnimalInfo();
        }
        
        protected override void FillWithDefaultAnimals()
        {
            AddAnimal(new Animal("лев Лева", "мужского пола", "рычит"));
            AddAnimal(new Animal("пантера Багира", "женского пола", "мурчит"));
            AddAnimal(new Animal("тигр Полосатик", "мужского пола", "урчит"));
        }
    }

    public class AviaryReptiles : Aviary
    {
        public AviaryReptiles() : base("\nВольер с рептилиями\n") 
        {
            FillWithDefaultAnimals();
        }

        public override void ShowAviaryInfo()
        {
            Console.WriteLine($"\n{Name}");
            Console.WriteLine($"Количество рептилий: {AnimalCount}\n");
            ShowAnimalInfo();
        }

        protected override void FillWithDefaultAnimals()
        {
            AddAnimal(new Animal("крокодил Гена", "мужского пола", "открывает пасть"));
            AddAnimal(new Animal("ящерица Яр", "мужского пола", "ползает"));
            AddAnimal(new Animal("змея Снэг", "женского пола", "шипит"));
        }
    }

    public class AviaryBirds : Aviary
    {
        public AviaryBirds() : base("\nВольер с птицами\n") 
        {
            FillWithDefaultAnimals();
        }

        public override void ShowAviaryInfo()
        {
            Console.WriteLine($"\n{Name}");
            Console.WriteLine($"Количество птиц: {AnimalCount}\n");
            ShowAnimalInfo();
        }

        protected override void FillWithDefaultAnimals()
        {
            AddAnimal(new Animal("попугай Кеша", "мужского пола", "всех приветствует"));
            AddAnimal(new Animal("тукан Жако", "женского пола", "тук-тук"));
            AddAnimal(new Animal("павлин Арджун", "мужского пола", "раскрывает хвост"));
        }
    }

    public class AviaryHerbivores : Aviary
    {
        public AviaryHerbivores() : base("\nВольер с травоядными\n") 
        {
            FillWithDefaultAnimals();
        }

        public override void ShowAviaryInfo()
        {
            Console.WriteLine($"\n{Name}");
            Console.WriteLine($"Количество животных: {AnimalCount}\n");
            ShowAnimalInfo();
        }

        protected override void FillWithDefaultAnimals()
        {
            AddAnimal(new Animal("жираф Стив", "мужского пола", "жует листья"));
            AddAnimal(new Animal("слон Мэни", "женского пола", "трубит"));
            AddAnimal(new Animal("олень Бэмби", "мужского пола", "ревет"));
        }
    }

    public class AviaryPredator : Aviary
    {
        public AviaryPredator() : base("\nВольер с хищниками\n") 
        {
            FillWithDefaultAnimals();
        }

        public override void ShowAviaryInfo()
        {
            Console.WriteLine($"\n{Name}");
            Console.WriteLine($"Количество хищников: {AnimalCount}\n");
            ShowAnimalInfo();
        }

        protected override void FillWithDefaultAnimals()
        {
            AddAnimal(new Animal("медведь Миша", "мужского пола", "сопит"));
            AddAnimal(new Animal("волк Альфа", "мужского пола", "воет"));
            AddAnimal(new Animal("лиса Курама", "женского пола", "фырчит"));
        }
    }

    public abstract class Aviary
    {
        private string _name;
        private List<Animal> _animals;

        public Aviary(string name)
        {
            this._name = name;
            this._animals = new List<Animal>();
        }

        public string Name => _name;
        public int AnimalCount => _animals.Count;

        public void ShowAnimalInfo()
        {
            foreach (Animal animal in _animals)
            {
                animal.ShowAnimalInfo();
            }
        }

        public abstract void ShowAviaryInfo();
        protected abstract void FillWithDefaultAnimals();

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

        public string Type { get; set; }
        public string Sex { get; set; }
        public string Sound { get; set; }

        public void ShowAnimalInfo()
        {
                Console.WriteLine($"Вид: {Type}, Пол: {Sex}, Звук: {Sound}");
        }
    }
}
