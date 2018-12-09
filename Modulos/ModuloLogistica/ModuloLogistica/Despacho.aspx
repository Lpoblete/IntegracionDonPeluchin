<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Despacho.aspx.cs" Inherits="ModuloLogistica.Despacho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Estilos/estilo.css">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" height="100%">
            <tr>
                <td colspan="2"> <div id="cabezaPagina">
           <asp:Button ID="AlPrincipal" class="botonMenuPrin" runat="server" Text="Menu Principal" OnClick="AlPrincipal_Click" />
            ERP Bodega
</div>
                </td>
            </tr>
            <tr>
                <td width="25%" valign="top">
                    <table id="acciones" height="100%" border="0">
                        <tr>
                            <td colspan="2"><a id="tituloAcciones">Acciones</a> </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="Consulta.aspx">
                                    <img src="Img/iconConsultar.png" />
                                </a>
                            </td>
                            <td>
                                <a href="Consulta.aspx">Consultar</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="IngresosVarios.aspx">
                                    <img src="Img/iconAgregar.png" />
                                </a>
                            </td>
                            <td>
                                <a href="IngresosVarios.aspx">Ingreso</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="Modificar.aspx">
                                    <img src="Img/iconModificar.png" /></a>
                            </td>
                            <td>
                                <a href="Modificar.aspx">Modificar</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="Despacho.aspx">
                                    <img height="50%" src="Img/despacho.png" width="90%" /></a>
                            </td>
                            <td>
                                <a class="eleccion" href="Despacho.aspx">Despacho</a>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
    <!-- AQUI LA TABLA PRINCIPAL -->
                    NO. detalle venta<asp:TextBox ID="txtbuscar" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="Buscar" />
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="NoDetalle" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="NoDetalle" HeaderText="NoDetalle" ReadOnly="True" SortExpression="NoDetalle" />
                            <asp:BoundField DataField="Linea" HeaderText="Linea" SortExpression="Linea" />
                            <asp:BoundField DataField="NoFactura" HeaderText="NoFactura" SortExpression="NoFactura" />
                            <asp:BoundField DataField="Producto" HeaderText="Producto" SortExpression="Producto" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                            <asp:BoundField DataField="Existencia" HeaderText="Existencia" SortExpression="Existencia" />
                            <asp:BoundField DataField="subtotal" HeaderText="subtotal" SortExpression="subtotal" />
                        </Columns>
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBDConnectionString %>" SelectCommand="SELECT * FROM [DetalleVenta]" FilterExpression="Convert(NoFactura,'System.String') LIKE '{0}%'" >
                        <FilterParameters>
                            <asp:ControlParameter Name="NoDetalle" ControlID="txtbuscar" PropertyName="Text" />
                        </FilterParameters>
                    </asp:SqlDataSource>
                    
    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div id="piePagina">
                        Todos los derechos reservados © 2016
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
