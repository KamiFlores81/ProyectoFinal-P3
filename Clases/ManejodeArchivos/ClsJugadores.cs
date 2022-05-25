using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Clases.ManejodeArchivos
{
    class ClsJugadores : IEquatable<ClsJugadores>, IComparable<ClsJugadores>
    {
        private string nombre;
        private int punteo;
        private string dificultad;

        public string Nombre { get => nombre; set => nombre = value; }
        public int Punteo { get => punteo; set => punteo = value; }
        public string Dificultad { get => dificultad; set => dificultad = value; }
       
        public int CompareTo(ClsJugadores comparar)
        {
            if (comparar == null) { return 1; }
            else { return comparar.punteo.CompareTo(this.punteo); }
        }

        public override string ToString()
        {
            return $"Nombre: {nombre}, Punteo: {punteo}, Dificultad: {dificultad}";
        }

        public bool Equals(ClsJugadores obj)
        {
            if (obj == null) { return false; }
            ClsJugadores objs = obj;
            if (objs == null) { return false; }
            else return Equals(objs);
        }
    }
}
