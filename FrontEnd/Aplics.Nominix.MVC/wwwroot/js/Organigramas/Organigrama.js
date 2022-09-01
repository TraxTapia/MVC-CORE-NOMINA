var organigrama;
var sizeOrganigrama;
var urlDetalleIndex;
var urlOrganigramaIndex;
var urlPlazaIndex;
var urlPlazaGrupal;
var urlRequisicionCreate;
var urlReemplazo;
var urlExportPDF;
var empleadoActual;
var tipoUsuario;
var mostrarSueldos;
var edus;
function onChangeLevel() {
    document.getElementById("level-form").submit();
}

function drawChart() {
    try {
        var jsonOrganigrama = JSON.parse(organigrama);  //Creamos un arreglo de elementos JSON
    }
    catch (e) {
        console.log(e);
    }
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'id');
    data.addColumn('string', 'Manager');
    data.addColumn('string', 'ToolTip');
    var raiz = true;
    var styleNodeVar;
    if (tipoUsuario === "1") {
        styleNodeVar = "styleNode more";
    }
    else {
        styleNodeVar = "styleNode more act";
    }

    function formatMoney(num) {
        return "$" + num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
    }

    function createEmpleado(data, styleNodeVar) {
        var estiloEmp = "";
        var requisicion = "";
        if (empleadoActual === data.id.toString()) { estiloEmp = "color: red;"; }
        var nodo = '<div class="styleNode"><table>';
        requisicion = "";
        if (data.reqAbierta !== "") {
            requisicion = "<br/><span>(REQUISICIÓN  ENVIADA No." + data.reqAbierta + ")</span>";
        }
        var nombrePlaza = data.nombres;
        var apellidos = data.apellidos;
        if (data.nombre === "" || data.nombre==="VACANTE") {
            nombrePlaza = "VACANTE";
            apellidos = "";
        }
        if (data.tipoPlaza === "G") {
            apellidos = "Sindicalizado (Plaza Grupal)"
            nombrePlaza = "Aut: " + data.plazaAutorizada + " Ocu: " + data.plazaOcupada;
        } 
        if (apellidos !== "") {
            apellidos = '<span>' + apellidos + '</span><br/>';
        }
        nombrePlaza = apellidos + nombrePlaza;
        nodo += '<tr><td class="td_h">Nombre</td><td style="' + estiloEmp + '"><b>' + nombrePlaza + '</b>' + requisicion + '</td></tr>';    

        nodo += '<tr><td class="td_h">Puesto</td><td>' + data.puesto + '</td></tr>' +
            '<tr><td class="td_h">Loc.</td><td>' + data.localidadCadena + '</td></tr>' +
            '<tr><td class="td_h">Dep.</td><td>' + data.departamento + '</td></tr>';
           
        if (mostrarSueldos === 1) {
            nodo += '<tr><td class="td_h">Sueldo</td><td>' + (data.sueldo !== "" ? formatMoney(data.sueldo) : "No registrado") + '</td></tr>';
        }

        if (edus === 1) {
            nodo += '<tr style="height: 15px;"><td colspan="2" align="right"><a href="' + urlDetalleIndex + '?id=' + data.id.toString() + '">+ Más Info</a></td></tr>';
        }
        nodo+='</table></div>'; 
         

        if (data.tienePersonal === "1" && empleadoActual !== data.id.toString() && !raiz && edus === 1) {
            nodo += '<a href="' + urlOrganigramaIndex + '?id=' + data.id.toString() + '&varupd=true&VisualizarSueldos=' + mostrarSueldos + '" style="text-decoration:none">' +
                '<div class="styleNode more"><h6>Mostrar desde aquí</h6></div>' +
                '</a>';
        }

        if (data.tipoPlaza === "G") {
            nodo += "<a href='#' onclick='MostrarEmpleadosPlaza(" + JSON.stringify(data) + ");' style='text-decoration:none'>" +
                '<div class="styleNode more"><h6>Consultar Empleados</h6></div></a>';
        }
        var poc = data.plazaOcupada;
        var paut = data.plazaAutorizada;
        if (parseInt(paut) >parseInt(poc) && data.reqAbierta === "" && edus === 1) {
            if (data.plaza === undefined) {
                data.plaza = "";
            }
            var cvePlaza = data.plaza;
            if (cvePlaza === "") { cvePlaza = "0"; }
            var paramReq = "'" + data.compania + "','" + data.localidad + "','" + data.direccion + "','" + data.claveDepartamento + "'," + data.clavePuesto + "," + cvePlaza;
            nodo += '<a href="#" onclick="CrearRequisicion(this,' + paramReq + ');return false;" style="text-decoration:none">' +
                '<div class="styleNode replace"><h6>Crear Requisición</h6></div>' +
                '</a>';
        }

        if (empleadoActual !== data.id.toString() && !raiz && data.nombre !== "" && data.solPAbierta === "" && edus === 1) {
        /*var params = "&puesto=" + data.puesto + "&localidad=" + data.localidad + "&departamento=" + data.departamento + "&plazaOcupada=" + data.plaza;*/
        /*var params = "&puesto=" + data.puesto + "&localidad=" + data.localidad + "&departamento=" + data.departamento + "&plazaOcupada=" + data.plaza + "&TipoPza=" + data.tipoPlaza;*/
            var params = "&puesto=" + data.puesto + "&localidad=" + data.localidad + "&departamento=" + data.departamento + "&plazaOcupada=" + data.plaza + "&TipoPza=" + data.tipoPlaza + "&compania=" + data.compania + "&direccion=" + data.direccion + "&cvedepto=" + data.claveDepartamento + "&cvepuesto=" + data.clavePuesto + "&plaza=" + data.plaza;
            nodo += '<a href="' + urlPlazaIndex + '?id=' + data.id.toString() + params + '" style="text-decoration:none">' +
                '<div class="styleNode replace"><h6>Ampliar</h6></div>' +
                '</a>';
        }
        
        if (empleadoActual !== data.id.toString() && !raiz && data.nombre !== "" && data.solReempAbierta === "" && edus === 1) {
            var paramsR = "&nombre=" + data.nombre + "&puesto=" + data.puesto + "&localidad=" + data.localidad + "&departamento=" + data.departamento + "&plazaOcupada=" + data.plaza;
            nodo += '<a href="' + urlReemplazo + '?id=' + data.id.toString() + paramsR + '" style="text-decoration:none">' +
                '<div class="styleNode replace"><h6>Revisar</h6></div>' +
                '</a>';
        }
        raiz = false;
        return nodo;
    }

    function createPlaza(data, styleNodeVar) {
        var nodo = '<a href="' + urlDetalleIndex + '?id=0" style="text-decoration:none">' +
            '<div class="styleNode">' +
            '<table>' +
            '<tr><td class="td_h"></td><td><b>' + "Plaza vacía" + '</b></td></tr>' +
            '<tr><td class="td_h">Puesto</td><td>' + data.puesto + '</td></tr>' +
            '<tr><td class="td_h">Loc.</td><td>' + data.localidadCadena + '</td></tr>' +
            '<tr><td class="td_h">Dep.</td><td>' + data.departamento + '</td></tr>' ;
        if (mostrarSueldos === 1) {
            nodo += '<tr><td class="td_h">Sueldo</td><td>' + (data.sueldo !== "" ? formatMoney(data.sueldo) : "No registrado") + '</td></tr>';
        }
        nodo += '</table></div></a>';

        if (data.tienePersonal === "1" && empleadoActual !== data.id.toString() && !raiz && edus === 1) {
            nodo += '<a href="' + urlOrganigramaIndex + '?id=' + data.id.toString() + '" style="text-decoration:none">' +
                '<div class="styleNode more"><h6>Mostrar desde aquí</h6></div>' +
                '</a>';
        }

        if (data.nombre === "" && data.reqAbierta === "" && edus === 1) {
            if (data.plaza === undefined) {
                data.plaza = "";
            }
            var cvePlaza = data.plaza;
            if (cvePlaza === "") { cvePlaza = "0"; }
            var paramReq = "'" + data.compania + "','" + data.localidad + "','" + data.direccion + "','" + data.claveDepartamento + "'," + data.clavePuesto + "," + cvePlaza;
            nodo += '<a href="#" onclick="CrearRequisicion(this,' + paramReq + ');return false;" style="text-decoration:none">' +
                '<div class="styleNode replace"><h6>Crear Requisición</h6></div>' +
                '</a>';
        }

        if (empleadoActual !== data.id.toString() && !raiz && data.solPAbierta === "" && edus === 1) {
            nodo += '<a href="' + urlPlazaIndex + '" style="text-decoration:none">' +
                '<div class="' + styleNodeVar + '"><h6>Ampliar</h6></div>' +
                '</a>';
         }

        if (empleadoActual !== data.id.toString() && !raiz && data.nombre !== "" && data.solReempAbierta === "" && edus === 1) {
            data.plaza = data.plaza === undefined ? "" : data.plaza;
            var cvePlazaR = data.plaza;
            if (cvePlazaR === "") { cvePlazaR = "0"; }
            var paramsR = "&nombre=" + data.nombre + "&puesto=" + data.puesto + "&localidad=" + data.localidad + "&departamento=" + data.departamento + "&plazaOcupada=" + cvePlazaR;
            nodo += '<a href="' + urlReemplazo + '?id=' + data.id.toString() +  paramsR +  + '" style="text-decoration:none">' +
                '<div class="styleNode replace"><h6>Revisar</h6></div>' +
                '</a>';
        }

        raiz = false;
        return nodo;
    }

    var strPadre;
    var strHijos;
    if (jsonOrganigrama.organigrama[0].id !== 0) { //Se añade el nodo padre
        strPadre = createEmpleado(jsonOrganigrama.organigrama[0], styleNodeVar);
        data.addRows([[{ 'v': jsonOrganigrama.organigrama[0].numEmp.toString(), 'f': strPadre }, "", ""]]); //Se añade el nodo padre
    }
    else {
        strPadre = createPlaza(jsonOrganigrama.organigrama[0], styleNodeVar);
        data.addRows([[{ 'v': jsonOrganigrama.organigrama[0].numEmp.toString(), 'f': strPadre }, "", ""]]); //Se añade el nodo padre
    }

    for (var i = 1; i < sizeOrganigrama; ++i) { //Se añaden los nodos hijos
        if (jsonOrganigrama.organigrama[i].id !== 0) {
            strHijos = createEmpleado(jsonOrganigrama.organigrama[i], styleNodeVar);
            data.addRows([[{ 'v': jsonOrganigrama.organigrama[i].numEmp.toString(), 'f': strHijos }, jsonOrganigrama.organigrama[i].numEmpSup.toString(), ""]]);  //Se añaden los nodos hijos
        }
        else {
            strHijos = createPlaza(jsonOrganigrama.organigrama[i], styleNodeVar);
            data.addRows([[{ 'v': jsonOrganigrama.organigrama[i].numEmp.toString(), 'f': strHijos }, jsonOrganigrama.organigrama[i].numEmpSup.toString(), ""]]);  //Se añaden los nodos hijos con número de empleado == 0
        }
    }

    var chart = new google.visualization.OrgChart(document.getElementById('chart_div'));

    chart.draw(data, {
        allowHtml: true,
        nodeClass: 'myNodeClas',
        size: 'small',
        chartArea: {
            // leave room for y-axis labels
            width: '94%'
        },
        legend: {
            position: 'top'
        },
        width: '100%'
    });
}

function exportPdf() {
    $("#pdfButton").html("Exportando...");
    $(".styleNode.more").css("display", "none");
    $(".styleNode.replace").css("display", "none");
    printScreen();
}

function printScreen() {
    var node = document.getElementById("chart_div");
    domtoimage.toPng(node).then(function (dataUrl) {
        var imgb64 = dataUrl.replace(/^data:image.+;base64,/, '');
        $("#imgPDF").val(imgb64);
        $("#pdfButton").html("Exportar a PDF");
        $(".styleNode.more").css("display", "block");
        $(".styleNode.replace").css("display", "block");
        SendImage(imgb64);
    }).catch(function (error) {
        console.error('oops, something went wrong!', error);
    });
}

function MostrarEmpleadosPlaza(data) {
    var popup = $("#modalGrupal");
    var pData = {
        "compania": data.compania, "localidad": data.localidad,
        "direccion": data.direccion, "claveDepartamento": data.claveDepartamento,
        "clavePuesto": data.clavePuesto, "plaza": data.plaza
    };
    sendAjaxPostCore(pData, urlPlazaGrupal, "html", ListaEmpleadosPlaza, errorPlaza, popup, false);
}

function ListaEmpleadosPlaza(result, psender) {
    $("#Plaza_Empleados").html(result);
    $("#modalGrupal").modal("show");
}

function errorPlaza(xhr) {
    alert("Error al consultar la plaza " + xhr);
}

function padLeft(n) {
    return ("00" + n).slice(-2);
}

function formatDate() {
    var d = new Date(),
        dformat = [padLeft(d.getDate()),
            padLeft(d.getMonth() + 1),
            d.getFullYear()].join('/');
    dformat += " " + [padLeft(d.getHours()), padLeft(d.getMinutes())].join(':');
    return dformat;
}

function CrearRequisicion(btn, compania, localidad, direccion, departamento, clavePuesto, plaza) {
    $(btn).hide();
    var pData = {
        "Compañia": compania, "Localidad": localidad,
        "Direccion": direccion, "Departamento": departamento,
        "Puesto": clavePuesto, "Plaza": plaza
    };
    sendAjaxPostCore(pData, urlRequisicionCreate, "html", notificarReq, errorReq, btn, false);
}

function notificarReq(result, psender) {
    if (result === "") {
        alert("Requisición creada con éxito");
    } else {
        $(psender).show();
        alert("Error al crear la requisición " + result);
    }
}

function errorReq(xhr) {
    alert("Error al crear la requisición " + xhr);
}

function SendImage(imgData) {
    var sender = $("#pdfprint-form");
    var pData = { "img": imgData };
    sendAjaxPostCore(pData, urlExportPDF, "html", descargaPDF, errorDescarga, sender, false);
}

function descargaPDF(result, psender) {
    if (result !== "") {
        $("#imgPDF").val(result);
        $(psender).submit();
    } else {
        alert("Error al generar el organígrama.");
    }
}

function errorDescarga(xhr) {
    alert("Error al generar el organígrama." + xhr);
}

function sendAjaxPostCore(filters, purl, pdatatype, pfuncexito, pfuncerror, psender, JsonResult) {
    $.ajax({
        url: purl,
        type: 'POST',
        cache: false,
        async: true,
        dataType: pdatatype,
        data: filters,
        beforeSend: function () {

        }
    })
        .done(function (result) {
            if (JsonResult) {
                pfuncexito(JSON.parse(result), psender);
            } else {
                pfuncexito(result, psender);
            }
        })
        .always(function () {

        })
        .fail(function (xhr) {
            pfuncerror(xhr);
        });
}