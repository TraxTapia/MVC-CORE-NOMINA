using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplics.Nominix.DTOS;
namespace Aplics.Nominix.MVC
{
	public static class HelperRender
	{

		public static List<SelectListItem> getCatalogoGeneral(List<dto_ComboGral> lista, Boolean elementoVacio = true, String ValorDefault = "")
        {
			List<SelectListItem> catalogo = new List<SelectListItem>();
			if (elementoVacio)
			{
				catalogo.Add(new SelectListItem() { Value = String.Empty, Text = String.Empty });
			}
			if (!String.IsNullOrEmpty(ValorDefault))
            {
				int index = catalogo.FindIndex(x=> x.Value.Trim().ToLower().Equals(ValorDefault.Trim().ToLower()));
			}
			catalogo.AddRange(lista.Select(x=> new SelectListItem { Value=x.Valor, Text=x.Descripcion }).ToList());
			return catalogo;
		}
		public static List<SelectListItem> getCatalogo<T>(List<T> lista, String campovalor, String campoDescripcion, Boolean elementoVacio = true, String ValorDefault = "")
		{
			List<SelectListItem> catalogo = new List<SelectListItem>();
			try
			{
				if (elementoVacio)
				{
					catalogo.Add(new SelectListItem() { Value = String.Empty, Text = String.Empty });
				}
				if (lista.Count() > 0)
				{
					String valor = String.Empty;
					Boolean selected = false;
					foreach (T item in lista)
					{
						valor = GetDataCatalogo(item, campovalor);
						selected = false;
						if (!String.IsNullOrEmpty(ValorDefault))
						{
							selected = ValorDefault.Trim().ToLower().Equals(valor.Trim().ToLower()) ? true : false;
						}
						catalogo.Add(new SelectListItem() { Value = valor, Text = GetDataCatalogo(item, campoDescripcion), Selected = selected });
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return catalogo;
		}

		private static String GetDataCatalogo(Object src, String propName)
		{
			String result = String.Empty;
			try
			{
				result = src.GetType().GetProperty(propName).GetValue(src, null).ToString();
			}
			catch (Exception)
			{
				result = String.Empty;
			}
			return result;
		}
	}
}
