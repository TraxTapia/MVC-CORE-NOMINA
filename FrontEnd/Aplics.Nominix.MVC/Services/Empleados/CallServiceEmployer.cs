using System;
using System.Collections.Generic;
using System.Text;
using Aplics.Nominix.DTOS.Services;
using Aplics.Nominix.DTOS;
using Aplics.Servicios.Client;
using Aplics.Nominix.DTOS.EmpleadosNomina;
using System.Threading.Tasks;
using System.Linq;
using Aplics.Nominix.DTOS.Finiquito;

namespace Aplics.Services.Empleados
{
    public class CallServiceEmployer
    {
        private string UrlEndPoint;
        public CallServiceEmployer()
        {
            this.UrlEndPoint = string.Empty;
        }

        public bool ExisteEndPoint()
        {
            return !String.IsNullOrEmpty(this.UrlEndPoint);
        }
        public void SetEndPoint(string UrlEndPoint)
        {
            this.UrlEndPoint = UrlEndPoint;
        }
        public ServiceResponse<List<dto_Empleados>> GetEmpleados()
        {
            ServiceResponse<List<dto_Empleados>> _Response = new ServiceResponse<List<dto_Empleados>>()
            {
                ResponseData = new List<dto_Empleados>(),
                Code = "200",
                Message = "Ok"
            };
            List<dto_Empleados> _List = new List<dto_Empleados>();
            _List.Add(new dto_Empleados()
            {
                Code = "001",
                Name = "Empleado Goku",
                Estatus = "Activo",
                Compania = "Aplics",
                Direccion = "Administrativo",
                Localidad = "Ciudad de México",
                Departamento = "Dirección General",
                Puesto = "Dirección General",
                CentroCostos = "000"
            });
            _List.Add(new dto_Empleados()
            {
                Code = "002",
                Name = "Empleado Vegueta",
                Estatus = "Activo",
                Compania = "Aplics",
                Direccion = "Administrativo",
                Localidad = "Ciudad de México",
                Departamento = "Dirección General",
                Puesto = "Dirección General",
                CentroCostos = "000"

            });
            _List.Add(new dto_Empleados()
            {
                Code = "003",
                Name = "Empleado Krilin",
                Estatus = "Activo",
                Compania = "Aplics",
                Direccion = "Administrativo",
                Localidad = "Ciudad de México",
                Departamento = "Dirección General",
                Puesto = "Gerente General",
                CentroCostos = "000"
            });
            _List.Add(new dto_Empleados()
            {
                Code = "004",
                Name = "Empleado Trunks",
                Estatus = "Inactivo",
                Compania = "Aplics",
                Direccion = "Administrativo",
                Localidad = "Ciudad de México",
                Departamento = "Dirección Sistemas",
                Puesto = "Dirección Sistemas",
                CentroCostos = "000"
            });
            _List.Add(new dto_Empleados()
            {
                Code = "005",
                Name = "Empleado Picolo",
                Estatus = "Activo",
                Compania = "Aplics",
                Direccion = "Administrativo",
                Localidad = "Ciudad de México",
                Departamento = "Dirección General",
                Puesto = "Dirección Operaciones",
                CentroCostos = "000"
            });
            _Response.ResponseData = _List;
            return _Response;
        }
        public ServiceResponse<List<dto_ComboGral>> GetSelectGral(string _TipoSelect, string _RouteApi)
        {

            ServiceResponse<List<dto_ComboGral>> _Response =
             new ServiceResponse<List<dto_ComboGral>>()
             {
                 ResponseData = new List<dto_ComboGral>(),
                 Code = "200",
                 Message = "Ok"
             };

            if (_TipoSelect == "Plaza")
            {
                List<dto_ComboGral> _List = new List<dto_ComboGral>();
                _List.Add(new dto_ComboGral()
                {
                    Valor = "1",
                    Descripcion = "Plaza 1"
                });
                _List.Add(new dto_ComboGral()
                {
                    Valor = "2",
                    Descripcion = "Plaza 2"
                });
                _List.Add(new dto_ComboGral()
                {
                    Valor = "3",
                    Descripcion = "Plaza 3"
                });
                _List.Add(new dto_ComboGral()
                {
                    Valor = "4",
                    Descripcion = "Plaza 4"
                });
                _List.Add(new dto_ComboGral()
                {
                    Valor = "5",
                    Descripcion = "Plaza 5"
                });
                _Response.ResponseData = _List;

            }
            else
            {
                List<dto_ComboGral> _List = new List<dto_ComboGral>();
                _List.Add(new dto_ComboGral()
                {
                    Valor = "1",
                    Descripcion = "datos dummy 1"
                });
                _List.Add(new dto_ComboGral()
                {
                    Valor = "2",
                    Descripcion = "datos dummy 2"
                });
                _List.Add(new dto_ComboGral()
                {
                    Valor = "3",
                    Descripcion = "datos dummy 3"
                });
                _List.Add(new dto_ComboGral()
                {
                    Valor = "4",
                    Descripcion = "datos dummy 4"
                });
                _List.Add(new dto_ComboGral()
                {
                    Valor = "5",
                    Descripcion = "datos dummy 5"
                });
                _Response.ResponseData = _List;
            }
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);

            return _Response;
        }
        public ServiceResponse<string> DeleteEmployerById(int id)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>()
            {
                Message = "ISOK",
                Errors = null,
                Code = "200"
            };
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);

            return _Response;
        }
        public ServiceResponse<string> AgregarEmpleado(string Name)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>()
            {
                Message = "ISOK",
                Errors = null,
                Code = "200"
            };
            if (string.IsNullOrEmpty(Name))
            {
                _Response.Message = string.Empty;
                _Response.Code = "500";
                _Response.Errors = new List<Exception>() { new Exception("Ocurrio un error") };
            }
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);

            return _Response;
        }
        public ServiceResponse<string> FiltroBusquedaEmpleados(int IdCompania, int IdLocalidad)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>()
            {
                Message = "ISOK",
                Errors = null,
                Code = "200"
            };
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);

            return _Response;
        }
        public ServiceResponse<dto_Empleados> ObtenerEmpleadoByCode(string _Code,
            string _ApiUrl, string recurso, string _Token)
        {
            ServiceResponse<dto_Empleados> _Response = new ServiceResponse<dto_Empleados>()
            {
                Message = "ISOK",
                Errors = null,
                Code = "200"
            };
            dto_Empleados _Employer = new dto_Empleados()
            {
                Code = "004",
                Name = "Empleado Trunks",
                Estatus = "Inactivo",
                Compania = "Aplics",
                Direccion = "Administrativo",
                Localidad = "Ciudad de México",
                Departamento = "Dirección Sistemas",
                Puesto = "Dirección Sistemas",
                CentroCostos = "000"
            };
            _Response.ResponseData = _Employer;

            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);
            return _Response;
        }
        public ServiceResponse<string> ReingresoEmpleado(ServiceRequest<dto_Empleados> _Request, string _ApiUrl, string recurso, string _Token)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>()
            {
                Message = "ISOK",
                Errors = null,
                Code = "200"
            };
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);

            return _Response;
        }
        public ServiceResponse<string> ActualizarEmpleado(ServiceRequest<dto_Empleados> _Request, string _ApiUrl, string recurso, string _Token)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>()
            {
                Message = "ISOK",
                Errors = null,
                Code = "200"
            };
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);

            return _Response;
        }


        #region  Nomina

        public ServiceResponse<List<NominaEmpleadoResponseDTO>> GetDataNominaEmpleado(ServiceRequest<FiltroNominaRequestDTO> _Request)
        {
            ServiceResponse<List<NominaEmpleadoResponseDTO>> _Response = new ServiceResponse<List<NominaEmpleadoResponseDTO>>();
            _Response.ResponseData = new List<NominaEmpleadoResponseDTO>()
            {
                new NominaEmpleadoResponseDTO()
                {
                    Codigo="0967",
                    Nombre ="EMLEADO 1",
                    Estatus = "A"
                },
                 new NominaEmpleadoResponseDTO()
                {
                    Codigo="0967",
                    Nombre ="EMLEADO 1",
                    Estatus = "A"
                },
                  new NominaEmpleadoResponseDTO()
                {
                    Codigo="0967",
                    Nombre ="EMLEADO 1",
                    Estatus = "A"
                },
            };
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);
            return _Response;

        }
        public ServiceResponse<List<NominaResponseDTO>> GetDataNomina(ServiceRequest<FiltroNominaRequestDTO> _Request)
        {
            ServiceResponse<List<NominaResponseDTO>> _Response = new ServiceResponse<List<NominaResponseDTO>>();
            _Response.ResponseData = new List<NominaResponseDTO>()
            {
                new NominaResponseDTO()
                {
                    Id=88,
                    Empleado ="EMLEADO 1",
                    Nombre ="EMLEADO 1",
                    Concepto = "Concepto A",
                    DescConcepto ="Concepto nuevo",
                    Unidades=12,
                    Importe=123.4M
                },
                 new NominaResponseDTO()
                {
                   Id=89,
                    Empleado ="EMLEADO 2",
                    Nombre ="EMLEADO 2",
                    Concepto = "Concepto B",
                    DescConcepto ="Concepto nuevo",
                    Unidades=12,
                    Importe=123.4M
                },
                  new NominaResponseDTO()
                {
                   Id=90,
                    Empleado ="EMLEADO 3",
                    Nombre ="EMLEADO 3",
                    Concepto = "Concepto C",
                    DescConcepto ="Concepto nuevo",
                    Unidades=12,
                    Importe=123.4M
                },
            };
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);
            return _Response;

        }
        public ServiceResponse<List<ConceptoCatalogoResponseDTO>> GetConceptoCatalogo(string _CodeEmpleado)
        {
            ServiceResponse<List<ConceptoCatalogoResponseDTO>> _Response = new ServiceResponse<List<ConceptoCatalogoResponseDTO>>();
            _Response.ResponseData = new List<ConceptoCatalogoResponseDTO>()
            {
                new ConceptoCatalogoResponseDTO()
                {
                    Code = "AS32",
                    Name="AGUINALDO"
                },
                 new ConceptoCatalogoResponseDTO()
                {
                   Code = "002BF",
                   Name="ABONO"
                },
                  new ConceptoCatalogoResponseDTO()
                {
                  Code="SAQ",
                  Name ="ANTICIPO DE PAGO"
                },
            };
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);
            return _Response;

        }
        #endregion
        #region Excepciones Excel 

        public async Task<ServiceResponse<string>> ExcepcionesExcel(ExcepcionesExcelRequestDTO _Request)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>()
            {
                Message = "Ok",
                Code = "200",
                Errors = null
            };

            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);

            return _Response;

        }

        #endregion
        #region
        public ServiceResponse<List<ConsultaNominaResponseDTO>> ConsultaNomina(ConsultaNominaRequestDTO _Request)
        {
            ServiceResponse<List<ConsultaNominaResponseDTO>> _Response = new ServiceResponse<List<ConsultaNominaResponseDTO>>();
            _Response.ResponseData = new List<ConsultaNominaResponseDTO>()
            {
                new ConsultaNominaResponseDTO()
                {
                    Empleado = 000034,
                    Nombre="Perez Juan",
                    Neto= 1424.34M
                },
                 new ConsultaNominaResponseDTO()
                {
                   Empleado = 000075,
                    Nombre="Perez Pedro",
                    Neto= 1532.12M
                },
                  new ConsultaNominaResponseDTO()
                {
                  Empleado = 000166,
                    Nombre="Sanchez Maria",
                    Neto= 2115.92M
                },
            };
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);
            return _Response;
        }
        public ServiceResponse<List<DetalleNominaEmpleadoResponseDTO>> DetalleConsultaNomina(int CodEmpleado)
        {
            ServiceResponse<List<DetalleNominaEmpleadoResponseDTO>> _Response = new ServiceResponse<List<DetalleNominaEmpleadoResponseDTO>>();
            _Response.ResponseData = new List<DetalleNominaEmpleadoResponseDTO>()
            {
                new DetalleNominaEmpleadoResponseDTO()
                {
                    Concepto = "1PA",
                    Descripcion="PMO. POR ASISTENCIA",
                    Unidades =15.00M,
                    Percepciones = 121.50M,
                    Deducciones = 0,
                },
                 new DetalleNominaEmpleadoResponseDTO()
                {
                    Concepto = "1PU",
                    Descripcion="PREMIO POR PUNTUALIDAD",
                    Unidades =15.00M,
                    Percepciones = 121.50M,
                    Deducciones = 0,
                },
                  new DetalleNominaEmpleadoResponseDTO()
                {
                  Concepto = "5DI",
                    Descripcion="DIFERENCIA INFONAVIT",
                    Unidades =0.00M,
                    Percepciones = 0.00M,
                    Deducciones = 68.63M,
                },
            };

            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);
            return _Response;
        }
        #endregion
        #region Finiquito
        public ServiceResponse<List<ConsultaFiniquitoResponseDTO>> ConsultarFiniquito(FiltrosRequestDTO _Request)
        {
            ServiceResponse<List<ConsultaFiniquitoResponseDTO>> _Response = new ServiceResponse<List<ConsultaFiniquitoResponseDTO>>();
            if (_Request == null)
            {
                _Response.SetStatusCode(ServiceResponse<List<ConsultaFiniquitoResponseDTO>>.StatusCodesEnum.BAD_REQUEST);
                _Response.AddException(new Exception("Parámetros inválidos."));
                return _Response;
            }
            _Response.ResponseData = new List<ConsultaFiniquitoResponseDTO>()
            {
                new ConsultaFiniquitoResponseDTO()
                {
                    DocEntry="001",
                    Empleado = "002139",
                    Nombre="Perez Juan",
                    FechaFiniquito="27/08/2022",
                    NoSim=2,
                    TipoNomina="FIN",
                    DesTipoNomina="FINIQUITOS",
                    NetoaPagar=0.00M,
                    EstatusEmpleado="Activo",
                    Cia=1,
                    DescripcionCia="New Co",
                    Localidad=003,
                    DescLocalidad="SALTILLO",
                    EstatusFiniquito="Abierto",
                    Sim="",
                },
                 new ConsultaFiniquitoResponseDTO()
                {
                    DocEntry="002",
                    Empleado = "002311",
                    Nombre="Perez Maria",
                    FechaFiniquito="27/08/2022",
                    NoSim=1,
                    TipoNomina="FIN",
                    DesTipoNomina="FINIQUITOS",
                    NetoaPagar=13248.23M,
                    EstatusEmpleado="Baja",
                    Cia=1,
                    DescripcionCia="New Co",
                    Localidad=901,
                    DescLocalidad="",
                    EstatusFiniquito="Cerrado",
                    Sim="",
                },

            };
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);
            return _Response;

        }
        public ServiceResponse<string> AgregarNuevoFiniquito(FiniquitoRequestDTO _Request)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>();
            if (_Request == null)
            {
                _Response.SetStatusCode(ServiceResponse<string>.StatusCodesEnum.BAD_REQUEST);
                _Response.AddException(new Exception("Parámetros inválidos."));
                return _Response;
            }
            _Response.Message = "Resgitro creado correctamente";
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);
            return _Response;
        }
        public ServiceResponse<string> ActualizarFiniquito(FiniquitoRequestDTO _Request)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>();
            if (_Request == null)
            {
                _Response.SetStatusCode(ServiceResponse<string>.StatusCodesEnum.BAD_REQUEST);
                _Response.AddException(new Exception("Parámetros inválidos."));
                return _Response;
            }
            _Response.Message = "Resgitro Actualizado correctamente";
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);
            return _Response;
        }
        public ServiceResponse<string> EliminarFiniquitoById(string _CodEmpleado)
        {
            ServiceResponse<string> _Response = new ServiceResponse<string>();
            if (_CodEmpleado == null)
            {
                _Response.SetStatusCode(ServiceResponse<string>.StatusCodesEnum.BAD_REQUEST);
                _Response.AddException(new Exception("Parámetros inválidos."));
                return _Response;
            }
            _Response.Message = "Resgitro Eliminado correctamente";
            //_Client.ApiClient<ServiceRequest<dto_Empleados>>(_ApiUrl,recurso, 
            //   RestClient<ServiceResponse<string>>.VerbEnum.POST, _Request, _Token, _UrlParams, _Header, true, 300);
            return _Response;
        }



        #endregion




    }
}
