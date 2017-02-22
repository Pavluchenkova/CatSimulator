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
        public uint _energy;
        private CatState _state;

        public delegate void CatEventHandler();
        public event CatEventHandler CatFed;
        public event CatEventHandler CatHungy;

        public Cat(string name)
        {
            Name = name;
            _energy = 100;
            _state = CatState.Fed;
            CatFed += SayPurpur;
            CatHungy += SayMeow;
        }

        
        public void Feeding()
        {
            _energy += 10;

            if (_energy >= 70 && _state == CatState.Hungry)
            {
                CatFed?.Invoke();
                _state = CatState.Fed;
            }
            if (_energy >= 100)
            { 
                _state = CatState.Satiated;
            }

        }

        public void Pet()
        {
            SayPurpur();
        }

        public void Call()
        {
            SayMeow();
        }
        public string CatImage()
        {
            return String.Format(@"
 .       .
 |\_---_/|
/   o_o   \
|    U    |
\  ._I_.  /
 `-_____-'");
        }
        
        
        public void Physiology()
        {
            do
            {
                var interval = 1000;
                Thread.Sleep((int)interval);

                if (_energy >= 70 && _energy < 100)
                {
                    _state = CatState.Fed;

                }
                if(_energy <= 60 && _state == CatState.Fed)
                {
                    CatHungy?.Invoke();
                    _state = CatState.Hungry;
                }
                _energy--;

            } while (_energy != 0);
        }

        private void SayPurpur ()
        {
            Console.WriteLine("Pur-Pur...");
        }

        private void SayMeow()
        {
            Console.WriteLine($"Meow! ({this._energy})");
        }

    }
}
