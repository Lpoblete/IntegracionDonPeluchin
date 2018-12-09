<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ERPIntegracion.Login" %>

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
            <td align="center">
                <a id="tituloIntegra">DON PELUCHíN</a>
            </td>
        </tr>
    </table>
        <br/><br/><br/><br/><br/><br/>
    <table class="login" align="center">
        <tr>
            <td>
                Nombre
            </td>
            <td>
                <asp:TextBox ID="Nombre" class="casilla" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Contraseña
            </td>
            <td>
                <asp:TextBox ID="Pass" class="casilla" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Modulo
            </td>
            <td>
                <asp:TextBox ID="Modulo" class="casilla" runat="server" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="Button1" class="boton2" runat="server" Text="Ingresar" OnClick="Button1_Click" />
                <asp:Button ID="Button2" class="boton2" runat="server" Text="Volver" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
