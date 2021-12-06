using FawzyApp.Services.RequestProvider;
using FawzyShared.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(RequestProvider))]
namespace FawzyApp.Services.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {

        private const string BaseUrl = "http://192.168.99.13:5005/api/";

        HttpClient client = new HttpClient
        {
            BaseAddress = new Uri(BaseUrl),
        };

        public RequestProvider()
        {
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<TResult> GetListAsync<TResult>(string uri, string token = "")
        {
            TResult result;
            try
            {
                var json = await client.GetAsync(uri);
                var content = await json.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<TResult>(content);
                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
            return default(TResult);// await Task.FromResult(default(TResult));
        }

        public async Task<TResult> GetOneAsync<TResult>(string uri, Guid id, string token = "")
        {
            try
            {
                client.DefaultRequestHeaders.Add("id", id.ToString());
                var json = await client.GetStringAsync("Students");
                TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(json));
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<TResult> PostOneAsync<TResult, Take>(Take item, string uri, string token = "")
        {
            //TResult result;
            var valueReturned = default(TResult);// as ResponseResult<TResult>;
            
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content);

            if (response.IsSuccessStatusCode)
            {
                //valueReturned.Status = true;
                var resJson = response.Content.ReadAsStringAsync().Result;
                valueReturned = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(resJson));

                return valueReturned; // default(TResult);
            }
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
           
            return default(TResult);
        }



        // remove 
        public async Task<TResult> DeleteOneAsync<TResult>(Guid id, string uri, string token = "")
        {
            //var json = JsonConvert.SerializeObject(item);
            // HttpResponseMessage response = await client.DeleteAsync(uri);
            //var content = new StringContent(id.ToString(), Encoding.UTF8, "application/json");
            try
            {
                //Uri uri1 = new Uri(string.Format(uri, id));

                var fullUri = Path.Combine(uri, id.ToString());

                var response = await client.DeleteAsync(fullUri);

                if (!response.IsSuccessStatusCode)
                {
                    return default(TResult);
                }

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                }

                var resJson = response.Content.ReadAsStringAsync().Result;
                TResult result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(resJson));
                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return default(TResult);
        }

        // 




    } // end main class
}
