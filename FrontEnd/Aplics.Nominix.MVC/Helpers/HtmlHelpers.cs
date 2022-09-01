using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Aplics.Nominix.DTOS.Account;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Aplics.Nominix.MVC
{
    public static class HtmlHelpers
    {

        public static string IsSelected(this IHtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {
            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static string PageClass(this IHtmlHelper htmlHelper)
        {
            string currentAction = (string)htmlHelper.ViewContext.RouteData.Values["action"];
            return currentAction;
        }

        public static string UserName(this IHtmlHelper htmlHelper, ISession accessor)
        {
            String usuario = accessor.GetString("NombreUsuario");
            return usuario;
        }

		public static string Puesto(this IHtmlHelper htmlHelper, ISession accessor)
		{
			String usuario = accessor.GetString("Puesto");
			return usuario;
		}

		public static string Ambiente(this IHtmlHelper htmlHelper, ISession accessor)
        {
            String usuario = accessor.GetString("Ambiente");
            return usuario;
        }

        public static string NombreSitio(this IHtmlHelper htmlHelper, ISession accessor)
        {
            String NombreSitio = accessor.GetString("NombreSitio");
            return String.IsNullOrEmpty(NombreSitio) ? String.Empty : NombreSitio;
        }

        public static string AppHeaderData(this IHtmlHelper htmlHelper, ISession accessor)
        {
            String AppHeaderData = accessor.GetString("AppHeaderData");
            if (!String.IsNullOrEmpty(AppHeaderData)) { AppHeaderData = "Paciente :" + AppHeaderData; }
            return String.IsNullOrEmpty(AppHeaderData) ? String.Empty : AppHeaderData;
        }

		public static string fnConsultaMensajes(this IHtmlHelper htmlHelper, ISession accessor, int tipoMensaje)
		{
			String result = String.Empty;
			try
			{
				string functionBorrarTodo = "MensajeriaAppBorrar";
				string functionBorrar = "MensajeriaAppBorrarxId";
				string functionLeerTodo = "MensajeriaAppLeerTodo";
				string functionLeer = "MensajeriaAppLeer";

				//String apiUrl = ReadConfig.ReadKey("AppServices", "ServiciosMensajeria");
				//int idSitio = int.Parse(accessor.GetString("SitioActual"));
				//List<int> ListaPerfiles = Perfiles.ListaPerfiles(accessor.GetString("Roles"), idSitio);
				//MensajeApp mensaje = new MensajeApp();
				//mensaje.id_Rol_Destino = ListaPerfiles[0];
				//String app = accessor.GetString("IddApNum");
				//mensaje.id_App = int.Parse(app);
				//mensaje.id_Tipo_Mensaje = tipoMensaje;

				//List<MensajeApp> serviceResult = new List<MensajeApp>();
				//serviceResult = await ConsultarMensajes(apiUrl, mensaje);

				int nummensajes = 10;//serviceResult.Count()
				String classIcon = tipoMensaje == 1 ? "warning" : "primary";
				var sb = new System.Text.StringBuilder();
				sb.AppendFormat("<a class='dropdown-toggle count-info' data-toggle='dropdown' href='#'>");
				sb.AppendFormat("<i class='fa ");
				sb.AppendFormat(tipoMensaje == 1 ? "fa-envelope text-white" : "fa-bell text-danger");
				sb.AppendFormat("'></i>");
				sb.AppendFormat("<span class='label label-" + classIcon + "'" + " id='numavisos_" + tipoMensaje.ToString() + "'>" + nummensajes + "</span>");
				sb.AppendFormat("</a><ul class='dropdown-menu dropdown-messages'>");
				Boolean read = false;

				//    <span style="color:silver; font-weight:bold;"></span>
				String estilomensaje = String.Empty;
				String jsonmensaje = String.Empty;
				sb.AppendFormat("<li id='listamensajes_" + tipoMensaje.ToString() + "'>");
				//foreach (MensajeApp m in serviceResult)
				//Resolver funciones
				String temporal = String.Empty;
				foreach (var m in temporal)
				{
					jsonmensaje = ((char)34).ToString() + Newtonsoft.Json.JsonConvert.SerializeObject(m).Replace("\"", "|").Replace("{", "").Replace("}", "") + ((char)34).ToString();
					sb.AppendFormat("<li class='dropdown-divider'></li>");
					sb.AppendFormat("<li><div class='dropdown-messages-box'><a href='#' class='float-left' onclick='" + functionBorrar + "(this," + jsonmensaje + "," + nummensajes.ToString() + ");'><i class='fa fa-trash' aria-hidden='true'></i>");
					sb.AppendFormat("</a><div class='media-body'>");
					//TimeSpan diff = System.DateTime.Now - m.fecha_Alta;
					TimeSpan diff = System.DateTime.Now - System.DateTime.Now.AddDays(-3);
					double hours = System.Math.Round(diff.TotalHours, 1);
					double dias = diff.TotalDays;
					//read = m.isread;
					estilomensaje = read ? ";color:silver;'" : ";font-weight:bold;' onclick='" + functionLeer + "(this," + jsonmensaje + ");'";
					sb.AppendFormat("<small class='float-right'>" + hours.ToString() + "h antes" + "</small>");
					sb.AppendFormat("<span style='cursor:pointer" + estilomensaje + ">");
					//sb.AppendFormat(m.mensaje);
					sb.AppendFormat("</span>");
					//sb.AppendFormat("<br><small class='text-muted'>" + ((int)System.Math.Round(dias, 1)).ToString() + " días antes a las " + m.fecha_Alta.ToString("hh:mm - dd/MM/yyyy") + "</small>");
					sb.AppendFormat("</div></div></li>");
				}
				//jsonmensaje = ((char)34).ToString() + Newtonsoft.Json.JsonConvert.SerializeObject(mensaje).Replace("\"", "|").Replace("{", "").Replace("}", "") + ((char)34).ToString();
				sb.AppendFormat("</li>");
				sb.AppendFormat("<li><div class='text-center link-block'><a href='#' onclick='" + functionLeerTodo + "(this," + jsonmensaje + ");'>");
				sb.AppendFormat(tipoMensaje == 1 ? "<i class='fa fa-envelope'>" : "<i class='fa fa-bell'>");
				sb.AppendFormat("</i><strong>Marcar como leídos</strong></a></div></li>");
				sb.AppendFormat("<li><div class='text-center link-block'><a href='#' onclick='" + functionBorrarTodo + "(this," + jsonmensaje + ");'><i class='fa fa-trash'></i> <strong>Eliminar todo</strong></a></div></li>");
				sb.AppendFormat("</ul>");
				result = sb.ToString();
			}
			catch (Exception ex)
			{
				result = "<li><a href='#'>" + ex.Message.ToString() + "</a><li/>";
			}
			return result;
		}

		//private static async Task<List<MensajeApp>> ConsultarMensajes(String apiUrl, MensajeApp mensaje)
		//{
		//	List<MensajeApp> serviceResult = new List<MensajeApp>();
		//	ClienteRest<List<MensajeApp>> cliente = new ClienteRest<List<MensajeApp>>();
		//	serviceResult = await cliente.LLamarServicioPostGeneral(apiUrl, ReadConfig.ReadKey("AppServices", "ServicioConsultaMensajesApp"), mensaje);
		//	return serviceResult;
		//}

		//public static string PerfilUsuario(this IHtmlHelper htmlHelper, ISession accessor)
		//{
		//	String cverolactual = accessor.GetString("RolActual");
		//	string roles = accessor.GetString("Roles");
		//	dto_Menu rolesusuario = Newtonsoft.Json.JsonConvert.DeserializeObject<dto_Menu>(roles);
		//	dto_ElementoMenu rolactual = rolesusuario.MenuContent.Opciones.Where(x => x.id.Equals(cverolactual)).FirstOrDefault();
		//	return rolactual.texto;
		//}

		//public static string MenuContent(this IHtmlHelper htmlHelper, ISession accessor)
		//{
		//	var urlHelper = new UrlHelper(htmlHelper.ViewContext);
		//	string menu = String.Empty;
		//	string contmenu = accessor.GetString("MenuUsuario");
		//	dto_Menu usermenu = new dto_Menu();
		//	try
		//	{
		//		usermenu = Newtonsoft.Json.JsonConvert.DeserializeObject<dto_Menu>(contmenu);
		//		menu = RenderMenu(usermenu, urlHelper, htmlHelper.ViewContext);
		//	}
		//	catch (Exception ex)
		//	{
		//		menu = "<li><a href='#'>" + ex.Message.ToString() + "</a><li/>";
		//	}
		//	return menu;
		//}

		//public static String RenderPerfiles(this IHtmlHelper htmlHelper, ISession accessor)
		//{
		//	var sb = new System.Text.StringBuilder();
		//	UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext);
		//	String colorActivo = "#94d60f";
		//	String colorInactivo = "#3c8dbc";
		//	String color = string.Empty;
		//	string roles = accessor.GetString("Roles");
		//	int rolActual = 0;
		//	int sitioActual = 0;
		//	if (accessor.GetString("RolActual") != null)
		//	{
		//		String rol = accessor.GetString("RolActual");
		//		rolActual = int.Parse(rol);
		//	}
		//	if (accessor.GetString("SitioActual") != null)
		//	{
		//		String sitio = accessor.GetString("SitioActual");
		//		sitioActual = int.Parse(sitio);
		//	}
		//	sb.AppendFormat("<div class='sidebar-title'>");
		//	sb.AppendFormat("<h3><i class='fa fa-user-circle'></i>&nbsp;Roles del usuario &nbsp;</h3>");
		//	sb.AppendFormat("<small><i class='fa fa-tim'></i>Selecciona un Rol</small>");
		//	sb.AppendFormat("</div>");
		//	String url = String.Empty;
		//	String sesionRoles = accessor.GetString("Roles");
		//	if (!String.IsNullOrEmpty(sesionRoles))
		//	{
		//		dto_PerfilAcceso DataPerfiles = Newtonsoft.Json.JsonConvert.DeserializeObject<dto_PerfilAcceso>(sesionRoles);
		//		if (DataPerfiles != null)
		//		{
		//			//Lugares de atención
		//			foreach (dto_SitioAcceso vs in DataPerfiles.ListSitioAcceso)
		//			{
		//				sb.AppendFormat("<div class='row'><div class='col-sm-12' style='text-align:center;'>");
		//				sb.AppendFormat("<h3 class='text-warning'><strong>");
		//				sb.AppendFormat(vs.NombreSitio);
		//				sb.AppendFormat("</strong></h3>");
		//				sb.AppendFormat("</div></div>");
		//				//Perfiles del sitio
		//				sb.AppendFormat("<div class='row'><div class='col-sm-12'>");
		//				sb.AppendFormat("<ul class='sidebar-list'>");
		//				String formfunct = String.Empty;
		//				foreach (dto_RolAcceso vr in vs.ListRolAcceso)
		//				{
		//					url = "/Home/Perfil?idRol=" + vr.IdRol + "&idSitio=" + vs.IdSitio.ToString() + "&idSitioExterno=" + vs.IdSitioExterno.ToString() + "&NombreSitio=" + vs.NombreSitio;
		//					color = rolActual == vr.IdRol & sitioActual == vs.IdSitio ? colorActivo : colorInactivo;
		//					sb.AppendFormat("<li>");
		//					sb.AppendFormat("<a href='");
		//					sb.AppendFormat(url);
		//					sb.AppendFormat("'>");
		//					sb.AppendFormat("<div class='small float-right m-t-xs'><i class='menu-icon fa fa-circle-o' style='color: " + color + ";'></i></div>");
		//					sb.AppendFormat("<button type='button' class='btn btn-link'><h4>");
		//					sb.AppendFormat(vr.NombreRol);
		//					sb.AppendFormat("</h4></button>");
		//					sb.AppendFormat(vr.Descripcion);
		//					sb.AppendFormat("</a>");
		//					sb.AppendFormat("</li>");
		//				}
		//				sb.AppendFormat("</ul>");
		//				sb.AppendFormat("</div></div>");
		//			}
		//		}
		//	}
		//	return sb.ToString();
		//}

		//private static String RenderMenu(dto_Menu menu, UrlHelper urlHelper, ViewContext context)
		//{
		//	var sb = new System.Text.StringBuilder();

		//	String smenuItems = String.Empty;
		//	String url = String.Empty;

		//	List<dto_ElementoMenu> ListaMenus = menu.MenuContent.Opciones;
		//	List<dto_ElementoMenu> ListaElementos = new List<dto_ElementoMenu>();
		//	int nivel = 1;
		//	Boolean isSelected = false;
		//	string claseMenu = string.Empty;
		//	foreach (var mp in ListaMenus.Where(p => p.father.Equals(p.id)))
		//	{
		//		ListaElementos = ListaMenus.Where(p => p.father.Equals(mp.id)).ToList();
		//		if (ListaElementos.Count() == 0)
		//		{
		//			ListaElementos.Add(mp);
		//		}
		//		isSelected = buscaOpcionUsuario(ListaElementos, urlHelper, context);
		//		claseMenu = isSelected ? " class='active'" : "";
		//		sb.AppendFormat("<li" + claseMenu + ">");
		//		if (ListaElementos.Count() > 1)
		//		{

		//			sb.AppendFormat("<a href = '#' >");
		//			sb.AppendFormat(mp.imagen);
		//			if (!String.IsNullOrEmpty(mp.imagen))
		//			{
		//				sb.AppendFormat("&nbsp;");
		//			}
		//			sb.AppendFormat(mp.texto + "<span class='fa arrow'></span>");
		//			sb.AppendFormat("</a>");
		//			claseMenu = isSelected ? " in" : "";
		//			sb.AppendFormat("<ul class='nav nav-third-level collapse" + claseMenu + "'>");
		//		}
		//		else
		//		{
		//			sb.AppendFormat("<a href = '");
		//			url = GetURL(mp.accion, mp.controlador, urlHelper);
		//			sb.AppendFormat(url);
		//			sb.AppendFormat("'>");
		//			sb.AppendFormat(mp.imagen);
		//			if (!String.IsNullOrEmpty(mp.imagen))
		//			{
		//				sb.AppendFormat("&nbsp;");
		//			}
		//			sb.AppendFormat(mp.texto);
		//			sb.AppendFormat("</a>");
		//		}

		//		smenuItems = RenderMenuItems(menu, mp, nivel, urlHelper, context);
		//		sb.AppendFormat(smenuItems);

		//		if (ListaMenus.Count(p => p.father.Equals(mp.id)) > 1)
		//		{
		//			sb.AppendFormat("</ul>");
		//		}
		//		sb.AppendFormat("</li>");
		//	}
		//	return sb.ToString();
		//}

		//private static String RenderMenuItems(dto_Menu menu, dto_ElementoMenu mi, int nivel, UrlHelper urlHelper, ViewContext context)
		//{
		//	var sb = new System.Text.StringBuilder();

		//	String parametros = String.Empty;
		//	List<dto_ElementoMenu> ListaMenus = menu.MenuContent.Opciones;
		//	List<dto_ElementoMenu> ListaElementos = new List<dto_ElementoMenu>();
		//	String url = String.Empty;
		//	Boolean isSelected = false;
		//	String claseMenu = String.Empty;
		//	foreach (var cp in ListaMenus.Where(p => p.father.Equals(mi.id)))
		//	{
		//		if (!cp.father.Equals(cp.id))
		//		{
		//			ListaElementos = ListaMenus.Where(p => p.father.Equals(cp.id)).ToList();
		//			if (ListaElementos.Count() == 0)
		//			{
		//				ListaElementos.Add(cp);
		//			}
		//			isSelected = buscaOpcionUsuario(ListaElementos, urlHelper, context);
		//			claseMenu = isSelected ? " class='active'" : "";
		//			parametros = cp.parametros;
		//			if (!parametros.Equals(""))
		//			{
		//				parametros = "?" + parametros;
		//			}
		//			if (ListaMenus.Count(p => p.father.Equals(cp.id)) == 0)
		//			{
		//				sb.AppendFormat("<li" + claseMenu + ">");
		//				url = GetURL(cp.accion, cp.controlador, urlHelper);
		//				sb.AppendFormat("<a href='");
		//				sb.AppendFormat(url);
		//				sb.AppendFormat("'>");
		//			}
		//			else
		//			{
		//				sb.AppendFormat("<li" + claseMenu + ">");
		//				sb.AppendFormat("<a href=''>");
		//			}
		//			sb.AppendFormat(cp.imagen);
		//			if (!String.IsNullOrEmpty(cp.imagen))
		//			{
		//				sb.AppendFormat("&nbsp;");
		//			}
		//			sb.AppendFormat(cp.texto);
		//			sb.AppendFormat("</a>");

		//			if (ListaMenus.Count(p => p.father.Equals(cp.id)) > 0)
		//			{
		//				nivel += 1;
		//				claseMenu = isSelected ? " in" : "";
		//				sb.AppendFormat("<ul class='nav nav-third-level collapse" + claseMenu + "'>");
		//			}

		//			sb.AppendFormat(RenderMenuItems(menu, cp, nivel, urlHelper, context));

		//			if (ListaMenus.Count(p => p.father.Equals(cp.id)) > 0)
		//			{
		//				sb.AppendFormat("</ul>");
		//			}
		//			else
		//			{
		//				sb.AppendFormat("</li>");
		//			}
		//		}
		//	}
		//	return sb.ToString();
		//}

		//private static Boolean buscaOpcionUsuario(List<dto_ElementoMenu> ListaElementos, UrlHelper urlHelper, ViewContext context)
		//{
		//	Boolean seleccionado = false;
		//	String ruta = context.HttpContext.Request.Path;
		//	String url;
		//	foreach (var op in ListaElementos)
		//	{
		//		url = GetURL(op.accion, op.controlador, urlHelper);
		//		if (ruta.Equals(url))
		//		{
		//			seleccionado = true;
		//			break;
		//		}
		//	}
		//	return seleccionado;
		//}

		//private static String GetURL(String accion, String controlador, UrlHelper urlHelper)
		//{
		//	String url = String.Empty;
		//	if (!controlador.Equals(""))
		//	{
		//		url = urlHelper.Content(controlador + "/" + accion);
		//	}
		//	else
		//	{
		//		url = urlHelper.Content(accion);
		//	}
		//	if (url == null) { url = String.Empty; }
		//	return url;
		//}
	}
}
