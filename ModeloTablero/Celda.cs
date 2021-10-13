using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloTablero
{
    public class Celda
    {
        public int NroColumna { get; set; }
        public int NroFila { get; set; }
        public bool Ocupados { get; set; }
        public bool Legal_Movim { get; set; }

        public Celda(int x, int y)
        {
            NroFila = x;
            NroColumna = y;
        }
    }
}
