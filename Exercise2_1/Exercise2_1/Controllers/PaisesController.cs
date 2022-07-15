using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Exercise2_1.Models;
using System.Threading.Tasks;

namespace Exercise2_1.Controllers
{
    public class PaisesController
    {
        public async static Task<List<Paises.Pais>> getPaisesA()
        {
            List<Paises.Pais> listaPaises = new List<Paises.Pais>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://restcountries.com/v3.1/region/America");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content.ReadAsStringAsync().Result;
                    listaPaises = JsonConvert.DeserializeObject<List<Paises.Pais>>(contenido);

                }
            }
            return listaPaises;
        }
        public async static Task<List<Paises.Pais>> getPaisesE()
        {
            List<Paises.Pais> listaPaises = new List<Paises.Pais>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://restcountries.com/v3.1/region/Europe");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content.ReadAsStringAsync().Result;
                    listaPaises = JsonConvert.DeserializeObject<List<Paises.Pais>>(contenido);

                }
            }
            return listaPaises;
        }
        public async static Task<List<Paises.Pais>> getPaisesAf()
        {
            List<Paises.Pais> listaPaises = new List<Paises.Pais>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://restcountries.com/v3.1/region/Africa");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content.ReadAsStringAsync().Result;
                    listaPaises = JsonConvert.DeserializeObject<List<Paises.Pais>>(contenido);

                }
            }
            return listaPaises;
        }
        public async static Task<List<Paises.Pais>> getPaisesAs()
        {
            List<Paises.Pais> listaPaises = new List<Paises.Pais>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://restcountries.com/v3.1/region/Asia");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content.ReadAsStringAsync().Result;
                    listaPaises = JsonConvert.DeserializeObject<List<Paises.Pais>>(contenido);

                }
            }
            return listaPaises;
        }
        public async static Task<List<Paises.Pais>> getPaisesOs()
        {
            List<Paises.Pais> listaPaises = new List<Paises.Pais>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://restcountries.com/v3.1/region/Oceania");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content.ReadAsStringAsync().Result;
                    listaPaises = JsonConvert.DeserializeObject<List<Paises.Pais>>(contenido);

                }
            }
            return listaPaises;
        }
        //--ESTA ULTIMA ES USADA PARA FACILITAR LA OBTENCION DE ALGUNOS DATOS del pin del mapa
        public async static Task<List<Pais2>> getOnePais(String nom)
        {
            List<Pais2> listaPais = new List<Pais2>();
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://restcountries.com/v2/name/" + nom);
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content.ReadAsStringAsync().Result;
                    listaPais = JsonConvert.DeserializeObject<List<Pais2>>(contenido);
                }
            }
            return listaPais;
        }

    }

}
