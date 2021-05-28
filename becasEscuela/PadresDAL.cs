using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace becasEscuela
{
    class PadresDAL
    {
        public static int Agregar(Padres pPadres)
        {
            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into Padres(apellido,Nombre,edad,ocupacion," +
            "lugar_Trabajo,ingresos_Netos,convive,rol,dniAlumno)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
            pPadres.Apellido, pPadres.Nombre, pPadres.Edad, pPadres.Ocupación,
            pPadres.LugarTrabajo, pPadres.IngresosNetos, pPadres.convive, pPadres.rol, pPadres.dniAlumno), BdComun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();

            return retorno;
        }
    }
}
