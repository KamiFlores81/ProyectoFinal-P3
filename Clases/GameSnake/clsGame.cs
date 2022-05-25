using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Clases.GameSnake
{
    class clsGame
    {
        private object punteo = 0;
        private object velocidad = 100; //modificar estos valores y ver qué pasa
        private object posiciónComida = Point.Empty;
        private object tamañoPantalla = new Size(60, 20);
        private object longitudCulebra = 3; //modificar estos valores y ver qué pasa
        private object posiciónActual = new Point(20, 9); //modificar estos valores y ver qué pasa
        private object dirección = Direction.Derecha; //modificar estos valores y ver qué pasa

        public object Punteo { get => punteo; }
        public object Velocidad { get => velocidad; set => velocidad = value; }
        public object PosiciónComida { get => posiciónComida; }
        public object TamañoPantalla { get => tamañoPantalla;}
        public object LongitudCulebra { get => longitudCulebra; }
        public object PosiciónActual { get => posiciónActual; }
        public object Dirección { get => dirección;}

        internal enum Direction
        {
            Abajo, Izquierda, Derecha, Arriba
        }
        public void DibujaPantalla(Size size)
        {
            Console.Title = "CULEBRITA";
            Console.WindowHeight = size.Height + 2;
            Console.WindowWidth = size.Width + 2;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Black;
            for (int row = 0; row < size.Height; row++)
            {
                for (int col = 0; col < size.Width; col++)
                {
                    Console.SetCursorPosition(col + 1, row + 1);
                    Console.Write(" ");
                }
            }
        }//end DibujaPantalla

        public void MuestraPunteo(int punteo)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(1, 0);
            Console.Write($"Puntuación: {punteo.ToString("00000000")}");
        }//end Muestra Punteo

        public Direction ObtieneDireccion(Direction direccionAcutal)
        {
            if (!Console.KeyAvailable) return direccionAcutal;

            var tecla = Console.ReadKey(true).Key;
            switch (tecla)
            {
                case ConsoleKey.DownArrow:
                    if (direccionAcutal != Direction.Arriba)
                        direccionAcutal = Direction.Abajo;
                    break;
                case ConsoleKey.LeftArrow:
                    if (direccionAcutal != Direction.Derecha)
                        direccionAcutal = Direction.Izquierda;
                    break;
                case ConsoleKey.RightArrow:
                    if (direccionAcutal != Direction.Izquierda)
                        direccionAcutal = Direction.Derecha;
                    break;
                case ConsoleKey.UpArrow:
                    if (direccionAcutal != Direction.Abajo)
                        direccionAcutal = Direction.Arriba;
                    break;
            }
            return direccionAcutal;
        }//end obtieneDireccion

        public Point ObtieneSiguienteDireccion(Direction direction, Point currentPosition)
        {
            Point siguienteDireccion = new Point(currentPosition.X, currentPosition.Y);
            switch (direction)
            {
                case Direction.Arriba:
                    siguienteDireccion.Y--;
                    break;
                case Direction.Izquierda:
                    siguienteDireccion.X--;
                    break;
                case Direction.Abajo:
                    siguienteDireccion.Y++;
                    break;
                case Direction.Derecha:
                    siguienteDireccion.X++;
                    break;
            }
            return siguienteDireccion;
        }// end ObtieneSiguienteDireccion

        public int defineVelocidad(int i)
        {
            if ((i % 50 == 0))
            {
                if (i >= 40)
                {
                    return 10;
                }

            }
            return 0;
        }

    }
}
