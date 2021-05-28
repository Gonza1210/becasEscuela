using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace becasEscuela
{
    class Hermano
    {
        public string NombyApe;
        public int Edad;
        public string Ocupación;
        public string Escuela;
        public int convive;
        public Int64 dniAlumno;

        public Hermano(string nombyApe, int edad, string ocupación, string escuela, int convive, long dniAlumno)
        {
            NombyApe = nombyApe;
            Edad = edad;
            Ocupación = ocupación;
            Escuela = escuela;
            this.convive = convive;
            this.dniAlumno = dniAlumno;
        }
    }
}
