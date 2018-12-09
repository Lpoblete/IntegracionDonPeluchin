using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Pago
    {
        private int id;
        private int idPago;
        private string fechaImpresion;
        private string comprobante;

        public Pago() { }
        public Pago(int id, int idPago, string fechaImpresion, string comprobante)
        {
            Id = id;
            IdPago = idPago;
            FechaImpresion = fechaImpresion;
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

        public int IdPago
        {
            get
            {
                return idPago;
            }

            set
            {
                idPago = value;
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

        public int Agregar()
        {
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand comando = new SqlCommand("insert into Pago values(" + Id + "," + IdPago + ",'" + FechaImpresion + "','" + Comprobante + "');", conx.conectar());
            int resultado = comando.ExecuteNonQuery();
            conx.cerrar();
            return resultado;
        }

        public DataTable ListarRutEspecifica(string id)
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();

            SqlCommand cmd = new SqlCommand("select pa.ID_Pago, pa.Cobranza_ID, pa.Comprobante, pa.FechaImpresion, co.Cliente_Rut " +
                "from Pago pa inner join Cobranza co ON pa.Cobranza_ID=co.ID_Cobranza " +
                "where Cobranza_ID=" + id, conx.conectar());
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

            SqlCommand cmd = new SqlCommand("select pa.ID_Pago, pa.Cobranza_ID, pa.Comprobante, pa.FechaImpresion, co.Cliente_Rut " +
    "from Pago pa inner join Cobranza co ON pa.Cobranza_ID=co.ID_Cobranza " +
    "where FechaImpresion = '" + f + "'", conx.conectar());
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

        public DataTable ListarFechaDesdeHasta(string fd, string fh)
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();

            SqlCommand cmd = new SqlCommand("select pa.ID_Pago, pa.Cobranza_ID, pa.Comprobante, pa.FechaImpresion, co.Cliente_Rut " +
"from Pago pa inner join Cobranza co ON pa.Cobranza_ID=co.ID_Cobranza " +
"where FechaImpresion >= '" + fd + "' and FechaImpresion <= '" + fh + "'", conx.conectar());
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

        public DataTable Listar()
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();

            SqlCommand cmd = new SqlCommand("select pa.ID_Pago, pa.Cobranza_ID, pa.Comprobante, pa.FechaImpresion, co.Cliente_Rut " +
                "from Pago pa inner join Cobranza co ON pa.Cobranza_ID=co.ID_Cobranza", conx.conectar());
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
