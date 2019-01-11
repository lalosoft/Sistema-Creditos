var tabla;

function addRowDt1(data) {
    tabla = $("#tbl_creditos").DataTable({
        "aaSorting": [[0, 'asc']],
        "bSort": false,
        "aoColumns": [
            null,
            null,
            null,
            null,
            null,
            null,
            null,
        ],
        bDestroy: true
    });

    tabla.fnClearTable();

    for (var i = 0 ; i < data.length ; i++) {
        tabla.fnAddData([
            data[i].IdCredito,
            data[i].FechaInicio,
            data[i].CveCte,
            data[i].SolicitudCte,
            parseFloat(data[i].MontoPago).toFixed(2),
            parseFloat(data[i].PrecioPedido).toFixed(2),
            getStatusCobranza(data[i].StatusCobranza)
        ]);
    }
}

function sendDataAjaxRecep() {
    $.ajax({
        type: "POST",
        url: "Recepcion.aspx/CreditosRecepcion",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            addRowDt1(data.d);
        }
    });
}

function getSolCte(valor) {
    switch (valor) {
        case 0:
            return '<span>NO ASIGNADO</span>';
            break;
        case 1:
            return '<span>Credito</span>';
            break;
        case 2:
            return '<span>Activacion Cuenta</span>';
            break;
    }
}

function getStatusCobranza(valor) {
    switch (valor) {
        case 0:
            return '<span style="color: red">NO ASIGNADO</span>';
        case 1:
            return '<span style="color: green">ACEPTADO</span>';
        case 2:
            return '<span style="color: brown">PENDIENTE</span>';
        case 3:
            return '<span style="color: red">NO ACEPTADO</span>';
    }
}

sendDataAjaxRecep();