//Método que inserta las novedades en la base de datos.
async function InsertarNovedad(empleado) {
    try {
        //Inicializamos el view model para agregar la novedad por medio de un petición
        let idCompania = sessionStorage.getItem("idCompaniaSession");
        let idConcepto = conceptoSeleccionado.value;
        let codigoConcepto = (await ObtenerCodigoConceptoPorIdConcepto(conceptoSeleccionado.value)).codigoConcepto
        let observacion = document.getElementById("txtObservacion").value;
        let novedadAIngresar

        // Comprobamos que exista almacenamiento en Session
        if (window.sessionStorage)
            var tipoConcepto = JSON.parse(sessionStorage.getItem("tipoConceptoSession")).tipoConcepto; // Obtenemos la variable de sesión que tiene el tipo de novedad seleccionada en este momento
        else {
            throw new Error('¡Tu navegador no soporta sessionStorage!');
        }

        if (centroCostoLogeado = !empleado.idCentroCosto) {
            return console.error("No se encontró el empleado")
        }

        //Switch case de discriminación de tipo de concepto
        switch (tipoConcepto) {
            case "1":
                var valor = document.getElementById("txtValor").value;

                novedadAIngresar = {
                    idEmpleado: empleado.id,
                    tipoNomina: empleado.tipoNomina,
                    claseNomina: empleado.claseNomina,
                    codigoConcepto: codigoConcepto,
                    valor: valor,
                    observacion: observacion,
                    idConcepto: idConcepto,
                }

                return fetch('/Novedad/InsertarNovedadValor', {
                    method: 'POST', //Especificar el método
                    headers: {
                        'Content-Type': 'application/json' //Especificar el tipo de contenido del Response
                    },
                    body: JSON.stringify(novedadAIngresar)
                })
                    .then(response => {
                        if (!response.ok) {

                            throw new Error('Error en la respuesta del servidor');
                        }
                        return response.json();
                    })
                    .then(data => {
                        if (data.Error) {

                            console.error(data.Error);
                        } else {
                            AgregarNovedadValorTemporal(novedadAIngresar)
                            $('.modal').modal('hide');
                            limpiarCampos();
                        }
                    })
                    .catch(error => {

                        console.error('Error al insertar esta novedad de tipo valor:', error);
                    });
                break;

            case "2":
                var horas = document.getElementById("txtHoras").value;

                novedadAIngresar = {
                    idEmpleado: empleado.id,
                    tipoNomina: empleado.tipoNomina,
                    claseNomina: empleado.claseNomina,
                    codigoConcepto: codigoConcepto,
                    horas: horas,
                    observacion: observacion,
                    idConcepto: idConcepto,
                }

                return fetch('/Novedad/InsertarNovedadHoras', {
                    method: 'POST', //Especificar el método
                    headers: {
                        'Content-Type': 'application/json' //Especificar el tipo de contenido del Response
                    },
                    body: JSON.stringify(novedadAIngresar)
                })
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Error en la respuesta del servidor');
                        }
                        return response.json();
                    })
                    .then(data => {
                        if (data.Error) {
                            console.error(data.Error);
                        } else {

                            AgregarNovedadHorasTemporal(novedadAIngresar)
                            $('.modal').modal('hide');
                            limpiarCampos();
                        }
                    })
                    .catch(error => {
                        console.error('Error al insertar esta novedad de tipo horas:', error);
                    });
                break;

            case "3":
            case "4":
                var fechaInicial = document.getElementById("txtFechaInicio");
                var fechaFinal = document.getElementById("txtFechaFin");

                if (!fechaInicial.value || !fechaFinal.value) {
                    alert("Seleccione ambas fechas.");
                    break;
                }


                novedadAIngresar = {
                    idEmpleado: empleado.id,
                    tipoNomina: empleado.tipoNomina,
                    claseNomina: empleado.claseNomina,
                    codigoConcepto: codigoConcepto,
                    fechaInicial: fechaInicial.value,
                    fechaFinal: fechaFinal.value,
                    observacion: observacion,
                    idConcepto: idConcepto,
                }

                return fetch('/Novedad/InsertarNovedadFechas', {
                    method: 'POST', //Especificar el método

                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(novedadAIngresar)
                })
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Error en la respuesta del servidor');
                        }
                        return response.json();
                    })
                    .then(data => {
                        if (data.Error) {
                            console.error(data.Error);
                        } else {

                            AgregarNovedadFechasTemporal(novedadAIngresar)
                            $('.modal').modal('hide');
                            limpiarCampos();
                        }
                    })
                    .catch(error => {
                        console.error('Error al insertar esta novedad de tipo fechas:', error);
                    });
                break;
            default:

                console.log("Tipo de concepto no válido")
                break;
        }

    } catch (ex) {
        console.log(ex);

    }
}


//Método que retorna las novedades que hay en la base de datos de tipo Valor
function ObtenerNovedadesValor() {
    try {
        return fetch('/Novedad/ObtenerNovedadesValor')
            .then(response => {
                if (!response.ok) {
                }
                return response.json()
            })
            .then(data => {
                if (data.error) {
                    console.log(data.error)
                } else {
                    var NovedadesValor = JSON.parse(JSON.stringify(data))

                    NovedadesValor.forEach(novedad => {
                        console.log(novedad.idEmpleado)
                    })

                    return NovedadesValor

                }
            })

    } catch (ex) {
        console.log(ex)
    }

}


//Método que retorna las novedades que hay en la base de datos de tipo Valor
function ObtenerNovedadesHoras() {
    try {
        return fetch('/Novedad/ObtenerNovedadesHoras')
            .then(response => {
                if (!response.ok) {
                }
                return response.json()
            })
            .then(data => {
                if (data.error) {
                    console.log(data.error)
                } else {
                    var NovedadesHoras = JSON.parse(JSON.stringify(data))

                    NovedadesHoras.forEach(novedad => {
                        console.log(novedad.idEmpleado)
                    })

                    return NovedadesHoras

                }
            })

    } catch (ex) {
        console.log(ex)
    }

}


//Método que retorna las novedades que hay en la base de datos de tipo Valor
function ObtenerNovedadesFechas() {
    try {
        return fetch('/Novedad/ObtenerNovedadesFechas')
            .then(response => {
                if (!response.ok) {
                }
                return response.json()
            })
            .then(data => {
                if (data.error) {
                    console.log(data.error)
                } else {
                    var NovedadesFechas = JSON.parse(JSON.stringify(data))

                    NovedadesFechas.forEach(novedad => {
                        console.log(novedad.idEmpleado)
                    })

                    return NovedadesFechas

                }
            })

    } catch (ex) {
        console.log(ex)
    }

}


//Método que elimina las novedades en la base de datos, se ejecuta en este archivo, en el método que crea el grid y el botón de eliminar (AgregarNovedadAlGrid)
async function EliminarNovedad(novedad) {

    try {

        await ObtenerTipoConceptoPorIdConcepto(novedad.idConcepto)
            .then(data => {
                tipoConcepto = data
            })

        //Switch case de discriminación de tipo de concepto
        switch (tipoConcepto) {

            case "1":
                return fetch('/Novedad/EliminarNovedadValor?idNovedad=' + novedad.idNovedad, {
                    method: 'DELETE', //Especificar el método
                    headers: {
                        'Content-Type': 'application/json' //Especificar el tipo de contenido del Response
                    },
                })
                    .then(response => {
                        if (!response.ok) {
                        }
                        return response.json();
                    })
                    .then(data => {
                        if (data.Error) {
                            console.error(data.Error);
                        } else {

                            return data;

                        }
                    })
                    .catch(error => {
                        console.error('Error al eliminar esta novedad de tipo valor:', error);
                    });
                break;

            case "2":
                return fetch('/Novedad/EliminarNovedadHoras?idNovedad=' + novedad.idNovedad, {

                    method: 'DELETE', //Especificar el método
                    headers: {
                        'Content-Type': 'application/json' //Especificar el tipo de contenido del Response
                    },
                })
                    .then(response => {
                        if (!response.ok) {
                        }
                        return response.json();
                    })
                    .then(data => {
                        if (data.Error) {
                            console.error(data.Error);
                        } else {

                            return data

                        }
                    })
                    .catch(error => {
                        console.error('Error al eliminar esta novedad de tipo horas:', error);
                    });
                break;

            case "3":
            case "4":
                return fetch('/Novedad/EliminarNovedadFechas?idNovedad=' + novedad.idNovedad, {
                    method: 'DELETE', //Especificar el método
                    headers: {
                        'Content-Type': 'application/json' //Especificar el tipo de contenido del Response
                    },
                })
                    .then(response => {
                        if (!response.ok) {
                        }
                        return response.json();
                    })
                    .then(data => {
                        if (data.Error) {
                            console.error(data.Error);
                        } else {

                            return data

                        }
                    })
                    .catch(error => {
                        console.error('Error al eliminar esta novedad de tipo fechas:', error);
                    });
                break;
            default:
                console.log("Tipo de concepto no válido")
                break;
        }

    } catch (ex) {
        console.log(ex)
    }
}


function ObtenerIdUltimaNovedad() {
    try {
        return fetch('/Novedad/ObtenerIdUltimaNovedad')
            .then(response => {
                if (!response.ok) {
                }
                return response.json()
            })
            .then(data => {
                if (data.error) {
                    console.log(data.error)
                } else {

                    return data

                }
            })

    } catch (ex) {
        console.log(ex)
    }
}
