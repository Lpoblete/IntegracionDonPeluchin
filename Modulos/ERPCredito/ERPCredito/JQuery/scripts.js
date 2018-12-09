
function elegido()
{
    $("#eleccion2").fadeToggle("slow");
}

function despejarCasillas(a) {
    if (a === 1) {
        $("#Fecha1").val("");
    }
    if (a === 2) {
        $("#Rut").val("");
    }
    if (a === 3) {
        $("#Fecha1").val("");
        $("#Fecha2").val("");
    }
    if (a === 4) {
        $("#Rut").val("");
        $("#Fecha2").val("");
    }
    if (a === 5) {
        $("#Rut").val("");
        $("#Fecha1").val("");
    }
}
