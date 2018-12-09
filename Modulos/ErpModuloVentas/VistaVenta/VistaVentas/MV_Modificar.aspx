<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MV_Modificar.aspx.cs" Inherits="VistaVentas.MV_Modificar" %>

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
        </style>
</head>
<body id="fondo" onload="setInterval('elegido()', 500);">
    <form id="form1" runat="server">
        <div id="cabezaPagina">
            <asp:Button ID="Button2" Class="botonMenuPrin" runat="server" Text="Menu Principal" OnClick="Button2_Click"  />
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
               <img  src="Imagenes/iconAgregar.png" />
               <a href="MV_Venta.aspx">Venta</a>
           </td>
       </tr>
       <tr>
           <td>
               <img id="eleccion2" src="Imagenes/iconModificar.png" />
               <a id="eleccion">Modificar</a>
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
                <td>
                     <table><tr><td>
                    <table id="crCobranza">
                    <caption><h1>Cliente</h1></caption>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="Label1" runat="server" Text="Factura:" Font-Names="Cooper Black"></asp:Label></td>
                            <td class="auto-style2">
                                <asp:DropDownList ID="ddCodigo" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="NoFactura" DataValueField="NoFactura"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:erpConnectionString %>" SelectCommand="SELECT [NoFactura] FROM [Factura] WHERE (([Entrega] &lt;&gt; @Entrega) AND ([Entrega] &lt;&gt; @Entrega2))">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="si" Name="Entrega" Type="String" />
                                        <asp:Parameter DefaultValue="Si" Name="Entrega2" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            
                        </tr>
                        <tr><td colspan="2" class="auto-style1">
                            <center>
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="None">
                                    <AlternatingRowStyle BackColor="PaleGoldenrod" />
                                    <Columns>
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                                        <asp:BoundField DataField="Linea" HeaderText="Linea" SortExpression="Linea" ReadOnly="True" />
                                        <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="Producto" ReadOnly="True" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                        <asp:BoundField DataField="subtotal" HeaderText="subtotal" ReadOnly="True" SortExpression="subtotal" />
                                    </Columns>
                                    <FooterStyle BackColor="Tan" />
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                    <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                                    <SortedAscendingCellStyle BackColor="#FAFAE7" />
                                    <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                                    <SortedDescendingCellStyle BackColor="#E1DB9C" />
                                    <SortedDescendingHeaderStyle BackColor="#C2A47B" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:erpConnectionString %>" DeleteCommand="DELETE FROM DetalleVenta FROM DetalleVenta INNER JOIN DetalleVenta AS DetalleVenta_1 ON DetalleVenta.NoDetalle = DetalleVenta_1.NoDetalle" SelectCommand="SELECT [Linea], [Producto], [Cantidad], [subtotal] FROM [DetalleVenta] WHERE ([NoFactura] = @NoFactura)" UpdateCommand="UPDATE DetalleVenta SET Cantidad = @Cantidad">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddCodigo" Name="NoFactura" PropertyName="SelectedValue" Type="Decimal" />
                                    </SelectParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="Cantidad" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>
                            </center>
                            </td>
                        </tr>                        
                        <tr><td colspan="2" class="auto-style1">
                            &nbsp;</td>
                        </tr>
                        
                   </table>
                         
                    <table id="crCobranza1">
                        
                    </table>
                             </td>
                        </tr>
                         <tr>
                             <td>
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
