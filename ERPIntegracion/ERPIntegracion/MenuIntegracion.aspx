<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuIntegracion.aspx.cs" Inherits="ERPIntegracion.MenuIntegracion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Estilos/estiloMenuIntegracion.css" rel="stylesheet"/>
    <title></title>
</head>
<body id="fondo">
    <form id="form1" runat="server">
    <div>
    <table align="center">
        <tr>
            <td colspan="3" align="center">
                <a id="tituloIntegra">DON PELUCHíN</a>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" class="boton" runat="server" Text="Ventas" OnClick="Button1_Click" />
            </td>
            <td rowspan="2">
                <img src="Imagenes/peluchin.png"/>
            </td>
            <td>
                <asp:Button ID="Button2" class="boton" runat="server" Text="Logistica" OnClick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button3" class="boton" runat="server" Text="Cobranza" OnClick="Button3_Click" />
            </td>
            <td>
                <asp:Button ID="Button4" class="boton" runat="server" Text="Credito" OnClick="Button4_Click" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
