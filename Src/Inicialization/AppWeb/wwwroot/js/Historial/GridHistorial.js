document.addEventListener('DOMContentLoaded', async function () {
    const NovedadesValor = await ObtenerNovedadesValor();
    if (NovedadesValor != null) {
        LlenarGridHistorialValor(NovedadesValor);
    }
    const NovedadesHoras = await ObtenerNovedadesHoras();
    if (NovedadesHoras != null) {
        LlnearGridHistorialHoras(NovedadesHoras);

    }

    const NovedadesFechas = await ObtenerNovedadesFechas();
    if (NovedadesFechas != null) {
        LlenarGridHistorialFechas(NovedadesFechas);
    }

});

function LlenarGridHistorialValor(NovedadesValor) {
    try {
        // Capturamos todos los elementos necesarios para la función
        dvMensaje = document.getElementById("dvMensaje");
        grid = document.getElementById("gridHistorialValor");
        tbod = grid.querySelector('tbody'); // Cambiado de 'tbod' a 'tbody'

        // Limpiamos el mensaje y el grid
        dvMensaje.setAttribute("hidden", true);
        dvMensaje.innerText = "";
        tbod.innerText = '';

        // Llenar la tabla con los datos de las novedades
        NovedadesValor.forEach(novedad => {
            var row = tbod.insertRow();
            row.insertCell().textContent = novedad.idEmpleado;
            row.insertCell().textContent = novedad.nombreEmpleado;
            row.insertCell().textContent = novedad.idConcepto;
            row.insertCell().textContent = novedad.descripcionConcepto;
            row.insertCell().textContent = novedad.valor;
            row.insertCell().textContent = novedad.observacion;

            // Crea el botón que borra la fila
            var button = document.createElement("button");
            button.textContent = "X";
            button.className = "bg-g fw-bold mx-2";

            row.insertCell().appendChild(button);

            button.onclick = function () {
                // Eliminar de la base de datos
                EliminarNovedad(novedad)
                    .then(data => {
                        if (data) {
                            // Eliminar la fila al hacer clic en el botón
                            var filaPadre = this.parentNode.parentNode;
                            filaPadre.parentNode.removeChild(filaPadre);
                        }
                    })
                    .catch(error => {
                        console.error('Error al eliminar esta novedad de tipo valor: ', error);
                    });
            }
        });
    } catch (ex) {
        console.log(ex);
    }
}

//GRID PARAR MOSTRAR HISTORIAL DE NOVEDADES HORAS 
function LlnearGridHistorialHoras(NovedadesHoras) {
    try {
        // Capturamos todos los elementos necesarios para la función
        dvMensaje = document.getElementById("dvMensaje");
        grid = document.getElementById("gridHistorialHoras");
        tbod = grid.querySelector('tbody');

        // Limpiamos el mensaje y el grid
        dvMensaje.setAttribute("hidden", true);
        dvMensaje.innerText = "";
        tbod.innerText = '';

        // Llenar la tabla con los datos de las novedades
        NovedadesHoras.forEach(novedad => {
            var row = tbod.insertRow();
            row.insertCell().textContent = novedad.idEmpleado;
            row.insertCell().textContent = novedad.nombreEmpleado;
            row.insertCell().textContent = novedad.idConcepto;
            row.insertCell().textContent = novedad.descripcionConcepto;
            row.insertCell().textContent = novedad.horas;
            row.insertCell().textContent = novedad.observacion;

            // Crea el botón que borra la fila
            var button = document.createElement("button");
            button.textContent = "X";
            button.className = "bg-g fw-bold mx-2";

            row.insertCell().appendChild(button);

            button.onclick = function () {
                // Eliminar de la base de datos
                EliminarNovedad(novedad)
                    .then(data => {
                        if (data) {
                            // Eliminar la fila al hacer clic en el botón
                            var filaPadre = this.parentNode.parentNode;
                            filaPadre.parentNode.removeChild(filaPadre);
                        }
                    })
                    .catch(error => {
                        console.error('Error al eliminar esta novedad de tipo valor: ', error);
                    });
            }
        });
    } catch (ex) {
        console.log(ex);
    }


}

// GRID PARA MOSTRAR HISTORIAL NOVEDADES FECHAS
function LlenarGridHistorialFechas(NovedadesFechas) {
    try {
        //Capturamos todos los elementos necesarios para la función
        dvMensaje = document.getElementById("dvMensaje");
        grid = document.getElementById("gridHistorialFechas");
        tbod = grid.querySelector('tbody');

        //Limpiamos el mensaje y el grid
        dvMensaje.setAttribute("hidden", true);
        dvMensaje.innerText = "";
        tbod.innerText = '';

        // Llenar la tabla con los datos de las novedades
        NovedadesFechas.forEach(novedad => {
            var row = tbod.insertRow();
            row.insertCell().textContent = novedad.idEmpleado;
            row.insertCell().textContent = novedad.nombreEmpleado;
            row.insertCell().textContent = novedad.codigoConcepto;
            row.insertCell().textContent = novedad.descripcionConcepto;
            var fechaInicio = new Date(novedad.fechaInicial);
            row.insertCell().textContent = fechaInicio.toLocaleDateString();
            var fechaFin = new Date(novedad.fechaFinal);
            row.insertCell().textContent = fechaFin.toLocaleDateString();
            row.insertCell().textContent = novedad.observacion;

            //Crea el botón que borra la fila
            var button = document.createElement("button");
            button.textContent = "X";
            button.className = "bg-g fw-bold mx-2";


            row.insertCell().appendChild(button);

            button.onclick = function () {


                //Eliminar de la base de datos
                EliminarNovedad(novedad)
                    .then(data => {
                        if (data) {
                            // Eliminar la fila al hacer clic en el botón
                            var filaPadre = this.parentNode.parentNode;
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