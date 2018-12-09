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
    public partial class NuevaExistencia : System.Web.UI.Page
    {
        public SqlConnection Conn = new SqlConnection();
        public SqlCommand Tabb = new SqlCommand();
        public SqlDataAdapter Dadap = new SqlDataAdapter();
        public DataSet Dset = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        //FUNCION LOCAL CONECTARBD
        protected void ConectarBD()
        {
            Conn = new SqlConnection(ConfigurationManager.ConnectionStrings["IntegracionBD"].ConnectionString);
            Conn.Open();
        }

        //FUNCION LOCAL CARGAR TABLA
        protected void CargarTabla()
        {
            Tabb = new SqlCommand("Select * from Producto", Conn);
            Dadap.SelectCommand = Tabb;
            Dadap.Fill(Dset, "Producto");

        }

        protected void limpiacasillas()
        {
            radio.ClearSelection();
            radio.Enabled = true;
            ListBox1.Items.Clear();
            CbxProducto.Items.Clear();
            CbxProducto.Enabled = false;
            txtcant.Text = "";
            txtcant.Enabled = false;
            ListBox1.Enabled = false;
            BtnIngresar.Enabled = false;
            BtnBodega.Enabled = true;
            BtnCodigo.Enabled = false;
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                int rowsaffected = 0;
                ConectarBD();
                CargarTabla();
                Tabb = new SqlCommand("SP_SumarExistencia", Conn);
                Tabb.CommandType = CommandType.StoredProcedure;
                Tabb.Parameters.AddWithValue("@Codigo_bodega", Convert.ToString(radio.SelectedValue));
                Tabb.Parameters.AddWithValue("@Codigo_producto", Convert.ToString(CbxProducto.SelectedValue));
                Tabb.Parameters.AddWithValue("@Cantidad", Convert.ToInt32(txtcant.Text));
                Tabb.Parameters.AddWithValue("@Fecha_Ingreso", Convert.ToDateTime(txtfecha.Text));

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
                limpiacasillas();

            }
            catch (Exception RR)
            {
                Response.Write("Error en el Grabar Datos" + RR.Message);
            }
        }

        protected void BtnBodega_Click(object sender, EventArgs e)
        {
            radio.Enabled = false;
            BtnBodega.Enabled = false;
            CbxProducto.Enabled = true;
            BtnCodigo.Enabled = true;
        }

        protected void BtnCodigo_Click(object sender, EventArgs e)
        {
            txtcant.Enabled = true;
            BtnIngresar.Enabled = true;
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            radio.ClearSelection();
            radio.Enabled = true;
            ListBox1.Items.Clear();
            CbxProducto.Items.Clear();
            CbxProducto.Enabled = false;
            txtcant.Text = "";
            txtcant.Enabled = false;
            CbxProducto.Enabled = false;
            ListBox1.Enabled = false;
            BtnIngresar.Enabled = false;
            BtnBodega.Enabled = true;
            BtnCodigo.Enabled = false;
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}