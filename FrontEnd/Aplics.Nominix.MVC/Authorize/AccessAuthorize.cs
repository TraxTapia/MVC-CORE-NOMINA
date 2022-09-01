using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplics.Nominix.MVC.Services.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
namespace Aplics.Nominix.MVC.Authorize
{
    public class AccessAuthorize : ActionFilterAttribute
    {
		private String urlLogService = String.Empty;

		public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            String lasError = String.Empty;
			try
            {
                String urlSoporte = UrlDeploy(filterContext.HttpContext.Request) + "Account/SoporteAcceso";
                //Recuperar de configuración

                filterContext.HttpContext.Session.SetString("Ambiente", "Desarrollo");
                filterContext.HttpContext.Session.SetString("NombreSitio", "Aplics-ZZZZ");
                filterContext.HttpContext.Session.SetString("NombreUsuario", "My name");
                filterContext.HttpContext.Session.SetString("Puesto", "Puesto del usuario");
				String Token = String.Empty;
				Perfil(filterContext,"1", "1", "Myname", "My name", Token);
			}
            catch(Exception ex)
            {
                lasError = ex.Message.ToString();
            }
        }

		private void Perfil(ActionExecutingContext filterContext, String appid, String IdUser, String UserName, String Usuario, String Token)
		{
			try
			{
				filterContext.HttpContext.Session.SetString("IddNum", IdUser);
				filterContext.HttpContext.Session.SetString("IddPar", UserName);
				filterContext.HttpContext.Session.SetString("NombreUsuario", Usuario);
				filterContext.HttpContext.Session.SetString("AppToken", Token);
				filterContext.HttpContext.Session.SetString("ApiToken", Token);
				filterContext.HttpContext.Session.SetString("AzureLogin", "1");

				//String[] ArrayPerfil=Perfiles.obtenerOpciones(Convert.ToInt32(appid), Convert.ToInt32(IdUser), urlLogService);

				
			//	filterContext.HttpContext.Session.SetString("MenuUsuario", ArrayPerfil[0]);
			//	filterContext.HttpContext.Session.SetString("Roles", ArrayPerfil[1]);
			//	filterContext.HttpContext.Session.SetString("RolActual", ArrayPerfil[2]);
			//	filterContext.HttpContext.Session.SetString("SitioActual", ArrayPerfil[3]);
			//	filterContext.HttpContext.Session.SetString("NombreSitio", ArrayPerfil[4]);
			//	filterContext.HttpContext.Session.SetString("SitioApp", ArrayPerfil[5]);
			//	filterContext.HttpContext.Session.SetString("AppHeaderData", String.Empty);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Returns the absolute url base.
		/// </summary>
		public string UrlDeploy(HttpRequest request)
        {
            String vp = request.PathBase;
            if (!String.IsNullOrEmpty(vp)) { vp = "/" + vp; }
            return $"{request.Scheme}://{request.Host}{vp}/";
        }
    }
}
