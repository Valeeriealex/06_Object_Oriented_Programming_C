//using System;
//using System.Collections.Generic;
//using System.Diagnostics;

//namespace Tasks_IJunior_02._06_OOP
//{
//    internal class PassengerTrain
//    {
//        static void Main(string[] args)
//        {
//            Dispatcher dispatcher = new Dispatcher();
//            dispatcher.Work();
//        }
//    }

//    public class Dispatcher
//    {
//        private List<Train> _trains = new List<Train>();

//        public void Work()
//        {
//            const string CommandCreateTrain = "1";
//            const string CommandExit = "2";

//            bool isWork = true;

//            while (isWork)
//            {
//                ShowInfoAllTrains();

//                Console.WriteLine($"\n{CommandCreateTrain} - создание поезда {CommandExit} - завершение работы");

//                switch (Console.ReadLine())
//                {
//                    case CommandCreateTrain:
//                        CreateTrain();
//                        break;

//                    case CommandExit:
//                        isWork = false;
//                        break;

//                    default:
//                        ShowError();
//                        break;
//                }
//            }
//        }

//        private void CreateTrain()
//        {
//            Directions direction = GetDirection();

//            int passengers = GetRandomPassengers();
//            Console.WriteLine($"Количество проданных билетов: {passengers}");

//            List<Car> cars = CreateCars(passengers);
//            Train train = new Train(direction, passengers, cars);
//            _trains.Add(train);

//            Console.WriteLine($"ПОЕЗД СОЗДАН");
//            ShowInfoTrain(train);
//        }

//        private void ShowInfoAllTrains()
//        {
//            Console.WriteLine("\nВСЕ ПОЕЗДА");

//            foreach (var train in _trains)
//            {
//                ShowInfoTrain(train);
//            }
//        }

//        private void ShowInfoTrain(Train train)
//        {
//            Console.WriteLine($"Направление: {train.Direction}, Пассажиры: {train.Passengers}, Вагоны: {train.CarsAmount}");
//        }

//        private void ShowError()
//        {
//            Console.WriteLine("\nОшибка: Неккоректный ввод\n");
//        }

//        private Directions GetDirection()
//        {
//            string departurePoint = GetRightDirection("Откуда: ");
//            string arrivalPoint;

//            do
//            {
//                arrivalPoint = GetRightDirection("Куда: ");
//            } while (IsSameDirection(departurePoint, arrivalPoint) == false);

//            return new Directions(departurePoint, arrivalPoint);
//        }

//        private bool IsSameDirection(string departurePoint, string arrivalPoint)
//        {
//            if (departurePoint == arrivalPoint)
//            {
//                Console.WriteLine("Ошибка: Пункт отправления не может быть равен пункту прибытия. Пожалуйста, введите пункт прибытия снова.");
//                return false;
//            }

//            return true;
//        }

//        private string GetRightDirection(string direction)
//        {
//            Console.Write(direction);
//            string input = Console.ReadLine();

//            while (input == null || input.Length == 0)
//            {
//                Console.WriteLine("Ошибка: Направление не может быть пустым. Пожалуйста, введите направление снова.");
//                Console.Write(direction);
//                input = Console.ReadLine();
//            }

//            return input;
//        }

//        private int GetRandomPassengers()
//        {
//            int minimumNumberPassengers = 1;
//            int maximumNumberPassengers = 1001;
//            Random random = new Random();
//            return random.Next(minimumNumberPassengers, maximumNumberPassengers);
//        }

//        private List<Car> CreateCars(int passengers)
//        {
//            List<Car> cars = new List<Car>();

//            while (passengers > 0)
//            {
//                Car car = new Car();
//                int capacity = car.Capacity;

//                if (passengers >= capacity)
//                {
//                    passengers -= capacity;
//                    cars.Add(car);
//                }
//                else
//                {
//                    cars.Add(new Car(passengers));
//                    passengers = 0;
//                }
//            }

//            return cars;
//        }
//    }

//    public class Directions
//    {
//        public Directions(string departurePoint, string arrivalPoint)
//        {
//            DeparturePoint = departurePoint;
//            ArrivalPoint = arrivalPoint;
//        }

//        public string DeparturePoint { get; private set; }
//        public string ArrivalPoint { get; private set; }

//        public override string ToString()
//        {
//            return $"{DeparturePoint} - {ArrivalPoint}";
//        }
//    }

//    public class Train
//    {
//        private List<Car> _cars;

//        public Train(Directions direction, int passengers, List<Car> cars)
//        {
//            Direction = direction;
//            Passengers = passengers;
//            _cars = cars;
//        }

//        public Directions Direction { get; private set; }
//        public int Passengers { get; private set; }
//        public int CarsAmount => _cars.Count;
//    }

//    public class Car
//    {
//        public Car()
//        {
//            Capacity = 50;
//        }

//        public Car(int capacity)
//        {
//            Capacity = capacity;
//        }

//        public int Capacity { get; private set; }
//    }
//}
