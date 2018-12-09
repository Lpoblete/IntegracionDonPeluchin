<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modificar2.aspx.cs" Inherits="ERPCobranza.Modificar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="JQuery/scripts.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="Estilo/estilo.css"/>
    <title>Modificar</title>
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

        function fechasOcultas()
        {
            $("#FechaOculta1").val($("#Fecha1").val());
            $("#FechaOculta2").val($("#Fecha2").val());
            $("#FechaOculta3").val($("#Fecha3").val());
        }
</script>

<body id="fondo" onload="setInterval('elegido()', 500); setInterval('fechasOcultas()', 1);">
    <form id="form1" runat="server">
        <div id="cabezaPagina">
            <asp:Button ID="AlPrincipal" class="botonMenuPrin" runat="server" Text="Menu Principal" OnClick="AlPrincipal_Click" />
            ERP COBRANZA</div>
        <input id="FechaOculta1" type="text" hidden="hidden" runat="server"/>
        <input id="FechaOculta2" type="text" hidden="hidden" runat="server"/>
        <input id="FechaOculta3" type="text" hidden="hidden" runat="server"/>
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
               <img src="Imagenes/iconAgregar.png" height="80" width="80"/>
               <a href="CrearCobranza.aspx">Crear Cobranza</a>
           </td>
       </tr>
       <tr>
           <td>
               <img id="eleccion2" src="Imagenes/iconModificar.png" height="80" width="80"/>
               <a id="eleccion">Modificar</a>
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
                    <table id="modificar">
                        <tr>
                            <td>
                                ID Cobranza: <a id="IDcobranza" runat="server">???</a>
                            </td>
                            <td>
                                NO. Factura: <a id="NOfactura" runat="server">???</a>
                            </td>
                            <td>
                                Cliente: <a id="Cliente" runat="server">???</a>
                            </td>
                            <td>
                                Monto total $
                                <asp:TextBox ID="montTotal" class="casilla" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Metodo de pago: <a id="metPago" runat="server">???</a>
                            </td>
                            <td>
                                Cuotas: <a id="numCuotas" runat="server">???</a>
                            </td>
                            <td>
                                Saldo Tarjeta: <a id="saldTarjeta" runat="server">???</a>
                            </td>
                            <td>

                            </td>
                        </tr>
                        <tr id="cuot1" runat="server" visible="false">
                            <td>
                                Cuota 1
                            </td>
                            <td>
                                <asp:TextBox ID="Cuota1" class="casilla" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                Fecha
                            </td>
                            <td>
                                <asp:TextBox ID="Fecha1" class="casilla" placeholder="XX/XX/XXXX" onmouseover="abrirCalendario(1)" runat="server" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="cuot2" runat="server" visible="false">
                            <td>
                                Cuota 2
                            </td>
                            <td>
                                <asp:TextBox ID="Cuota2" class="casilla" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                Fecha
                            </td>
                            <td>
                                <asp:TextBox ID="Fecha2" class="casilla" placeholder="XX/XX/XXXX" onmouseover="abrirCalendario(2)" runat="server" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="cuot3" runat="server" visible="false">
                            <td>
                                Cuota 3
                            </td>
                            <td>
                                <asp:TextBox ID="Cuota3" class="casilla" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                Fecha
                            </td>
                            <td>
                                <asp:TextBox ID="Fecha3" class="casilla" placeholder="XX/XX/XXXX" onmouseover="abrirCalendario(3)" runat="server" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:Button ID="Button1" class="boton" runat="server" Text="Modificar" OnClick="Button1_Click" />
                                <asp:Button ID="Button2" class="boton" runat="server" Text="Volver" OnClick="Button2_Click" />
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
