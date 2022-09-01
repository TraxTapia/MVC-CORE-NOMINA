using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplics.Nominix.DTOS.Account;
namespace Aplics.Nominix.MVC.Services.Account
{
	public static class Perfiles
	{
		//public static String[] obtenerOpciones(int idApp, int idUsuario, String apiUrl)
		//{
		//	String[] Perfil = { "", "", "", "", "", "" };
		//	String SMenu = String.Empty;
		//	String SPerfil = String.Empty;
		//	dto_Menu ArbolPerfiles = new dto_Menu();
		//	try
		//	{
		//		dto_PerfilAcceso DataPerfiles = new dto_PerfilAcceso();
		//		//Datos Dumie

		//		List<dto_ItemModulo> _ItemModulos = new List<dto_ItemModulo>();
		//		_ItemModulos.Add(new dto_ItemModulo()
		//		{
		//			DescripcionItem = "Organigrama y Plazas",
		//			IdItemModulo = 1,
		//			IdItemPadre = 0,
		//			IdModulo = 1,
		//			UrlDestino = "/Organigrama/Main",
		//			UrlIcono = "<i class='fa fa-users'></i>"
		//		});

		//		_ItemModulos.Add(new dto_ItemModulo()
		//		{
		//			DescripcionItem = "Empleados",
		//			IdItemModulo = 2,
		//			IdItemPadre = 0,
		//			IdModulo = 1,
		//			UrlDestino = "/Empleados/Index",
		//			UrlIcono = "<i class='fa fa-user-circle-o'></i>"
		//		});

		//		_ItemModulos.Add(new dto_ItemModulo()
		//		{
		//			DescripcionItem = "Movimientos",
		//			IdItemModulo = 3,
		//			IdItemPadre = 0,
		//			IdModulo = 1,
		//			UrlDestino = "/Movimientos/Index",
		//			UrlIcono = "<i class='fa fa-send'></i>"
		//		});

		//		_ItemModulos.Add(new dto_ItemModulo()
		//		{
		//			DescripcionItem = "Procesos de Nómina",
		//			IdItemModulo = 4,
		//			IdItemPadre = 0,
		//			IdModulo = 1,
		//			UrlDestino = "/ProcesosNomina/Index",
		//			UrlIcono = "<i class='fa fa-money'></i>"
		//		});

		//		List<dto_Modulo> _Modulos = new List<dto_Modulo>();
		//		_Modulos.Add(new dto_Modulo()
		//		{
		//			IdModulo=1,
		//			ListItemsModulo= _ItemModulos,
		//			NombreModulo="OPERACIÓN DIARIA",
		//			UrlIcono= "<i class='fa fa-file-excel-o'></i>"
		//		});

		//		List<dto_RolAcceso> _RolAccesos = new List<dto_RolAcceso>();
		//		_RolAccesos.Add(new dto_RolAcceso() 
		//		{
		//			 Activo=true,
		//			 Descripcion = "Operador Nómina",
		//			 IdApp=1,
		//			 IdExternoConfig="0",
		//			 IdRol=1,
		//			 ListModulos= _Modulos,
		//			 ListUrlPost=new List<String>(),
		//			 NombreRol = "Operador Nómina"
		//		});

		//		List<dto_SitioAcceso> _SitioAccesos = new List<dto_SitioAcceso>();

		//		_SitioAccesos.Add(new dto_SitioAcceso()
		//		{
		//			IdSitio = 1,
		//			IdSitioExterno=1,
		//			ListRolAcceso = _RolAccesos,
		//			NombreSitio="Nominix Web"
		//		});

		//		DataPerfiles.ListSitioAcceso = _SitioAccesos;

		//		Perfil[1] = Newtonsoft.Json.JsonConvert.SerializeObject(DataPerfiles);
		//		int idSitio = 0;
		//		int? idSitioApp = 0;
		//		int idRol = 0;
		//		String NombreSitio = String.Empty;
		//		if (DataPerfiles.ListSitioAcceso.Count > 0)
		//		{
		//			idSitio = DataPerfiles.ListSitioAcceso[0].IdSitio;
		//			idSitioApp = DataPerfiles.ListSitioAcceso[0].IdSitioExterno;
		//			NombreSitio = DataPerfiles.ListSitioAcceso[0].NombreSitio;
		//			if (DataPerfiles.ListSitioAcceso[0].ListRolAcceso.Count > 0)
		//			{
		//				idRol = DataPerfiles.ListSitioAcceso[0].ListRolAcceso[0].IdRol;
		//			}
		//		}
		//		SMenu = MenuPerfil(DataPerfiles, idRol, idSitio);
		//		Perfil[0] = SMenu;
		//		Perfil[2] = idRol.ToString();
		//		Perfil[3] = idSitio.ToString();
		//		Perfil[4] = NombreSitio;
		//		Perfil[5] = idSitioApp.ToString();
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//	return Perfil;
		//}

		//public static String MenuPerfil(dto_PerfilAcceso DataPerfiles, int idRol, int idSitio)
		//{
		//	String SMenu = String.Empty;
		//	try
		//	{
		//		dto_Menu menu = new dto_Menu();
		//		if (DataPerfiles.ListSitioAcceso.Count > 0)
		//		{
		//			int indexSitio = DataPerfiles.ListSitioAcceso.FindIndex(x => x.IdSitio == idSitio);
		//			int indexRol = DataPerfiles.ListSitioAcceso[indexSitio].ListRolAcceso.FindIndex(x => x.IdRol == idRol);
		//			if (indexRol >= 0)
		//			{
		//				foreach (dto_Modulo modulo in DataPerfiles.ListSitioAcceso[indexSitio].ListRolAcceso[indexRol].ListModulos)
		//				{
		//					menu.MenuContent.Opciones.Add(nuevomenu("MOD_" + modulo.IdModulo.ToString(), "MOD_" + modulo.IdModulo.ToString(), modulo.NombreModulo, String.Empty, modulo.UrlIcono != null ? modulo.UrlIcono : String.Empty, String.Empty));
		//					foreach (dto_ItemModulo itemModulo in modulo.ListItemsModulo)
		//					{
		//						menu.MenuContent.Opciones.Add(nuevomenu("SM_" + itemModulo.IdItemModulo.ToString(), itemModulo.IdItemPadre == 0 ? "MOD_" + itemModulo.IdModulo.ToString() : "SM_" + itemModulo.IdItemPadre.ToString(), itemModulo.DescripcionItem, "1", itemModulo.UrlIcono != null ? itemModulo.UrlIcono : String.Empty, itemModulo.UrlDestino));
		//					}
		//				}
		//			}
		//		}
		//		SMenu = Newtonsoft.Json.JsonConvert.SerializeObject(menu);
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//	return SMenu;
		//}

				

		//private static dto_ElementoMenu nuevomenu(String pid, String ppadre, string pTexto, String pTipo, string picono, String pagina)
		//{
		//	dto_ElementoMenu elm = new dto_ElementoMenu();
		//	elm.id = pid;
		//	elm.father = ppadre;
		//	elm.texto = pTexto;
		//	elm.tipo = pTipo;
		//	elm.accion = pagina;
		//	elm.imagen = picono;
		//	return elm;
		//}

		//public static List<int> ListaPerfiles(string pPerfiles, int idSitio)
		//{
		//	List<int> LPerfiles = new List<int>();
		//	dto_PerfilAcceso DataPerfiles = Newtonsoft.Json.JsonConvert.DeserializeObject<dto_PerfilAcceso>(pPerfiles);
		//	int indexSitio = DataPerfiles.ListSitioAcceso.FindIndex(x => x.IdSitio == idSitio);
		//	foreach (dto_RolAcceso pa in DataPerfiles.ListSitioAcceso[indexSitio].ListRolAcceso)
		//	{
		//		LPerfiles.Add(pa.IdRol);
		//	}
		//	return LPerfiles;
		//}
	}
}
