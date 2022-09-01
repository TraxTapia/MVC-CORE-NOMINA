var fileUpload;
function readURL(input) {
    if (input.files && input.files.length > 0) {
        fileUpload = input.files;
        var reader = new FileReader();

        reader.onload = function (e) {
            $('.image-upload-wrap').hide();

            $('.file-upload-image').attr('src', e.target.result);
            $('.file-upload-content').show();
            var FileNames = [];
            for (var i = 0; i < fileUpload.length; i++) {
                FileNames.push(fileUpload[i].name);
                AddFileList(i, fileUpload[i].name);
            }
            ListFilesHelp(FileNames);
            $("#btnCargarArchivos").show();
        };

        reader.readAsDataURL(input.files[0]);

    } else {
        removeUpload();
    }
}

function AddFileList(pos, nombre) {
    var newUi;
    var uipadre;
    if ($('.ListaInputFile').length) {
        uipadre=$('.ListaInputFile');
        if (pos === 0) {
            newUi = $("<table class='TablaInputFile table table-striped table-bordered' style='width: 100%;'></table>");
            $(uipadre).append(newUi);
            uipadre = $(newUi);
        } else {
            uipadre = $('.ListaInputFile table');
        }
        newUi = $("<tr style='cursor: pointer;'><td style='width: 5%;'><button class='btn btn-danger btn-circle' type='button'  title='Eliminar Archivos' onclick='DeleteFileInput(this);'><i class='fa fa-lg fa-trash' aria-hidden='true'></i></button></td><td style='text-align: left;'>" + nombre + "</td></tr>");
        uipadre.append(newUi);
    }
}

function BorrarTablaFiles() {
    if ($('.TablaInputFile').length) {
        $('.TablaInputFile').remove();
    }
}

function DeleteFileInput(op) {
    var row = $(op).parent().parent();
    $(row).remove();
    var files = recoverFiles();
    if (files.length === 0) {
        removeUpload();
    }
    ListFilesHelp(files);
}

function recoverFiles() {
    var files = [];
    var td;
    $('.TablaInputFile > tr').each(function () {
        td = $(this).find("td").eq(1);
        files.push($(td).html());
    }
    );
    return files;
}

function ListFilesHelp(files) {
    var nombre = "";
    for (var i = 0; i < files.length; i++) {
        nombre += nombre !== "" ? "\n" : "";
        nombre += files[i];
    }
    $('.image-title').html(nombre);
}

function removeUpload() {
    $('.file-upload-input').replaceWith($('.file-upload-input').clone());
    $('.file-upload-content').hide();
    $('.image-upload-wrap').show();
    $("#btnCargarArchivos").hide();
    $('.file-upload-input').val("");
    fileUpload = [];
    BorrarTablaFiles();
}

function SendServer(url, param, param2, sender, pfuncOk, pfuncError, isJson) {
    let formData = new FormData();
    for (var i = 0; i < fileUpload.length; i++) {
        formData.append('file', fileUpload[i]);
    }
    formData.append('param', param);
    formData.append('param2', param2);
    sendAjaxPostCoreForm(formData, url, "html", pfuncOk, pfuncError, sender, isJson);
}