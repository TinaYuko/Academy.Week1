using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_1
{
    internal class Prodotto
    {
        public string Nome { get; set; }
        public string Codice { get; private set; }
        public int Weight { get; } //posso leggerlo ma non settarlo

        //posso settarlo qui o nel costruttore

        public Prodotto()
        {
            Codice = "ABC" + Nome[0]; //ABC + prima lettera
        }
    }


}
