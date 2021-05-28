using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace becasEscuela
{
    class Alumno
    {
        public Int64 DNI;
        public string Nombre;
        public string Apellido;
        public string Nacionalidad;
        public string FechaNacimiento;
        public Int64 CUIL;
        public string Domicilio;
        public string CodigoPostal;
        public string LocalidadBarrio;
        public string Email;
        public string Telefono;
        public string GradoAño;
        public string Turno;
        public int idEscuela;
        public int EstadoBecaFk;
        public EstadoBeca EstadoBeca;
        public List<Padres> PadresLista;
        public List<Hermano> HermanosLista;
        public FamiliarEnfermedadCronica EnfermedadCronica { get; set; }

        internal Padres Padres
        {
            get => default;
            set
            {
            }
        }

        public Alumno(Int64 dNI, string nombre, string apellido, string nacionalidad,
            string fechaNacimiento, Int64 cUIL, string domicilio, string codigoPostal,
            string localidadBarrio, string email, string telefono, string gradoAño, string turno,
            int idEscue, int estadoBeca)
        {
            DNI = dNI;
            Nombre = nombre;
            Apellido = apellido;
            Nacionalidad = nacionalidad;
            FechaNacimiento = fechaNacimiento;
            CUIL = cUIL;
            Domicilio = domicilio;
            CodigoPostal = codigoPostal;
            LocalidadBarrio = localidadBarrio;
            Email = email;
            Telefono = telefono;
            GradoAño = gradoAño;
            Turno = turno;
            idEscuela = idEscue;
            EstadoBecaFk = estadoBeca;

            PadresLista = new List<Padres>();
            //            PadresLista = null;
            HermanosLista = new List<Hermano>();
            //          HermanosLista   = null;

        }

        public int CalificarAlumnoBeca(Alumno alumno)
        {

            int tipo = alumno.EstadoBecaFk;
            Double netosFamiliar = 0;
            netosFamiliar = alumno.PadresLista[0].IngresosNetos + alumno.PadresLista[1].IngresosNetos;
            
            Double gastosEnferCronica = alumno.EnfermedadCronica.gastoMensual;

            int cantHermanos = alumno.HermanosLista.Count;

            if ((netosFamiliar-gastosEnferCronica)>60000 && cantHermanos<=2)
            {
                tipo = 2;
                //MessageBox.Show("BECA RECHAZADA”, “Estado Beca");
            }

            if (((netosFamiliar - gastosEnferCronica) > 60000 && cantHermanos >= 3) || 
                ((netosFamiliar - gastosEnferCronica) < 60000 && (netosFamiliar - gastosEnferCronica) > 50000  && cantHermanos <= 2) ||
                    ((netosFamiliar - gastosEnferCronica) < 50000 && cantHermanos== 0 ))
            {
                tipo = 3;
                //MessageBox.Show("MEDIA BECA”, “Estado Beca");
            }

            if ((netosFamiliar - gastosEnferCronica) < 50000 && cantHermanos ==0)
            {
                tipo = 4;
                //MessageBox.Show("BECA COMPLETA”, “Estado Beca");
            }
            if (tipo == 1)
            {
                tipo = 5;
                //MessageBox.Show("EN ESTUDIO POR LA COMISION DE BECA”, “Estado Beca");
            }
            return tipo;
        }



    }
}
