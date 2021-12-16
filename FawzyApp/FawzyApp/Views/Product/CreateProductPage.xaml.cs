using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FawzyApp.Views.Product
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateProductPage : ContentPage
    {
        public CreateProductPage()
        {
            InitializeComponent();
        }

        private const string BaseUrl = "http://192.168.99.13:5005/api/Products/UploadFile";

        HttpClient client = new HttpClient
        {
            BaseAddress = new Uri(BaseUrl),
        };

        public static byte[] streamToByteArray(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var file = await MediaPicker.PickPhotoAsync();

            var product = new FawzyShared.Models.Product();
            product.ID = new Guid();
            product.Title = "mohamed";
            product.Description = "description";
            product.Price = 434;

            product.Bytes= streamToByteArray(await file.OpenReadAsync());
            if (file == null)
                return;

            var json = JsonConvert.SerializeObject(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");



            // 

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(BaseUrl, content);

            StatusLabel.Text = response.StatusCode.ToString();
        }
        void vss()
        {
            var client = new RestClient("http://192.168.99.13:5005/api/Products/UploadFile");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddParameter("ID", "c7f8cfd5-7250-460e-89d7-352a35a765d2");
            request.AddParameter("Title", "PostMan1");
            request.AddParameter("Description", "desPostMan1");
            request.AddParameter("Price", "452");
            //request.AddFile("File", file.FullPath);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

           
        }


        //private StreamContent CreateFileContent(AppFileDTO appFileDTO)
        //{
        //    var fileContent = new StreamContent(appFileDTO.File.Stream);//your file stream
        //    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
        //    {
        //        Name = "\"files\"",
        //        FileName = "\"" + appFileDTO.File.FileName + "\"",
        //    }; // the extra quotes are key here
        //    fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
        //    fileContent.Headers.ContentDisposition.Parameters.Add(new NameValueHeaderValue("CategoryName", appFileDTO.CategoryName));
        //    fileContent.Headers.ContentDisposition.Parameters.Add(new NameValueHeaderValue("CategoryDescription", appFileDTO.CategoryDescription));
        //    fileContent.Headers.ContentDisposition.Parameters.Add(new NameValueHeaderValue("Detail", appFileDTO.Detail));
        //    return fileContent;
        //}





    }
}