using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace becasEscuela
{
     class AlumnoDAL
     {
        public static int Agregar(Alumno pAlumno)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Alumno(dniAlumno,Nombres,Apellidos,Nacinalidad,fechaNacimiento," +
            "Cuil,Domicilio,CodPostal,LocalidadBarrio,mail,telefono,gradoAño,turno,escuela_id_escuela,estado_beca)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}'" +
            ",'{10}','{11}','{12}','{13}','{14}')"
            , pAlumno.DNI,pAlumno.Nombre, pAlumno.Apellido,pAlumno.Nacionalidad,pAlumno.FechaNacimiento,
            pAlumno.CUIL,pAlumno.Domicilio,pAlumno.CodigoPostal,pAlumno.LocalidadBarrio,pAlumno.Email,pAlumno.Telefono
            ,pAlumno.GradoAño,pAlumno.Turno,pAlumno.idEscuela,pAlumno.EstadoBecaFk), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();

            return retorno;
        }

            
        public static int Actualizar(Int64 dni,int calificacionBecaAlumno)
        {
            int retorno = 0;

            MySqlConnection conexion = BdComun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update Alumno set estado_beca='{0}' where dniAlumno='{1}'", calificacionBecaAlumno,dni), conexion);

            retorno = comando.ExecuteNonQuery();

            conexion.Close();

            return retorno;
        }




    }
}
