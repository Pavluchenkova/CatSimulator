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
            
            Console.WriteLine("Give me a name:");
            string name = Console.ReadLine();

            Cat myCat = new Cat(name);

            Task task = new Task(myCat.Physiology);
            task.Start();
            Console.WriteLine($"I'm your cat {myCat.Name} \nPlease press: \nF - feed \nC - call \nP - pet \nEsc - exit ");
            Console.WriteLine($"{myCat.CatImage()}");
   
            var working = true;

            while (working)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.F:
                        myCat.Feeding();
                        break;                 
                    case ConsoleKey.C:
                        myCat.Call();
                        break;
                    case ConsoleKey.P:
                        myCat.Pet();
                        break;
                    case ConsoleKey.Escape:
                            working = false;
                        break;
                }
            }
        }
    }
}
