
$(document).ready(function () {


   
});
function UploadFiles() {
    let resetInput = document.getElementById('file')
   
    var formData = new FormData();
    formData.append('file', $('#file')[0].files[0]);
    resetInput.value = '';
    $.ajax({
        url: '/ExcepcionesExcel/UploadFileExcel',
        type: 'POST',
        data: formData,
        processData: false,  // tell jQuery not to process the data
        contentType: false,  // tell jQuery not to set contentType
        success: function (data) {
            console.log(data);
            alert(data);
        }
    });
}
