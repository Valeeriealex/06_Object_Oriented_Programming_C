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
        private AviaryCats aviaryCats = new AviaryCats();
        private AviaryReptiles aviaryReptiles = new AviaryReptiles();
        private AviaryBirds aviaryBirds = new AviaryBirds();
        private AviaryHerbivores aviaryHerbivores = new AviaryHerbivores();
        private AviaryPredator aviaryPredators = new AviaryPredator();

        public void Create()
        {
            aviaryCats.FillWithDefaultAnimals();
            aviaryReptiles.FillWithDefaultAnimals();
            aviaryBirds.FillWithDefaultAnimals();
            aviaryHerbivores.FillWithDefaultAnimals();
            aviaryPredators.FillWithDefaultAnimals();

            bool isInside = true;

            while (isInside)
            {
                const string MenuAviaryCats = "1";
                const string MenuAviaryReptiles = "2";
                const string MenuAviaryBirds = "3";
                const string MenuAviaryHerbivores = "4";
                const string MenuAviaryPredator = "5";
                const string MenuGoOutside = "6";

                Console.WriteLine("\nДобро пожаловать в зоопарк!\nКакой вольер желаете посетить? ");
                Console.WriteLine($"\n{MenuAviaryCats} - Вольер с кошачьими\n{MenuAviaryReptiles} - Вольер с рептилиями\n" +
                    $"{MenuAviaryBirds} - Вольер с пернатыми\n{MenuAviaryHerbivores} - Вольер с травоядными\n{MenuGoOutside} - Покинуть зоопарк\n");

                string userChose = Console.ReadLine();

                switch (userChose)
                {
                    case MenuAviaryCats:
                        aviaryCats.ShowInfo();
                        break;

                    case MenuAviaryReptiles:
                        aviaryReptiles.ShowInfo();
                        break;

                    case MenuAviaryBirds:
                        aviaryBirds.ShowInfo();
                        break;

                    case MenuAviaryHerbivores:
                        aviaryHerbivores.ShowInfo();
                        break;

                    case MenuAviaryPredator:
                        aviaryPredators.ShowInfo();
                        break;

                    case MenuGoOutside:
                        isInside = false;
                        break;

                    default:
                        Console.WriteLine("Ошибка: Неверный ввод!\nСделайте выбор еще раз: ");
                        break;
                }
            }
        }
    }

    public class AviaryCats : Aviary
    {
        public AviaryCats() : base("\nВольер с кошачьими\n") { }

        public void FillWithDefaultAnimals()
        {
            AddAnimal(new Animal("лев Лева", "мужского пола", "рычит"));
            AddAnimal(new Animal("пантера Багира", "женского пола", "мурчит"));
            AddAnimal(new Animal("тигр Полосатик", "мужского пола", "урчит"));
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"\n{Name}");
            Console.WriteLine($"Количество кошек: {AnimalCount}\n");
            GetAnimalInfo();
        }
    }

    public class AviaryReptiles : Aviary
    {
        public AviaryReptiles() : base("\nВольер с рептилиями\n") { }

        public void FillWithDefaultAnimals()
        {
            AddAnimal(new Animal("крокодил Гена", "мужского пола", "открывает пасть"));
            AddAnimal(new Animal("ящерица Яр", "мужского пола", "ползает"));
            AddAnimal(new Animal("змея Снэг", "женского пола", "шипит"));
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"\n{Name}");
            Console.WriteLine($"Количество рептилий: {AnimalCount}\n");
            GetAnimalInfo();
        }
    }

    public class AviaryBirds : Aviary
    {
        public AviaryBirds() : base("\nВольер с птицами\n") { }

        public void FillWithDefaultAnimals()
        {
            AddAnimal(new Animal("попугай Кеша", "мужского пола", "всех приветствует"));
            AddAnimal(new Animal("тукан Жако", "женского пола", "тук-тук"));
            AddAnimal(new Animal("павлин Арджун", "мужского пола", "раскрывает хвост"));
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"\n{Name}");
            Console.WriteLine($"Количество птиц: {AnimalCount}\n");
            GetAnimalInfo();
        }
    }

    public class AviaryHerbivores : Aviary
    {
        public AviaryHerbivores() : base("\nВольер с травоядными\n") { }

        public void FillWithDefaultAnimals()
        {
            AddAnimal(new Animal("жираф Стив", "мужского пола", "жует листья"));
            AddAnimal(new Animal("слон Мэни", "женского пола", "трубит"));
            AddAnimal(new Animal("олень Бэмби", "мужского пола", "ревет"));
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"\n{Name}");
            Console.WriteLine($"Количество животных: {AnimalCount}\n");
            GetAnimalInfo();
        }
    }

    public class AviaryPredator : Aviary
    {
        public AviaryPredator() : base("\nВольер с хищниками\n") { }

        public void FillWithDefaultAnimals()
        {
            AddAnimal(new Animal("медведь Миша", "мужского пола", "сопит"));
            AddAnimal(new Animal("волк Альфа", "мужского пола", "воет"));
            AddAnimal(new Animal("лиса Курама", "женского пола", "фырчит"));
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"\n{Name}");
            Console.WriteLine($"Количество хищников: {AnimalCount}\n");
            GetAnimalInfo();
        }
    }

    public abstract class Aviary
    {
        private string name;
        private List<Animal> animals;

        public Aviary(string name)
        {
            this.name = name;
            this.animals = new List<Animal>();
        }

        public string Name => name;
        public int AnimalCount => animals.Count;

        protected void AddAnimal(Animal animal)
        {
            animals.Add(animal);
        }

        public void GetAnimalInfo() 
        {
            foreach (Animal animal in animals)
            {
                Console.WriteLine($"Вид: {animal.Type}, Пол: {animal.Sex}, Звук: {animal.Sound}");
            }
        }

        public abstract void ShowInfo();
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
    }
}
