using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Cobranza
    {
        private int id;
        private int noFactura;
        private string rut;
        private string fecha;
        private int saldo;
        private string metodoPago;
        private int numConsulta;
        private string estado;

        public Cobranza() { }
        public Cobranza(int id, int nofactura, string rut, string fecha, int saldo, string metodoPago, int numConsulta, string estado)
        {
            Id = id;
            NoFactura = nofactura;
            Rut = rut;
            Fecha = fecha;
            Saldo = saldo;
            MetodoPago = metodoPago;
            NumConsulta = numConsulta;
            Estado = estado;
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
        
        public string Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public int Saldo
        {
            get
            {
                return saldo;
            }

            set
            {
                saldo = value;
            }
        }

        public string MetodoPago
        {
            get
            {
                return metodoPago;
            }

            set
            {
                metodoPago = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public int NoFactura
        {
            get
            {
                return noFactura;
            }

            set
            {
                noFactura = value;
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

        public int NumConsulta
        {
            get
            {
                return numConsulta;
            }

            set
            {
                numConsulta = value;
            }
        }

        public int Agregar()
        {
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand comando = new SqlCommand("insert into Cobranza values(" + Id + "," + NoFactura + ",'" + Rut + "','" + Fecha + "'," + Saldo + ",'" + MetodoPago + "'," + NumConsulta + ",'" + Estado + "');", conx.conectar());
            int resultado = comando.ExecuteNonQuery();
            conx.cerrar();
            return resultado;
        }

        public int ModificarSaldoPendiente(int i, int s, string e)
        {
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand comando = new SqlCommand("update Cobranza set Saldo=" + s + ", Estado='" + e + "' where ID_Cobranza=" + i, conx.conectar());
            int resultado = comando.ExecuteNonQuery();
            conx.cerrar();
            return resultado;
        }

        public DataTable Listar()
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();

            SqlCommand cmd = new SqlCommand("select co.ID_Cobranza, co.Factura_NO, cl.Rut_Cliente, cl.Nombre_Cliente, co.FechaCobranza, co.Saldo, co.MetodoPago, co.NumCuotas, co.Estado " +
                                            "from Cobranza co inner join Cliente cl ON co.Cliente_Rut=cl.Rut_Cliente", conx.conectar());
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

        public bool BuscarIDCobranzaEspecifica(int i)
        {
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand cmd = new SqlCommand("select * from Cobranza where ID_Cobranza=" + i + " and MetodoPago='Tarjeta' and Estado='Pendiente'", conx.conectar());
            SqlDataReader reader = cmd.ExecuteReader();

            return reader.Read();
        }

        public DataTable ListarIDCobranzaEspecifica(int i)
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();

            SqlCommand cmd = new SqlCommand("select co.ID_Cobranza, co.Factura_NO, co.Cliente_Rut, cl.Nombre_Cliente, co.FechaCobranza, co.Saldo, co.MetodoPago, co.NumCuotas, co.Estado " +
                "from Cobranza co inner join Cliente cl ON co.Cliente_Rut=cl.Rut_Cliente " +
                "where ID_Cobranza=" + i, conx.conectar());
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

        public DataTable ListarNOFacturaEspecifica(int f)
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();

            SqlCommand cmd = new SqlCommand("select co.ID_Cobranza, co.Factura_NO, cl.Nombre_Cliente, co.FechaCobranza, co.Saldo, co.MetodoPago, co.Estado " +
                "from Cobranza co inner join Cliente cl ON co.Cliente_Rut=cl.Rut_Cliente " +
                "where Factura_NO=" + f, conx.conectar());
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

        public DataTable ListarRutEspecifica(string r)
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();

            SqlCommand cmd = new SqlCommand("select co.ID_Cobranza, co.Factura_NO, cl.Rut_Cliente, cl.Nombre_Cliente, co.FechaCobranza, co.Saldo, co.MetodoPago, co.Estado " +
                "from Cobranza co inner join Cliente cl ON co.Cliente_Rut=cl.Rut_Cliente " +
                "where Cliente_Rut='" + r + "'", conx.conectar());
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

            SqlCommand cmd = new SqlCommand("select co.ID_Cobranza, co.Factura_NO, cl.Rut_Cliente, cl.Nombre_Cliente, co.FechaCobranza, co.Saldo, co.MetodoPago, co.Estado " +
    "from Cobranza co inner join Cliente cl ON co.Cliente_Rut=cl.Rut_Cliente " +
    "where FechaCobranza = '" + f + "'", conx.conectar());
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

            SqlCommand cmd = new SqlCommand("select co.ID_Cobranza, co.Factura_NO, cl.Rut_Cliente, cl.Nombre_Cliente, co.FechaCobranza, co.Saldo, co.MetodoPago, co.Estado " +
"from Cobranza co inner join Cliente cl ON co.Cliente_Rut=cl.Rut_Cliente " +
"where FechaCobranza >= '" + fd + "' and FechaCobranza <= '" + fh + "'", conx.conectar());
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
