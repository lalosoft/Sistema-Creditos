function areaTrabAjax() {
    $.ajax({
        type: "POST",
        url: "Inicio.aspx/getArea",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (area) {
            console.log(area.d);
            direcciona(area.d);
        }
    });
}

function direcciona(area_job)
{
    var valor = area_job[0].Area_Empleado;
    console.log(valor);

    switch(valor)
    {
        case 2:
            document.getElementById("cobr").href = "#";
            //console.log('soy recepcion');
            break;
        case 3:
            document.getElementById("recep").href = "#";
            //console.log('soy cobranza');
            break

        case 5:
            document.getElementById("recep").href = "#";
            //console.log('soy cobranza');
            break
    }
}
areaTrabAjax();