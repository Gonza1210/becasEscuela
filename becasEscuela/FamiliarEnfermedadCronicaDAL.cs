using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace becasEscuela
{
    class FamiliarEnfermedadCronicaDAL
    {
        public static int Agregar(FamiliarEnfermedadCronica enfCronica)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into familiar_Enfermedad_cronica(diagnostico,gasto_mensual," +
             "dniAlumnoCronica)values('{0}','{1}','{2}')",
            enfCronica.Diagnostico,enfCronica.gastoMensual, enfCronica.idAlumno), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();

            return retorno;
        }
    }
}
