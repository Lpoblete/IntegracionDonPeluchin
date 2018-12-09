<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearCobranza.aspx.cs" Inherits="ERPCobranza.CrearCobranza" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="JQuery/scripts.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="Estilo/estilo.css"/>
    <title>Crear Cobranza</title>
</head>
<body id="fondo" onload="setInterval('elegido()', 500);">
    <form id="form1" runat="server">
        <div id="cabezaPagina">
            <asp:Button ID="AlPrincipal" class="botonMenuPrin" runat="server" Text="Menu Principal" OnClick="AlPrincipal_Click" />
            ERP COBRANZA</div>

        <table>
            <tr>
                <td>
       <!--INICIO Hipervinculos de las acciones-->
       <table id="acciones">
       <tr>
           <td>
               <a id="tituloAcciones">Acciones</a>
           </td>
       </tr>
       <tr>
           <td>
               <img src="Imagenes/iconConsultar.png" height="80" width="80"/>
               <a href="Consultar.aspx">Consultar Cobranza</a>
           </td>
       </tr>
       <tr>
           <td>
               <img id="eleccion2" src="Imagenes/iconAgregar.png" height="80" width="80"/>
               <a id="eleccion">Crear Cobranza</a>
           </td>
       </tr>
       <tr>
           <td>
               <img src="Imagenes/iconModificar.png" height="80" width="80"/>
               <a href="Modificar.aspx">Modificar</a>
           </td>
       </tr>
       <tr>
           <td>
               <img src="Imagenes/iconCobrar.png" height="80" width="80"/>
               <a href="CobranzaPendiente.aspx">Cobranzas Pendientes</a>
           </td>
       </tr>
       <tr>
           <td>
               <img src="Imagenes/iconComprobante.png" height="80" width="80"/>
               <a href="VerComprobantes.aspx">Ver Comprobantes</a>
           </td>
       </tr>
       </table>
         </td>
            </tr>
            <!--FIN Hipervinculos de las acciones-->

            <!--INICIO botones, casillas, labels y mas-->
            <tr>
                <td>
                    <table id="crCobranza">
                        <tr>
                            <td>
                                NO. Factura:
                                <asp:TextBox ID="NumFactura" placeholder="Ingrese NO." class="casilla" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                             <center>
                                   <asp:Button ID="Button1" class="boton" runat="server" Text="Crear Cobranza" OnClick="Button1_Click"></asp:Button>
                             </center>
                            </td>
                        </tr>
                   </table>
              </td>
         </tr>
        <tr>
             <td>
                  <div id="consultar2">
                    <table border="1" >
                        <tr>
                            <td>
                               NO.
                            </td>
                            <td>
                               Monto Total
                            </td>
                            <td>
                               Cliente
                            </td>
                        </tr>
                        <%
                            try
                            {
                                if(facturas.Rows.Count > 0)
                                {
                                    foreach(System.Data.DataRow fa in facturas.Rows)
                                    {
                             %>
                       <tr>
                            <td>
                                <%=fa["NoFactura"].ToString() %>
                            </td>
                            <td>
                                <%=fa["Total"].ToString() %>
                            </td>
                            <td>
                                <%=fa["Cliente"].ToString() %>
                            </td>
                        </tr>
                        <%
                                    }
                                }
                            }
                            catch
                            {

                            }
                             %>
                   </table>
                   </div>
              </td>
         </tr>
            <!--FIN botones, casillas, labels y mas-->
         </table>

        <div id="piePagina">
            Todos los derechos reservados © 2016 <br>
            desarrollado por Leandro
        </div>
    </form>
</body>
</html>
