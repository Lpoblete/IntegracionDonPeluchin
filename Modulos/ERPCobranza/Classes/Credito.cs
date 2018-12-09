using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Credito
    {
        private int id;
        private string clienteRut;
        private string fechaEmision;
        private string fechaVencimiento;
        private int limiteCredito;
        private int dispCredito;

        public Credito() { }
        public Credito(int id, string cliRut, string fecEmi, string fecVen, int limCre, int dispCre)
        {
            Id = id;
            ClienteRut = cliRut;
            FechaEmision = fecEmi;
            FechaVencimiento = fecVen;
            LimiteCredito = limCre;
            DispCredito = dispCre;
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

        public string FechaEmision
        {
            get
            {
                return fechaEmision;
            }

            set
            {
                fechaEmision = value;
            }
        }

        public string FechaVencimiento
        {
            get
            {
                return fechaVencimiento;
            }

            set
            {
                fechaVencimiento = value;
            }
        }

        public int LimiteCredito
        {
            get
            {
                return limiteCredito;
            }

            set
            {
                limiteCredito = value;
            }
        }

        public int DispCredito
        {
            get
            {
                return dispCredito;
            }

            set
            {
                dispCredito = value;
            }
        }

        public int ModificarSaldo(int s, string r)
        {
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand comando = new SqlCommand("update Credito set Disp_Credito=" + s + " where Cliente_Rut='" + r +"'", conx.conectar());
            int resultado = comando.ExecuteNonQuery();
            conx.cerrar();
            return resultado;
        }

        public DataTable ListarRutEspecifico(string rut)
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand cmd = new SqlCommand("select * from Credito where Cliente_Rut='" + rut+"'", conx.conectar());
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
