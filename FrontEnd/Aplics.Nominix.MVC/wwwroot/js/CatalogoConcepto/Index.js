$(document).ready(function () {

})

function frmBuscarConceptoCatalogo() {
    let _Search = document.getElementById('txtBuscar').value;
    let _Req = {
        CodConcepto: _Search
    }

    $('#tblConceptoCatalogo').DataTable({
        'ajax': {
            'url': '/EmpleadosNomina/BuscarConceptoCatalogo',
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
            "decimal": "", "emptyTable": "No hay información",
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
                    "data": "Code",
                    "title": "Code"
                },
                {
                    "data": "Name",
                    "title": "Name"
                },

            ]
    });



}
