
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consulta.aspx.cs" Inherits="ModuloLogistica.Consulta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="Estilos/estilo.css"/>
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/Habilita.js" type="text/javascript"></script>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 71%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" height="100%">
            <tr>
                <td colspan="2">
                    <div id="cabezaPagina">
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
                                <a class="eleccion" href="Consulta.aspx">Consultar</a>
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
                                <a href="Despacho.aspx">Despacho</a>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table align="center" class="auto-style1">
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Bodega"></asp:Label>
                            </td>
                            <td>
                                Bodega: 
                                <asp:DropDownList ID="dllbodega" runat="server"  DataSourceID="Sqlbodega" DataValueField="Codigo_bodega" AutoPostBack="True" AppendDataBoundItems="True" DataTextField="Codigo_bodega">
                                    <asp:ListItem Text="Todos" Value="%"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Codigo Producto"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="dllid" runat="server"  DataSourceID="Sqlid" DataValueField="Codigo_producto" AutoPostBack="True" AppendDataBoundItems="True" DataTextField="Codigo_producto">
                                    <asp:ListItem Text="Todos" Value="%"></asp:ListItem>
                                </asp:DropDownList>
                                </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Fecha/Fecha Desde"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="Fecha1" runat="server" DataSourceID="SqlFecha" DataValueField="Fecha_Ingreso" AutoPostBack="True" AppendDataBoundItems="True" DataTextField="Fecha_Ingreso">
                                    <asp:ListItem Text="Todos" Value="%"></asp:ListItem>
                                    </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="Codigo_existencia" DataSourceID="SqlDetalle" ForeColor="#333333" GridLines="None" >
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="Codigo_existencia" HeaderText="Codigo_existencia" InsertVisible="False" ReadOnly="True" SortExpression="Codigo_existencia" />
                                        <asp:BoundField DataField="Codigo_bodega" HeaderText="Codigo_bodega" SortExpression="Codigo_bodega" />
                                        <asp:BoundField DataField="Codigo_producto" HeaderText="Codigo_producto" SortExpression="Codigo_producto" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                        <asp:BoundField DataField="Fecha_Ingreso" HeaderText="Fecha_Ingreso" SortExpression="Fecha_Ingreso" />
                                    </Columns>
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy"/>
                                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                    <SortedDescendingHeaderStyle BackColor="#820000" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="Sqlbodega" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBDConnectionString %>" SelectCommand="SELECT DISTINCT [Codigo_bodega] FROM [Existencia]"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="Sqlid" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBDConnectionString %>" SelectCommand="SELECT DISTINCT [Codigo_producto] FROM [Existencia]"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlFecha" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBDConnectionString %>" SelectCommand="SELECT DISTINCT [Fecha_Ingreso] FROM [Existencia]"></asp:SqlDataSource>
                                <asp:SqlDataSource ID="SqlDetalle" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBDConnectionString %>" SelectCommand="SELECT * FROM [Existencia] " FilterExpression="Codigo_bodega LIKE '{0}%' AND Convert([Codigo_producto] ,'System.String') LIKE '%{1}%' AND Convert([Fecha_Ingreso],'System.String') LIKE'{2}%'">
                                        <FilterParameters>
                                        <asp:ControlParameter ControlID="dllbodega" Name="Codigo_bodega" PropertyName="SelectedValue" Type="String" />
                                        <asp:ControlParameter ControlID="dllid" Name="Codigo_producto" PropertyName="SelectedValue" Type="String" />
                                            <asp:ControlParameter ControlID="Fecha1" Type="String" Name="Fecha_Ingreso" PropertyName="SelectedValue" />
                                       </FilterParameters>
                                </asp:SqlDataSource>
                                
                                <br />
                            </td>
                        </tr>
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Exportar a PDF" />
                    </table>
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
