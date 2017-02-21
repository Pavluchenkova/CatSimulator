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
        public readonly string _name;
        public uint _energy;
        public Cat(string name, uint energy)
        {
            _name = name;
            _energy = energy;
        }

        public void Feeding(uint feed)
        {
            _energy += feed;
            if (_energy >= 70)
            {
                SayPurpur();
            }
        }

        public void Physiology()
        {
            do
            {
                var interval = 200000/_energy;
                Thread.Sleep((int)interval);
               
                if(_energy <= 50)
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
            Console.WriteLine("Meow!");
        }

    }
}
