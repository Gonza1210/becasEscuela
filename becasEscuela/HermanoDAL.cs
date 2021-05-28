using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace becasEscuela
{
    class HermanoDAL
    {
        public static int Agregar(Hermano pHer)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into hermanos(nombApe,edad,ocupación," +
            "escuela,convive,dniAlu)values('{0}','{1}','{2}','{3}','{4}','{5}')",
            pHer.NombyApe, pHer.Edad, pHer.Ocupación, pHer.Escuela, pHer.convive, pHer.dniAlumno), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();

            return retorno;
        }
    }
}
