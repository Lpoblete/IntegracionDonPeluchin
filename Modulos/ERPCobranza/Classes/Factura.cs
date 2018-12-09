using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Factura
    {
        private int noFactura;
        private int total;
        private string rutCliente;
        private string observacion;
        private string entrega;

        public Factura() { }
        public Factura(int nFactura, int total, string rutCli, string observacion, string entrega)
        {
            NoFactura = nFactura;
            Total = total;
            RutCliente = rutCli;
            Observacion = observacion;
            Entrega = entrega;
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

        public int Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public string RutCliente
        {
            get
            {
                return rutCliente;
            }

            set
            {
                rutCliente = value;
            }
        }

        public string Observacion
        {
            get
            {
                return observacion;
            }

            set
            {
                observacion = value;
            }
        }

        public string Entrega
        {
            get
            {
                return entrega;
            }

            set
            {
                entrega = value;
            }
        }

        public bool BuscarNOFactura(int no)
        {
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand cmd = new SqlCommand("select * from Factura where NoFactura=" + no + " and Total > 0 and entrega='si'", conx.conectar());
            SqlDataReader reader = cmd.ExecuteReader();

            return reader.Read();
        }

        public DataTable Listar()
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();

            SqlCommand cmd = new SqlCommand("select * from Factura where Total > 0 and entrega='si'", conx.conectar());
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

        public DataTable ListarNOFacturaEspecifico(int no)
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand cmd = new SqlCommand("select fa.NoFactura, fa.Cliente, fa.Total, cl.Nombre_Cliente " +
                                            "from Factura fa inner join Cliente cl " +
                                            "ON fa.Cliente = cl.Rut_Cliente where NoFactura="+no, conx.conectar());
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
