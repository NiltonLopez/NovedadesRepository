
let novedadesValorRecientes = [];
let novedadesHorasRecientes = [];
let novedadesFechasRecientes = [];

// Función para guardar los datos en localStorage
function guardarDatosEnLocalStorage() {
    localStorage.setItem('novedadesValor', JSON.stringify(novedadesValorRecientes));
    localStorage.setItem('novedadesHoras', JSON.stringify(novedadesHorasRecientes));
    localStorage.setItem('novedadesFechas', JSON.stringify(novedadesFechasRecientes));
}

// Función para cargar los datos desde localStorage
function cargarDatosDesdeLocalStorage() {
    if (localStorage.getItem('novedadesValor')) {
        novedadesValorRecientes = JSON.parse(localStorage.getItem('novedadesValor'));
        LlenarGridNovedadesValor(novedadesValorRecientes);
    }
    if (localStorage.getItem('novedadesHoras')) {
        novedadesHorasRecientes = JSON.parse(localStorage.getItem('novedadesHoras'));
        LlenarGridNovedadesHoras(novedadesHorasRecientes);
    }
    if (localStorage.getItem('novedadesFechas')) {
        novedadesFechasRecientes = JSON.parse(localStorage.getItem('novedadesFechas'));
        LlenarGridNovedadesFechas(novedadesFechasRecientes);
    }
}
function eliminarNovedadDeLocalStorage(novedad) {
    // Filtrar los arrays para eliminar el elemento específico
    novedadesValorRecientes = novedadesValorRecientes.filter(item => item.idNovedad !== novedad.idNovedad);
    novedadesHorasRecientes = novedadesHorasRecientes.filter(item => item.idNovedad !== novedad.idNovedad);
    novedadesFechasRecientes = novedadesFechasRecientes.filter(item => item.idNovedad !== novedad.idNovedad);

    // Guardar los cambios actualizados en localStorage
    guardarDatosEnLocalStorage();
}
// Función para limpiar los datos de localStorage
function limpiarDatosDeLocalStorage() {
    localStorage.removeItem('novedadesValor');
    localStorage.removeItem('novedadesHoras');
    localStorage.removeItem('novedadesFechas');
     novedadesValorRecientes = [];
     novedadesHorasRecientes = [];
     novedadesFechasRecientes = [];
}

// Cargar datos cuando la página se carga
window.onload = function () {
    // Cargar datos solo si no fueron confirmados previamente
    cargarDatosDesdeLocalStorage();
};
// Guardar automáticamente los datos cuando se intenta salir de la página o se recarga
window.addEventListener('beforeunload', function () {
    guardarDatosEnLocalStorage();
});
