using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ERPIntegracion
{
    public class Usuario
    {
        private string nombre;
        private string pass;
        private string tipoUsuario;

        public Usuario() { }
        public Usuario(string nombre, string pass, string tipoUsuario)
        {
            Nombre = nombre;
            Pass = pass;
            TipoUsuario = tipoUsuario;
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Pass
        {
            get
            {
                return pass;
            }

            set
            {
                pass = value;
            }
        }

        public string TipoUsuario
        {
            get
            {
                return tipoUsuario;
            }

            set
            {
                tipoUsuario = value;
            }
        }

        public string inicioSesion()
        {
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand comando = new SqlCommand("select * from Usuario where Nombre='" + Nombre + "' and Pass='" + Pass + "' and TipoUsuario='" + TipoUsuario + "'", conx.conectar());
            SqlDataReader sdr = comando.ExecuteReader();

            if (sdr.Read())
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
    }
}