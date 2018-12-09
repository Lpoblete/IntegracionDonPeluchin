using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Conexion
    {
        public static string cadenaConexion = "INGRESA TU CADENA DE CONEXION";
        public SqlConnection conx = new SqlConnection();

        public Conexion()
        {
            conx = new SqlConnection();
            conx.ConnectionString = cadenaConexion;
        }

        public SqlConnection conectar()
        {
            return conx;
        }

        public void cerrar()
        {
            conx.Close();
        }
    }
}
