//document.addEventListener('DOMContentLoaded', (event) => {
//    const txtFechaInicio = document.getElementById('txtFechaInicio');
//    const txtFechaFin = document.getElementById('txtFechaFin');

//    const hoyStr = hoy.toISOString().split('T')[0];
//    const mananaStr = manana.toISOString().split('T')[0];

//    txtFechaInicio.min = hoyStr;
//    txtFechaInicio.max = hoyStr;
//    txtFechaFin.min = hoyStr;
//    txtFechaFin.max = mananaStr;

//    txtFechaInicio.addEventListener('change', (event) => {
//        const selectedDate = new Date(event.target.value);
//        const selectedDateStr = selectedDate.toISOString().split('T')[0];
//        txtFechaFin.min = selectedDateStr;
//        txtFechaFin.max = mananaStr;
//    });
//});


async function ObtenerFechasCalendario(idEmpleado) {
    try {
        empleado = await ObtenerEmpleadoPorId(idEmpleado);
        tipoNomina = empleado.tipoNomina;
        claseNomina = empleado.claseNomina;
        fetch(`/Calendario/ObtenerCalendarioPorTipoNominaYClaseNomina?tipoNomina=${encodeURIComponent(tipoNomina)}&claseNomina=${encodeURIComponent(claseNomina)}`, {
            method: 'GET', // Especificar el método
            headers: {
                'accept': 'application/json' // Especificar el tipo de contenido que espera tu endpoint
            },
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok ' + response.statusText);
                }
                return response.json();
            })
            .then(async (data) => {

                let calendario = await CalcularCalendario(data, tipoNomina)

                const txtFechaInicio = document.getElementById('txtFechaInicio');
                const txtFechaFin = document.getElementById('txtFechaFin');

                const fechaInicial = calendario.fechaInicial.toISOString().split('T')[0];
                const fechaFinal = calendario.fechaFinal.toISOString().split('T')[0];

                txtFechaInicio.min = fechaInicial;
                txtFechaInicio.max = fechaFinal;
                txtFechaFin.min = fechaInicial;
                txtFechaFin.max = fechaFinal;

            })
            .catch(error => {
                console.log('Error al obtener el calendario', error);
            });
    } catch (Ex) {

    }
}

async function CalcularCalendario(calendario, tipoNomina) {

    let tipoConcepto = await ObtenerTipoConceptoPorIdConcepto(conceptoSeleccionado.value);
    let fechaInicial = new Date(calendario.fechaInicial);
    let fechaFinal = new Date(calendario.fechaFinal);

    // Obtener el último día del mes anterior
    let fechaFinalCalendarioAnterior = new Date(fechaInicial.getFullYear(), fechaInicial.getMonth(), 0);
    let fechaInicialCalendarioSiguiente = new Date(fechaInicial.getFullYear(), fechaInicial.getMonth() + 1, 1)

    switch (tipoNomina) {
        // Habilitar el elemento elegido según el tipo de concepto
        case "QC":
        case "CT":
        case "DC":
        case "QA":

            if (fechaInicial.getDate() == 1) {

                fechaInicialCalendarioSiguiente.setMonth(fechaInicialCalendarioSiguiente.getMonth() - 1)
                fechaInicialCalendarioSiguiente.setDate(16)


            } else if (fechaInicial.getDate() == 16) {

                fechaFinalCalendarioAnterior.setMonth(fechaFinalCalendarioAnterior.getMonth() + 1)
                fechaFinalCalendarioAnterior.setDate(15);

            }

            if (tipoConcepto == "3") {

                fechaInicial.setDate((fechaFinalCalendarioAnterior.getDate() - 30) - 16);

                calendario = {
                    fechaInicial: fechaInicial,
                    fechaFinal: fechaFinal
                }

            } else if (tipoConcepto == "4") {

                fechaInicial.setDate((fechaFinalCalendarioAnterior.getDate() - 30) - 16);
                fechaFinal.setDate((fechaInicialCalendarioSiguiente.getDate() + 30) - 16);


                calendario = {
                    fechaInicial: fechaInicial,
                    fechaFinal: fechaFinal
                }

            } else if (tipoConcepto == "5") {

                fechaFinal.setDate((fechaInicialCalendarioSiguiente.getDate() + 30) - 16);

                calendario = {
                    fechaInicial: fechaInicial,
                    fechaFinal: fechaFinal
                }

            }

            return calendario
            break;
        case "MS":

            if (tipoConcepto == "3") {

                fechaInicial.setMonth(fechaInicial.getMonth() - 1)

                calendario = {
                    fechaInicial: fechaInicial,
                    fechaFinal: fechaFinal
                }

            } else if (tipoConcepto == "4") {

                fechaInicial.setMonth(fechaInicial.getMonth() - 1);
                fechaFinal.setMonth(fechaFinal.getMonth() + 1);


                calendario = {
                    fechaInicial: fechaInicial,
                    fechaFinal: fechaFinal
                }

            } else if (tipoConcepto == "5") {

                fechaFinal.setMonth(fechaFinal.getMonth() + 1);

                calendario = {
                    fechaInicial: fechaInicial,
                    fechaFinal: fechaFinal
                }

            }

            return calendario;
            break;
        case "SM":

            if (fechaInicial.getDate() == 1) {

                fechaInicialCalendarioSiguiente.setMonth(fechaInicialCalendarioSiguiente.getMonth() - 1)
                fechaInicialCalendarioSiguiente.setDate(16)


            } else if (fechaInicial.getDate() == 16) {

                fechaFinalCalendarioAnterior.setMonth(fechaFinalCalendarioAnterior.getMonth() + 1)
                fechaFinalCalendarioAnterior.setDate(15);

            }

            if (tipoConcepto == "3") {

                fechaInicial.setDate((fechaFinalCalendarioAnterior.getDate() - 30) - 16);

                calendario = {
                    fechaInicial: fechaInicial,
                    fechaFinal: fechaFinal
                }

            } else if (tipoConcepto == "4") {

                fechaInicial.setDate((fechaFinalCalendarioAnterior.getDate() - 30) - 16);
                fechaFinal.setDate((fechaInicialCalendarioSiguiente.getDate() + 30) - 16);


                calendario = {
                    fechaInicial: fechaInicial,
                    fechaFinal: fechaFinal
                }

            } else if (tipoConcepto == "5") {

                fechaFinal.setDate((fechaInicialCalendarioSiguiente.getDate() + 30) - 16);

                calendario = {
                    fechaInicial: fechaInicial,
                    fechaFinal: fechaFinal
                }

            }

            return calendario;
            break;
        default:
            console.log(data.Error);
            break;
    }
}