using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KCS_Retro
{
    public static class FileConfig
    {
        public static KansasCityStandardParameters LoadKcsSettings(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<KansasCityStandardParameters>(json);
            }
            else
            {
                // Lager standard-innstillinger
                var defaultParams = new KansasCityStandardParameters();
                SaveKcsSettings(defaultParams, filePath); // Lagre første gang
                return defaultParams;
            }
        }
        public static void SaveKcsSettings(KansasCityStandardParameters kcsParams, string filePath)
        {
            var json = JsonSerializer.Serialize(kcsParams, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }


    }
}
