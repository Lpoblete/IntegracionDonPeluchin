<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consultar.aspx.cs" Inherits="ERPCobranza.Consultar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="JQuery/scripts.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="Estilo/estilo.css"/>
    <title>Consultar</title>
</head>

<script type="text/javascript">
    function abrirCalendario(a) {
        $("#Fecha" + a).datepicker({
            closeText: 'Cerrar',
            prevText: '<Ant',
            nextText: 'Sig>',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
            weekHeader: 'Sm',
            dateFormat: 'dd/mm/yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        });
    }
</script>

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
               <img id="eleccion2" src="Imagenes/iconConsultar.png" height="80" width="80"/>
               <a id="eleccion">Consultar Cobranza</a>
           </td>
       </tr>
       <tr>
           <td>
               <img src="Imagenes/iconAgregar.png" height="80" width="80"/>
               <a href="CrearCobranza.aspx">Crear Cobranza</a>
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
                    <table id="consultar">
                        <tr>
                            <td>
                               RUT:
                                <asp:TextBox ID="Rut" class="casilla" placeholder="Ingrese rut" runat="server" OnClick="despejarCasillas(1)"></asp:TextBox>
                            </td>
                            <td>
                               Fecha:
                                <asp:TextBox ID="Fecha1" class="casilla" placeholder="XX/XX/XXXX" OnMouseOver="abrirCalendario(1)" OnClick="despejarCasillas(2)" runat="server" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               Fecha desde:
                                <asp:TextBox ID="Fecha2" class="casilla" placeholder="XX/XX/XXXX" OnMouseOver="abrirCalendario(2)" OnClick="despejarCasillas(3)" runat="server" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                            <td>
                               Fecha hasta:
                                <asp:TextBox ID="Fecha3" class="casilla" placeholder="XX/XX/XXXX" OnMouseOver="abrirCalendario(3)" OnClick="despejarCasillas(3)" runat="server" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                               <center>
                               <asp:Button ID="Button1" class="boton" runat="server" Text="Consultar" OnClick="Button1_Click"></asp:Button>
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
                               ID
                            </td>
                            <td>
                               NO Factura
                            </td>
                            <td>
                               Rut Cli.
                            </td>
                            <td>
                               Nombre Cli.
                            </td>
                            <td>
                               Fecha Cobranza
                            </td>
                            <td>
                               Saldo pendiente
                            </td>
                            <td>
                               Metodo Pago
                            </td>
                            <td>
                               Estado
                            </td>
                        </tr>
                        <%
                            try
                            {
                                if(cobranzas.Rows.Count > 0)
                                {
                                    foreach(System.Data.DataRow cl in cobranzas.Rows)
                                    {
                             %>
                       <tr>
                            <td>
                                <%=cl["ID_Cobranza"].ToString() %>
                            </td>
                            <td>
                                <%=cl["Factura_NO"].ToString() %>
                            </td>
                            <td>
                                <%=cl["Rut_Cliente"].ToString() %>
                            </td>
                            <td>
                                <%=cl["Nombre_Cliente"].ToString() %>
                            </td>
                            <td>
                                <%=cl["FechaCobranza"].ToString().Substring(0, 8) %>
                            </td>
                            <td>
                                <%=cl["Saldo"].ToString() %>
                            </td>
                            <td>
                                <%=cl["MetodoPago"].ToString() %>
                            </td>
                            <td>
                                <%=cl["Estado"].ToString() %>
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

