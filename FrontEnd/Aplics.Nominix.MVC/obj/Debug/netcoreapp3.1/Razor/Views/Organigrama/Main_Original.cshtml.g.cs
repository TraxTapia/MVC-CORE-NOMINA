#pragma checksum "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Organigrama\Main_Original.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20ae7cbb1fd8c556af1dabf965a352f6e88179bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Organigrama_Main_Original), @"mvc.1.0.view", @"/Views/Organigrama/Main_Original.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\_ViewImports.cshtml"
using Aplics.Nominix.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Organigrama\Main_Original.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20ae7cbb1fd8c556af1dabf965a352f6e88179bc", @"/Views/Organigrama/Main_Original.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"130ca5bf84dc986f25aecee20ba7740ab7969c7d", @"/Views/_ViewImports.cshtml")]
    public class Views_Organigrama_Main_Original : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/popupClass.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Libraries/assets/js/domToImage.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/Organigramas/Organigrama.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Organigrama\Main_Original.cshtml"
  
    ViewData["Title"] = "Organigrama";
    //Layout = "~/Views/OrganigramaLayout.cshtml";
    var org = ViewBag.organigrama;
    var size = ViewBag.sizeOrganigrama;
    var rh = ViewBag.RH;
    var edicion = ViewBag.OrganigramaEdicion == null ? 0 : ViewBag.OrganigramaEdicion;
    var urlOrganigramaIndex = @Url.Action("Index", "Organigrama");
    var urlPlazaGrupal = @Url.Action("PlazaGrupal", "Organigrama");
    int posIndex = urlOrganigramaIndex.IndexOf("Index");
    int mostrarSueldo = 0;
    const string SessionSueldos = "PermisoSueldos";
    //mostrarSueldo = ViewBag.mostrarSueldo == null ? int.Parse(Context.Session.GetString(SessionSueldos)) : ViewBag.mostrarSueldo;
    mostrarSueldo = ViewBag.mostrarSueldo == null ? 0 : ViewBag.mostrarSueldo;
    if (posIndex > 0)
    {
        urlOrganigramaIndex = urlOrganigramaIndex.Substring(0, posIndex + 5);
    }
    else
    {
        urlOrganigramaIndex = String.Concat(urlOrganigramaIndex, "/Index");
    }
    String checkSi = mostrarSueldo == 1 ? "checked" : "";
    String checkNo = mostrarSueldo != 1 ? "checked" : "";
    var urlPlazaIndex = @Url.Action("Index", "CreacionPlaza");
    var urlReemplazo = @Url.Action("Reemplazo", "CreacionPlaza");
    var urlDetalleIndex = @Url.Action("Index", "Detalle");
    var urlRequisicionCreate = @Url.Action("Create", "Requisiciones");
    var urlExportPDF = Url.Action("OrganigramaFromImg", "Organigrama");

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "20ae7cbb1fd8c556af1dabf965a352f6e88179bc6439", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<script type=\"text/javascript\" src=\"https://www.gstatic.com/charts/loader.js\"></script>\r\n<script src=\"https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.3.2/jspdf.min.js\"></script>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20ae7cbb1fd8c556af1dabf965a352f6e88179bc7741", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            WriteLiteral(@"<script type=""text/javascript"">
    google.charts.load('current', { packages: [""orgchart""] });
    google.charts.setOnLoadCallback(drawChart);

    function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Name');
        data.addColumn('string', 'Manager');
        data.addColumn('string', 'ToolTip');

        // For each orgchart box, provide the name, manager, and tooltip to show.
        data.addRows([
            [{ 'v': 'Mike', 'f': 'Mike<div style=""color:red; font-style:italic"">President</div>' },
                '', 'The President'],
            [{ 'v': 'Jim', 'f': 'Jim<div style=""color:red; font-style:italic"">Vice President</div>' },
                'Mike', 'VP'],
            ['Alice', 'Mike', ''],
            ['Bob', 'Jim', 'Bob Sponge'],
            ['Carol', 'Bob', '']
        ]);

        // Create the chart.
        var chart = new google.visualization.OrgChart(document.getElementById('chart_div'));
        // Draw th");
            WriteLiteral(@"e chart, setting the allowHtml option to true for the tooltips.
        chart.draw(data, { 'allowHtml': true });
    }
</script>

<style>

    body {
        background: white;
    }

    /*.main-div.overflow {
        overflow-y: visible;
        overflow-x: visible;
    }*/

    .main-div.inn {
        zoom: 60%;
        padding: 48px;
    }

    .styleNode {
        min-width: 400px;
        border: 1px solid #aaa;
        padding: 6px;
        -webkit-box-shadow: 1px 1px 5px 0px rgba(0, 0, 0, 0.35);
        -moz-box-shadow: 1px 1px 5px 0px rgba(0, 0, 0, 0.35);
        box-shadow: 1px 1px 5px 0px rgba(0, 0, 0, 0.35);
    }

        .styleNode table {
            font-size: 15px;
            margin: 17px 14px;
            width: 100%;
        }

            .styleNode table .td_h {
                text-align: left;
                font-size: 14px;
                max-width: 21px;
            }

        .styleNode img {
            width: 70px;
            border-r");
            WriteLiteral(@"adius: 50%;
        }

        .styleNode .aux {
            display: none;
        }

        .styleNode img.top {
            width: 120px;
        }

        .styleNode h3 {
            font-size: 14px;
        }

        .styleNode.more {
        }

            .styleNode.more.act {
                display: none;
            }

    .google-visualization-orgchart-linenode {
        border-color: #FF5A00 !important;
        border-left-width: 4px !important;
        border-right-width: 4px !important;
        border-bottom-width: 3px !important;
    }

    .google-visualization-orgchart-lineleft,
    .google-visualization-orgchart-lineright {
        padding: 7px 2px;
    }

    .google-visualization-orgchart-linenode,
    .myNodeClas {
        background-color: transparent;
    }

    google-visualization-orgchart-table > * {
        background-color: transparent;
    }

    .options {
        position: absolute;
        z-index: 100;
        background-color: ");
            WriteLiteral(@"#fff;
        border: 1px solid #a0a0a0;
        border-radius: 10px;
        padding: 15px 14px;
        font-size: 17px;
    }

    .callButton {
        margin-top: 0px;
        width: 260px;
    }

    .selectButton,
    .exportButton {
        width: 260px !important;
    }

    .exportButton {
        margin-top: 10px;
        color: #FF5A00;
        background: white;
    }

    .options form {
        display: inline;
    }

        .options form select {
            width: 100%;
            margin-top: 7px;
            margin-bottom: 15px;
        }
</style>
<!-- / JAVASCRIPT -->
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20ae7cbb1fd8c556af1dabf965a352f6e88179bc12622", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 186 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Organigrama\Main_Original.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            WriteLiteral("\r\n<div class=\"container main-div\">\r\n    <div class=\"row h-85 main-div\">\r\n        <div class=\"col main-div inn\">\r\n            <div class=\"options\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-12\">\r\n");
#nullable restore
#line 214 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Organigrama\Main_Original.cshtml"
                         using (Html.BeginForm("BusquedaSimple", "Organigrama", FormMethod.Post, new { id = "level-form", style = "margin-bottom: 0px" }))
                        {
                            

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input type=\"hidden\"");
            BeginWriteAttribute("value", " value=\"", 6946, "\"", 6962, 1);
#nullable restore
#line 217 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Organigrama\Main_Original.cshtml"
WriteAttributeValue("", 6954, edicion, 6954, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"pvarupd\" id=\"HFpvarupd\" />\r\n");
#nullable restore
#line 218 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Organigrama\Main_Original.cshtml"
                             if (edicion == 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""row"">
                                    <div class=""col-12"">
                                        <span>Nivel de Visualización</span>
                                    </div>
                                </div>
                                <div class=""row"">
                                    <div class=""col-12"">
");
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 234 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Organigrama\Main_Original.cshtml"
                            }
                            else
                            {
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <input type=\"hidden\" value=\"0\" name=\"Nivel\" id=\"HFNivel\" />\r\n");
#nullable restore
#line 239 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Organigrama\Main_Original.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 254 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Organigrama\Main_Original.cshtml"
                               
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n                <div class=\"row text-center\">\r\n                    <div class=\"col-12\">\r\n");
#nullable restore
#line 260 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Organigrama\Main_Original.cshtml"
                         using (Html.BeginForm("PDFOrganigrama1N", "Organigrama", FormMethod.Post, new { id = "pdfprint-form", style = "margin-bottom: 0px" }))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"row\">\r\n                                <button type=\"submit\" id=\"pdfButton1N\" class=\"callButton btn scrollbar fontColor\">PDF 1 Nivel</button>\r\n                            </div>\r\n");
            WriteLiteral("                            <input type=\"hidden\" name=\"IdEmpleado\" id=\"IdEmpleado\" value=\"0\" />\r\n                            <input type=\"hidden\" name=\"imgPDF\" id=\"imgPDF\"");
            BeginWriteAttribute("value", " value=\"", 10310, "\"", 10318, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                            <input type=\"hidden\" name=\"mostrarSueldos\" id=\"hfmostrarSueldos\"");
            BeginWriteAttribute("value", " value=\"", 10416, "\"", 10438, 1);
#nullable restore
#line 272 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Organigrama\Main_Original.cshtml"
WriteAttributeValue("", 10424, mostrarSueldo, 10424, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 273 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Organigrama\Main_Original.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>
                </div>
            </div>
            <div id=""chart_div"" style=""max-width: 1280px"">

            </div>
        </div>
    </div>
    <div class=""modal fade"" id=""modalGrupal"" role=""dialog"" data-backdrop=""static"" data-keyboard=""false"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h3 class=""modal-title"">Plaza Grupal</h3>
                </div>
                <div class=""modal-body"" id=""Plaza_Empleados"">
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-danger btn-sm"" data-dismiss=""modal"">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
</div>


");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
