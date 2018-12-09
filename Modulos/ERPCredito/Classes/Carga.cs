using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Carga
    {
        private int id;
        private string clienteRut;
        private string fechaImpresion;
        private string comprobante;

        public Carga() { }
        public Carga(int id, string clienteRut, string fecha, string comprobante)
        {
            Id = id;
            ClienteRut = clienteRut;
            FechaImpresion = fecha;
            Comprobante = comprobante;
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

        public string ClienteRut
        {
            get
            {
                return clienteRut;
            }

            set
            {
                clienteRut = value;
            }
        }

        public string FechaImpresion
        {
            get
            {
                return fechaImpresion;
            }

            set
            {
                fechaImpresion = value;
            }
        }

        public string Comprobante
        {
            get
            {
                return comprobante;
            }

            set
            {
                comprobante = value;
            }
        }

        public int Agregar()
        {
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand comando = new SqlCommand("insert into Carga values(" + Id + ",'" + ClienteRut + "','" + FechaImpresion + "','" + Comprobante + "')", conx.conectar());
            int resultado = comando.ExecuteNonQuery();
            conx.cerrar();
            return resultado;
        }

        public DataTable Listar()
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand cmd = new SqlCommand("select * from Carga", conx.conectar());
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
            SqlCommand cmd = new SqlCommand("select * from Carga where Cliente_Rut='" + r+"'", conx.conectar());
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

        public DataTable ListarFechaEspecifica(string f)
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand cmd = new SqlCommand("select * from Carga where FechaImpresion='" + f + "'", conx.conectar());
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
