using Aplics.Nominix.DTOS.Finiquito;
using Aplics.Nominix.DTOS.Services;
using Aplics.Services.Empleados;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aplics.Nominix.MVC.Controllers
{
    public class FiniquitoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult ConsultarFiniquito(FiltrosRequestDTO _Request)
        {
            var _Result = new object();
            ServiceResponse<List<ConsultaFiniquitoResponseDTO>> _Response = new ServiceResponse<List<ConsultaFiniquitoResponseDTO>>();
            CallServiceEmployer _Service = new CallServiceEmployer();
            try
            {
                if (!(_Response = _Service.ConsultarFiniquito(_Request)).IsOK())
                    throw new Exception(string.Join(", ", _Response.Errors.Select(x => x.Message)));
                _Result = new { data = _Response.ResponseData, MessageException = string.Empty, IsOK = true };

            }
            catch (Exception ex)
            {
                _Result = new { IsOK = false, MessageException = ex.Message };
            }
            return Json(_Result);
        }
        [HttpPost]
        public JsonResult NuevoRegistroFiniquito(FiniquitoRequestDTO _Request)
        {
            var _Result = new object();
            ServiceResponse<string> _Response = new ServiceResponse<string>();
            CallServiceEmployer _Service = new CallServiceEmployer();
            try
            {
                if (!(_Response = _Service.AgregarNuevoFiniquito(_Request)).IsOK())
                    throw new Exception(string.Join(", ", _Response.Errors.Select(x => x.Message)));
                _Result = new { MessageException = _Response.Message, IsOK = true };
            }
            catch (Exception ex)
            {
                _Result = new { IsOK = false, MessageException = ex.Message };
            }
            return Json(_Result);
        }
        [HttpPost]
        public JsonResult ActualizarFiniquito(FiniquitoRequestDTO _Request)
        {
            var _Result = new object();
            ServiceResponse<string> _Response = new ServiceResponse<string>();
            CallServiceEmployer _Service = new CallServiceEmployer();
            try
            {
                if (!(_Response = _Service.AgregarNuevoFiniquito(_Request)).IsOK())
                    throw new Exception(string.Join(", ", _Response.Errors.Select(x => x.Message)));
                _Result = new { MessageException = _Response.Message, IsOK = true };
            }
            catch (Exception ex)
            {
                _Result = new { IsOK = false, MessageException = ex.Message };
            }
            return Json(_Result);
        }
        [HttpPost]
        public JsonResult EliminarRegistroById(string _CodEmpleados)
        {
            var _Result = new object();
            ServiceResponse<string> _Response = new ServiceResponse<string>();
            CallServiceEmployer _Service = new CallServiceEmployer();
            try
            {
                _Response = _Service.EliminarFiniquitoById(_CodEmpleados);
                if (_Response.Code == ServiceResponse<string>.StatusCodesEnum.CONFLICT.ToString("D"))
                    return Json(new { Error = string.Empty, IsOK = false, Code = ServiceResponse<string>.StatusCodesEnum.CONFLICT });
                if (!_Response.IsOK() && _Response.Code != ServiceResponse<string>.StatusCodesEnum.ACCEPTED.ToString("D"))
                    throw new Exception(string.Join(", ", _Response.Errors.Select(x => x.Message)));
                _Result = new { Error = string.Empty, IsOK = true, Code = ServiceResponse<string>.StatusCodesEnum.OK };
            }
            catch (Exception ex)
            {
                _Result = new { IsOK = false, MessageException = ex.Message, Code = ServiceResponse<string>.StatusCodesEnum.INTERNAL_SERVER_ERROR };
            }
            return Json(_Result);
        }

    }
}
