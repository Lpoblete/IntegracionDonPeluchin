<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PAgo.aspx.cs" Inherits="VistaVentas.PAgo" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.6/jquery.min.js" type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="JQuery/scripts.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="Estilo/estilo.css"/>
    <title>Bloquear</title>
    <style>
        
        #piePagina {
            font-family: 'Cooper';
        }
        #cabezaPagina {
            font-family: 'Cooper';
        }


        .botonMenuPrin {
            background-image: -moz-linear-gradient(top, #000000, #ff6600);
            background-image: -ms-linear-gradient(top, #000000, #ff6600);
            background-image: -o-linear-gradient(top, #000000, #ff6600);
            background-image: linear-gradient(to bottom, #000000, #ff6600);
            -webkit-border-radius: 28;
            -moz-border-radius: 28;
            border-radius: 28px;
            font-family: 'Agency FB';
            color: #ffffff;
            font-size: 15px;
            position: absolute;
            right: 90%;
            top: 3%;
        }
            .botonMenuPrin:hover {
                background-image: -webkit-linear-gradient(top, #ff6600, #000000);
                background-image: -moz-linear-gradient(top, #ff6600, #000000);
                background-image: -ms-linear-gradient(top, #ff6600, #000000);
                background-image: -o-linear-gradient(top, #ff6600, #000000);
                background-image: linear-gradient(to bottom, #ff6600, #000000);
                font-weight: bold;
            }
            .boton {
            background-image: -webkit-linear-gradient(top, #000000, #ff6600);
            background-image: -moz-linear-gradient(top, #000000, #ff6600);
            background-image: -ms-linear-gradient(top, #000000, #ff6600);
            background-image: -o-linear-gradient(top, #000000, #ff6600);
            background-image: linear-gradient(to bottom, #000000, #ff6600);
            -webkit-border-radius: 28;
            -moz-border-radius: 28;
            border-radius: 28px;
            font-family: 'Agency FB';
            color: #ffffff;
            font-size: 30px;
            padding: 5px 5px 5px 5px;
        }

                .boton:hover {
                    background-image: -webkit-linear-gradient(top, #ff6600, #000000);
                    background-image: -moz-linear-gradient(top, #ff6600, #000000);
                    background-image: -ms-linear-gradient(top, #ff6600, #000000);
                    background-image: -o-linear-gradient(top, #ff6600, #000000);
                    background-image: linear-gradient(to bottom, #ff6600, #000000);
                    font-weight: bold;
                }
        .estilo1:disabled {
            background: #CCC;
            color: #900;
        }
    </style>
</head>
<body id="fondo" onload="setInterval('elegido()', 500);">
<form id="form1" runat="server">
        <div id="cabezaPagina">
            <asp:Button ID="Button2" Class="botonMenuPrin" runat="server" Text="Menu Principal" OnClick="Button2_Click" />
            ERP Don Peluchin - Ventas</div>

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
               <img src="Imagenes/iconConsultar.png" />
               <a href="MV_Listar.aspx">Consultar</a>
           </td>
       </tr>
       <tr>
           <td>
               <img src="Imagenes/iconAgregar.png" />
               <a href="MV_Venta.aspx">Venta</a>
           </td>
       </tr>
       <tr>
           <td>
               <img src="Imagenes/iconModificar.png" />
               <a href="MV_Modificar.aspx">Modificar</a>
           </td>
       </tr>
       <tr>
           <td>
               <img id="eleccion2" src="Imagenes/iconBloquear.png" style="height: 100px; width: 100px"/>
               <a id="eleccion">Pago</a>
           </td>
       </tr>
       </table>
         </td>
            </tr>
            <!--FIN Hipervinculos de las acciones-->

            <!--INICIO botones, casillas, labels y mas-->
            <tr>
                <td>
                    <table id="bloquear">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Factura :" CssClass="letra" Font-Names="Cooper Black"></asp:Label>
                            </td>
                             <td>
                                 <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="NoFactura" DataValueField="NoFactura"></asp:DropDownList>
                                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:erpConnectionString %>" SelectCommand="SELECT [NoFactura] FROM [Factura] WHERE (([Entrega] &lt;&gt; @Entrega) AND ([Entrega] &lt;&gt; @Entrega2))">
                                     <SelectParameters>
                                         <asp:Parameter DefaultValue="Si" Name="Entrega" Type="String" />
                                         <asp:Parameter DefaultValue="si" Name="Entrega2" Type="String" />
                                     </SelectParameters>
                                 </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <center>
                                <asp:Button ID="btnPAgo" runat="server" Text="Pagar" OnClick="btnPAgo_Click" CssClass="boton"></asp:Button>
                                </center>
                            </td>
                        </tr>
                   </table>
              </td>
         </tr>
            <!--FIN botones, casillas, labels y mas-->
         </table>

        <div id="piePagina">
            Todos los derechos reservados © 2016 <br>
            Seccion 142 | diseñador Leandro
        </div>
    </form>
</body>
</html>

