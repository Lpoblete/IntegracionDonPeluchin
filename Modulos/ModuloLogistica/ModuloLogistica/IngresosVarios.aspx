<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresosVarios.aspx.cs" Inherits="ModuloLogistica.IngresosVarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="Estilos/estilo.css">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 135px;
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
                    <table width="50%" align="center" style="border-width: medium; border-style: dotted; background-color: #FF9933; height: 249px;">
                        <tr>
                            <td class="auto-style1">
                                <a href="Ingreso.aspx"><img src="Img/nuevo.png" width="50%" height="20%"/></a>
                            </td>
                            <td>
                                <a href="Ingreso.aspx">Ingreso Nuevo Producto</a>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">
                                <a href="NuevaExistencia.aspx"><img src="Img/Existente.png" width="50%" height="30%"/></a>
                            </td>
                            <td>
                                <a href="NuevaExistencia.aspx">Ingreso Productos Existentes</a>
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
