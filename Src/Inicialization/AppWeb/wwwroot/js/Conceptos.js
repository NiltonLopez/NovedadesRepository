function ObtenerConceptoPorId(idConcepto) {
    return fetch('/Concepto/ObtenerConceptoPorId?idConcepto=' + idConcepto)
        .then(response => {
            if (!response.ok) {
                throw new Error('Error en la solicitud de obtener el tipo de concepto.');
            }
            return response.json(); // Parsear la respuesta como JSON
        })
        .then(data => {
            if (data.Error) {
                console.error(data.Error);
            } else {

                return data

            }
        })
        .catch(error => {
            console.error('Error al obtener conceptos:', error);
        });
}


function ObtenerTipoConceptoPorIdConcepto(idConcepto) {
    return fetch('/Concepto/ObtenerTipoConceptoPorId?idConcepto=' + idConcepto)
        .then(response => {
            if (!response.ok) {
                throw new Error('Error en la solicitud de obtener el tipo de concepto.');
            }
            return response.json(); // Parsear la respuesta como JSON
        })
        .then(data => {
            if (data.Error) {
                console.error(data.Error);
            } else {
                sessionStorage.setItem("tipoConceptoSession", JSON.stringify(data));
                return TipoConceptoSeleccionado = data.tipoConcepto;
            }
        })
        .catch(error => {
            console.error('Error al obtener conceptos:', error);
        });
}


async function ObtenerCodigoConceptoPorIdConcepto(idConcepto) {
    return await fetch('/Concepto/ObtenerCodigoConceptoPorIdConcepto?id=' + idConcepto)
        .then(response => {
            if (!response.ok) {
                throw new Error('Error en la solicitud de obtener el tipo de concepto.');
            }
            return response.json(); // Parsear la respuesta como JSON
        })
        .then(data => {
            if (data.Error) {
                console.error(data.Error);
            } else {
                return data

            }
        })
        .catch(error => {
            console.error('Error al obtener conceptos:', error);
        });
}
