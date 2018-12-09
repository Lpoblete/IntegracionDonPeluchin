<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CrearCliente.aspx.cs" Inherits="ERPCredito.CrearCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="JQuery/scripts.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="Estilo/estilo.css"/>
    <title>Crear Cliente</title>
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
            ERP CREDITO</div>
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
               <img src="Imagenes/iconConsultarTarj.png" height="80" width="80"/>
               <a href="Consultar.aspx">Consultar</a>
           </td>
       </tr>
       <tr>
           <td>
               <img src="Imagenes/iconAgregarTarj.png" height="80" width="80"/>
               <a href="CrearTarjeta.aspx">Crear Tarjeta</a>
           </td>
       </tr>
       <tr>
           <td>
               <img src="Imagenes/iconCargarTarj.png" height="80" width="80"/>
               <a href="CargarTarjeta.aspx">Pagos</a>
           </td>
       </tr>
       <tr>
           <td>
               <img src="Imagenes/iconBloquearTarj.png" height="80" width="80"/>
               <a href="BloquearTarjeta.aspx">Bloquear Tarjeta</a>
           </td>
       </tr>
       <tr>
           <td>
               <img id="eleccion2" src="Imagenes/iconAgregarClie.png" height="80" width="80"/>
               <a class="eleccion">Crear Cliente</a>
           </td>
       </tr>
       </table>
         </td>
            </tr>
            <!--FIN Hipervinculos de las acciones-->

            <!--INICIO botones, casillas, labels y mas-->
            <tr>
                <td>
                    <table id="crCliente">
                        <tr>
                            <td>
                                RUT<br/>
                                <asp:TextBox ID="Rut" class="casilla" runat="server" placeholder="ingrese rut"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nombre<br/>
                                <asp:TextBox ID="Nombre" class="casilla" runat="server" placeholder="ingrese nombre"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Direccion<br/>
                                <asp:TextBox ID="Direccion" class="casilla" runat="server" placeholder="ingrese direccion"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Telefono<br/>
                                <asp:TextBox ID="Telefono" class="casilla" runat="server" placeholder="ingrese telefono" MaxLength="8" onkeypress="if (event.keyCode < 45 || event.keyCode > 57) event.returnValue = false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Button ID="Button1" class="boton" runat="server" Text="Crear Cliente" OnClick="Button1_Click" />
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
