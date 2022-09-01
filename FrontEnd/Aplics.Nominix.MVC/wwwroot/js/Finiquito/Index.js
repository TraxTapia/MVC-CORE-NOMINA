let divtitle = '';
let title = '';
let nombreEmpleado = document.getElementById('txtEmpleado');
let fFiniquito = document.getElementById('txtFFiniquito');
let selectCompania = document.getElementById('txtCompania');
let txtNomina = document.getElementById('txtTNomina');
let selectLocalidad = document.getElementById('txtLocalidad');
let txtSimulacion = document.getElementById('txtSimulacion');
let selectEstatus = document.getElementById('txtEstatus');
let txtPSimulacion = document.getElementById('txtPSimulacion');
let selectTContrato = document.getElementById('txtTContrato');
let txtIntIndem = document.getElementById('txtIntIndem');
let txtIReservado = document.getElementById('txtIReservado');
let txtNLlegar = document.getElementById('txtNLlegar');
let txtFAntiguedad = document.getElementById('txtFAntiguedad');
let txtSueldoM = document.getElementById('txtSueldoM');
let txtSueldoD = document.getElementById('txtSueldoD');

$(document).ready(function () {
    $('#btnNuevo').hide()

});
function OpenModalNuevoEmpleado(button, id) {
    if (button != undefined) {
        nombreEmpleado.disabled = false
        selectCompania.disabled = false
        selectLocalidad.disabled = false
        selectTContrato.disabled = false
        selectEstatus.disabled = false
        txtFAntiguedad.disabled = false
        txtSueldoM.disabled = false
        txtSueldoD.disabled = false
        divButtons = document.getElementById('btnNew');
        divtitle = document.getElementById('tAlta');
        title = '<h4 class="modal-title">Nuevo finiquito</h4>';      
        divtitle.innerHTML = title;
        $(id).modal({ backdrop: 'static', keyboard: false })
    }
}
function OpenModalCambioFiniquito(button,) {
    if (button != undefined) {
        $("#frmFiniquitoUpdate :input").prop('readonly', true);
        let nombreEmpleado = document.getElementById('txtEmpleadoEdit');
        let fFiniquito = document.getElementById('txtFFiniquitoEdit');
        let selectCompania = document.getElementById('txtCompaniaEdit');
        let txtTNomina = document.getElementById('txtTNominaEdit');
        let selectLocalidad = document.getElementById('txtLocalidadEdit');
        let txtSimulacion = document.getElementById('txtSimulacionEdit');
        let selectEstatus = document.getElementById('txtEstatusEdit');
        let txtPSimulacion = document.getElementById('txtPSimulacionEdit');
        let selectTContrato = document.getElementById('txtTContratoEdit');
        let txtIntIndem = document.getElementById('txtIntIndemEdit');
        let txtIReservado = document.getElementById('txtIReservadoEdit');
        let txtNLlegar = document.getElementById('txtNLlegarEdit');
        let txtFAntiguedad = document.getElementById('txtFAntiguedadEdit');
        let txtSueldoM = document.getElementById('txtSueldoMEdit');
        let txtSueldoD = document.getElementById('txtSueldoDEdit');
       
        nombreEmpleado.value = $(button).closest('tr').find('td:eq(5)').text(); 
        fFiniquito.value = $(button).closest('tr').find('td:eq(6)').text();
        selectCompania.value = "Compania";
        txtTNomina.value ="1";
        selectLocalidad.value = $(button).closest('tr').find('td:eq(14)').text();
        txtSimulacion.value = $(button).closest('tr').find('td:eq(7)').text();
        selectEstatus.value = $(button).closest('tr').find('td:eq(11)').text();
        txtPSimulacion.value = $(button).closest('tr').find('td:eq(17)').text();
        selectTContrato.value = "";
        txtIntIndem.value = "";
        txtIReservado.value = "";
        txtNLlegar.value = "";
        txtFAntiguedad.value = "";
        txtSueldoM.value = "";
        txtSueldoD.value = "";
        divtitle = document.getElementById('Tcambio');
        title = '<h4 class="modal-title">Actualizar datos</h4>';       
        divtitle.innerHTML = title;
        $('#mdlActualizarFiniquito').modal({ backdrop: 'static', keyboard: false })
    }
}
function ConsultarFiniquitos(event) {
    event.preventDefault();
    let _Req = {};
    let _Compania = document.getElementById('selectCompaniaFiltro').value;
    let _Localidad = document.getElementById('selectLocalidadFiltro').value;
    let _FecFiniquito = document.getElementById('txtFecFiniquito').value;
    let _Nombre = document.getElementById('txtNombreEmpleadoFiltro').value;
    let _NoEmpleado = document.getElementById('txtNoEmpleadoFiltro').value;
    let _Estatus = document.getElementById('selectEstatusFiltro').value;
    _Req = {

        Compania: _Compania,
        Localidad: _Localidad,
        FechaFiniquito: _FecFiniquito,
        Nombre: _Nombre,
        NoEmpleado: _NoEmpleado,
        Estatus: _Estatus,
    };

    if (_Compania === '' && _Localidad === '' && _FecFiniquito === '' && _Nombre === '' && _NoEmpleado === '' && _Estatus === '') {
        swal(
            'warning',
            "Selecciona almenos un filtro",
            "warning",
        );
        return;
    };
    blockPartial('#frmConsultaNomina');

    $('#tblFiniquito').DataTable({
        'ajax': {
            'url': '/Finiquito/ConsultarFiniquito',
            'type': 'POST',
            'data': _Req,
            'datatype': 'json',
            'dataSrc': function (data) {
                console.log(data.data)
                return data.data
            }
        },
        dom: 'Blfrtip',
        buttons: ['csv', 'excel', 'pdf'],
        destroy: true,
        responsive: true,
        lengthMenu: [10, 15, 20],
        language: {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar en resultado:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "columns":
            [
                { 'defaultContent': '<button onclick="OpenModalCambioFiniquito(this)"  title="Cambio" class="btn btn-primary">Cambio</i></button>' },
                { 'defaultContent': '<button    title="Consulta" class="btn btn-success">Consulta</button>' },
                { 'defaultContent': '<button   onclick="EliminarById(this)"class="btn btn-danger">Eliminar</button>' },

                {
                    "data": "DocEntry",
                },
                {
                    "data": "Empleado",
                },
                {
                    "data": "Nombre",
                },
                {
                    "data": "FechaFiniquito",
                },
                {
                    "data": "NoSim",
                },
                {
                    "data": "TipoNomina",
                },
                {
                    "data": "DesTipoNomina",
                },
                {
                    "data": "NetoaPagar",
                },
                {
                    "data": "EstatusEmpleado",
                },
                {
                    "data": "Cia",
                },
                {
                    "data": "DescripcionCia",
                },
                {
                    "data": "Localidad",
                },
                {
                    "data": "DescLocalidad",
                },
                {
                    "data": "EstatusFiniquito",
                },
                {

                    "data": "Sim",
                },

            ],
    });
    $('#btnNuevo').show()
}
function AgregarNuevoFiniquito() {
    let _Empleado = $('#txtEmpleado').val();
    let _FechaFiniquito = $('#txtFFiniquito').val();
    let _Compania = $('#txtCompania').val();
    let _TipoNomina = $('#txtTNomina').val();
    let _Localidadd = $('#txtLocalidad').val();
    let _Simulacion = $('#txtSimulacion').val();
    let _PorcentajeSimulacion = $('#txtPSimulacion').val();
    let _Estatus = $('#txtEstatus').val();
    let _TipoContrato = $('#txtTContrato').val();
    let _SueInteIndem = $('#txtIntIndem').val();
    let _ImporteReservado = $('#txtIReservado').val();
    let _NetoLlegar = $('#txtNLlegar').val();
    let _FechaAntiguedad = $('#txtFAntiguedad').val();
    let _SueldoM = $('#txtSueldoM').val();
    let _SueldoD = $('txtSueldoD').val(); 
    _Req = {
        Empleado: _Empleado,
        FechaFiniquito: _FechaFiniquito,
        Compania: _Compania,
        TipoNomina: _TipoNomina,
        Localidadd: _Localidadd,
        Simulacion: _Simulacion,
        PorcentajeSimulacion: _PorcentajeSimulacion,
        Estatus: _Estatus,
        TipoContrato: _TipoContrato,
        SueInteIndem: _SueInteIndem,
        ImporteReservado: _ImporteReservado,
        NetoLlegar: _NetoLlegar,
        FechaAntiguedad: _FechaAntiguedad,
        SueldoM: _SueldoM,
        SueldoD: _SueldoD,

    }
    CloseModal('#mdlNuevoFiniquito')
    $.ajax({     
        url: '/Finiquito/NuevoRegistroFiniquito',
        type: 'POST',
        data: _Req,
        success: function (data) {
           
            var IsOK_ = data.IsOK;
            if (IsOK_ == true) {
                swal(
                    'success',
                    "Se creo correctamente el registro",
                    "success",
                );
            }
        },
        error: function (jqXHR, status, error) {
         
            swal(
                'warning',
                'Aviso...',
                'Surgio un error inesperado. \n' + jqXHR.status + ' ' + jqXHR.statusText,
            );
        }
    });
}
function EliminarById(button) {
    if (button != undefined) {
        swal({
            title: "Eliminar",
            text: "¿Estas seguro de eliminar el registro?",
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Eliminar",
            closeOnConfirm: false
        }, function (result) {
            let _Req = {
                _CodEmpleados: $(button).closest('tr').find('td:eq(3)').text(),
            }
            if (result) {
                $.ajax({
                    url: '/Finiquito/EliminarRegistroById',
                    type: 'POST',
                    data: _Req,
                    success: function (data) {
                        var IsOK_ = data.IsOK;
                        //obtenerCatalogoEstudios();
                        $.unblockUI();
                        if (IsOK_ == true) {
                            swal("¡Eliminado!", "Registro eliminado correctamente", "success");
                        }
                    },
                    error: function (jqXHR, status, error) {
                        $.unblockUI();
                        swal({
                            icon: 'Error',
                            title: 'Aviso...',
                            text: 'Surgio un error inesperado. \n' + jqXHR.status + ' ' + jqXHR.statusText,
                            allowEscapeKey: true,
                            allowEnterKey: true,
                            focusCancel: true,
                            focusConfirm: true,
                        });
                    }
                });

            } else {
                return;
            }

        });
    }
}
function ActualizarFiniquito() {
    let _Empleado = $('#txtEmpleado').val();
    let _FechaFiniquito = $('#txtFFiniquito').val();
    let _Compania = $('#txtCompania').val();
    let _TipoNomina = $('#txtTNomina').val();
    let _Localidadd = $('#txtLocalidad').val();
    let _Simulacion = $('#txtSimulacion').val();
    let _PorcentajeSimulacion = $('#txtPSimulacion').val();
    let _Estatus = $('#txtEstatus').val();
    let _TipoContrato = $('#txtTContrato').val();
    let _SueInteIndem = $('#txtIntIndem').val();
    let _ImporteReservado = $('#txtIReservado').val();
    let _NetoLlegar = $('#txtNLlegar').val();
    let _FechaAntiguedad = $('#txtFAntiguedad').val();
    let _SueldoM = $('#txtSueldoM').val();
    let _SueldoD = $('txtSueldoD').val();
    _Req = {
        Empleado: _Empleado,
        FechaFiniquito: _FechaFiniquito,
        Compania: _Compania,
        TipoNomina: _TipoNomina,
        Localidadd: _Localidadd,
        Simulacion: _Simulacion,
        PorcentajeSimulacion: _PorcentajeSimulacion,
        Estatus: _Estatus,
        TipoContrato: _TipoContrato,
        SueInteIndem: _SueInteIndem,
        ImporteReservado: _ImporteReservado,
        NetoLlegar: _NetoLlegar,
        FechaAntiguedad: _FechaAntiguedad,
        SueldoM: _SueldoM,
        SueldoD: _SueldoD,

    }
    CloseModal('#mdlActualizarFiniquito')
    $.ajax({
        beforeSend: function () {
            $.blockUI({
                theme: true,
                message: `<div class="row"><div class="col-lg-12"><div class="ibox-content"><div class="spiner-example"><div class="sk-spinner sk-spinner-three-bounce"><div class="sk-bounce1"></div><div class="sk-bounce2"></div><div class="sk-bounce3"></div></div></div></div></div></div >`,
                baseZ: 40000
            });
        },
        url: '/Finiquito/ActualizarFiniquito',
        type: 'POST',
        data: _Req,
        success: function (data) {
            var IsOK_ = data.IsOK;
            if (IsOK_ == true) {
                swal(
                    'success',
                    "Se actualizo el registro correctamente.",
                    "success",
                );
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
}
function CloseModal(id) {
        $(id).modal('hide');

}

