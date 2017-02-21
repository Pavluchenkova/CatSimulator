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
            Cat myCat = new Cat("Barsyk");
            

            Task task = new Task(myCat.Physiology);
            task.Start();
            Console.WriteLine($"Feed {myCat.Name}:");
           
            var working = true;
            while (working)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.F)
                {
                    myCat.Feeding();
                }
                if (key == ConsoleKey.Escape) working = false;
            }
        }
    }
}
