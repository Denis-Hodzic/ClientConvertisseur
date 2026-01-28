using ClientConvertisseurV2.Models;
using ClientConvertisseurV2.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ClientConvertisseurV2
{
    public class WSService: IService
    {
        private readonly HttpClient httpClient;

        public WSService(string uriDevice)
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(uriDevice)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Devise>> GetDevisesAsync(string nomControleur)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<List<Devise>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
