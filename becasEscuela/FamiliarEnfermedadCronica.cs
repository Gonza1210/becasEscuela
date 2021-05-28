using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace becasEscuela
{
    class FamiliarEnfermedadCronica
    {
        public string Diagnostico;
        public Double gastoMensual;
        public Int64 idAlumno;

        public FamiliarEnfermedadCronica(long idAlumno) 
        {
            Diagnostico = "";
            this.gastoMensual =0;
            this.idAlumno = idAlumno;
        }

        public FamiliarEnfermedadCronica(string diagnostico, double gastoMensual, long idAlumno)
        {
            Diagnostico = diagnostico;
            this.gastoMensual = gastoMensual;
            this.idAlumno = idAlumno;
        }
    }
}
