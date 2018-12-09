<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsTarjetas.aspx.cs" Inherits="ERPCredito.ConsTarjetas" %>

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
    <style type="text/css">
        .auto-style1 {
            height: 63px;
        }
    </style>
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
               <img id="eleccion2" src="Imagenes/iconConsultarTarj.png" height="80" width="80"/>
               <a class="eleccion">Consultar</a>
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
               <img src="Imagenes/iconAgregarClie.png" height="80" width="80"/>
               <a href="CrearCliente.aspx">Crear Cliente</a>
           </td>
       </tr>
       </table>
         </td>
            </tr>
            <!--FIN Hipervinculos de las acciones-->

            <!--INICIO botones, casillas, labels y mas-->
            <tr>
                <td>
                    <table id="crCliente2">
                        <tr>
                            <td class="auto-style1">
                                RUT<br/>
                                <asp:TextBox ID="Rut" class="casilla" runat="server" placeholder="ingrese rut" OnClick="despejarCasillas(3)"></asp:TextBox>
                            </td>
                            <td class="auto-style1">
                                Estado<br/>
                                <asp:RadioButton ID="Vige" runat="server" Text="Vigente" Checked="true" AutoPostBack="true" OnCheckedChanged="RadioButton2_CheckedChanged"/>
                                <asp:RadioButton ID="Bloq" runat="server" Text="Bloqueado" AutoPostBack="true" OnCheckedChanged="RadioButton1_CheckedChanged"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fecha Emision<br/>
                                <asp:TextBox ID="Fecha1" class="casilla" runat="server" placeholder="ingrese fecha" OnClick="despejarCasillas(4)" OnMouseOver="abrirCalendario(1)" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                            <td>
                                Fecha Vencimiento<br/>
                                <asp:TextBox ID="Fecha2" class="casilla" runat="server" placeholder="ingrese fecha" OnClick="despejarCasillas(5)" OnMouseOver="abrirCalendario(2)" onkeydown="if (event.keyCode == 8) event.returnValue = false;" onkeypress="if (event.keyCode > 0) event.returnValue = false;"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                <asp:Button ID="Button2" class="boton" runat="server" Text="Buscar" OnClick="Button2_Click" />
                                <asp:Button ID="Button1" class="boton" runat="server" Text="Volver" OnClick="Button1_Click" />
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
                               Rut Cliente
                            </td>
                            <td>
                               Fecha Emision
                            </td>
                            <td>
                               Fecha Vencimiento
                            </td>
                            <td>
                               Limite Credito
                            </td>
                            <td>
                               Saldo Disponible
                            </td>
                            <td>
                               Estado
                            </td>
                        </tr>
                        <%
                            try
                            {
                                if(tarjetas.Rows.Count > 0)
                                {
                                    foreach(System.Data.DataRow ca in tarjetas.Rows)
                                    {
                             %>
                       <tr>
                            <td>
                                <%=ca["ID_Credito"].ToString() %>
                            </td>
                            <td>
                                <%=ca["Cliente_Rut"].ToString() %>
                            </td>
                            <td>
                                <%=ca["FechaEmision"].ToString().Substring(0,8) %>
                            </td>
                            <td>
                                <%=ca["FechaVencimiento"].ToString().Substring(0,8) %>
                            </td>
                            <td>
                                <%=ca["LimiteCredito"].ToString() %>
                            </td>
                            <td>
                                <%=ca["Disp_Credito"].ToString() %>
                            </td>
                            <td>
                                <%=ca["Estado"].ToString() %>
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
