////let selectData = '<select class="calcular" name="Calcular"><option disabled selected>Seleccione un documento</option><option value="S">Si</option><option value="N">No</option><option value="I">Segun Importe</option></select>';
////let resultData = [
////    [1, '0231','Empleado 1','concepto 1','concepto 1' ,12,123.55, selectData],
////    [2, '1223','Empleado 2','concepto 1','concepto 1' ,12,123.55, selectData ],
////    [3, '0033','Empleado 3','concepto 1','concepto 1' ,12,123.55, selectData ]
////];
let EnumTipoBusqueda = {
    Nomina: 1,
    NominaEmpleado: 2
};
//let myDropzone = Dropzone.options.dropzoneForm = {
//    paramName: "file", // The name that will be used to transfer the file
//    maxFilesize: 2, // MB
//    addRemoveLinks: true,
//    //acceptedFiles: '.csv',
//    dictDefaultMessage: "<strong>Arrastre su archivo aqui. </strong>"
//};
Dropzone.autoDiscover = false;
let myDropzone = new Dropzone('.dropzone', {
    url: '/EmpleadosNomina',
    maxFilesize: 2,
    maxFiles: 3,
    acceptedFiles: '.csv,.xlsx, application/vnd.ms-excel, text/csv',
    addRemoveLinks: true,
    dictRemoveFile: 'Quitar',
    dictDefaultMessage: "<strong>Arrastre su archivo aqui. </strong>"
})

let _file = [];
myDropzone.on('addedfile', file => {
    _file.push(file)
})
myDropzone.on('removedfile', file => {
    let i = _file.indexOf(file);
    _file.splice(i, 1);
    console.log(_file)
});

$(document).ready(function () {
    //     $('#tblNomina').DataTable({
    //       dom: 'Blfrtip',
    //       buttons: ['csv', 'excel', 'pdf'],
    //       destroy: true,
    //       responsive: true,
    //       lengthMenu: [10, 15, 20],
    //       language: {
    //           "decimal": "",
    //           "emptyTable": "No hay información",
    //           "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
    //           "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
    //           "infoFiltered": "(Filtrado de _MAX_ total entradas)",
    //           "infoPostFix": "",
    //           "thousands": ",",
    //           "lengthMenu": "Mostrar _MENU_ Entradas",
    //           "loadingRecords": "Cargando...",
    //           "processing": "Procesando...",
    //           "search": "Buscar en resultado:",
    //           "zeroRecords": "Sin resultados encontrados",
    //           "paginate": {
    //               "first": "Primero",
    //               "last": "Ultimo",
    //               "next": "Siguiente",
    //               "previous": "Anterior"
    //           }
    //       }
    //});
})

function frmFiltrosNomina() {
    let _Compania = document.getElementById('selectCompaniaFiltro').value;
    let _TipoNomina = document.getElementById('selectTpNominaFiltro').value;
    let _Estatus = document.getElementById('selectEstatusFiltro').value;
    let _FInicial = document.getElementById('txtFInical').value;
    let _FFinal = document.getElementById('txtFFinal').value;
    let _Ano = document.getElementById('txtAno').value;
    let _EstatusEmpleado = document.getElementById('selectEstatusEmpleadoFiltro').value;
    let _Nombre = document.getElementById('txtNombre').value;
    let _TipoBusqueda = document.getElementById('selectTipoBusqueda').value;
    let _NumeroNomina = document.getElementById('txtNumeroNomina').value;
    if (_TipoBusqueda === "1") {
        let _Req = {
            Compania: _Compania,
            TipoNomina: _TipoNomina,
            Ano: _Ano,
            NumeroNomina: _NumeroNomina,
            Estatus: _Estatus,
            FInicio: _FInicial,
            FFin: _FFinal,
            TipoBusqueda: EnumTipoBusqueda.Nomina
        }
        $('#tblNomina').DataTable({
            'ajax': {
                'url': '/EmpleadosNomina/BuscarNomina',
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
                        "data": "Id",
                        "title": "Id"
                    },
                    {
                        "data": "Empleado",
                        "title": "Empleado"
                    },
                    {
                        "data": "Nombre",
                        "title": "Nombre"
                    },
                    {
                        "data": "Concepto",
                        "title": "Concepto"
                    },
                    {
                        "data": "DescConcepto",
                        "title": "DescConcepto"
                    },
                    {
                        "data": "Unidades",
                        "title": "Unidades"
                    },
                    {
                        "data": "Importe",
                        "title": "Importe"
                    },
                ]
        });

    } else {
        let _Req = {
            Nombre: _Nombre,
            Estatus: _EstatusEmpleado,
            TipoBusqueda: EnumTipoBusqueda.NominaEmpleado
        }
        $('#tblEmpleado').DataTable({
            'ajax': {
                'url': '/EmpleadosNomina/BuscarNominaEmpleado',
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
                        "data": "Codigo",
                        "title": "Codigo"
                    },
                    {
                        "data": "Nombre",
                        "title": "Nombre"
                    },
                    {
                        "data": "Estatus",
                        "title": "Estatus"
                    }
                ]
        });
    }

}

function UploadFiles() {
    if (_file.length > 0) {
        let _Compania = document.getElementById('selectCompaniaExcel').value
        let _TipoNomina = document.getElementById('selectTpNominaExcel').value
        let _Ano = document.getElementById('txtAnoExcel').value
        let _NumeroNomina = document.getElementById('txtNumeroNominaExcel').value
        for (let i = 0; i < _file.length; i++) {
            let fileData = new FormData();
            fileData.append('File', _file[i]);
            fileData.append('Compania', _Compania);
            fileData.append('TipoNomina', _TipoNomina);
            fileData.append('Ano', _Ano);
            fileData.append('NumeroNomina', _NumeroNomina);
            myDropzone.removeAllFiles(true);
            LimpiarFrmExcepciones();
            closeModal();
            $.ajax({
                url: '/EmpleadosNomina/UploadFileExcel',
                type: 'POST',
                data: fileData,
                processData: false,  
                contentType: false, 
                success: function (data) {
                    console.log(data);
                    alert(data);
                }
            });
        }
    } else {
        swal(
            'warning',
            "Porfavor selecciona un archivo",
            "warning",
        );
    }  
}
function OpenModal() {
    $('#mdlUploadExcel').modal({ backdrop: 'static', keyboard: false })
}
function closeModal() {
    $('#mdlUploadExcel').modal('hide');
}
function cancelar() {
    myDropzone.removeAllFiles(true)
    LimpiarFrmExcepciones();
}
function LimpiarFrmExcepciones() {
    document.getElementById('dropzoneForm').reset();
}




    //let resetInput = document.getElementById('file')
    //var formData = new FormData();
    //formData.append('file', $('#file')[0].files[0]);
    //resetInput.value = '';
    //$.ajax({
    //    url: '/EmpleadosNomina/UploadFileExcel',
    //    type: 'POST',
    //    data: formData,
    //    processData: false,  // tell jQuery not to process the data
    //    contentType: false,  // tell jQuery not to set contentType
    //    success: function (data) {
    //        console.log(data);
    //        alert(data);
    //    }
    //});

function ValidateDate(_Fecha) {

    const validateDate = (_Fecha) => {
        const DATE_REGEX = /^(0[1-9]|[1-2]\d|3[01])(\/)(0[1-9]|1[012])\2(\d{4})$/
        const CURRENT_YEAR = new Date().getFullYear();
        /* Comprobar formato dd/mm/yyyy, que el no sea mayor de 12 y los días mayores de 31 */
        if (!birthDate.match(DATE_REGEX)) {
            return false
        }
        /* Comprobar los días del mes */
        const day = parseInt(birthDate.split('/')[0])
        const month = parseInt(birthDate.split('/')[1])
        const year = parseInt(birthDate.split('/')[2])
        const monthDays = new Date(year, month, 0).getDate()
        if (day > monthDays) {
            return false
        }
        /* Comprobar que el año no sea superior al actual*/
        if (year > CURRENT_YEAR) {
            return false
        }
        return true

    }
    //const validateForm = event => {
    //    event.preventDefault();
    //    const date = _Fecha //document.querySelector('.input').value;
    //    //const validationMessage = document.querySelector('.validation-message');
    //    if (validateDate(date)) {
    //        //validationMessage.classList.add("success");
    //        //validationMessage.innerHTML = '¡Fecha válida!';
    //    } else {
    //        return false
    //        //validationMessage.classList.add("error");
    //        //validationMessage.innerHTML = '¡Fecha  no válida!';
    //    }
    //}
    //return true

    //document.querySelector(".frmNew").addEventListener('submit', validateForm);

}