<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NuevaExistencia.aspx.cs" Inherits="ModuloLogistica.NuevaExistencia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Estilos/estilo.css">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 268435456px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
                                    <a class="eleccion" href="IngresosVarios.aspx">Ingreso</a>
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
                        <table align="center" width="50%">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Bodega"></asp:Label>
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="radio" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nombre_bodega" DataValueField="Codigo_bodega" Style="height: 27px"></asp:RadioButtonList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBD %>" SelectCommand="SELECT * FROM [Bodega]"></asp:SqlDataSource>
                                </td>
                                <td>&nbsp;</td>
                                <td colspan="3">
                                    <asp:Button ID="BtnBodega" runat="server" Text="Escoger Bodega" OnClick="BtnBodega_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Codigo Producto"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="CbxProducto" runat="server" DataSourceID="SqlDataSource2" DataTextField="Codigo_producto" DataValueField="Codigo_producto" Width="50%" Enabled="False">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBD %>" SelectCommand="SELECT * FROM [Existencia] WHERE ([Codigo_bodega] = @Codigo_bodega)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="radio" Name="Codigo_bodega" PropertyName="SelectedValue" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td colspan="2">&nbsp;</td>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Nombre Producto"></asp:Label>
                                </td>
                                <td>
                                    <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource3" DataTextField="Nombre_producto" DataValueField="ID_producto" Enabled="False" Width="328px"></asp:ListBox>
                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBD %>" SelectCommand="SELECT * FROM [Producto] WHERE ([ID_producto] = @ID_producto)">
                                        <SelectParameters>
                                            <asp:ControlParameter ControlID="CbxProducto" Name="ID_producto" PropertyName="SelectedValue" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                                <td colspan="2">&nbsp;</td>
                                <td colspan="2">
                                    <asp:Button ID="BtnCodigo" runat="server" Text="Verificar Codigo" Height="82px" Enabled="False" OnClick="BtnCodigo_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Cantidad"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtcant" runat="server" Min="1" TextMode="Number" Width="50%" Enabled="False"></asp:TextBox>
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="Label4" runat="server" Text="Fecha"></asp:Label>
                                </td>
                                <td class="auto-style2">
                                    <asp:TextBox ID="txtfecha" runat="server" ReadOnly Width="50%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">
                                    <asp:Button ID="BtnIngresar" runat="server" Text="Ingresar" OnClick="BtnIngresar_Click" Enabled="False" />
                                    <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" OnClick="BtnLimpiar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Codigo_existencia" DataSourceID="SqlDataSource4" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                        <SortedDescendingHeaderStyle BackColor="#820000" />
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBD %>" SelectCommand="SELECT * FROM [Existencia] ORDER BY [Codigo_producto]"></asp:SqlDataSource>
                                </td>
                            </tr>
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
        </div>
    </form>
</body>
</html>
