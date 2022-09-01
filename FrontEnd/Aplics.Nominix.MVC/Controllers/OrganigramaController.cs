using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aplics.Nominix.MVC.Authorize;
using Microsoft.AspNetCore.Mvc;
using Aplics.Nominix.DTOS;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Newtonsoft.Json;
using Aplics.Nominix.MVC.Tools;

namespace Aplics.Nominix.MVC.Controllers
{
    [AccessAuthorize]
    public class OrganigramaController : Controller
    {
        public IActionResult Main()
        {
            return View();
        }

        public IActionResult Minor()
        {

            return View();
        }

        public ActionResult AgregarPlaza(int? id)
        {
            dto_Plazas modPlazas = new dto_Plazas();

            modPlazas.Codigo = "C";
            modPlazas.PlazaSuperior = "C";
            modPlazas.Compañia = "C";
            modPlazas.Localidad = "C";
            modPlazas.Direccion = "C";
            modPlazas.Departamento = "C";
            modPlazas.Puesto = "C";
            modPlazas.TipoPlaza = "C";

            modPlazas.Autorizadas = 0;
            modPlazas.Ocupadas = 0;
            modPlazas.EventualesAutorizadas = 0;
            modPlazas.EventualesOcupadas = 0;
            modPlazas.Empleado = "C";
            modPlazas.Externo = "C";

            modPlazas.CodigoSup = "D";
            modPlazas.CompañiaSup = "D";
            modPlazas.LocalidadSup = "D";
            modPlazas.DireccionSup = "D";
            modPlazas.DepartamentoSup = "D";
            modPlazas.PuestoSup = "D";
            modPlazas.ExternoSup = "D";

            List<SelectListItem> lstCia = new List<SelectListItem>();
            List<SelectListItem> lstDireccion = new List<SelectListItem>();
            List<SelectListItem> lstLocalidad = new List<SelectListItem>();
            List<SelectListItem> lstPuesto = new List<SelectListItem>();
            List<SelectListItem> lstDepartamento = new List<SelectListItem>();

            Generales gralCia = new Generales("cias.json");
            var cia = gralCia.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var item in cia)
            {
                lstCia.Add(new SelectListItem() { Text = item.Descripcion, Value = item.Valor });
            }

            Generales gralDir = new Generales("direccion.json");
            var direccion = gralDir.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var itemDir in direccion)
            {
                lstDireccion.Add(new SelectListItem() { Text = itemDir.Descripcion, Value = itemDir.Valor });
            }

            Generales gralLoc = new Generales("localidad.json");
            var localidad = gralLoc.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var itemloc in localidad)
            {
                lstLocalidad.Add(new SelectListItem() { Text = itemloc.Descripcion, Value = itemloc.Valor });
            }

            Generales gralPue = new Generales("puesto.json");
            var puesto = gralPue.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var itemPue in puesto)
            {
                lstPuesto.Add(new SelectListItem() { Text = itemPue.Descripcion, Value = itemPue.Valor });
            }

            Generales gralDepto = new Generales("departamento.json");
            var departamento = gralDepto.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var itemDepto in departamento)
            {
                lstDepartamento.Add(new SelectListItem() { Text = itemDepto.Descripcion, Value = itemDepto.Valor });
            }

            ViewBag.comboCias = lstCia;
            ViewBag.comboDireccion = lstDireccion;
            ViewBag.comboLocalidad = lstLocalidad;
            ViewBag.comboPuesto = lstPuesto;
            ViewBag.comboDepartamento = lstDepartamento;

            return View(modPlazas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarPlaza(dto_Plazas modPlazas)
        {
            //llamada a api servicio para agregar el registro
            return View(modPlazas);
        }

        public ActionResult BorrarPlaza(int? id)
        {
            //aca se debeera de obtener los datos del dto de plazas filtrado por ID del API

            dto_Plazas modPlazas = new dto_Plazas();

            modPlazas.CodigoPlazaSeleccionada = "PS SSS";
            modPlazas.DescripcionPlaza = "PLAZA SELECCIONADA";

            modPlazas.Compañia = "C";
            modPlazas.Localidad = "C";
            modPlazas.Direccion = "C";
            modPlazas.Departamento = "C";
            modPlazas.Puesto = "C";
            modPlazas.TipoPlaza = "C";

            modPlazas.Autorizadas = 0;
            modPlazas.Ocupadas = 0;
            modPlazas.EventualesAutorizadas = 0;
            modPlazas.EventualesOcupadas = 0;
            modPlazas.Empleado = "C";
            modPlazas.Externo = "C";


            return View(modPlazas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarPlaza(dto_Plazas modPlazas)
        {
            //aca se debeera de obtener los datos del dto de plazas filtrado por ID del API

            //dto_Plazas modPlazas = new dto_Plazas();

            //modPlazas.CodigoPlazaSeleccionada = "PS SSS";
            //modPlazas.DescripcionPlaza = "PLAZA SELECCIONADA";

            //modPlazas.Compañia = "C";
            //modPlazas.Localidad = "C";
            //modPlazas.Direccion = "C";
            //modPlazas.Departamento = "C";
            //modPlazas.Puesto = "C";
            //modPlazas.TipoPlaza = "C";

            //modPlazas.Autorizadas = 0;
            //modPlazas.Ocupadas = 0;
            //modPlazas.EventualesAutorizadas = 0;
            //modPlazas.EventualesOcupadas = 0;
            //modPlazas.Empleado = "C";
            //modPlazas.Externo = "C";


            return View();

        }

        public ActionResult ModificarPlaza(int? id)
        {
            dto_Plazas modPlazas = new dto_Plazas();

            modPlazas.CodigoPlazaSeleccionada = "PS SSS";
            modPlazas.DescripcionPlaza = "PLAZA SELECCIONADA";

            modPlazas.Compañia = "C";
            modPlazas.Localidad = "C";
            modPlazas.Direccion = "C";
            modPlazas.Departamento = "C";
            modPlazas.Puesto = "C";
            modPlazas.TipoPlaza = "C";

            modPlazas.Autorizadas = 0;
            modPlazas.Ocupadas = 0;
            modPlazas.EventualesAutorizadas = 0;
            modPlazas.EventualesOcupadas = 0;
            modPlazas.Empleado = "C";
            modPlazas.Externo = "C";

            List<SelectListItem> lstCia = new List<SelectListItem>();
            List<SelectListItem> lstDireccion = new List<SelectListItem>();
            List<SelectListItem> lstLocalidad = new List<SelectListItem>();
            List<SelectListItem> lstPuesto = new List<SelectListItem>();
            List<SelectListItem> lstDepartamento = new List<SelectListItem>();

            Generales gralCia = new Generales("cias.json");
            var cia = gralCia.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var item in cia)
            {
                if (item.Valor == "2")
                {
                    lstCia.Add(new SelectListItem() { Text = item.Descripcion, Value = item.Valor, Selected = true });
                }
                lstCia.Add(new SelectListItem() { Text = item.Descripcion, Value = item.Valor });
            }

            Generales gralDir = new Generales("direccion.json");
            var direccion = gralDir.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var itemDir in direccion)
            {
                if (itemDir.Valor == "2")
                {
                    lstDireccion.Add(new SelectListItem() { Text = itemDir.Descripcion, Value = itemDir.Valor, Selected=true });
                }
                lstDireccion.Add(new SelectListItem() { Text = itemDir.Descripcion, Value = itemDir.Valor });
            }

            Generales gralLoc = new Generales("localidad.json");
            var localidad = gralLoc.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var itemloc in localidad)
            {
                if (itemloc.Valor == "2")
                {
                    lstLocalidad.Add(new SelectListItem() { Text = itemloc.Descripcion, Value = itemloc.Valor, Selected=true });
                }
                lstLocalidad.Add(new SelectListItem() { Text = itemloc.Descripcion, Value = itemloc.Valor });
            }

            Generales gralPue = new Generales("puesto.json");
            var puesto = gralPue.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var itemPue in puesto)
            {
                if (itemPue.Valor == "2")
                {
                    lstPuesto.Add(new SelectListItem() { Text = itemPue.Descripcion, Value = itemPue.Valor, Selected=true });
                }
                lstPuesto.Add(new SelectListItem() { Text = itemPue.Descripcion, Value = itemPue.Valor });
            }

            Generales gralDepto = new Generales("departamento.json");
            var departamento = gralDepto.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var itemDepto in departamento)
            {
                if (itemDepto.Valor == "2")
                {
                    lstDepartamento.Add(new SelectListItem() { Text = itemDepto.Descripcion, Value = itemDepto.Valor, Selected=true });
                }
                lstDepartamento.Add(new SelectListItem() { Text = itemDepto.Descripcion, Value = itemDepto.Valor });
            }

            ViewBag.comboCias = lstCia;
            ViewBag.comboDireccion = lstDireccion;
            ViewBag.comboLocalidad = lstLocalidad;
            ViewBag.comboPuesto = lstPuesto;
            ViewBag.comboDepartamento = lstDepartamento;


            return View(modPlazas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModificarPlaza(int id, dto_Plazas modPlazas)
        {
            //aca se debeera de obtener los datos del dto de plazas filtrado por ID del API

            //dto_Plazas modPlazas = new dto_Plazas();

            modPlazas.CodigoPlazaSeleccionada = "PS SSS";
            modPlazas.DescripcionPlaza = "PLAZA SELECCIONADA";

            modPlazas.Compañia = "C";
            modPlazas.Localidad = "C";
            modPlazas.Direccion = "C";
            modPlazas.Departamento = "C";
            modPlazas.Puesto = "C";
            modPlazas.TipoPlaza = "C";

            modPlazas.Autorizadas = 0;
            modPlazas.Ocupadas = 0;
            modPlazas.EventualesAutorizadas = 0;
            modPlazas.EventualesOcupadas = 0;
            modPlazas.Empleado = "C";
            modPlazas.Externo = "C";

            List<SelectListItem> lstCia = new List<SelectListItem>();
            List<SelectListItem> lstDireccion = new List<SelectListItem>();
            List<SelectListItem> lstLocalidad = new List<SelectListItem>();
            List<SelectListItem> lstPuesto = new List<SelectListItem>();
            List<SelectListItem> lstDepartamento = new List<SelectListItem>();

            Generales gralCia = new Generales("cias.json");
            var cia = gralCia.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var item in cia)
            {
                lstCia.Add(new SelectListItem() { Text = item.Descripcion, Value = item.Valor });
            }

            Generales gralDir = new Generales("direccion.json");
            var direccion = gralDir.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var itemDir in direccion)
            {
                lstDireccion.Add(new SelectListItem() { Text = itemDir.Descripcion, Value = itemDir.Valor });
            }

            Generales gralLoc = new Generales("localidad.json");
            var localidad = gralLoc.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var itemloc in localidad)
            {
                lstLocalidad.Add(new SelectListItem() { Text = itemloc.Descripcion, Value = itemloc.Valor });
            }

            Generales gralPue = new Generales("puesto.json");
            var puesto = gralPue.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var itemPue in puesto)
            {
                lstPuesto.Add(new SelectListItem() { Text = itemPue.Descripcion, Value = itemPue.Valor });
            }

            Generales gralDepto = new Generales("departamento.json");
            var departamento = gralDepto.Read().CombosGral.OrderBy(x => x.Descripcion).ToList();
            foreach (var itemDepto in departamento)
            {
                lstDepartamento.Add(new SelectListItem() { Text = itemDepto.Descripcion, Value = itemDepto.Valor });
            }

            ViewBag.comboCias = lstCia ;
            ViewBag.comboDireccion = lstDireccion;
            ViewBag.comboLocalidad = lstLocalidad;
            ViewBag.comboPuesto = lstPuesto;
            ViewBag.comboDepartamento = lstDepartamento;


            return View(modPlazas);

        }

        public ActionResult ConsultarPlaza(int? id)
        {
            //aca se debeera de obtener los datos del dto de plazas filtrado por ID del API

            dto_Plazas modPlazas = new dto_Plazas();

            modPlazas.CodigoPlazaSeleccionada = "PS SSS";
            modPlazas.DescripcionPlaza = "PLAZA SELECCIONADA";

            modPlazas.Compañia = "C";
            modPlazas.Localidad = "C";
            modPlazas.Direccion = "C";
            modPlazas.Departamento = "C";
            modPlazas.Puesto = "C";
            modPlazas.TipoPlaza = "C";

            modPlazas.Autorizadas = 0;
            modPlazas.Ocupadas = 0;
            modPlazas.EventualesAutorizadas = 0;
            modPlazas.EventualesOcupadas = 0;
            modPlazas.Empleado = "C";
            modPlazas.Externo = "C";

            List<dto_PlazasEmpleados> empPlazasList = new List<dto_PlazasEmpleados>();

            dto_PlazasEmpleados empPlazas = new dto_PlazasEmpleados();
            empPlazas.Nombre = "EMP 1";
            empPlazas.ApellidoPaterno = "EMP 1";
            empPlazas.ApellidoMaterno = "EMP 1";

            dto_PlazasEmpleados empPlazas2 = new dto_PlazasEmpleados();
            empPlazas2.Nombre = "EMP 2";
            empPlazas2.ApellidoPaterno = "EMP 2";
            empPlazas2.ApellidoMaterno = "EMP 2";

            empPlazasList.Add(empPlazas);
            empPlazasList.Add(empPlazas2);

            modPlazas.Empleados = empPlazasList;


            return View(modPlazas);
        }




        public JsonResult AjaxMethod()
        {
            List<object> chartData = new List<object>();

            chartData.Add(new object[] {
                1,"Cesar1","CEO",null
            });
            chartData.Add(new object[] {
                2,"Cesar2","VP1",1
            });
            chartData.Add(new object[] {
                3,"Cesar22","V2",1
            });
            chartData.Add(new object[] {
                4,"Cesar222","V3",1
            });
            chartData.Add(new object[] {
                5,"Cesar3","chalan",4
            });

            return Json(chartData);
        }
    }

}
