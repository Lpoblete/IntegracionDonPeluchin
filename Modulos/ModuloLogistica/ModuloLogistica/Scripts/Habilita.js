$(document).ready(function (e) {
    $("#chknombre").change(checknombre);
    $("#chkvalor").change(checkval);
    $("#chkdescripcion").change(checkdes);

});

function checknombre()
{
    
    if (document.getElementById("chknombre").checked) {
        
        document.getElementById("txtnombre").disabled = false;
        document.getElementById("BtnModifica").disabled = false;
    }
    else {
        document.getElementById("txtnombre").disabled = true;
    }
}

function checkval() {

    if (document.getElementById("chkvalor").checked) {

        document.getElementById("txtvalor").disabled = false;
        document.getElementById("BtnModifica").disabled = false;
    }
    else {
        document.getElementById("txtvalor").disabled = true;
    }
}

function checkdes() {

    if (document.getElementById("chkdescripcion").checked) {

        document.getElementById("txtdescripcion").disabled = false;
        document.getElementById("BtnModifica").disabled = false;
    }
    else {
        document.getElementById("txtdescripcion").disabled = true;
    }
}
