using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Cuotas
    {
        private int id;
        private int idCobranza;
        private double monto;
        private string fecha;
        private string estado;

        public Cuotas() { }
        public Cuotas(int id, int idcob, double monto, string fecha, string estado)
        {
            Id = id;
            IdCobranza = idcob;
            Monto = monto;
            Fecha = fecha;
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

        public int IdCobranza
        {
            get
            {
                return idCobranza;
            }

            set
            {
                idCobranza = value;
            }
        }

        public double Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
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

        public int Agregar()
        {
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand comando = new SqlCommand("insert into Cuota values("+Id+","+IdCobranza+","+Monto+",'"+Fecha+"','"+Estado+"');", conx.conectar());
            int resultado = comando.ExecuteNonQuery();
            conx.cerrar();
            return resultado;
        }

        public int Modificar(int i, string f)
        {
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand comando = new SqlCommand("update Cuota set Fecha='"+f+"' where ID_Cuota="+i, conx.conectar());
            int resultado = comando.ExecuteNonQuery();
            conx.cerrar();
            return resultado;
        }

        public int ModificarEstado(int i, int m, string e)
        {
            Conexion conx = new Conexion();
            conx.conectar().Open();
            SqlCommand comando = new SqlCommand("update Cuota set Estado='" + e + "', Monto=" + m + " where ID_Cuota=" + i, conx.conectar());
            int resultado = comando.ExecuteNonQuery();
            conx.cerrar();
            return resultado;
        }

        public DataTable Listar()
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();

            SqlCommand cmd = new SqlCommand("select * from Cuota", conx.conectar());
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

        public DataTable ListarIDCobranzaEspecifica(int i)
        {
            var dataTable = new DataTable();
            Conexion conx = new Conexion();
            conx.conectar().Open();

            SqlCommand cmd = new SqlCommand("select * from Cuota where Cobranza_ID="+i, conx.conectar());
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
