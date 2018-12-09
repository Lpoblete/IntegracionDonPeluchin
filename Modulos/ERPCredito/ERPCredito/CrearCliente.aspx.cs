using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes;
using System.Data;

namespace ERPCredito
{
    public partial class CrearCliente : System.Web.UI.Page
    {
        public DataTable clientes;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Rut.Text.Length > 0 && Nombre.Text.Length > 0 && Direccion.Text.Length > 0 && Telefono.Text.Length > 0)
                {
                    Cliente cli3 = new Cliente();
                    DataTable tablaCliente2 = cli3.ListarRutEspecifico(Rut.Text);

                    if (!(tablaCliente2.Rows.Count > 0))
                    {
                        Cliente cli2 = new Cliente();
                        DataTable tablaCliente = cli2.Listar();

                        int acumuladorID = tablaCliente.Rows.Count + 1;

                        Cliente cli = new Cliente(acumuladorID, Rut.Text, Nombre.Text, Direccion.Text, Telefono.Text);

                        if (cli.Agregar() == 1)
                        {
                            Response.Write("<script type='text/javascript'>alert('cliente creado'); location.href='Consultar.aspx';</script>");
                        }
                        else
                        {
                            Response.Write("<script type='text/javascript'>alert('no se pudo crear cliente');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('ya existe el cliente con el rut "+Rut.Text+"');</script>");
                    }
                }
                else
                {
                    Response.Write("<script type='text/javascript'>alert('hay casillas vacias');</script>");
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script type='text/javascript'>alert('"+ex.Message+"');</script>");
            }
        }

        protected void AlPrincipal_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}
