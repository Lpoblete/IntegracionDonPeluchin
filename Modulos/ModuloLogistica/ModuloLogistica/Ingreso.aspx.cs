using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ModuloLogistica
{
    public partial class Ingreso : System.Web.UI.Page
    {
        public SqlConnection Conn = new SqlConnection();
        public SqlCommand Tabb = new SqlCommand();
        public SqlDataAdapter Dadap = new SqlDataAdapter();
        public DataSet Dset = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ConectarBD()
        {
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IntegracionBD"].ConnectionString);
            Conn.Open();
        }

        protected void CargarTabla()
        {
            Tabb = new SqlCommand("SELECT * FROM Producto", Conn);
            Dadap.SelectCommand = Tabb;
            Dadap.Fill(Dset, "Producto");

        }

        protected void BtnIngreso_Click(object sender, EventArgs e)
        {
            try
            {
                int rowsaffected = 0;
                ConectarBD();
                CargarTabla();
                Tabb = new SqlCommand("SP_IngresoNuevoProducto", Conn);
                Tabb.CommandType = CommandType.StoredProcedure;
                Tabb.Parameters.AddWithValue("@Nombre_producto", Convert.ToString(txtnombre.Text));
                Tabb.Parameters.AddWithValue("@Valor", Convert.ToInt32(txtvalor.Text));
                Tabb.Parameters.AddWithValue("@Descripcion", Convert.ToString(txtdescripcion.Text));

                //SqlDataReader dr = Tabb.ExecuteReader();
                rowsaffected = Tabb.ExecuteNonQuery();
                if (rowsaffected < 1)
                {
                    MessageBox.Show("El Nombre del Producto ya existe en la base de datos", "Don Peluchin Te Informa",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("Datos Grabados", "Don Peluchin Te Informa",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                GridView1.DataBind();
                LimpiarCasillas();

            }
            catch (Exception RR)
            {
                Response.Write("Error en el Grabar Datos" + RR.Message);
            }
        }

        protected void LimpiarCasillas()
        {
            txtnombre.Text = "";
            txtvalor.Text = "";
            txtdescripcion.Text = "";
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}