using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace becasEscuela
{
    class EscuelaDAL
    {
        public static int Agregar(Escuela escuela)
        {
            int retorno = 0;
            MySqlCommand comando= new MySqlCommand(string.Format("Insert into Escuela(nombreNro)values('{0}')",escuela.Nombre),BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        
        }

    }
}
