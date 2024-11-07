using System;

namespace Tasks_IJunior_02._06_OOP
{
   internal class GladiatorFights
   {
       static void Main(string[] args)
       {
           Arena arena = new Arena();
           arena.Work();
       }
   }

   public class Arena
   {
       private Fighter _fighterOne;
       private Fighter _fighterTwo;
       private string _nameGaimerNumberOne;
       private string _nameGaimerNumberTwo;
       private int _minimumHealth = 0;

       public void Work()
       {
           const string CommandStartGame = "1";
           const string CommandExit = "2";

           bool isWork = true;

           while (isWork)
           {
               Console.WriteLine($"\n{CommandStartGame} - начать игру {CommandExit} - выйти");

               switch (Console.ReadLine())
               {
                   case CommandStartGame:
                       Play();
                       break;

                   case CommandExit:
                       isWork = false;
                       break;

                   default:
                       ShowError();
                       break;
               }
           }
       }

       private void Play()
       {
           Console.Write("Введите имя первого игрока: ");
           _nameGaimerNumberOne = Console.ReadLine();
           _fighterOne = SelectFighter(_nameGaimerNumberOne);

           Console.Write("Введите имя второго игрока: ");
           _nameGaimerNumberTwo = Console.ReadLine();
           _fighterTwo = SelectFighter(_nameGaimerNumberTwo);

           ShowState();
           Console.WriteLine("Бой начался!");
           Fight(_fighterOne, _fighterTwo);
       }

       private Fighter SelectFighter(string name)
       {
           Fighter[] fighters = new Fighter[]
       {
           new FightersNumberOne(),
           new FightersNumberTwo(),
           new FightersNumberThree(),
           new FightersNumberFour(),
           new FightersNumberFive()
       };

           Console.WriteLine($"Выбор {name}:");
           ShowGladiators(fighters);
           return GetFighter(fighters);
       }

       private void ShowGladiators(Fighter[] fighters)
       {
           for (int i = 0; i < fighters.Length; i++)
           {
               Console.WriteLine($"{i + 1} - {fighters[i].GetName()}");
           }
       }

       private Fighter GetFighter(Fighter[] fighters)
       {
           bool isCorrectInput = true;
           Fighter selectedFighter = null;

           while (isCorrectInput)
           {
               Console.Write("Введите номер бойца: ");
               string input = Console.ReadLine();

               if (int.TryParse(input, out int selectedFighterIndex) && selectedFighterIndex > 0 && selectedFighterIndex <= fighters.Length)
               {
                   selectedFighter = fighters[selectedFighterIndex - 1].Clone();
                   isCorrectInput = false;
               }
               else
               {
                   ShowError();
               }
           }

           return selectedFighter;
       }

       private void ShowState()
       {
           Console.WriteLine($"\nЗдоровье игрока {_nameGaimerNumberOne} - {_fighterOne.Health}");
           Console.WriteLine($"Здоровье игрока {_nameGaimerNumberTwo} - {_fighterTwo.Health}\n");
           Thread.Sleep(2000);
       }

       private void ShowError()
       {
           Console.WriteLine("\nОшибка!\n");
       }

       private void Fight(Fighter fighterOne, Fighter fighterTwo)
       {
           while (fighterOne.Health > 0 && fighterTwo.Health > 0)
           {
               Attack(_nameGaimerNumberOne, fighterOne, fighterTwo);

               if (fighterTwo.Health > 0)
               {
                   Attack(_nameGaimerNumberTwo, fighterTwo, fighterOne);
               }

               ShowState();
           }

           DetermineWinner(fighterOne, fighterTwo);
       }

       private void Attack(string name, Fighter attackingFighter, Fighter opponent)
       {
           Console.WriteLine($"Гладиатор {name} атакует");
           attackingFighter.Attack(opponent);
       }

       private void DetermineWinner(Fighter fighterOne, Fighter fighterTwo)
       {
           if (fighterOne.Health == fighterTwo.Health)
           {
               Console.WriteLine("Ничья!");
           }
           else if (fighterTwo.Health > _minimumHealth)
           {
               Console.WriteLine($"Победил гладиатор {_nameGaimerNumberTwo}!");
           }
           else if (fighterOne.Health > _minimumHealth)
           {
               Console.WriteLine($"Победил гладиатор {_nameGaimerNumberOne}!");
           }
       }
   }
}

public class UserUtils
{
   private static Random s_random = new Random();

   public static int GenerateRandomNumber(int min, int max)
   {
       return s_random.Next(min, max);
   }
}

public class FightersNumberOne : Fighter
{
   public override Fighter Clone()
   {
       return new FightersNumberOne();
   }

   public override string GetName()
   {
       return "первый боец имеет шанс нанести удвоенный урон";
   }

   public override void Attack(Fighter opponent)
   {
       int maxDamage = 10;
       int increasedDamage = 2;
       int doubleDamage = GenerateRandomDamage() * increasedDamage;

       if (GenerateRandomDamage() < maxDamage)
       {
           opponent.TakeDamage(doubleDamage);
           Console.WriteLine($"Вы нанесли двойной урон {doubleDamage}!");
           Thread.Sleep(2000);
       }
       else
       {
           base.Attack(opponent);
       }
   }
}

public class FightersNumberTwo : Fighter
{
   private int _attackCount = 0;

   public override Fighter Clone()
   {
       return new FightersNumberTwo();
   }

   public override string GetName()
   {
       return "второй боец каждую третью свою атаку наносит дважды урон врагу";

   }

   public override void Attack(Fighter opponent)
   {
       _attackCount++;

       int amountDoubleAttack = 3;
       int doublDamagePeriod = _attackCount % amountDoubleAttack;
       int increasedDamage = 2;
       int doubleDamage = GenerateRandomDamage() * increasedDamage;

       if (doublDamagePeriod == 0)
       {
           opponent.TakeDamage(doubleDamage);
           Console.WriteLine($"Вы нанесли удар два раза подряд, урон {doubleDamage}!");
           Thread.Sleep(2000);
       }
       else
       {
           base.Attack(opponent);
       }
   }
}

public class FightersNumberThree : Fighter
{
   private int _rage = 0;
   private int _maximumRage = 3;
   private int _treatment = 10;

   public override Fighter Clone()
   {
       return new FightersNumberThree();
   }

   public override string GetName()
   {
       return "третий боец получая по себе урон накапливает ярость, после накопления максимума, использует лечение";
   }

   public override void Attack(Fighter opponent)
   {
       _rage++;

       if (_rage == _maximumRage)
       {
           Heal(_treatment);
           Console.WriteLine($"Вы накопили максимум ярости {_rage} из {_maximumRage} и поправили здоровье на {_treatment}!");
           Thread.Sleep(2000);
           _rage = 0;
       }
       else
       {
           base.Attack(opponent);
       }
   }

   public void Heal(int amount)
   {
       Health += amount;
       int maximumHealth = 100;

       if (Health > maximumHealth)
       {
           Health = maximumHealth;
       }
   }
}

public class FightersNumberFour : Fighter
{
   private int _mana = 60;
   private int _fireBallMana = 20;

   public override Fighter Clone()
   {
       return new FightersNumberFour();
   }

   public override string GetName()
   {
       return "четвертый боец обладает маной и пока её достаточно, он применяет аклинание. Заклинание наносит урон, но урон больше от изначального";
   }

   public override void Attack(Fighter opponent)
   {
       int increasedDamage = 2;
       int fireBall = GenerateRandomDamage() * increasedDamage;

       if (_mana >= _fireBallMana)
       {
           opponent.TakeDamage(fireBall);
           _mana -= _fireBallMana;
           Console.WriteLine($"Ваша мана равна {_mana} из {_fireBallMana}. Вы использовали заклинание “Огненный шар” с уроном {fireBall}!");
           Thread.Sleep(2000);
       }
       else
       {
           base.Attack(opponent);
       }
   }
}

public class FightersNumberFive : Fighter
{
   public override Fighter Clone()
   {
       return new FightersNumberFive();
   }

   public override string GetName()
   {
       return "пятый боец имеет шанс уклониться, когда по нему наносят урон";
   }

   public override void Attack(Fighter opponent)
   {
       int definitionRandom = 10;

       if (GenerateRandomDamage() < definitionRandom)
       {
           Console.WriteLine("Увернулись от удара!");
           Thread.Sleep(2000);
           return;
       }
       else
       {
           base.Attack(opponent);
       }
   }
}

public class Fighter
{
   public Fighter()
   {
       Health = 100;
       RetaliatoryDamage = GenerateRandomDamage();
   }

   public int Health { get; protected set; }
   public int RetaliatoryDamage { get; private set; }

   public virtual Fighter Clone()
   {
       return new Fighter();
   }

   public virtual string GetName()
   {
       string name = "Gladiator";
       return name;
   }

   public virtual void Attack(Fighter opponent)
   {
       int randomDamage = GenerateRandomDamage();
       opponent.TakeDamage(randomDamage);
       Console.WriteLine($"Вы нанесли урон {randomDamage}!");
       Thread.Sleep(2000);
   }

   protected virtual int GenerateRandomDamage()
   {
       int minDamage = 1;
       int maxDamage = 20;
       return UserUtils.GenerateRandomNumber(minDamage, maxDamage + 1);
   }

   public void TakeDamage(int damage)
   {
       Health -= damage;
       int minimumHealth = 0;

       if (Health < minimumHealth)
       {
           Health = minimumHealth;
       }
   }
}
