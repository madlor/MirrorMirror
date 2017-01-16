using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MirrorMirror.Models.APIs
{
    public class FaceApi
    {
        private FaceServiceClient faceClient = null;

        //public const string _apiUrl = "https://api.projectoxford.ai/emotion/v1.0/recognize";
        private string apiKey = KeyHandler.GetFaceApiKey();

        

        private string apiUrl = "https://api.projectoxford.ai/face/v1.0/detect?returnFaceId=true";

        public FaceApi()
        {

            //TODO: REMOVE REMOVE REMOVE
            // faceClient = new FaceServiceClient("2181517829e04dc9b6b691a0c5a16fec");
        }

        public async Task<string> DetectFace(string image)
        {
            /*byte[] data = Convert.FromBase64String(image);

            var test = Convert.ToBase64String(data);

             
            MemoryStream stream = new MemoryStream(data);

            var face = await faceClient.DetectAsync(stream, true, true);

            return face[0].FaceId.ToString();*/

            MemoryStream stream = new MemoryStream(Convert.FromBase64String(image));
            //var content = new StreamContent(stream);

            string result = "";

            using (var httpClient = new HttpClient())
            {
                //setup HttpClient
                httpClient.BaseAddress = new Uri(apiUrl);
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", apiKey);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));

                //setup data object
                HttpContent content = new StreamContent(stream); //TESTTESTS

                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/octet-stream");

                //make request
                var response = await httpClient.PostAsync(apiUrl, content);

                //read response and write to view
                result = await response.Content.ReadAsStringAsync();
            }




            return result;

        }
    }
}
