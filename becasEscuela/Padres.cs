using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace becasEscuela
{
    class Padres
    {
        
        public string Apellido;
        public string Nombre;
        public int Edad;
        public string Ocupación;
        public string LugarTrabajo;
        public Double IngresosNetos;
        public int convive;
        public int rol;
        public Int64 dniAlumno;

        public Padres(string apellido, string nombre, int edad, string ocupación, 
            string lugarTrabajo, double ingresosNetos, 
            int convive, int rol, long dniAlumno)
        {
            Apellido = apellido;
            Nombre = nombre;
            Edad = edad;
            Ocupación = ocupación;
            LugarTrabajo = lugarTrabajo;
            IngresosNetos = ingresosNetos;
            this.convive = convive;
            this.rol = rol;
            this.dniAlumno = dniAlumno;
        }
    }
}
