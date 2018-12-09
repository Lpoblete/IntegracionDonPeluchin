using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPIntegracion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Modulo.Text = Request.Params["mod"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Response.Write("<script type='text/javascript'>alert('"+mod+" - "+Modulo.Text+"');</script>");
            if (Modulo.Text == "ventas")
            {
                    Usuario u = new Usuario(Nombre.Text, Pass.Text, "Vendedor");
                    string condicion = string.Empty;
                    condicion = u.inicioSesion();

                    if (condicion == "1")
                    {
                        Response.Redirect("http://localhost:1764/MV_Listar.aspx");
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('no existe usuario');</script>");
                    }
            }
            else if(Modulo.Text == "logistica")
            {
                    Usuario u = new Usuario(Nombre.Text, Pass.Text, "Bodegero");
                    string condicion = string.Empty;
                    condicion = u.inicioSesion();

                    if (condicion == "1")
                    {
                        Response.Redirect("http://localhost:52273/Ingreso.aspx");
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('no existe usuario');</script>");
                    }
                }
            else if (Modulo.Text == "cobranza")
            {
                    Usuario u = new Usuario(Nombre.Text, Pass.Text, "Cajero");
                    string condicion = string.Empty;
                    condicion = u.inicioSesion();

                    if (condicion == "1")
                    {
                        Response.Redirect("http://localhost:62213/Consultar.aspx");
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('no existe usuario');</script>");
                    }
                }
            else if (Modulo.Text == "credito")
            {
                    Usuario u = new Usuario(Nombre.Text, Pass.Text, "Ejecutivo");
                    string condicion = string.Empty;
                    condicion = u.inicioSesion();

                    if (condicion == "1")
                    {
                        Response.Redirect("http://localhost:59118/Consultar.aspx");
                    }
                    else
                    {
                        Response.Write("<script type='text/javascript'>alert('no existe usuario');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script type='text/javascript'>alert('"+ex.Message+"');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MenuIntegracion.aspx");
        }
    }
}
