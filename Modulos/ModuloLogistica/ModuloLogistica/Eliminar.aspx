<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eliminar.aspx.cs" Inherits="ModuloLogistica.Eliminar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Estilos/estilo.css">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
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
                                <a href="Despacho.aspx">Despacho</a>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <table align="center" class="auto-style1">
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Bodega"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:RadioButtonList ID="radio" runat="server" DataSourceID="SqlDataSource2" DataTextField="Nombre_bodega" DataValueField="Codigo_bodega">
                                </asp:RadioButtonList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBD %>" SelectCommand="SELECT * FROM [Bodega]"></asp:SqlDataSource>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="BtnBodega" runat="server" Text="Escoger Bodega" OnClick="BtnBodega_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="Label1" runat="server" Text="Codigo Producto"></asp:Label>
                                <asp:DropDownList ID="cbxproducto" runat="server" DataSourceID="SqlDataSource3" DataTextField="Codigo_producto" DataValueField="Codigo_producto" Enabled="False">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBD %>" SelectCommand="SELECT [Codigo_producto] FROM [Existencia] WHERE ([Codigo_bodega] = @Codigo_bodega)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="radio" Name="Codigo_bodega" PropertyName="SelectedValue" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:ListBox ID="ListBox1" runat="server" Height="93px" Width="349px" Enabled="False" DataSourceID="SqlDataSource4" DataTextField="Nombre_producto" DataValueField="ID_producto"></asp:ListBox>
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBD %>" SelectCommand="SELECT * FROM [Producto] WHERE ([ID_producto] = @ID_producto)">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cbxproducto" Name="ID_producto" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                            <td>
                                <asp:Button ID="BtnCodigo" runat="server" Text="Verificar Codigo" Height="82px" Enabled="False" OnClick="BtnCodigo_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="Label3" runat="server" Text="Elimine el producto en su totalidad o parte de él"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label2" runat="server" Text="Cantidad a Eliminar"></asp:Label>
                                <asp:TextBox ID="txtcantidad" runat="server" Enabled="False" Min="1" TextMode="Number"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:Label ID="Label5" runat="server" Text="Fecha"></asp:Label>
                                <asp:TextBox ID="txtfecha" runat="server" ReadOnly Enabled="False"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" OnClick="BtnEliminar_Click" Enabled="False" />
                                <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" OnClick="BtnLimpiar_Click" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Codigo_existencia" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="Codigo_existencia" HeaderText="Codigo_existencia" InsertVisible="False" ReadOnly="True" SortExpression="Codigo_existencia" />
                                        <asp:BoundField DataField="Codigo_bodega" HeaderText="Codigo_bodega" SortExpression="Codigo_bodega" />
                                        <asp:BoundField DataField="Codigo_producto" HeaderText="Codigo_producto" SortExpression="Codigo_producto" />
                                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad" />
                                        <asp:BoundField DataField="Fecha_Ingreso" HeaderText="Fecha_Ingreso" SortExpression="Fecha_Ingreso" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBD %>" SelectCommand="SELECT * FROM [Existencia]"></asp:SqlDataSource>
                            </td>
                            <td>
                                <asp:Button ID="button" runat="server" OnClick="button_Click" Text="Exportar PDF" />
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
    </form>
</body>
</html>
