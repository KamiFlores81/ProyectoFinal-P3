using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas.Clases.ColaLista
{
    class Nodo
    {
        public object elemento;
        public Nodo Siguiente;

        public Nodo(Object x)
        {
            elemento = x;
            Siguiente = null;
        }
    }
}
