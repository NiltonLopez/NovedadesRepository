// Función para limpiar los campos del formulario
function limpiarCampos() {

    document.getElementById("txtDocumento").value = "";
    document.querySelector("select[name='conceptos']").selectedIndex = 0;
    document.getElementById("txtObservacion").value = "";
    document.getElementById("AvisoReporte").style.display = "none";
    if (document.getElementById("txtValor")) document.getElementById("txtValor").value = "";
    if (document.getElementById("txtHoras")) document.getElementById("txtHoras").value = "";
    if (document.getElementById("txtFechaInicio")) document.getElementById("txtFechaInicio").value = "";
    if (document.getElementById("txtFechaFin")) document.getElementById("txtFechaFin").value = "";
}

