#pragma checksum "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Shared\_EmpleadosPlazas.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e208cebb0079b814501def8ece1a13058f789565"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__EmpleadosPlazas), @"mvc.1.0.view", @"/Views/Shared/_EmpleadosPlazas.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e208cebb0079b814501def8ece1a13058f789565", @"/Views/Shared/_EmpleadosPlazas.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"130ca5bf84dc986f25aecee20ba7740ab7969c7d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__EmpleadosPlazas : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Aplics.Nominix.DTOS.dto_PlazasEmpleados>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"ibox-content\"");
            BeginWriteAttribute("style", " style=\"", 88, "\"", 96, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n    <table class=\"table table-bordered\">\r\n        <thead>\r\n            <tr>\r\n                <th>Nombre</th>\r\n                <th>Apellido Paterno</th>\r\n                <th>Apellido Materno</th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 14 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Shared\_EmpleadosPlazas.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 17 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Shared\_EmpleadosPlazas.cshtml"
                   Write(Html.DisplayFor(modelitem => item.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 18 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Shared\_EmpleadosPlazas.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ApellidoPaterno));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 19 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Shared\_EmpleadosPlazas.cshtml"
                   Write(Html.DisplayFor(modelItem => item.ApellidoMaterno));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 21 "C:\Users\ivan.tapia\Desktop\proyect\FrontInspinia\FrontEnd\Aplics.Nominix.MVC\Views\Shared\_EmpleadosPlazas.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Aplics.Nominix.DTOS.dto_PlazasEmpleados>> Html { get; private set; }
    }
}
#pragma warning restore 1591
