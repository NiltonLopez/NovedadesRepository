var btnGuardarNovedad = document.getElementById('btnGuardarNovedad');
var conceptoSeleccionado = document.getElementById("conceptos");
var txtDocumento = document.getElementById("txtDocumento");
const listaCedulas = document.getElementById('listaCedulas');
const avisoReporte = document.getElementById('AvisoReporte');
const nombreEmpleado = document.getElementById('nombreEmpleado');
const btnAgregarNovedad = document.getElementById('btnAgregarNovedad');
const btnCerrarNovedad = document.getElementById('btnCerrarNovedad');
const modal = document.getElementById('alertaModal');


// Cuando se presione click sobre el botón Generar Novedad:
btnAgregarNovedad.addEventListener('click', function () {
    //Se muestre el formulario modal
    const modalNovedades = new bootstrap.Modal(document.getElementById('modalNovedad'), {});
    modalNovedades.show();

    //Escondemos todos los elementos
    dvHoras.setAttribute("hidden", true);
    dvValor.setAttribute("hidden", true);
    dvFechas.setAttribute("hidden", true);
});


//Cuando el concepto seleccionado dentro del formulario modal cambie:
conceptoSeleccionado.addEventListener('change', function () {

    var IdOpcionSeleccionada = conceptoSeleccionado.value;

    try {
        //Cambie las entradas dependiendo del tipo de concepto.
        CambiarModalTipoConcepto(IdOpcionSeleccionada);
    } catch (ex) {

        console.log(ex);
    }

})

//Cuando el texto del campo de cédula dentro del formulario modal cambie:
txtDocumento.addEventListener('input', function () {
    var idDigitado = txtDocumento.value;

    BuscarEmpleadoPorIDyCentroCostoYCompania(idDigitado)
        .then(data => {
            listaCedulas.innerHTML = '';
            data.forEach(option => {
                const li = document.createElement('li');
                li.textContent = option.id + " - " + option.nombre + " " + option.apellido;
                li.onclick = () => {
                    txtDocumento.value = option.id;
                    listaCedulas.style.display = 'none'; // Oculta la lista al seleccionar una opción
                    avisoReporte.style.display = 'block' // Enseña el aviso del nombre de la persona a reportar la novedad
                    nombreEmpleado.textContent = option.nombre + " " + option.apellido
                };
                listaCedulas.appendChild(li);
            });
            listaCedulas.style.display = data.length > 0 ? 'block' : 'none';
            avisoReporte.style.display = data.length > 0 ? 'block' : 'none'; //En caso de que la promesa tenga una respuesta mayor a 0, muestre la lista y el aviso, de lo contrario ocultelo.


        })
        .catch(ex => {
            console.error('Error al buscar empleado:', ex); // Manejo de errores de la promesa
        });
});


// Cuando se presiona click en la x del modal de alerta
const close = document.querySelector('.close-btn');
close.addEventListener('click', function () {
    modal.style.display = 'none'; // Oculta el modal
    if (overlay) {
        overlay.style.display = 'none'; // Oculta el overlay si existe
    }
});
// Cuando se presione click sobre el botón Guardar Novedad del del formulario modal:
btnGuardarNovedad.addEventListener('click', async function () {
    try {

        let idEmpleado = document.getElementById("txtDocumento").value;

        ObtenerEmpleadoPorId(idEmpleado)
            .then(empleado => {

                if (empleado == undefined) {
                    modal.style.display = "block";
                    document.getElementById('overlay').style.display = 'block';
                    $('.modal').modal('hide');
                    limpiarModal();

                } else {
                    InsertarNovedad(empleado);

                }

                
            })


        if (window.sessionStorage)
            var tipoConcepto = JSON.parse(sessionStorage.getItem("tipoConceptoSession")).tipoConcepto; //Obtenemos la variable de sesión que tiene el tipo de novedad seleccionada en este momento
        else {
            throw new Error('Tu Browser no soporta sessionStorage!');
        }


        if (tipoConcepto == "1") {

            LlenarGridNovedadesValor(novedadesValorRecientes);
        }
        else if (tipoConcepto == "2") {
            ObtenerNovedadesHoras()
                .then(data => {
                    LlenarGridNovedadesHoras(novedadesHorasRecientes);
                })
        }
        else if (tipoConcepto == "3" || tipoConcepto == "4") {

            ObtenerNovedadesFechas()

                .then(data => {
                    LlenarGridNovedadesFechas(novedadesFechasRecientes);
                });
        }

        $('.modal').modal('hide');
    } catch (ex) {
        console.error("Error: ", ex)
    }

})

//Método que cambia los campos de inserción del del formulario modal dependiendo del concepto elegido:
async function CambiarModalTipoConcepto(idConcepto) {
    idEmpleado = document.getElementById("txtDocumento").value;
    dvHoras = document.getElementById("dvHoras");
    dvValor = document.getElementById("dvValor");
    dvFechas = document.getElementById("dvFechas");

    dvHoras.setAttribute("hidden", true);
    dvValor.setAttribute("hidden", true);
    dvFechas.setAttribute("hidden", true);


    await ObtenerTipoConceptoPorIdConcepto(idConcepto)
        .then(async (data) => {
            switch (data) {
                // Habilitar el elemento elegido según el tipo de concepto
                case "1":
                    TipoConceptoSeleccionado = data.tipoConcepto;
                    dvValor.removeAttribute("hidden");
                    break;
                case "2":
                    dvHoras.removeAttribute("hidden");
                    break;
                case "3":
                case "4":
                    ObtenerFechasCalendario(idEmpleado)
                    dvFechas.removeAttribute("hidden");

                    break;
                default:
                    console.log(data.Error);
                    break;
            }
        });


}

//Muestra mensaje de éxito luego de insertar una novedad.
function MostrarModalExito() {
    var modalExito = new bootstrap.Modal(document.getElementById('modalExito'), {});
    modalExito.show();
    setTimeout(function () {
        modalExito.hide();
    }, 3000);
}

//Limpia el formulario modal.
function limpiarModal() {
    document.getElementById("txtDocumento").value = "";
    document.querySelector("select[name='conceptos']").selectedIndex = 0;
    document.getElementById("txtObservacion").value = "";
    document.getElementById("AvisoReporte").style.display = "none";
    if (document.getElementById("txtValor")) document.getElementById("txtValor").value = "";
    if (document.getElementById("txtHoras")) document.getElementById("txtHoras").value = "";
    if (document.getElementById("txtFechaInicio")) document.getElementById("txtFechaInicio").value = "";
    if (document.getElementById("txtFechaFin")) document.getElementById("txtFechaFin").value = "";
    $('.modal').modal('hide');
}


 
//Scrip de el boton confitmar y su configuracion

document.getElementById('btnConfirmar').addEventListener('click', function (event) {
    event.preventDefault();
    document.getElementById('overlay').style.display = 'block'; 
    document.getElementById('modalConfirmacion').style.display = 'block'; // Mostrar el modal
});

document.getElementById('btnAceptar').addEventListener('click', function () {
    // Si el usuario acepta, limpiar los datos y redirigir al historial
    limpiarDatosDeLocalStorage();
    window.location.href = "Home/Historial";
});

document.getElementById('btnCancelar').addEventListener('click', function () {
    // Cerrar el modal si se cancela
    document.getElementById('overlay').style.display = 'none';
    document.getElementById('modalConfirmacion').style.display = 'none';
    console.log('Confirmación cancelada');
});
