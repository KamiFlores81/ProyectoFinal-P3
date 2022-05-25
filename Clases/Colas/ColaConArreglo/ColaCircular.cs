using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas.Clases.ColaArreglo
{
    class ColaCircular
    {
        protected int fin;
        private static int MAXTAMQ = 99;
        protected int frente;
        private int tam;

        public Object[] listaCola;

        public ColaCircular()
        {
            frente = tam = 0;
            fin = MAXTAMQ - 1;
            listaCola = new Object[MAXTAMQ];
        }

        //avanza una posición
        private int siguiente(int r)
        {
            return (r + 1) % MAXTAMQ;
        }

        //validaciones
        public bool colaVacia()
        {
            return frente == siguiente(fin);
        }
        public bool colaLlena()
        {
            return frente == siguiente(siguiente(fin));
        }

        //operaciones de modificacion de cola
        public void insertar(Object elemento)
        {
            if (!colaLlena())
            {
                fin = siguiente(fin);
                listaCola[fin] = elemento;
                tam++;
            }
            else
            {
                throw new Exception("OverFlow de la cola");
            }
        }

        //quitar elemento
        public Object quitar()
        {
            if (!colaVacia())
            {
                Object tm = listaCola[frente];
                frente = siguiente(frente);
                tam--;
                return tm;
            }
            else
            {
                throw new Exception("Cola Vacía");
            }
        }
        public Object quitar2()
        {
            if (!colaVacia())
            {
                object tm= listaCola[frente];
                Object[] list2 = listaCola;
                for(int i=1; i<list2.Length; i++)
                {
                    listaCola[i - 1] = list2[i]; 
                }
                frente=0;
                fin--;
                return tm;
            }
            else
            {
                throw new Exception("Cola Vacía");
            }
        }

        public void BorrarCola()
        {
            frente = tam = 0;
            fin = MAXTAMQ - 1;
        }

        //obtener el valor de frente
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
        public Object finalCola()
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
                int z = (flag == true) ? cont++ : cont+0;
                i++;
            }
            return (cont != 0) ? true : false;
        }

        public bool all(int x, int y)
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
