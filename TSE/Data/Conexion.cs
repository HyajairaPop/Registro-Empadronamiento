using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace TSE
{
    public class Conexion
    {
        public static string MiCadena()
        {
            return ConfigurationManager.ConnectionStrings["Conexionsql"].ConnectionString;
        }

    }


}
