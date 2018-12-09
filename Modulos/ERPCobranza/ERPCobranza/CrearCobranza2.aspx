<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearCobranza2.aspx.cs" Inherits="ERPCobranza.CrearCobranza2" %>

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
                                Monto total $
                                <asp:TextBox ID="montTotal" class="casilla" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                NO. Factura: <a id="numFactura" runat="server">???</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Cliente: <a id="nomCli" runat="server">???</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Rut: <a id="rutCli" runat="server">???</a>
                            </td>
                        </tr>
                        <tr id="tarjetaSaldo" hidden="hidden">
                            <td>
                                Saldo Tarjeta: <a id="saldoTarj" runat="server">???</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input id="efectivo" type="radio" name="metp" onclick="metodosPago(1)" runat="server"/> Efectivo
                                <input id="tarjeta" type="radio" name="metp" onclick="metodosPago(2)" runat="server"/> Tarjeta
                                (<a id="estTarjeta" runat="server"></a>)
                            </td>
                        </tr>
                        <!--efectivo-->
                        <tr>
                            <td>
                            <table id="tablaEfectivo">
                                <tr>
                                    <td>
                                        Monto a Pagar <asp:TextBox ID="MontPagar" class="casilla" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            <tr>
                            <td colspan="3">
                                <asp:Button ID="Button1" class="boton" runat="server" Text="Aceptar" OnClick="Button1_Click" />
                                <asp:Button ID="Button2" class="boton" runat="server" Text="Volver" OnClick="Button2_Click" />
                            </td>
                            </tr>
                            </table>
                            </td>
                        </tr>
                        <!--tarjeta-->
                        <tr>
                            <td>
                            <table id="tablaTarjeta" hidden="hidden">
                                <tr>
                            <td>
                                N° Cuotas: 
                                <select id="numCuotas" onchange="cuotas()" runat="server">
                                    <option value="0">0</option>
                                    <option value="1">1</option>
                                    <option value="2">2</option>
                                    <option value="3">3</option>
                                </select>
                            </td>
                            </tr>
                            <tr>
                            <td id="cuotaTD1" hidden="hidden">
                                Cuota 1 <asp:TextBox ID="Cuota1" class="casilla" runat="server" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                            <td id="fechaVenTD1" hidden="hidden">
                                Fecha <asp:TextBox ID="Fecha1" class="casilla" placeholder="XX/XX/XXXX" OnMouseOver="abrirCalendario(1)" runat="server" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                            </tr>
                            <tr>
                            <td id="cuotaTD2" hidden="hidden">
                                Cuota 2 <asp:TextBox ID="Cuota2" class="casilla" runat="server" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                            <td id="fechaVenTD2" hidden="hidden">
                                Fecha <asp:TextBox ID="Fecha2" class="casilla" placeholder="XX/XX/XXXX" OnMouseOver="abrirCalendario(2)" runat="server" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                            </tr>
                            <tr>
                            <td id="cuotaTD3" hidden="hidden">
                                Cuota 3 <asp:TextBox ID="Cuota3" class="casilla" runat="server" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                            <td id="fechaVenTD3" hidden="hidden">
                                Fecha <asp:TextBox ID="Fecha3" class="casilla" placeholder="XX/XX/XXXX" OnMouseOver="abrirCalendario(3)" runat="server" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                            </tr>
                            <tr>
                                <td>
                                    Ajuste: <a id="ajust">0</a>
                                </td>
                            </tr>
                            <tr>
                            <td colspan="3">
                                <asp:Button ID="Button3" class="boton" runat="server" Text="Aceptar" OnClick="Button3_Click" />
                                <asp:Button ID="Button4" class="boton" runat="server" Text="Volver" OnClick="Button4_Click" />
                            </td>
                            </tr>
                            </table>
                            </td>
                        </tr>
                   </table>
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
