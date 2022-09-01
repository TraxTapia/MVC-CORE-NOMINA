const comapania = 'AST_001';
const localidad = 'AST_701';
const categoria = 'AST_704'
const prestaciones = 'AST_132'
const cveContable = 'AST_709'
const horario = 'AST_737'
const banco = 'AST_708'
const codResevado1 = 'AST_711'
const codResevado2 = 'AST_712'
const codResevado3 = 'AST_713'
const codResevado4 = 'AST_714'
const codResevado5 = 'AST_715'
const codResevado6 = 'AST_716'
const codResevado7 = 'AST_717'
const codResevado8 = 'AST_718'
const tipoContrato = 'AST_705'
const direccion = 'AST_722'
const subDireccion = 'AST_747'
const departamento = 'AST_723'
const puesto = 'AST_702'
const nivelTabulador = 'pendiente'
const categoriaSueldo = 'AST_754'
const turno = 'AST_706'
const cveRegistroPatronal = 'AST_142'
const centroBeneficios = 'AST_F11'
const tipoNomina = 'AST_703'
const plaza = "AST_P16"
let txtCodEmpleadoSearch = '';
let txtCodEmpleadoSearchEdit = '';

let _SelectConpania = document.getElementById('selectCompaniaFiltro');
let _SelectLocalidad = document.getElementById('selectLocalidadFiltro');
let _SelectCategoria = document.getElementById('selectCategoria');
let _SelectPrestacion = document.getElementById('selectPrestaciones');
let _SelectCveContable = document.getElementById('selectCveContables');
let _SelectHorario = document.getElementById('selectHoraios');
let _SelectBanco = document.getElementById('selectBancos');
let _SelectCodReservado1 = document.getElementById('selectCodReservado1');
let _SelectCodReservado2 = document.getElementById('selectCodReservado2');
let _SelectCodReservado3 = document.getElementById('selectCodReservado3');
let _SelectCodReservado4 = document.getElementById('selectCodReservado4');
let _SelectCodReservado5 = document.getElementById('selectCodReservado5');
let _SelectCodReservado6 = document.getElementById('selectCodReservado6');
let _SelectCodReservado7 = document.getElementById('selectCodReservado7');
let _SelectCodReservado8 = document.getElementById('selectCodReservado8');
let _SelectTipoContrato = document.getElementById('SelectTipoContrato');
let _SelectCompaniaFS = document.getElementById('selectCompaniaFS');
let _SelectLocalidadFS = document.getElementById('selectLocalaidadesFS');
let _SelectDireccionFS = document.getElementById('selectDireccionesFS');
let _SelectSubDireccionFS = document.getElementById('selectSubdireccionesFS');
let _SelectDepartamentoFS = document.getElementById('selectDepartamentosFS');
let _SelectPuestoFS = document.getElementById('selectPuestosFS');
let _SelectCatSueldo = document.getElementById('selectCategoriaSueldosFS');
let _SelectTurnoFS = document.getElementById('selectTurnosFS');
let _SelectCvePatronal = document.getElementById('selectCvePatronalFS');
let _SelectCentroBeneficioFS = document.getElementById('selectCentroBenficioFS');
let _SelectTipoNomina = document.getElementById('selectTipoNominaFS');
let _SelectPlaza = document.getElementById('selectPlazas');
let _Name = "";
$(document).ready(function () {
    $('#tblEmpleados').DataTable({
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
        }
    });
    $('#frmEmployerNew').on('submit', function (e) {
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
            url: '/Empleados/AgregarEmpleado',
            type: 'POST',
            data: objeto,
            success: function (data) {
                $.unblockUI();
                if (data.Code === "200") {
                    swal(
                        'Correcto',
                        "Se creo correctamente el empleado.",
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
    SelectGral(_SelectConpania, comapania, true)
    SelectGral(_SelectLocalidad, localidad, true)
    SelectGral(_SelectCategoria, categoria, true)
    SelectGral(_SelectPrestacion, prestaciones, true)
    SelectGral(_SelectCveContable, cveContable, true)
    SelectGral(_SelectHorario, horario, true)
    SelectGral(_SelectBanco, banco, true)
    SelectGral(_SelectCodReservado1, codResevado1, true)
    SelectGral(_SelectCodReservado2, codResevado2, true)
    SelectGral(_SelectCodReservado3, codResevado3, true)
    SelectGral(_SelectCodReservado4, codResevado4, true)
    SelectGral(_SelectCodReservado5, codResevado5, true)
    SelectGral(_SelectCodReservado6, codResevado6, true)
    SelectGral(_SelectCodReservado7, codResevado7, true)
    SelectGral(_SelectCodReservado8, codResevado8, true)
    SelectGral(_SelectTipoContrato, tipoContrato, true)
    SelectGral(_SelectCompaniaFS, comapania, true)
    SelectGral(_SelectLocalidadFS, localidad, true)
    SelectGral(_SelectDireccionFS, direccion, true)
    SelectGral(_SelectSubDireccionFS, subDireccion, true)
    SelectGral(_SelectDepartamentoFS, departamento, true)
    SelectGral(_SelectPuestoFS, puesto, true)
    SelectGral(_SelectCatSueldo, categoriaSueldo, true)
    SelectGral(_SelectTurnoFS, turno, true)
    SelectGral(_SelectCvePatronal, cveRegistroPatronal, true)
    SelectGral(_SelectCentroBeneficioFS, centroBeneficios, true)
    SelectGral(_SelectTipoNomina, tipoNomina, true)

 
});
function obtenerCatalogoEmpleados() {
    let table = $('#tblEmpleados').DataTable({
        'ajax': {
            'url': '/Empleados/GetEmpleados',
            'type': 'POST',
            'datatype': 'json'
        },
        "responsive": "true",
        "dom": 'Bfrtip',
        "buttons": ['csv', 'excel', 'pdf'],
        "destroy": true,
        'columns': [
            { 'data': 'Code', 'autoWith': true, },
            { 'data': 'Name', 'autoWith': true },
            { 'data': 'Estatus', 'autoWith': true },
            { 'data': 'Compania', 'autoWith': true },
            { 'data': 'Localidad', 'autoWith': true },
            { 'data': 'Direccion', 'autoWith': true },
            { 'data': 'Departamento', 'autoWith': true },
            { 'data': 'Puesto', 'autoWith': true },
            { 'data': 'CentroCostos', 'autoWith': true },
            { 'defaultContent': '<button  onclick="EliminarEmpleadoByCode(this)"  title="Eliminar" class="btn btn-danger"><i class="fa fa-trash white" aria-hidden="true" ></i></button>' },
            { 'defaultContent': '<button type="button"   title="Editar" class=" editar btn btn-primary"><i class=" fa fa-pencil white" aria-hidden="true" ></i></button>' },
        ]
    });
    botonDetalletabla('#tblEmpleados tbody', table)
}
function EliminarEmpleadoByCode(button) {
    if (button != undefined) {
        swal({
            title: '¡Aviso!',
            text: '¿Deseas elimar el empleado?',
            icon: 'warning',
            buttons: {
                cancel: {
                    text: "Cancelar",
                    value: false,
                    visible: true,
                    className: "",
                    closeModal: true,
                },
                confirm: {
                    text: "Eliminar",
                    value: true,
                    visible: true,
                    className: "",
                    closeModal: true
                }
            }
        }).then((result) => {
            if (result) {
                var object = {
                    CodeEmpleado: parseInt($(button).closest('tr').find('td:eq(0)').text()),
                };
                $.ajax({
                    beforeSend: function () {
                        $.blockUI({
                            theme: true, message: '<div class="row"><div class="col-lg-12"><br /><p style="font-size:small; text-align: center;"><img src="/SASE/Content/assets/img/loading.gif" style="width: 35px;" /></p><p style="font-size:small; text-align: center;"> Espere un momento por favor...</p><br /></div></div>',
                            baseZ: 10000
                        });
                    },
                    url: '/Empleados/DeleteEmployeByCode',
                    type: 'POST',
                    data: object,
                    success: function (data) {
                        $.unblockUI();
                        if (data.Code === "200") {
                            swal("El empleado fue eliminado y tiene el estatus de BAJA", {
                                icon: "success",
                            })
                        }
                        obtenerCatalogoEmpleados();
                    },
                    error: function (jqXHR, status, error) {
                        $.unblockUI();
                        swal({
                            icon: 'warning',
                            title: 'Aviso...',
                            text: 'Surgio un error inesperado. \n' + jqXHR.status + ' ' + jqXHR.statusText,
                            allowEscapeKey: true,
                            allowEnterKey: true,
                            focusCancel: true,
                            focusConfirm: true,
                        });
                    }
                });
            }
            else {
                return;
            }
        });
    }
}
function OpenModalNuevoEmpleado(button) {
    if (button != undefined) {
        SelectPlaza(_SelectPlaza, plaza, 'Plaza', true);
        $('#mdlPlaza').modal({ backdrop: 'static', keyboard: false })
    }
}
function OpenModalReingresoEmpleado(button) {
    if (button != undefined) {
        $('#mdlReingreso').modal({ backdrop: 'static', keyboard: false })
    }
}
function ValidarCodEmpleadoReingreso() {
    let codEmpleado = document.getElementById('txtCodEmpleadoReingresoMdl').value
    if (codEmpleado === '') {
        swal(
            'warning',
            "Debes ingresar en codigo de empleado a reingresar",
            "warning",
        );
        return;
    }
    window.location.href = `/Empleados/ReingresoEmpleados?codCodigo=${codEmpleado}`;
    document.getElementById('frmMdlReingreso').reset();
  
}
function SearchEmpleadoReingresar(_Req) {
    $.ajax({
        beforeSend: function () {
            $.blockUI({
                theme: true,
                message: `<div class="row"><div class="col-lg-12"><div class="ibox-content"><div class="spiner-example"><div class="sk-spinner sk-spinner-three-bounce"><div class="sk-bounce1"></div><div class="sk-bounce2"></div><div class="sk-bounce3"></div></div></div></div></div></div >`,
                baseZ: 40000
            });
        },
        url: '/Empleados/DataReingresoEmployer',
        type: 'POST',
        data: _Req,
        success: function (data) {
          console.log(data)
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
function OpenModalEmpleadoEdit(button) {
    if (button != undefined) {

        let _Code = $(button).closest('tr').find('td:eq(0)').text();
        let _Name = $(button).closest('tr').find('td:eq(1)').text();
        $('#txtCodeEmpleadoEdit').val(_Code);
        $('#txtNameEmpleadoEdit').val(_Name);
        $('#mdlEditEmpleado').modal({ backdrop: 'static', keyboard: false })
    }

}
function validaPlazaDisponible() {
    if (document.getElementById('selectPlazas').value == "") {
        swal(
            "warning",
            "Selecciona la plaza",
            "warning"
        )
        return;
    }
    if (document.getElementById('selectPlazas').value > 0) {
        if (document.getElementById('selectPlazas').value === "2") {
            swal(
                'warning',
                "La plaza no se encuntra disponible",
                "warning",
            );
            return;
        } else {
            document.location.href = '/Empleados/Empleado'


        }
    }
}
function FiltrarDatos(event) {
    event.preventDefault();
    let _Req = {};
    if (document.getElementById('selectCompaniaFiltro').value > 0) {
        _Req = {
            Compania: $('#selectCompaniaFiltro').val(),
        };
    } else if (document.getElementById('selectLocalidadFiltro').value > 0) {
        _Req = {
            Compania: $('#selectLocalidadFiltro').val(),
        };
    } else if (document.getElementById('txtNombreEmpleadoFiltro').value != "") {
        _Req = {
            Compania: $('#txtNombreEmpleadoFiltro').val(),
        };
    } else if (document.getElementById('txtNoEmpleadoFiltro').value != "") {
        _Req = {
            Compania: $('#txtNoEmpleadoFiltro').val(),
        };
    }
    if (Object.entries(_Req).length === 0) {
        swal(
            'warning',
            "Selecciona almenos un filtro",
            "warning",
        );
        return;
    }
    $.ajax({
        beforeSend: function () {
            $.blockUI({
                theme: true,
                message: `<div class="row"><div class="col-lg-12"><div class="ibox-content"><div class="spiner-example"><div class="sk-spinner sk-spinner-three-bounce"><div class="sk-bounce1"></div><div class="sk-bounce2"></div><div class="sk-bounce3"></div></div></div></div></div></div >`,
                baseZ: 40000
            });
        },
        url: '/Empleados/FiltroBusquedaEmpleados',
        type: 'POST',
        data: _Req,
        success: function (data) {
            var IsOK_ = data.IsOK;
            if (IsOK_ == true) {

            }
            obtenerCatalogoEmpleados();
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
function cancelarFomularioFiltro() {
    document.getElementById('frmFiltroEmpleados').reset();
}
function SelectGral(id, identificador, isNew) {
    let _isNew = isNew;
    let _Req = {
        Identificador: identificador
    }
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: '/Empleados/GetDataSelect',
            type: 'POST',
            dataType: 'json',
            data: _Req,
            success: function (data) {
                if (_isNew) {
                    for (var i = 0; i < data.data.length; i++) {
                        $(id).append('<option value =' + data.data[i].Valor + '>' + data.data[i].Descripcion + '</option>');
                    }
                } else {
                    for (var i = 0; i < data.dat.length; i++) {
                        $(id).append('<option value =' + data.data[i].Valor + '>' + data.List[i].Descripcion + '</option>');
                    }
                }
                resolve(true);
            },
            error: function (jqXHR, status, error) {
                swal({
                    title: "¡Error!",
                    text: 'Surgio un error inesperado. \n' + jqXHR.status + ' ' + jqXHR.statusText,
                    icon: "warning",
                });
                reject(error);
            }
        });
    });
}
function SelectPlaza(id, identificador, plaza, isNew) {
    let _isNew = isNew;
    let _Req = {
        Identificador: identificador,
        TipoSelect: plaza
    }
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: '/Empleados/GetDataSelect',
            type: 'POST',
            dataType: 'json',
            data: _Req,
            success: function (data) {
                if (_isNew) {
                    for (var i = 0; i < data.data.length; i++) {
                        $(id).append('<option value =' + data.data[i].Valor + '>' + data.data[i].Descripcion + '</option>');
                    }
                } else {
                    for (var i = 0; i < data.data.length; i++) {
                        $(id).append('<option value =' + data.data[i].Valor + '>' + data.List[i].Descripcion + '</option>');
                    }
                }
                resolve(true);
            },
            error: function (jqXHR, status, error) {
                swal({
                    title: "¡Error!",
                    text: 'Surgio un error inesperado. \n' + jqXHR.status + ' ' + jqXHR.statusText,
                    icon: "warning",
                });
                reject(error);
            }
        });
    });
}
function cancelarCrear() {
    $('#selectPlazas option').each(function () {
        if ($(this).val() != '') {
            $(this).remove();
        }
    });
}
function botonDetalletabla(tbody, table) {
    $(tbody).on('click', 'button.editar', function () {
        let data = table.row($(this).parents('tr')).data();
        window.location.href = `/Empleados/ActualizarEmpleado?CodeEmpleado= ${data.Code}`;
    });


}
function CancelarNuevoRegistro(button) {
    document.location.href = '/Empleados/Index'
}

function CancelarReingreso() {
    document.getElementById('frmReingreso').reset();
    window.location.href = '/Empleados/Index'
}


llenarSelectCatMoneda(false).then(function (data) {
    console.log("resp promise ==>", data);

    if (data) {
        $('#IdProducto').val(_Id);
        $('#autocompleteProductosEdit').val(_CodProducto);
        $('#_idCoberturaEdit').val(_Id_Cobertura);
        $('#autocompleteCoberturaEdit').val(_Cobertura);
        $('#txtTipoCopagoEdit').val(_TipoCopago);
        $('#txtMonedas').val(parseInt(_Id_Moneda));
        $('#txtlimiteinicial').val(_Limite_Inicial);
        $('#txtlimitefinal').val(_Limite_Final);
        $('#txtCopagoEdit').val(_Copago);
        $('#txtEspecificacion').val(_Especificaciones);
        $('#txtTipoGastoEdit').val(_TipoGastoCopago);

        //$('#txtcubiertoEdit').val(_Cubierto);
        //console.log('trae el valor de cubierto===>', _Cubierto);
        //$('#txtPorcentajes').val(_Porcentaje);
        //$('#txtFecha').datepicker('setDate', new Date()).val(_FechaCreacion);
        //console.log('Fecha edita ==> ', _FechaCreacion)

    }
}).catch(function (err) {
    console.log("error promise ==>", err);
});