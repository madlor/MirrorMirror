using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MirrorMirror.Models.APIs
{
    public static class FaceApiConfiguration
    {
        static string[] personGroupDetails;

        static string path = @"faceapiconfig\";
        static string configFilename = "config.txt";

        public static string[] GetPersonGroupID()
        {
            if (personGroupDetails == null)
            {
                if (File.Exists(path + configFilename))
                {
                    try
                    {
                        personGroupDetails = File.ReadAllLines(path + configFilename);
                    }
                    catch(Exception)
                    {
                        //DO STUFF
                    }
                }
            }

            return personGroupDetails;
        }

        public static void SetPersonGroupID(string groupID, string groupName)
        {
            if (!File.Exists(path + configFilename))
            {
                File.Create(path + configFilename);
            }
            string[] fileText = { groupID, groupName };
            File.WriteAllLines(path + configFilename, fileText);
        }
    }
}
