using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MirrorMirror.Models
{
    public static class KeyHandler
    { 
        static string path = @"secrets\";

        public static string GetFaceApiKey()
        {
            return File.ReadAllLines(path + "FaceApi.txt")[0];
        }
    }
}
