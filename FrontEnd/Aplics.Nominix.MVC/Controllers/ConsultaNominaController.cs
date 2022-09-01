using Aplics.Nominix.DTOS.EmpleadosNomina;
using Aplics.Nominix.DTOS.Services;
using Aplics.Services.Empleados;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Aplics.Nominix.MVC.Controllers
{
    public class ConsultaNominaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ConsultarNomina(ConsultaNominaRequestDTO _Request)
        {
            ServiceResponse<List<ConsultaNominaResponseDTO>> _Response = new ServiceResponse<List<ConsultaNominaResponseDTO>>();
            CallServiceEmployer _Core = new CallServiceEmployer();
            try
            {
                _Response = _Core.ConsultaNomina(_Request);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(new { data = _Response.ResponseData });
        }
        [HttpPost]
        public JsonResult DetalleNominaEmpleado(int CodEmpleado)
        {
            ServiceResponse<List<DetalleNominaEmpleadoResponseDTO>> _Response = new ServiceResponse<List<DetalleNominaEmpleadoResponseDTO>>();
            CallServiceEmployer _Core = new CallServiceEmployer();
            try
            {
                _Response = _Core.DetalleConsultaNomina(CodEmpleado);
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(new { data = _Response.ResponseData });
        }
    }
}
