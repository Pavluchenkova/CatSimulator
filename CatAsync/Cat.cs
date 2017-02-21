using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CatAsync
{
    class Cat
    {
        public string Name { get; private set; }
        public uint _energy = 100;
        public Cat(string name)
        {
            Name = name;           
        }
        
        public void Feeding()
        {
            _energy += 10;
            if (_energy >= 70)
            {
                SayPurpur();
            }
        }

        public void Physiology()
        {
            do
            {
                var interval = 1000;
                Thread.Sleep((int)interval);
               
                if(_energy <= 60)
                {
                    SayMeow();
                }
                _energy--;

            } while (_energy != 0);
        }

        public void SayPurpur ()
        {
            Console.WriteLine("Pur-Pur...");
        }

        public void SayMeow()
        {
            Console.WriteLine($"Meow! ({this._energy})");
        }

    }
}
