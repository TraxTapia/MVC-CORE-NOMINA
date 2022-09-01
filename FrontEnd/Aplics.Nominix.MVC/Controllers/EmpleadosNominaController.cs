
using Aplics.Nominix.DTOS.Services;
using Microsoft.AspNetCore.Mvc;
using Aplics.Services.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Aplics.Nominix.DTOS.EmpleadosNomina;
using Aplics.Nominix.DTOS.Enum;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Aplics.Nominix.MVC.Controllers
{
    public class EmpleadosNominaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ConceptoCatalogo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscarNominaEmpleado(ServiceRequest<FiltroNominaRequestDTO> _Request)
        {
            var data = new object();
            ServiceResponse<List<NominaEmpleadoResponseDTO>> _NominaEmpleadoResponse = new ServiceResponse<List<NominaEmpleadoResponseDTO>>();
            CallServiceEmployer _CoreService = new CallServiceEmployer();
            try
            {
                _NominaEmpleadoResponse = _CoreService.GetDataNominaEmpleado(_Request);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(new { data = _NominaEmpleadoResponse.ResponseData });

        }
        [HttpPost]
        public ActionResult BuscarNomina(ServiceRequest<FiltroNominaRequestDTO> _Request)
        {
            var data = new object();
            ServiceResponse<List<NominaResponseDTO>> _NominaResponse = new ServiceResponse<List<NominaResponseDTO>>();
            CallServiceEmployer _CoreService = new CallServiceEmployer();
            try
            {

                _NominaResponse = _CoreService.GetDataNomina(_Request);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(new { data = _NominaResponse.ResponseData });
            // return PartialView("_EmpleadoNomina", data = _NominaResponse.ResponseData);

        }
        public ActionResult BuscarConceptoCatalogo(string CodConcepto)
        {
            var data = new object();
            ServiceResponse<List<ConceptoCatalogoResponseDTO>> _Response = new ServiceResponse<List<ConceptoCatalogoResponseDTO>>();
            CallServiceEmployer _CoreService = new CallServiceEmployer();
            try
            {

                _Response = _CoreService.GetConceptoCatalogo(CodConcepto);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(new { data = _Response.ResponseData });
            // return PartialView("_EmpleadoNomina", data = _NominaResponse.ResponseData);

        }

        [HttpPost]
        public async Task<JsonResult> UploadFileExcel(ExcepcionesExcelRequestDTO _Request)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>();
            CallServiceEmployer _CoreService = new CallServiceEmployer();
            string _base64 = string.Empty;
            try
            {
                foreach (var file in  _Request.File)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            var fileBytes = ms.ToArray();
                          _Request.FileBase64 = Convert.ToBase64String(fileBytes);
                          
                        }
                    }
                }
                _Response = await _CoreService.ExcepcionesExcel(_Request);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(new { data = _Response });
        }
    }
}

