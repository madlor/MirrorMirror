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
        private FaceServiceClient faceClient;        
        //private string apiKey = KeyHandler.GetFaceApiKey();
        //private string apiUrl = "https://api.projectoxford.ai/face/v1.0/detect?returnFaceId=true";

        private string[] personGroupID = FaceApiConfiguration.GetPersonGroupID();

        public FaceApi()
        {
            faceClient = new FaceServiceClient(KeyHandler.GetFaceApiKey());            
        }

        public async Task<string> DetectFace(string image)
        {
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(image));
            var face = await faceClient.DetectAsync(stream, true);

            return face[0].FaceId.ToString();
        }

        public async void CreatePersonGroup(string groupID, string groupName)
        {
            await faceClient.CreatePersonGroupAsync(groupID, groupName);
        }
    }
}
