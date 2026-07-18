using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Notes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ZooAnimals zoo = new ZooAnimals();
            zoo.NumberOfAnimals();
            zoo.AddAnimal();
            zoo.RemoveAnimal();
            zoo.ShowAllAnimals();
            zoo.FeedAnimal();
        }
    }

    interface IZooService
    {
        void AddAnimal(); // Добовляет новых животных в зоопарк.
        void RemoveAnimal(); // Удоляет животное по имени
        void FeedAnimal(); // Находить животное по имени и кормить
        void ShowAllAnimals(); // Выводит список всех животных
    }

    class ZooAnimals : IZooService
    {
        List<string> animals = new List<string>();
        public void NumberOfAnimals() => Console.WriteLine("В зоопарк вы можете добовить только 4 животных.");

        public void AddAnimal() 
        {
            for (int i = 0; i <= 3; i++)
            {
            Console.WriteLine( "Введите животное, которое вы хотите добавить в зоопарк:");
            string name = Console.ReadLine();
            animals.Add(name);
            Console.WriteLine( $"{name} добавлен.");

            Console.WriteLine( "Хотите добавить еще? (yes/no)");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "no")
                break;
            }
        }
        public void RemoveAnimal() 
        {
            try
            {
            Console.WriteLine( "Введите имя животного, которого хотиту убрать из зоопарка:");
            string name = Console.ReadLine();

            bool removed = animals.Remove(name);

            if (removed)
                Console.WriteLine( $"{name} удален.");
            else
                Console.WriteLine( $"{name} не найден.");

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine( ex.Message);
            }
        }

        public void ShowAllAnimals() 
        {
            Console.WriteLine( "Все животные:");
            if(animals.Count == 0)
            {
                Console.WriteLine( "Пока нет животных.");
            }

            foreach (string _animals in animals)
                Console.WriteLine( _animals);
        }

        public void FeedAnimal() 
        {
            Console.WriteLine( "Введите название животного, которое вы хотите накормить:");
            string name = Console.ReadLine();

            if(animals.Contains(name))
                Console.WriteLine( $"{name} покормлен." );
            else
                Console.WriteLine( $"{name} не найден");
        }
    }
}
