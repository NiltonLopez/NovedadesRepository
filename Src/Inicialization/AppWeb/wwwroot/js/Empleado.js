function BuscarEmpleadoPorIDyCentroCostoYCompania(idEmpleado) {
    try {
        return fetch(`/Empleado/BuscarEmpleadoPorIDyCentroCostoYCompania?idEmpleado=${encodeURIComponent(idEmpleado)}`, {
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
            .then(data => {
                //
                return data
            })
            .catch(error => {
                console.log('Error al buscar los empleados', error);
            });
    } catch (ex) {
        console.log('Error al buscar los empleados', ex);
    }
}


function ObtenerEmpleadoPorId(idEmpleado) {
    try {
        return fetch(`/Empleado/ObtenerEmpleadoPorId?idEmpleado=${encodeURIComponent(idEmpleado)}`, {
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
            .then(data => {
                //
                return data
            })
            .catch(error => {
                console.log('Error al buscar los empleados', error);
            });
    } catch (ex) {
        console.log('Error al buscar los empleados', ex);
    }
}

