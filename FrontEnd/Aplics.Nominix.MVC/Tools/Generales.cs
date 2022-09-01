using Aplics.Nominix.DTOS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Aplics.Nominix.MVC.Tools
{
    
    public class Generales 
    {
        public string archivo;
        public Generales(string item)
        {
            archivo = item;
        }
        //public static dto_ComboGralList Read() =>
        //    JsonConvert.DeserializeObject<dto_ComboGralList>(File.ReadAllText("cias.json"));
        public dto_ComboGralList Read() =>
            JsonConvert.DeserializeObject<dto_ComboGralList>(File.ReadAllText(archivo));

    }
}
