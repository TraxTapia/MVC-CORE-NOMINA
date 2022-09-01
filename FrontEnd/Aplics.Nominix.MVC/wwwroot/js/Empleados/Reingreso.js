$(document).ready(function () {

    $('#frmReingreso').on('submit', function (e) {
        e.preventDefault();
        var objeto = {
            //Code: $('#txtDescripcionNew').val(),
            Name: $('#txtNombre').val(),
        };
        $.ajax({
            beforeSend: function () {
                $.blockUI({
                    theme: true,
                    title: 'Creando Nuevo Empleado...',
                    message: '<div class="row"><div class="col-lg-10"><br /><p><img src="/SASE/Content/assets/img/loading.gif" style="width: 35px;" /></p><p> Espere un momento por favor...</p><br /></div></div>',
                    baseZ: 10000
                });
            },
            url: '/Empleados/ReingresoEmpleado',
            type: 'POST',
            data: objeto,
            success: function (data) {
                $.unblockUI();
                if (data.Code === "200") {
                    swal(
                        'Correcto',
                        " el empleado se reingreso  correctamente.",
                        "success",
                    );
                } else {
                    swal(
                        "¡Error!",
                        "Ocurrio un error ",
                        "error");
                    return
                }
                document.location.href = '/Empleados/Index'
            },
            error: function (jqXHR, status, error) {
                $.unblockUI();

                //swal({
                //    title: "¡Cancelled!",
                //    text: 'Surgio un error inesperado. \n' + jqXHR.status + ' ' + jqXHR.statusText,
                //    icon: "error",
                //});
            }
        });
    });

    buscarEmpleadoReingreso();
})
function buscarEmpleadoReingreso() {
    txtCodEmpleadoSearch = $('#txtCodEmpleadoSearch').val();
    let _Req = {
        Code: txtCodEmpleadoSearch
    }

    $.ajax({
        beforeSend: function () {
            $.blockUI({
                theme: true,
                message: `<div class="row"><div class="col-lg-12"><div class="ibox-content"><div class="spiner-example"><div class="sk-spinner sk-spinner-three-bounce"><div class="sk-bounce1"></div><div class="sk-bounce2"></div><div class="sk-bounce3"></div></div></div></div></div></div >`,
                baseZ: 40000
            });
        },
        url: '/Empleados/ObtenerEmpleadoByCode',
        type: 'POST',
        data: _Req,
        success: function (data) {
            if (data.Code === '200') {
                document.getElementById('txtNombreReingreso').value = data.ResponseData.Name
                document.getElementById('txtApellidoPaternoReingreso').value = data.ResponseData.Name
                document.getElementById('txtApellidoMaternoReingreso').value = data.ResponseData.Name
            }
            $.unblockUI();
        },
        error: function (jqXHR, status, error) {
            $.unblockUI();
            swal(
                'warning',
                'Aviso...',
                'Surgio un error inesperado. \n' + jqXHR.status + ' ' + jqXHR.statusText,
            );
        }
    });
    //alert(txtCodEmpleadoSearch);
}
function CancelarReingreso() {
    document.getElementById('frmReingreso').reset();
    window.location.href='/Empleados/Index'
}