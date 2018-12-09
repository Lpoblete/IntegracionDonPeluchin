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
   
    public partial class MV_Venta : System.Web.UI.Page
    {
        public ExistenciaBD exi = new ExistenciaBD();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        
        }

        protected void ddCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            try
            {
                ProductoBd pro = new ProductoBd();
                Producto prof = pro.buscar(int.Parse(ddCodigo.SelectedValue));
                txtDescripcion.Text = prof.Descripcion;
                lblPrecioP.Text = prof.Valor.ToString();
                
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

        protected void btnDatosCliente_Click(object sender, EventArgs e)
        {
            try
            {                
                
                CLienteBD cli = new CLienteBD();
                Cliente clif = new Cliente();
                clif = cli.buscar(txtRut.Text.Trim());
               if(clif!=null)
               {
                   txtNombre.Text = clif.Nombre;
                   btnDatosCliente.Enabled = false;
                   lblCodigo.Visible = true;
                   ddCodigo.Visible = true;
                   lblDescrip.Visible = true;
                   txtDescripcion.Visible = true;
                   lblbodega.Visible = true;
                   ddBodega.Visible = true;
                   lblPrecio.Visible = true;
                   lblPrecioP.Visible = true;
                   lblStock.Visible = true;
                   lblStockP.Visible = true;
                   lblNo.Visible = true;
                   lblNofac.Visible = true;
                   btnAgregar.Visible = true;
                   lblCantidad.Visible = true;
                   txtCantidad.Visible = true;
                   lblpago.Visible = true;
                   txtTotal.Visible = true;
               }
               else
               {
                   Response.Write("<script>window.alert('Cliente no se Encuentra verifique rut   ')</script>");
               }
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

        protected void ddBodega_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                
                Existencia exis = exi.buscarPro(int.Parse(ddCodigo.SelectedValue),ddBodega.SelectedValue);
                if(exis!=null){
                    lblStockP.Text = exis.Cantidad.ToString();
                }
                else
                {
                    lblStockP.Text = "0";
                }
                

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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            
            try
            {
                DetalleBD det = new DetalleBD();
                FacturaBd fat = new FacturaBd();
                List<Factura> fats = fat.Mostrar();
                if (lblNofac.Text == "")
                {
                    lblNofac.Text = (1 + fats.Count).ToString(); ;
                    DateTime Hoy = DateTime.Today;
                    string fecha = DateTime.Now.ToString();
                    fecha = fecha.Substring(0, 9);
                    int resul = fat.Agregar(new Modelo.Factura(int.Parse(lblNofac.Text), 0, txtRut.Text, string.Empty, string.Empty, fecha));
                }
                Existencia exis = exi.buscarPro(int.Parse(ddCodigo.SelectedValue), ddBodega.SelectedValue);
                List<Detalle> dets = det.Mostrar();
                int linea = 1;
                if (int.Parse(txtCantidad.Text)<=exis.Cantidad)
                {
                    foreach (var item in dets)
                    {
                        if (item.Factura == int.Parse(lblNofac.Text))
                        {
                            linea++;
                        }
                    }
                    int resultado = det.Agregar(new Modelo.Detalle(dets.Count + 1, linea, int.Parse(lblNofac.Text), int.Parse(ddCodigo.SelectedValue), int.Parse(txtCantidad.Text), exis.Id, int.Parse(txtCantidad.Text) * int.Parse(lblPrecioP.Text)));
                    if (resultado == 1)
                    {
                        Response.Write("<script>window.alert('se agrego correctamente')</script>");
                        Session["factura"] = lblNofac.Text;
                    }
                    else if (resultado == 2)
                    {
                        Response.Write("<script>window.alert('El producto ya esta agregado')</script>");
                    }
                    else
                    {
                        Response.Write("<script>window.alert('error fatal')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>window.alert('la cantidad no debe ser superior al Stok')</script>");
                }

                dets = det.Mostrar();
                int total = 0;
                foreach (var item in dets)
                {
                    if (item.Factura.ToString().Equals(lblNofac.Text))
                    {
                        total = total + item.Subtotal;
                        txtTotal.Text = total.ToString();
                    }

                }
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