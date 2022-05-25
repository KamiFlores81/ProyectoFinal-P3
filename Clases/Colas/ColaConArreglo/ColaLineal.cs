using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas.Clases.ColaArreglo
{
    class ColaLineal
    {
        protected int fin;
        private static int MAXTAMQ = 39;
        protected int frente;
        private int tam;

        protected Object[] listaCola;

        public ColaLineal()
        {
            frente = tam = 0;
            fin = -1;
            listaCola = new Object[MAXTAMQ];
        }

        //Operaciones para trabajar con datos en la cola
        public void insertar(Object elemento)
        {
            if (!colaLlena())
            {
                listaCola[++fin] = elemento;
                tam++;
            }
            else
            {
                throw new Exception("Overflow de la cola");
            }
        }
        public bool colaLlena()
        {
            return fin == MAXTAMQ - 1;
        }
        public bool colaVacia()
        {
            return frente > fin;
        }

        //quitar elemento en la cola
        public Object quitar()
        {
            if (!colaVacia())
            {
                return listaCola[frente++];
                tam--;
            }
            else
            {
                throw new Exception("Cola Vacia");
            }
        }

        //limpiar toda la cola
        public void borrarCola()
        {
            frente = tam = 0;
            fin = -1;
        }

        //acceso a la cola
        public Object frenteCola()
        {
            if (!colaVacia())
            {
                return listaCola[frente];
            }
            else
            {
                throw new Exception("Cola Vacía");
            }
        }
        public Object finCola()
        {
            if (!colaVacia())
            {
                return listaCola[fin];
            }
            else
            {
                throw new Exception("Cola Vacía");
            }
        }
        public int cont()
        {
            return tam;
        }

        public bool Any(Point x)
        {
            int i = 0, cont = 0;
            bool flag;
            while (i <= fin)
            {
                Point a = (Point)listaCola[i];
                flag = ((a.X == x.X) && (a.Y == x.Y));
                int z = (flag == true) ? cont ++: cont+0;
                i++;
            }
            return (cont != 0) ? true : false;
        }

        public bool All(int x, int y)
        {
            int i = 0, cont = 0;
            bool flag;
            while (i <= fin)
            {
                Point a = (Point)listaCola[i];
                flag = (a.X != x || a.Y != y);
                int z = (flag == true) ? cont + 0 : cont++;
                i++;
            }
            return (cont == 0) ? true : false;
        }

    }
}
