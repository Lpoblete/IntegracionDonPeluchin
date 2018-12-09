<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MV_Venta.aspx.cs" Inherits="VistaVentas.MV_Venta" %>

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
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
        .auto-style2 {
            height: 26px;
        }
        .auto-style3 {
            height: 26px;
            width: 64px;
        }
        .auto-style4 {
            width: 64px;
        }
        .auto-style5 {
            width: 258px;
        }
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
        .boton:disabled {
            background: #CCC;
            color: #900;
            -webkit-border-radius: 28;
            -moz-border-radius: 28;
            border-radius: 28px;
            font-family: 'Agency FB';
            font-size: 30px;
            padding: 5px 5px 5px 5px;
        }
    </style>
</head>
<body id="fondo" onload="setInterval('elegido()', 500);">
    <form id="form1" runat="server">
        <div id="cabezaPagina">
            <asp:Button ID="Button2" Class="botonMenuPrin" runat="server" Text="Menu Principal" OnClick="Button2_Click"  />
            ERP Don Peluchin - Ventas</div>

        <table>
            <tr>
                <td class="auto-style5">
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
               <img id="eleccion2" src="Imagenes/iconAgregar.png" />
               <a id="eleccion">Venta</a>
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
               <img src="Imagenes/iconBloquear.png" style="height: 100px; width: 100px" />
               <a href="PAgo.aspx">Pago</a>
           </td>
       </tr>
       </table>
         </td>
            </tr>
            <!--FIN Hipervinculos de las acciones-->

            <!--INICIO botones, casillas, labels y mas-->
            <tr>
                <td class="auto-style5">
                     <table><tr><td>
                    <table id="crCobranza">
                    <caption><h1>Cliente</h1></caption>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label2" runat="server" Text="Rut:" Font-Names="Cooper Black"></asp:Label></td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtRut" runat="server"></asp:TextBox></td>
                            <td class="auto-style3">
                                <asp:Label ID="Label1" runat="server" Text="Nombre: " Font-Names="Cooper Black"></asp:Label></td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtNombre" runat="server" Enabled="False"></asp:TextBox></td>
                        </tr>
                        <tr><td colspan="4" class="auto-style1">
                            <center>
                            <asp:Button ID="btnDatosCliente" runat="server" Text="Cargar" Width="107px" OnClick="btnDatosCliente_Click" class="boton"/>
                            </center>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblCodigo" runat="server" Text="Codigo:" Visible="False" Font-Names="Cooper Black"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddCodigo" runat="server" Visible="False" DataSourceID="SqlDataSource1" DataTextField="Nombre_producto" DataValueField="ID_producto" OnSelectedIndexChanged="ddCodigo_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:erpConnectionString %>" SelectCommand="SELECT * FROM [Producto]" ></asp:SqlDataSource>
                            </td>
                            <td class="auto-style4">
                                <asp:Label ID="lblDescrip" runat="server" Text="Descripccion:" Visible="False" Font-Names="Cooper Black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescripcion" runat="server" ReadOnly="True" Visible="false"></asp:TextBox>
                            </td>
                        </tr>                       
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="lblbodega" runat="server" Text="Bodega:" Visible="False" Font-Names="Cooper Black"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:DropDownList ID="ddBodega" runat="server" Visible="False" DataSourceID="SqlDataSource2" DataTextField="Nombre_bodega" DataValueField="Codigo_bodega" OnSelectedIndexChanged="ddBodega_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:erpConnectionString %>" SelectCommand="SELECT * FROM [Bodega]"></asp:SqlDataSource>
                            </td>
                            <td class="auto-style3">
                                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:" Visible="False" Font-Names="Cooper Black"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtCantidad" runat="server" MaxLength="4" TextMode="Number" Wrap="False" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <asp:Label ID="lblPrecio" runat="server" Text="Precio :" Visible="False" Font-Names="Cooper Black"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblPrecioP" runat="server" Visible="False" Font-Names="Cooper Black"></asp:Label>
                            </td><td>
                                <asp:Label ID="lblStock" runat="server" Text="Disponibles " Visible="False" Font-Names="Cooper Black"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblStockP" runat="server" Visible="False" Font-Names="Cooper Black"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td id="izquierda" colspan="4" style="align-content:center">
                                <asp:Label ID="lblNo" runat="server" Text="Factura No: " Visible="False" Font-Names="Cooper Black"></asp:Label>
                                <asp:Label ID="lblNofac" runat="server" Visible="False" Font-Names="Cooper Black"></asp:Label>
                                <center>
                                    <asp:Button ID="btnAgregar" runat="server" Text="+" Visible="false" OnClick="btnAgregar_Click" Class="boton"/>
                                </center>
                             </td>
                        </tr>
                        <tr>
                            <td colspan="4">                               
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblpago" runat="server" Text="Total" Visible="False" Font-Names="Cooper Black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtTotal" runat="server" ReadOnly="True" Visible="false"></asp:TextBox>
                            </td>
                            <td colspan="2">                               
                                <center>                                    
                                </center>
                            </td>
                        </tr>
                   </table>
                         
                                    
              </td>
         </tr>
            <!--FIN botones, casillas, labels y mas-->
         </table>

        </table>
        <div id="piePagina">
            Todos los derechos reservados © 2016 <br>
            Seccion 142 | diseñador Leandro
        </div>
    </form>
</body>
</html>


