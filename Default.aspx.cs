using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace APIGiphy
{
    public partial class _Default : Page
    {
        private static readonly string ApiKey = "bxiLeWNd1SCRcTsqgIaoTCH3dNj0F1L4";
        private static readonly string ApiUrl = "https://api.giphy.com/v1/gifs/search?api_key={0}&q={1}&limit=4";
        protected async void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected async void btnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = Buscador.Text.Trim();
            if (!string.IsNullOrEmpty(busqueda))
            {
                await BuscarGif(busqueda);
            }
        }
        private async Task BuscarGif(string busqueda)
        {
            using (var httpClient = new HttpClient())
            {
                string url = string.Format(ApiUrl, ApiKey, busqueda);


                var response = await httpClient.GetStringAsync(url);
                var jsonResponse = JObject.Parse(response);

                var gifUrl = jsonResponse["data"]?[0]?["images"]?["original"]?["url"]?.ToString();

                if (!string.IsNullOrEmpty(gifUrl))
                {
                    imgGif.ImageUrl = gifUrl;

                }
                else
                {

                    imgGif.ImageUrl = string.Empty;
                }

            }
        }
    }
}