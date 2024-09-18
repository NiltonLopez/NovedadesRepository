//Método que inserta las novedades de tipo valor en la tabla de la página
function LlenarGridNovedadesValor(novedadesValorAMostrar) {
    try {

        //Capturamos todos los elementos necesarios para la función
        dvMensaje = document.getElementById("dvMensaje");
        grid = document.getElementById("gridNovedadesValor");
        tbody = grid.querySelector('tbody');

        //Limpiamos el mensaje y el grid
        dvMensaje.setAttribute("hidden", true);
        dvMensaje.innerText = "";
        tbody.innerText = '';

        // Llenar la tabla con los datos de las novedades
        novedadesValorAMostrar.forEach(novedad => {
            var row = tbody.insertRow();
            row.insertCell().textContent = novedad.idEmpleado;
            row.insertCell().textContent = novedad.nombreEmpleado;
            row.insertCell().textContent = novedad.codigoConcepto;
            row.insertCell().textContent = novedad.descripcionConcepto;
            row.insertCell().textContent = novedad.valor;
            row.insertCell().textContent = novedad.observacion;

            //Crea el botón que borra la fila
            var button = document.createElement("button");
            button.textContent = "X";
            button.className = "bg-r fw-bold mx-2";


            row.insertCell().appendChild(button);

            button.onclick = function () {

                //Eliminar de la base de datos
                EliminarNovedad(novedad)
                    .then(data => {
                        if (data) {
                            // Eliminar la fila al hacer clic en el botón
                            var filaPadre = this.parentNode.parentNode;
                            eliminarNovedadDeLocalStorage(novedad)
                            filaPadre.parentNode.removeChild(filaPadre);
                        }
                    })
                    .catch(error => {
                        console.error('Error al eliminar esta novedad de tipo valor: ', error);
                    })

            }
        })

    } catch (ex) {
        console.log(ex);
    }
}


//Método que inserta las novedades en la tabla de la página
function LlenarGridNovedadesHoras(novedadesHorasAMostrar) {
    try {

        //Capturamos todos los elementos necesarios para la función
        dvMensaje = document.getElementById("dvMensaje");
        grid = document.getElementById("gridNovedadesHoras");
        tbody = grid.querySelector('tbody');

        //Limpiamos el mensaje y el grid
        dvMensaje.setAttribute("hidden", true);
        dvMensaje.innerText = "";
        tbody.innerText = '';

        // Llenar la tabla con los datos de las novedades
        novedadesHorasAMostrar.forEach(novedad => {
            var row = tbody.insertRow();
            row.insertCell().textContent = novedad.idEmpleado;
            row.insertCell().textContent = novedad.nombreEmpleado;
            row.insertCell().textContent = novedad.codigoConcepto;
            row.insertCell().textContent = novedad.descripcionConcepto;
            row.insertCell().textContent = novedad.horas;
            row.insertCell().textContent = novedad.observacion;

            //Crea el botón que borra la fila
            var button = document.createElement("button");
            button.textContent = "X";
            button.className = "bg-r fw-bold mx-2";


            row.insertCell().appendChild(button);

            button.onclick = function () {
                //Eliminar de la base de datos
                EliminarNovedad(novedad)
                    .then(data => {
                        if (data) {
                            var filaPadre = this.parentNode.parentNode;
                            eliminarNovedadDeLocalStorage(novedad)
                            filaPadre.parentNode.removeChild(filaPadre);
                        }
                    })
                    .catch(error => {
                        console.error('Error al eliminar esta novedad de tipo horas: ', error);
                    })
            }
        })

    } catch (ex) {
        console.log(ex);
    }
}


//Método que inserta las novedades en la tabla de la página
function LlenarGridNovedadesFechas(novedadesFechasAMostrar) {
    try {
        //Capturamos todos los elementos necesarios para la función
        dvMensaje = document.getElementById("dvMensaje");
        grid = document.getElementById("gridNovedadesFechas");
        tbody = grid.querySelector('tbody');

        //Limpiamos el mensaje y el grid
        dvMensaje.setAttribute("hidden", true);
        dvMensaje.innerText = "";
        tbody.innerText = '';

        // Llenar la tabla con los datos de las novedades
        novedadesFechasAMostrar.forEach(novedad => {
            var row = tbody.insertRow();
            row.insertCell().textContent = novedad.idEmpleado;
            row.insertCell().textContent = novedad.nombreEmpleado;
            row.insertCell().textContent = novedad.codigoConcepto;
            row.insertCell().textContent = novedad.descripcionConcepto;
            var fechaInicio = new Date(novedad.fechaInicial);
            row.insertCell().textContent = new Date(fechaInicio.getTime() + Math.abs(fechaInicio.getTimezoneOffset() * 60000)).toLocaleDateString();
            var fechaFin = new Date(novedad.fechaFinal);
            row.insertCell().textContent = new Date(fechaFin.getTime() + Math.abs(fechaFin.getTimezoneOffset() * 60000)).toLocaleDateString();
            row.insertCell().textContent = novedad.observacion;

            //Crea el botón que borra la fila
            var button = document.createElement("button");
            button.textContent = "X";
            button.className = "bg-r fw-bold mx-2";


            row.insertCell().appendChild(button);

            button.onclick = function () {


                //Eliminar de la base de datos
                EliminarNovedad(novedad)
                    .then(data => {
                        if (data) {
                            // Eliminar la fila al hacer clic en el botón
                            var filaPadre = this.parentNode.parentNode;
                            eliminarNovedadDeLocalStorage(novedad)
                            filaPadre.parentNode.removeChild(filaPadre);
                        }
                    })
                    .catch(error => {
                        console.error('Error al eliminar esta novedad de tipo fechas: ', error);
                    })
            }
        })

    } catch (ex) {
        console.log(ex);
    }
}


async function AgregarNovedadValorTemporal(novedad) {

    idNovedad = await ObtenerIdUltimaNovedad()

    novedadTemporal = {

        idNovedad: idNovedad,
        idConcepto: novedad.idConcepto,
        idEmpleado: novedad.idEmpleado,
        nombreEmpleado: "",
        codigoConcepto: "",
        descripcionConcepto: "",
        valor: novedad.valor || "",  // Asegúrate que los campos tengan datos antes de enviarlos
        observacion: novedad.observacion || "",
    };

    await ObtenerEmpleadoPorId(novedad.idEmpleado)
        .then(data => {
            novedadTemporal.nombreEmpleado = data.nombre + " " + data.apellido;
        })

    await ObtenerConceptoPorId(novedad.idConcepto)
        .then(data => {
            novedadTemporal.codigoConcepto = data.codigoConcepto;
            novedadTemporal.descripcionConcepto = data.descripcion;
        })

    novedadesValorRecientes.push(novedadTemporal);
    LlenarGridNovedadesValor(novedadesValorRecientes);
}


async function AgregarNovedadHorasTemporal(novedad) {

    idNovedad = await ObtenerIdUltimaNovedad()

    novedadTemporal = {

        idNovedad: idNovedad,
        idConcepto: novedad.idConcepto,
        idEmpleado: novedad.idEmpleado,
        nombreEmpleado: "",
        codigoConcepto: "",
        descripcionConcepto: "",
        horas: novedad.horas || "",  // Asegúrate que los campos tengan datos antes de enviarlos
        observacion: novedad.observacion || "",
    };

    await ObtenerEmpleadoPorId(novedad.idEmpleado)
        .then(data => {
            novedadTemporal.nombreEmpleado = data.nombre + " " + data.apellido;
        })

    await ObtenerConceptoPorId(novedad.idConcepto)
        .then(data => {
            novedadTemporal.codigoConcepto = data.codigoConcepto;
            novedadTemporal.descripcionConcepto = data.descripcion;
        })

    novedadesHorasRecientes.push(novedadTemporal);
    LlenarGridNovedadesHoras(novedadesHorasRecientes);
}

async function AgregarNovedadFechasTemporal(novedad) {
    idNovedad = await ObtenerIdUltimaNovedad()

    novedadTemporal = {

        idNovedad: idNovedad,
        idConcepto: novedad.idConcepto,
        idEmpleado: novedad.idEmpleado,
        nombreEmpleado: "",
        codigoConcepto: "",
        descripcionConcepto: "",
        fechaInicial: novedad.fechaInicial || "",  // Asegúrate que los campos tengan datos antes de enviarlos
        fechaFinal: novedad.fechaFinal || "",  // Asegúrate que los campos tengan datos antes de enviarlos
        observacion: novedad.observacion || "",
    };

    await ObtenerEmpleadoPorId(novedad.idEmpleado)
        .then(data => {
            novedadTemporal.nombreEmpleado = data.nombre + " " + data.apellido;
        })

    await ObtenerConceptoPorId(novedad.idConcepto)
        .then(data => {
            novedadTemporal.codigoConcepto = data.codigoConcepto;
            novedadTemporal.descripcionConcepto = data.descripcion;
        })

    novedadesFechasRecientes.push(novedadTemporal);
    LlenarGridNovedadesFechas(novedadesFechasRecientes);
}

