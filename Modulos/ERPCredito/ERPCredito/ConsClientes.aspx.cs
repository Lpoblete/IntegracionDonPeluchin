using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Classes;

namespace ERPCredito
{
    public partial class ConsClientes : System.Web.UI.Page
    {
        public DataTable clientes;

        protected void Page_Load(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();

            clientes = cli.Listar();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Cliente cli = new Cliente();

            if(Rut.Text.Length > 0)
            {
                clientes = cli.ListarRutEspecifico(Rut.Text);
            }
            else
            {
                clientes = cli.Listar();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Consultar.aspx");
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}
