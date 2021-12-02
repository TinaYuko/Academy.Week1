using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1
{
    internal class User : Persona, IPrintable, IEntity
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void IsAdult() //Obbligatoriamente faccio l'override perchè Persona è abstract
            //e IsAdult è abstract
        {
            if (Età>18)
            {
                Console.WriteLine("Maggiorenne");
            }
        }
    }
}
