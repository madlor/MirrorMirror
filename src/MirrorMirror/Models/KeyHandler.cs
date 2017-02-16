using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace MirrorMirror.Models
{
    public static class KeyHandler
    {
        private static string faceApiKey = "";

        static string path = @"secrets\";
        static string faceApiFilename = "FaceApi.txt";

        public static string GetFaceApiKey()
        {
            if (faceApiKey == "")
            {
                if (File.Exists(path + faceApiFilename))
                {
                    try
                    {
                        faceApiKey = File.ReadAllLines(path + faceApiFilename)[0];
                    }
                    catch (Exception)
                    {
                        //DO STUFF
                    }
                }
            }

            return faceApiKey;
        }

        public static void SetFaceApiKey(string key)
        {
            //TODO: verify key is valid
            if(!File.Exists(path + faceApiFilename))
            {
                File.Create(path + faceApiFilename);
            }
            File.WriteAllText(path + faceApiFilename, key);
        }
    }
}
