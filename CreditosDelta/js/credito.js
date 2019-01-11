var tabla, id_credito;

function addRowDt(data)
{
    tabla = $("#tbl_content").DataTable({
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
            null,
            null,
            null,
            null,
            null,
        ],
        bDestroy: true
    });

    tabla.fnClearTable();

    for (var i = 0 ; i < data.length ; i++)
    {
        tabla.fnAddData([
            data[i].IdCredito,
            data[i].FechaInicio,
            data[i].CveCte,
            data[i].SolicitudCte,
            parseFloat(data[i].MontoPago).toFixed(2),
            parseFloat(data[i].PrecioPedido).toFixed(2),
            getStatusCobranza(data[i].StatusCobranza),
            data[i].Motivo,
            getAutorizado(data[i].Autorizado),
            getStatusVend(data[i].StatusVendedor),
            ((data[i].StatusCobranza != "1") ? 'NO AUTORIZADO' : data[i].FechaAceptado),
            getBoton(data[i].StatusCobranza)
        ]);
    }
}

function sendDataAjax()
{
    $.ajax({
        type: "POST",
        url: "Cobranza.aspx/ListarCreditos",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            console.log(data.d);
            addRowDt(data.d);
        }
    });
}

//Evento clik para actualizar

$(document).on('click', '.btn-edit', function (e) {
    e.preventDefault();
    id_credito = $(this).parent().parent().children().first().text();
    llenaFormAjax(id_credito);
});

function llenaFormAjax(id_credito)
{
    var obj = JSON.stringify({ id_credito: id_credito });
    $.ajax({
        type: "POST",
        url: "Cobranza.aspx/datosCredito",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (lista) {
            fillModalData(id_credito, lista.d)
        }
    });
}

//Cargar datos en el modal
function fillModalData(id,lista)
{
    $("#txtIdCredito").val(id);
    $("#txtCveCte").val(lista[0].CveCte);
    $("#listStatusCobranza").val(lista[0].StatusCobranza);
    $("#txtMotivo").val(lista[0].Motivo);
    $("#listAutoriza").val(lista[0].Autorizado);
    $("#listStatusVend").val(lista[0].StatusVendedor);

}

//enviar los datos al servidor
$("#btnGuardar").click(function (e) {
    e.preventDefault();
    updateDataAjax();
});


function updateDataAjax() {

    var obj = JSON.stringify({ id_credito: id_credito, statusCob: $("#listStatusCobranza").val(), motivo: $("#txtMotivo").val(), qAut: $("#listAutoriza").val(), statusVend: $("#listStatusVend").val() });

    $.ajax({
        type: "POST",
        url: "Cobranza.aspx/ActualizarCredito",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if(response.d)
            {
                alert("Registo actualizado de manera correcta");
                sendDataAjax();
                resetDatos()
            }
            else alert("No se pudo actualizar");
        }
    });
}

function getStatusCobranza(valor)
{
    switch(valor)
    {
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

function getAutorizado(valor)
{
    switch (valor) {
        case 0:
            return '<span style="color: red">NO ASIGNADO</span>';
        case 1:
            return '<span style="color: green">C.P. Gereardo</span>';
        case 2:
            return '<span style="color: green">Holger</span>';
        case 3:
            return '<span style="color: green">Sr. Martin</span>';
    }
}

function getStatusVend(valor)
{
    switch (valor) {
        case 0:
            return '<span style="color: red">NO ASIGNADO</span>';
        case 1:
            return '<span style="color: green">PAGADO</span>';
        case 2:
            return '<span style="color: brown">PENDIENTE</span>';
    }
}

function getBoton(valor)
{
    switch (valor) {
        case 0:
            return '<button type="button" class="btn btn-danger btn-edit" data-target="#formModal" data-toggle="modal" id="btnMod">Modificar</button>';
            break;
        case 1:
            return '<button type="button" class="btn btn-success btn-edit" data-target="#formModal" data-toggle="modal" id="btnMod">Modificar</button>';
            break;
        case 2:
            return '<button type="button" class="btn btn-danger btn-edit" data-target="#formModal" data-toggle="modal" id="btnMod">Modificar</button>';
            break;
        case 3:
            return '<button type="button" class="btn btn-danger btn-edit" data-target="#formModal" data-toggle="modal" id="btnMod">Modificar</button>';
            break;
    }
}

function resetDatos()
{
    $('#listStatusCobranza').val(0);
    $('#txtMotivo').val("");
    $('#listAutoriza').val(0);
    $('#listStatusVend').val(0);
}

//Llamando la funcion de ajax al cargar el documento
sendDataAjax();