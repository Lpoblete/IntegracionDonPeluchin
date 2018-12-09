<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuscarVenta.aspx.cs" Inherits="BuscarVenta" %>

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
</head>
<body id="fondo" onload="setInterval('elegido()', 500);">
    <form id="form1" runat="server">
        <div id="cabezaPagina">ERP Don Peluchin - Ventas</div>

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
               <img src="Imagenes/iconAgregar.png" /> <a href="Venta.aspx">Venta</a></td>
       </tr>
       <tr>
           <td>
               <img src="Imagenes/iconModificar.png" />
               <a href="ModificarVenta.aspx">Modificar</a>
           </td>
       </tr>
       <tr>
           <td>
               <img src="Imagenes/iconBloquear.png" />
               <a href="AnularVenta.aspx">Anular</a>
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
                               RUT:
                               <input id="casilla" size="27" type="text" placeholder="Ingrese rut" />
                            </td>
                            <td>
                               Factura:
                               <input id="calendario1" size="27" type="text" placeholder="XXXXXXXX" readonly="true" onmouseover="abrirCalendario(1)"/>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               Fecha desde:
                               <input id="calendario2" size="27" type="text" placeholder="XX/XX/XXXX" readonly="true" onmouseover="abrirCalendario(2)"/>
                            </td>
                            <td>
                               Fecha hasta:
                               <input id="calendario3" size="27" type="text" placeholder="XX/XX/XXXX" readonly="true" onmouseover="abrirCalendario(3)"/>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                               <center>
                               <input id="boton" type="button" value="Consultar" />
                               </center>
                            </td>
                        </tr>
                   </table>
              </td>

              <td>
                  <div id="consultar2">
                    <table border="1">
                        <tr>
                            <td>
                               ID
                            </td>
                            <td>
                               RUT
                            </td>
                            <td>
                               Nombre
                            </td>
                            <td>
                               Monto Pagado
                            </td>
                            <td>
                               Metodo de pago
                            </td>
                        </tr>
                   </table>
                   </div>
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


