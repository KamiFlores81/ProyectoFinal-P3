using Colas.Clases.ColaLista;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colas.Clases.BicolaEnlazada
{
    class Bicola : ColaConLista
    {
        //insertar por el final de la bicola
        public void ponerFinal(Object elemento)
        {
            insertar(elemento);
        }

        //insertar al frente
        public void ponerFrente(object elemento)
        {
            Nodo aux;
            aux = new Nodo(elemento);
            if (colaVacia())
            {
                fin = aux;
            }
            aux.Siguiente = frente;
            frente = aux;
        }

        //quitar elemento
        public object quitarFrente()
        {
            return quitar();
        }

        
        //retirar elemento al final
        //Es un elemento propio de Bicola
        //Es necesario hacer una iteración de la bicola para llegar del nodo anterior al final, para despues enlazar y ajustar la cola

        public object quitarFinal()
        {
            Object aux;
            if (!colaVacia())
            {
                if(frente == fin) //La bicola solo tiene un nodo
                {
                    aux = quitar();
                }
                else
                {
                    //como no tiene elementos vamos a iterar
                    Nodo a = frente;
                    while(a.Siguiente != fin)
                    {
                        a = a.Siguiente;
                    }
                    //siguiente del nodo anterior lo vamos a poner en null
                    a.Siguiente = null;
                    aux = fin.elemento;
                    fin = a;
                }
            }
            else
            {
                throw new Exception("La cola está vacía");
            }
            return aux;
        }

        //retorna el valor que se encuentra en el primer elemento o frente  de ña cpña
        public object frenteBicola()
        {
            return frenteCola();
        }

        //devolver el final de la cola
        public object finalBicola()
        {
            if (colaVacia())
            {
                throw new Exception("Cola Vacía");
            }
            return (fin.elemento);
        }

        //retorna si está vacía la cola
        public bool biColaVacia()
        {
            return colaVacia();
        }

        //borrar bicola
        public void borrarBicola()
        {
            borrarCola();
        }

        //conteo de elementos
        public int numElementosBicola()
        {
            int n;
            Nodo a = frente;
            if (biColaVacia())
            {
                n = 0;
            }
            else
            {
                n = 1;
                while(a!= fin)
                {
                    n++;
                    a = a.Siguiente;
                }
            }
            return n;
        }

    }
}
