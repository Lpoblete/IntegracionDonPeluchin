using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Classes
{
    public class Cliente
    {
        private int id;
        private string rut;
        private string nombre;
        private string direccion;
        private string telefono;

        public Cliente() { }
        public Cliente(int id, string rut, string nombre, string direccion, string telefono)
        {
            Id = id;
            Rut = rut;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Rut
        {
            get
            {
                return rut;
            }

            set
            {
                rut = value;
            }
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

        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public int Agregar()
        {
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand comando = new SqlCommand("insert into Cliente values('" + Rut + "','" + Nombre + "','" + Direccion + "','" + Telefono + "')", conx.conectar());
            int resultado = comando.ExecuteNonQuery();
            conx.cerrar();
            return resultado;
        }

        public DataTable Listar()
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand cmd = new SqlCommand("select * from Cliente", conx.conectar());
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                dataTable.Load(reader);
            }
            catch
            {

            }
            conx.cerrar();
            return dataTable;
        }

        public DataTable ListarRutEspecifico(string r)
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand cmd = new SqlCommand("select * from Cliente where Rut_Cliente='"+r+"'", conx.conectar());
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                dataTable.Load(reader);
            }
            catch
            {

            }
            conx.cerrar();
            return dataTable;
        }
    }
}
