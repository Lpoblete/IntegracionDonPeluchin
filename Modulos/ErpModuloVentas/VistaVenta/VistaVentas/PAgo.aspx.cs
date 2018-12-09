using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Modelo;
using Coneccion;

namespace VistaVentas
{
    public partial class PAgo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPAgo_Click(object sender, EventArgs e)
        {
            try
            {
                DetalleBD Ch = new DetalleBD();
                FacturaBd fa = new FacturaBd();
                ExistenciaBD exi = new ExistenciaBD();
                List <Detalle> dess = Ch.Mostrar();
                int total = 0;
                foreach (var item in dess)
                {
                    if(item.Factura==int.Parse(DropDownList1.Text)){                        
                    Existencia exis = exi.buscar(item.Existencia);
                    exis.Cantidad = exis.Cantidad - item.Cantidad;
                    exi.Modificar(exis);
                    total += item.Subtotal;
                    }
                }
                Factura fass = fa.buscar(int.Parse(DropDownList1.Text));                
                fass.Total=total;
                fass.Entrega = "si";
                fa.Modificar(fass);              

            }
            catch (ArgumentException ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>window.alert('" + ex.Message + "')</script>");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://localhost:56834/MenuIntegracion.aspx");
        }
    }
}