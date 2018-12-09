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
    public partial class Modificar : System.Web.UI.Page
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

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (txtcodigo.Text != "")
            {
                Buscar();
                
            }
            else
            {
                MessageBox.Show("Debe Ingresar El Codigo De Producto", "DonPeluchin Informa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        protected void Buscar()
        {
            try
            {
                ConectarBD();
                Tabb = new SqlCommand("Select count(*) from Producto where ID_producto=@Codigo_producto", Conn);
                Dadap.SelectCommand = Tabb;
                Dadap.SelectCommand.Parameters.Add("@Codigo_producto", SqlDbType.Int).Value = txtcodigo.Text;
                Dadap.SelectCommand.ExecuteNonQuery();


                int n;
                n = Convert.ToInt32(Tabb.ExecuteScalar());
                if (n == 1)
                {
                    Listar();
                    chknombre.Enabled = true;
                    chkvalor.Enabled = true;
                    chkdescripcion.Enabled = true;
                    txtcodigo.Enabled = false;
                    BtnBuscar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("El Codigo De Producto NO Existe", "DonPeluchin Informa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception RR)
            {
                Response.Write("Error en el Grabar Datos" + RR.Message);
            }
        }

        protected void Listar()
        {
            SqlDataReader dr;
            ConectarBD();
            Tabb = new SqlCommand("Select * from Producto where ID_producto=@Codigo_producto", Conn);
            Dadap.SelectCommand = Tabb;
            Dadap.SelectCommand.Parameters.Add("@Codigo_producto", SqlDbType.Int).Value = txtcodigo.Text;
            Dadap.SelectCommand.ExecuteNonQuery();

            dr = Tabb.ExecuteReader();
            ListBox1.Items.Clear();
            while (dr.Read())
            {
                ListBox1.Items.Add(dr[0].ToString());
                ListBox1.Items.Add(dr[1].ToString());
                txtnombre.Text = dr[1].ToString();
                ListBox1.Items.Add(dr[2].ToString());
                txtvalor.Text = dr[2].ToString();
                ListBox1.Items.Add(dr[3].ToString());
                txtdescripcion.Text = dr[3].ToString();
            }
            dr.Close();
        }


        protected void LimpiaCasillas()
        {
            txtcodigo.Text = "";
            txtcodigo.Enabled = true;
            BtnBuscar.Enabled = true;

            ListBox1.Items.Clear();

            chknombre.Checked = false;
            chknombre.Enabled = false;
            chkvalor.Checked = false;
            chkvalor.Enabled = false;
            chkdescripcion.Checked = false;
            chkdescripcion.Enabled = false;

            txtnombre.Text = "";
            txtnombre.Enabled = false;
            txtvalor.Text = "";
            txtvalor.Enabled = false;
            txtdescripcion.Text = "";
            txtdescripcion.Enabled = false;

            BtnModifica.Enabled = false;
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiaCasillas();
        }

        protected void BtnModifica_Click(object sender, EventArgs e)
        {
            if (txtnombre.Text == "" || txtvalor.Text == "" || txtdescripcion.Text == "")
            {
                MessageBox.Show("Debe Mantener O llenar Todos los campos", "Don Peluchin Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiaCasillas();
            }
            else
            {
                Modifica();
                GridView1.DataBind();
            }
        }

        protected void Modifica()
        {
            ConectarBD();
            Tabb = new SqlCommand("Update Producto Set Nombre_producto=@Nombre, Valor=@Valor, Descripcion=@Descripcion WHERE ID_producto=@Codigo_producto", Conn);
            Dadap.UpdateCommand = Tabb;
            Dadap.UpdateCommand.Parameters.Add("@Codigo_producto", SqlDbType.Int).Value = Convert.ToInt32(txtcodigo.Text);
            Dadap.UpdateCommand.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = Convert.ToString(txtnombre.Text);
            Dadap.UpdateCommand.Parameters.Add("@Valor", SqlDbType.Int).Value = Convert.ToInt32(txtvalor.Text);
            Dadap.UpdateCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = Convert.ToString(txtdescripcion.Text);

            Dadap.UpdateCommand.ExecuteNonQuery(); // Esta es la linea que inserta
            MessageBox.Show("Datos Grabados", "Don Peluchin Informa", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}