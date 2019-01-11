var valor = 'si llego';

//enviar los datos al servidor
$("#btnSalir").click(function (e) {
    e.preventDefault();
    window.location.href = "Logout.aspx";
});

/*function salirAjax()
{
    var obj = JSON.stringify({ variable: valor });

    $.ajax({
        type: "POST",
        url: "Logout.aspx/salirSistema",
        data: obj,
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + "\n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (response) {
            if (response) {
                console.log(valor);
                window.location.href = "Inicio.aspx";
            }
            else alert("No se pudo actualizar");
        }
    });
}*/