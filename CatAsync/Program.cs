using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = GetCatName();
            Cat myCat = new Cat(name);
            Task task = new Task(myCat.Physiology);
            task.Start();
            Greating(myCat);
            Living(myCat);
        }
        private static string GetCatName()
        {
            Console.WriteLine("Give me a name:");
            string name = Console.ReadLine();
            return name;
        }
        private static void Greating(Cat cat)
        {
            Console.WriteLine($"I'm your cat {cat.Name} \nPlease press: \nF - feed \nC - call \nP - pet \nEsc - exit ");
            Console.WriteLine($"{cat.CatImage()}");
        }
        private static void Living(Cat cat)
        {
            var working = true;

            while (working)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.F:
                        cat.Feeding();
                        break;
                    case ConsoleKey.C:
                        cat.Call();
                        break;
                    case ConsoleKey.P:
                        cat.Pet();
                        break;
                    case ConsoleKey.Escape:
                        working = false;
                        break;
                }
            }
        }
    }
}
