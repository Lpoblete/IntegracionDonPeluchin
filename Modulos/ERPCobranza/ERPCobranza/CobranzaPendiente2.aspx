<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CobranzaPendiente2.aspx.cs" Inherits="ERPCobranza.CobranzaPendiente2" %>

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
               <img id="eleccion2" src="Imagenes/iconCobrar.png" height="80" width="80"/>
               <a id="eleccion">Cobranzas Pendientes</a>
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
                <table id="cobrarPendiente">
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
                            <td colspan="2">
                                Monto total $
                                <asp:TextBox ID="montTotal" class="casilla" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Metodo de pago: <a id="metPago" runat="server">???</a>
                            </td>
                            <td id="tarj" visible="false" runat="server">
                                Cuotas: <a id="numCuotas" runat="server">???</a>
                            </td>
                            <td id="tarj2" visible="false" runat="server">
                                Saldo Tarjeta: <a id="saldTarjeta" runat="server">???</a>
                            </td>
                            <td colspan="2">
                                Saldo Pendiente $
                                <asp:TextBox ID="saldPendiente" class="casilla" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="efect" visible="false" runat="server">
                            <td>
                                Monto a Pagar
                            </td>
                            <td>
                            <asp:TextBox ID="Efectivo" class="casilla" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="cuot1" runat="server" visible="false">
                            <td align="center">
                                Cuota 1
                            </td>
                            <td>
                                <asp:TextBox ID="Cuota1" class="casilla" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                            <td align="center">
                                Fecha
                            </td>
                            <td>
                                <asp:TextBox ID="Fecha1" class="casilla" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <a id="mensajeCobro1" runat="server">Pagar</a>
                            </td>
                            <td>
                                <asp:CheckBox ID="PagadoCuo1" runat="server" AutoPostBack="true" OnCheckedChanged="PagadoCuo1_CheckedChanged"/>
                            </td>
                        </tr>
                        <tr id="cuot2" runat="server" visible="false">
                            <td align="center">
                                Cuota 2
                            </td>
                            <td>
                                <asp:TextBox ID="Cuota2" class="casilla" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                            <td align="center">
                                Fecha
                            </td>
                            <td>
                                <asp:TextBox ID="Fecha2" class="casilla" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <a id="mensajeCobro2" runat="server">Pagar</a>
                            </td>
                            <td>
                                <asp:CheckBox ID="PagadoCuo2" runat="server" AutoPostBack="true" OnCheckedChanged="PagadoCuo2_CheckedChanged"/>
                            </td>
                        </tr>
                        <tr id="cuot3" runat="server" visible="false">
                            <td align="center">
                                Cuota 3
                            </td>
                            <td>
                                <asp:TextBox ID="Cuota3" class="casilla" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                            <td align="center">
                                Fecha
                            </td>
                            <td>
                                <asp:TextBox ID="Fecha3" class="casilla" ReadOnly="true" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <a id="mensajeCobro3" runat="server">Pagar</a>
                            </td>
                            <td>
                                <asp:CheckBox ID="PagadoCuo3" runat="server" AutoPostBack="true" OnCheckedChanged="PagadoCuo3_CheckedChanged"/>
                            </td>
                        </tr>
                        <tr>
                            <td id="efect2" colspan="4" align="center" runat="server" visible="false">
                                <asp:Button ID="Button3" class="boton" runat="server" Text="Cobrar" OnClick="Button3_Click"/>
                                <asp:Button ID="Button4" class="boton" runat="server" Text="Volver" OnClick="Button2_Click"/>
                            </td>
                            <td id="tarj3" colspan="4" align="center" runat="server" visible="false">
                                <asp:Button ID="Button1" class="boton" runat="server" Text="Cobrar" OnClick="Button1_Click"/>
                                <asp:Button ID="Button2" class="boton" runat="server" Text="Volver" OnClick="Button2_Click"/>
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
