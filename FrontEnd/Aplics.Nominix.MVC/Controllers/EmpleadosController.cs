
using Aplics.Nominix.DTOS;
using Aplics.Nominix.DTOS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Aplics.Services.Empleados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Nomina2.Controllers
{
    public class EmpleadosController : Controller
    {
        public string UrlEndPoint = "https://localhost:44347/";
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ActualizarEmpleado(string CodeEmpleado)
        {
            ViewBag.Code = CodeEmpleado;
            return View();
        }
        public ActionResult Empleado()
        {

            return View();
        }
        public ActionResult Ubicaciones()
        {
            return PartialView("_UbicacionVP");
        }
        public ActionResult FechasSueldos()
        {
            return PartialView("_FechasSueldosVP");
        }
        public ActionResult FiscalesPersonales()
        {
            return PartialView("_FiscalesPersonalesVP");
        }
        public ActionResult ReingresoEmpleados(string codCodigo)
        {
            ViewBag.codCodigo = codCodigo;
            return View();
        }
        [HttpPost]
        public ActionResult GetEmpleados()
        {
            ServiceResponse<List<dto_Empleados>> _Response = new ServiceResponse<List<dto_Empleados>>();
            CallServiceEmployer _Serice = new CallServiceEmployer();
            try
            {
                _Response = _Serice.GetEmpleados();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(new { data = _Response.ResponseData });
        }
        [HttpPost]
        public JsonResult DeleteEmployeByCode(int Id)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>();
            CallServiceEmployer _Serice = new CallServiceEmployer();
            try
            {
                _Response = _Serice.DeleteEmployerById(Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(_Response);
        }
        [HttpPost]
        public JsonResult FiltroBusquedaEmpleados(int IdCompania, int IdLocalidad)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>();
            CallServiceEmployer _Serice = new CallServiceEmployer();
            try
            {
                _Response = _Serice.FiltroBusquedaEmpleados(IdCompania, IdLocalidad);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(_Response);
        }
        [HttpPost]
        public JsonResult GetDataSelect(string Identificador, string TipoSelect)
        {
            ServiceResponse<List<dto_ComboGral>> _Response = new ServiceResponse<List<dto_ComboGral>>();
            CallServiceEmployer _Serice = new CallServiceEmployer();
            try
            {
                _Response = _Serice.GetSelectGral(TipoSelect, UrlEndPoint);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(new { data = _Response.ResponseData });
        }
        [HttpPost]
        public JsonResult AgregarEmpleado(string Name)
        {

            ServiceResponse<string> _Response = new ServiceResponse<string>();
            CallService _Serice = new CallService();
            try
            {
                _Response = _Serice.AgregarEmpleado(Name);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(_Response);

        }
        [HttpPost]
        public JsonResult ObtenerEmpleadoByCode( string Code)
        {
            ServiceResponse<dto_Empleados> _Response = new ServiceResponse<dto_Empleados>();
            string _ApiUrl = "https://localhost:44347/";
            string recurso = "Actualizar";
            string _Token = "prueba904894u4398";
            CallServiceEmployer _Serice = new CallServiceEmployer();
            try
            {
                _Response = _Serice.ObtenerEmpleadoByCode(Code, _ApiUrl, recurso, _Token);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(_Response);
        }
        [HttpPost]
        public JsonResult UpdateEmpleado(ServiceRequest<dto_Empleados> _Request)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>();
            string _ApiUrl = "https://localhost:44347/";
            string recurso = "Actualizar";
            string _Token = "prueba904894u4398";
            CallServiceEmployer _Service = new CallServiceEmployer();
            try
            {
                _Response = _Service.ActualizarEmpleado(_Request, _ApiUrl, recurso, _Token);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(_Response);
        }
        [HttpPost]
        public JsonResult ReingresoEmpleado(ServiceRequest<dto_Empleados> _Request)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>();
            string _ApiUrl = "https://localhost:44347/";
            string recurso = "Actualizar";
            string _Token = "prueba904894u4398";
            CallServiceEmployer _Service = new CallServiceEmployer();
            try
            {
                _Response = _Service.ReingresoEmpleado(_Request, _ApiUrl, recurso, _Token);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error " + ex.Message);
            }
            return Json(_Response);
        }
      
        
    }
}
