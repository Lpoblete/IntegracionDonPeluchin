<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MV_Listar.aspx.cs" Inherits="VistaVentas.MV_Listar" %>

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
    <style type="text/css">
        
        .auto-style1 {
            width: 112px;
        }
        .auto-style2 {
            width: 199px;
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
               <img id="eleccion2" src="Imagenes/iconConsultar.png" />
               <a id="eleccion">Consultar</a>
           </td>
       </tr>
       <tr>
           <td>
               <img src="Imagenes/iconAgregar.png" /> <a href="MV_Venta.aspx">Venta</a></td>
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
                <td>
                    <table id="consultar">
                        <tr>
                            <td>
                                <asp:RadioButton ID="rdFactura" runat="server" GroupName="buscar" OnCheckedChanged="rdFactura_CheckedChanged" />
                                </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Listar Facturas" Font-Names="Cooper Black"></asp:Label> 
                            </td>
                            <td class="auto-style1">
                               <asp:RadioButton ID="rdDetalle" runat="server" GroupName="buscar" OnCheckedChanged="rdDetalle_CheckedChanged" /> 
                            </td><td class="auto-style2"><asp:Label ID="Label2" runat="server" Text="Listar Detalles" Font-Names="Cooper Black"></asp:Label> </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblfactura" runat="server" Text="Factura" Font-Names="Cooper Black"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="NoFactura" DataValueField="NoFactura" Visible="False">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:erpConnectionString %>" SelectCommand="SELECT [NoFactura] FROM [Factura]"></asp:SqlDataSource>
                            </td>
                            <td class="auto-style1">
                                <asp:Label ID="lblrut" runat="server" Text="Rut" Font-Names="Cooper Black"></asp:Label>
                            </td>
                            <td class="auto-style2">
                                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="Rut_Cliente" DataValueField="Rut_Cliente" Visible="False">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:erpConnectionString %>" SelectCommand="SELECT [Rut_Cliente] FROM [Cliente]"></asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                               <center>
                                 <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" class="boton"></asp:Button>
                               </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <center>
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource3" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="Linea" HeaderText="Linea" SortExpression="Linea" />
                                            <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="Producto" />
                                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                            <asp:BoundField DataField="subtotal" HeaderText="subtotal" SortExpression="subtotal" />
                                        </Columns>
                                        <EditRowStyle BackColor="#2461BF" />
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:erpConnectionString %>" SelectCommand="SELECT [Linea], [Producto], [Cantidad], [subtotal] FROM [DetalleVenta] WHERE ([NoFactura] = @NoFactura)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList1" Name="NoFactura" PropertyName="SelectedValue" Type="Decimal" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="NoFactura" DataSourceID="SqlDataSource4" ForeColor="#333333" GridLines="None">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <Columns>
                                            <asp:BoundField DataField="NoFactura" HeaderText="NoFactura" ReadOnly="True" SortExpression="NoFactura" />
                                            <asp:BoundField DataField="Cliente" HeaderText="Cliente" SortExpression="Cliente" />
                                            <asp:BoundField DataField="Total" HeaderText="Total" SortExpression="Total" />
                                            <asp:BoundField DataField="Observacion" HeaderText="Observacion" SortExpression="Observacion" />
                                            <asp:BoundField DataField="fecha" HeaderText="fecha" SortExpression="fecha" />
                                        </Columns>
                                        <EditRowStyle BackColor="#999999" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:erpConnectionString %>" SelectCommand="SELECT [NoFactura], [Cliente], [Total], [Observacion], [fecha] FROM [Factura] WHERE ([Cliente] = @Cliente)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="DropDownList2" Name="Cliente" PropertyName="SelectedValue" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                <asp:Button ID="btnimprir" runat="server" Text="Imprimir" OnClick="btnimprir_Click"  class="boton" />
                                </center>
                            </td>
                        </tr>
                   </table>
              </td>

              <td>
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

