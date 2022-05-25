using Colas.Clases.ColaLista;
using Snake.Clases.GameMenu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;

namespace Snake.Clases.GameSnake
{
    class SnakeColaConLista : clsGame
    {
        private bool MoverLaCulebrita(ColaConLista culebra, Point posiciónObjetivo,
           int longitudCulebra, Size screenSize)
        {
            var lastPoint = (Point)culebra.finalCola(); //Obtenemos el fin de la cola

            if (lastPoint.Equals(posiciónObjetivo)) return true;

            if (culebra.any(posiciónObjetivo)) return false;

            if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= screenSize.Width
                    || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= screenSize.Height)
            {
                return false;
            }


            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.WriteLine(" ");

            culebra.insertar(posiciónObjetivo); //colocamos al final lo que se coma

            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
            Console.Write(" ");

            // Quitar cola
            if (culebra.numElementosCola() > longitudCulebra)
            {
                var removePoint = (Point)culebra.quitar();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }
            return true;
        }//end MoverLaCulebrita

        private Point MostrarComida(Size screenSize, ColaConLista culebra)
        {
            var lugarComida = Point.Empty;
            var cabezaCulebra = (Point)culebra.frenteCola(); //obtenemos la posicion de la cabeza de la serpiente
            var rnd = new Random();
            do
            {
                var x = rnd.Next(0, screenSize.Width - 1);
                var y = rnd.Next(0, screenSize.Height - 1);
                if (culebra.all(x, y)
                    && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
                {
                    lugarComida = new Point(x, y);
                }

            } while (lugarComida == Point.Empty);

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
            Console.Write(" ");

            return lugarComida;
        }//end MostrarComida

        public int Game()
        {
            int punteo = (int)Punteo;
            int velocidad = (int)Velocidad;
            Point posiciónComida = (Point)PosiciónComida;
            Size tamañoPantalla = (Size)TamañoPantalla;
            int longitudCulebra = (int)LongitudCulebra;
            Point posiciónActual = (Point)PosiciónActual;
            Direction dirección = (Direction)Dirección;
            var culebrita = new ColaConLista();
            culebrita.insertar(posiciónActual);

            DibujaPantalla(tamañoPantalla);
            MuestraPunteo(punteo);

            while (MoverLaCulebrita(culebrita, posiciónActual, longitudCulebra, tamañoPantalla))
            {
                Thread.Sleep(velocidad);
                dirección = ObtieneDireccion(dirección);
                posiciónActual = ObtieneSiguienteDireccion(dirección, posiciónActual);

                if (posiciónActual.Equals(posiciónComida))
                {
                    posiciónComida = Point.Empty;
                    longitudCulebra ++; //modificar estos valores y ver qué pasa
                    punteo += 10; //modificar estos valores y ver qué pasa
                    MuestraPunteo(punteo);
                    velocidad -= defineVelocidad(punteo);
                }

                if (posiciónComida == Point.Empty) //entender qué hace esta linea
                {
                    posiciónComida = MostrarComida(tamañoPantalla, culebrita);
                }

            }

            Console.ResetColor();
            Console.SetCursorPosition(tamañoPantalla.Width / 2 - 4, tamañoPantalla.Height / 2);
            Console.Write("Fin del Juego");
            Thread.Sleep(2000);
            Console.ReadKey();
            return punteo;
        }// end GamePrincipal
    }
}
