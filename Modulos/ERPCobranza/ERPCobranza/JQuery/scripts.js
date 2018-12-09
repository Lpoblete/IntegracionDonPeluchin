
function elegido()
{
    $("#eleccion2").fadeToggle("slow");
}

function metodosPago(a)
{
    var saldoTarj = parseInt($("#saldoTarj").text());
    var mont = parseInt($("#montTotal").val());

    if (a === 1)
    {
        $("#tablaEfectivo").show(0);
        $("#tablaTarjeta").hide(0);
        $("#tarjetaSaldo").hide(0);

    }
    if (a === 2) 
    {
        if (saldoTarj >= mont)
        {
        $("#tablaEfectivo").hide(0);
        $("#tablaTarjeta").show(0);
        $("#tarjetaSaldo").show(0);
        }
        else
        {
            alert("Saldo insuficiente en la tarjeta");
            $("#tablaEfectivo").show(0);
            $("#tablaTarjeta").hide(0);
            $("#tarjetaSaldo").hide(0);
            $("#efectivo").attr("checked", true);
            $("#tarjeta").prop("checked", false);
        }
    }
}

function cuotas()
{
    var a = $("#numCuotas").val();
    var mont = $("#montTotal").val();
    var cuo1 = $("#Cuota1").val();
    var cuo2 = $("#Cuota2").val();
    var cuo3 = $("#Cuota3").val();
    var ajuste;

    if (a === '0') {
        $("#cuotaTD1").hide(0);
        $("#fechaVenTD1").hide(0);
        $("#cuotaTD2").hide(0);
        $("#fechaVenTD2").hide(0);
        $("#cuotaTD3").hide(0);
        $("#fechaVenTD3").hide(0);

        $("#Cuota1").val("");

        $("#ajust").text("0");
    }
    if (a === '1')
    {
        $("#cuotaTD1").show(0);
        $("#fechaVenTD1").show(0);
        $("#cuotaTD2").hide(0);
        $("#fechaVenTD2").hide(0);
        $("#cuotaTD3").hide(0);
        $("#fechaVenTD3").hide(0);

        $("#Cuota1").val(mont);

        $("#ajust").text("0");
    }
    if (a === '2')
    {
        $("#cuotaTD1").show(0);
        $("#fechaVenTD1").show(0);
        $("#cuotaTD2").show(0);
        $("#fechaVenTD2").show(0);
        $("#cuotaTD3").hide(0);
        $("#fechaVenTD3").hide(0);

        $("#Cuota1").val(parseInt(mont / 2));
        $("#Cuota2").val(parseInt(mont / 2));

        $("#ajust").text(mont - parseInt(parseInt($("#Cuota1").val()) + parseInt($("#Cuota2").val())));
    }
    if (a === '3')
    {
        $("#cuotaTD1").show(0);
        $("#fechaVenTD1").show(0);
        $("#cuotaTD2").show(0);
        $("#fechaVenTD2").show(0);
        $("#cuotaTD3").show(0);
        $("#fechaVenTD3").show(0);

        $("#Cuota1").val(parseInt(mont / 3));
        $("#Cuota2").val(parseInt(mont / 3));
        $("#Cuota3").val(parseInt(mont / 3));

        $("#ajust").text(mont - parseInt(parseInt($("#Cuota1").val()) + parseInt($("#Cuota2").val()) + parseInt($("#Cuota3").val())));
    }
}

function cuotas2() {
    var a = $("#numCuotas2").val();

    var mont = $("#montTotal").val();

    if (a === '1') {
        $("#cuotaTD4").show(0);
        $("#fechaVenTD4").show(0);
        $("#cuotaTD5").hide(0);
        $("#fechaVenTD5").hide(0);
        $("#cuotaTD6").hide(0);
        $("#fechaVenTD6").hide(0);

        $("#Cuota4").val(mont);
    }
    if (a === '2') {
        $("#cuotaTD5").show(0);
        $("#fechaVenTD5").show(0);
        $("#cuotaTD5").show(0);
        $("#fechaVenTD5").show(0);
        $("#cuotaTD6").hide(0);
        $("#fechaVenTD6").hide(0);

        $("#Cuota4").val(mont / 2);
        $("#Cuota5").val(mont / 2);
    }
    if (a === '3') {
        $("#cuotaTD4").show(0);
        $("#fechaVenTD4").show(0);
        $("#cuotaTD5").show(0);
        $("#fechaVenTD5").show(0);
        $("#cuotaTD6").show(0);
        $("#fechaVenTD6").show(0);

        $("#Cuota4").val(mont / 3);
        $("#Cuota5").val(mont / 3);
        $("#Cuota6").val(mont / 3);
    }
}

function despejarCasillas(a)
{
    if(a === 1)
    {
        $("#Fecha1").val("");
        $("#Fecha2").val("");
        $("#Fecha3").val("");
    }
    if (a === 2)
    {
        $("#Rut").val("");
        $("#Fecha2").val("");
        $("#Fecha3").val("");
    }
    if (a === 3)
    {
        $("#Rut").val("");
        $("#Fecha1").val("");
    }
}
