using Colas.Clases.BicolaEnlazada;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Clases.ManejodeArchivos
{
    class ClsArchivos
    {
        public void GuardaNombres(string nombre, int punteo, int i)
        {
            StreamWriter archivo = new StreamWriter(@"Punteos.txt", true);
            string dificultad;
            if (i == 0) { dificultad = "Fácil"; }
            else if (i == 1) { dificultad = "Difícil"; }
            else { dificultad = "Legendario"; }
            archivo.WriteLine($"{nombre};{punteo};{dificultad}") ;
            archivo.Close();
        }

        public void MuestraNombres()
        {
            StreamReader archivo;
            try
            {
                archivo = new StreamReader(@"Punteos.txt",UTF8Encoding.UTF8);
                string tem = archivo.ReadToEnd();
                string[] temp2 = tem.Split(Environment.NewLine);

                List<ClsJugadores> jugadores = new List<ClsJugadores>();

                foreach (string linea in temp2)
                {
                    string[] CadaEspacio = linea.Split(';');
                    if(CadaEspacio.Length > 1)
                    {
                        jugadores.Add(new ClsJugadores()
                        {
                            Nombre = CadaEspacio[0],
                            Punteo = int.Parse(CadaEspacio[1]),
                            Dificultad = CadaEspacio[2]
                        });
                    }
                    
                }

                Console.Clear();
                Console.SetCursorPosition(15, 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("TOP 10 JUGADORES CON MÁS PUNTOS");
                Console.SetCursorPosition(0, 5);
                Console.ForegroundColor = ConsoleColor.White;
                OrdenamientoDeDatos(jugadores);
                Console.WriteLine("\nPRESIONE CUALQUIER TECLA PARA CONTINUAR");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"No existe el archivo {ex.Message}");
            }

        }
        public void OrdenamientoDeDatos(List<ClsJugadores> jugadores) {

            jugadores.Sort();
            int cont = 1;
            foreach(ClsJugadores ss in jugadores)
            {
                if (cont <= 10)
                {
                    Console.WriteLine($"{cont++}.{ss}");
                }
            }
        }
    }
}
