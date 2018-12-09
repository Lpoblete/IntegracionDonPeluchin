using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPIntegracion
{
    public class Conexion
    {
        public static string cadenaConx = "INGRESA TU CADENA DE CONEXION";
        public SqlConnection conx;

        public Conexion()
        {
            conx = new SqlConnection();
            conx.ConnectionString = cadenaConx;
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