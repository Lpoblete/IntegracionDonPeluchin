<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="ModuloLogistica.Ingreso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Estilos/estilo.css">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Nombre Producto:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtnombre" runat="server" MaxLength="50" Placeholder="Maximo 50 caracteres" required="required"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Valor Producto:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtvalor" runat="server" MaxLength="12" required="required" TextMode="Number" Min="1"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Descripción Producto:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdescripcion" placeholder="Maximo 256 caracteres" required="required" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="BtnIngreso" runat="server" Text="Ingresar" OnClick="BtnIngreso_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID_producto" DataSourceID="SqlDataSource1" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:BoundField DataField="ID_producto" HeaderText="ID_producto" InsertVisible="False" ReadOnly="True" SortExpression="ID_producto" />
                                        <asp:BoundField DataField="Nombre_producto" HeaderText="Nombre_producto" SortExpression="Nombre_producto" />
                                        <asp:BoundField DataField="Valor" HeaderText="Valor" SortExpression="Valor" />
                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" SortExpression="Descripcion" />
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
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:IntegracionBD %>" SelectCommand="SELECT * FROM [Producto] ORDER BY [ID_producto] DESC"></asp:SqlDataSource>
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
