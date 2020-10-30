using FrontendRealEstate.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FrontendRealEstate.DataProvider
{
    class DataProviderC
    {
        public async Task<List<Estate>> GetEstatesData()
        {
            string URL = "https://realestatewebapinb.azurewebsites.net/api/estates";
            List<Estate> dataEstateList = new List<Estate>();
          
            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();

                    
                    var data = JsonConvert.DeserializeObject<List<Estate>>(result.Result); 
                    foreach(var e in data)
                    {
                        dataEstateList.Add(e);
                    }                
                   
                }
            }
            return dataEstateList;
        }


        public async Task<List<Estate>> SearhByPriceGet(int min, int max)
        {
            string URL = $"https://realestatewebapinb.azurewebsites.net/api/estates/{min}-{max}";
            List<Estate> dataEstateListSPrice = new List<Estate>();

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();


                    var data = JsonConvert.DeserializeObject<List<Estate>>(result.Result); 
                    foreach (var e in data)
                    {   
                        dataEstateListSPrice.Add(e);
                    }

                }
            }
            return dataEstateListSPrice;
        }

        public async Task<List<Estate>> SearhBySizeGet(int min, int max)
        {
            string URL = $"https://realestatewebapinb.azurewebsites.net/api/estates/{min},{max}";
            List<Estate> dataEstateListSPrice = new List<Estate>();

            using (HttpResponseMessage response = await APIHelper.ApiClient.GetAsync(URL))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();


                    var data = JsonConvert.DeserializeObject<List<Estate>>(result.Result); 
                    foreach (var e in data)
                    {
                        dataEstateListSPrice.Add(e);
                    }

                }
            }
            return dataEstateListSPrice;
        }

       
    }


}
