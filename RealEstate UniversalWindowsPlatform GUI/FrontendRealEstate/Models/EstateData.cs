using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontendRealEstate.Models
{
 
    public class Estate
    {
        [JsonProperty("estateID")]
        public int ID { get; set; }
        [JsonProperty("type")]
        public string TypeP { get; set; }
        [JsonProperty("location")]
        public string Location { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("size")]
        public int Size { get; set; }
        [JsonProperty("price")]
        public int Price { get; set; }
    }
    

}
