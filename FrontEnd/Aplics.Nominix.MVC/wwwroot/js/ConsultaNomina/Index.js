$(document).ready(function () {
    jQuery.fn.dataTable.Api.register('sum()', function () {
        return this.flatten().reduce(function (a, b) {
            if (typeof a === 'string') {
                a = a.replace(/[^\d.-]/g, '') * 1;
            }
            if (typeof b === 'string') {
                b = b.replace(/[^\d.-]/g, '') * 1;
            }
            return a + b;
        }, 0);
    });

});

function ConsultarNomina(event) {
    event.preventDefault();
    let _Req = {};
    let _Compania = document.getElementById('selectCompaniaExcel').value;
    let _TipoNomina = document.getElementById('selectTpNominaExcel').value;
    let _Ano = document.getElementById('txtAnoExcel').value;
    let _NoNomina = document.getElementById('txtNumeroNominaExcel').value;
    let _FecInicial = document.getElementById('FecInicial').value;
    let _FecFinal = document.getElementById('FecFinal').value;
    let FecPago = document.getElementById('FecPago').value;
    let _Estatus = document.getElementById('selectEstatusExcel').value;

    _Req = {
        Compania: _Compania,
        TipoNomina: _TipoNomina,
        Ano: _Ano,
        NoNomina: _NoNomina,
        FecInicial: _FecInicial,
        FecFinal: _FecFinal,
        FecPago: FecPago,
        Estatus: _Estatus,
    };

    if (Object.entries(_Req).length === 0) {
        swal(
            'warning',
            "Selecciona almenos un filtro",
            "warning",
        );
        return;
    };
    blockPartial('#frmConsultaNomina');
    $('#tblConsultaNomina').DataTable({
        'ajax': {
            'url': '/ConsultaNomina/ConsultarNomina',
            'type': 'POST',
            'data': _Req,
            'datatype': 'json',
            "dataSrc": "data",
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
                {
                    "data": "Empleado",
                    "title": "Empleado"
                },
                {
                    "data": "Nombre",
                    "title": "Nombre"
                },
                {
                    "data": "Neto",
                    "title": "Neto"
                },
                { 'defaultContent': '<button  onclick="ModalDetalle(this)"  title="Eliminar" class="btn btn-warning"><i class="fa fa-search white" aria-hidden="true" ></i></button>' },

            ],

    });
    unblockPartial('#frmConsultaNomina');

}
function ModalDetalle(button) {
    if (button != undefined) {
        let _Code = $(button).closest('tr').find('td:eq(0)').text();
        let _Name = $(button).closest('tr').find('td:eq(1)').text();
        $('#txtNoEmpleado').val(_Code);
        $('#txtNombre').val(_Name);

        let _Req = {
            CodEmpleado: _Code
        }
        $('#tblDetalleNomina').DataTable({
            'ajax': {
                'url': '/ConsultaNomina/DetalleNominaEmpleado',
                'type': 'POST',
                'data': _Req,
                'datatype': 'json',
                "dataSrc": "data",
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
                    {
                        "data": "Concepto",
                        "title": "Concepto"
                    },
                    {
                        "data": "Descripcion",
                        "title": "Descripcion"
                    },
                    {
                        "data": "Unidades",
                        "title": "Unidades"
                    },
                    {
                        "data": "Percepciones",
                        render: $.fn.dataTable.render.number(',', '.', 2, '$'), 'autoWith': true,
                        "title": "Percepciones"
                    },
                    {
                        "data": "Deducciones",
                        render: $.fn.dataTable.render.number(',', '.', 2, '$'), 'autoWith': true,
                        "title": "Deducciones"
                    },

                ],

            drawCallback: function () {
                var api = this.api();
                var percepciones = api.column(3, { "filter": "applied" }).data().sum();
                var deducciones = api.column(4, { "filter": "applied" }).data().sum();
                let neto = percepciones - deducciones;
                $('#percepciones').html('$ '+ percepciones);
                $('#deducciones').html('$ ' + deducciones);
                $('#neto').html('$ ' + neto);
            }

        });
        $('#mdlDetalle').modal({ backdrop: 'static', keyboard: false })
    }
}

function cancelar() {
    document.getElementById('DetalleNomina').reset();
}