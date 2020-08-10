using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TicTacToeWinF
{
    class FileIO
    {
        public static void SaveToFile(PlayData pd)
        {
            string jsonString;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            jsonString = System.Text.Json.JsonSerializer.Serialize(pd, options);

            File.WriteAllText(GetGameFile(), jsonString);
        }

        public static PlayData LoadFromFile()
        {
            try
            {
                StreamReader reader = new StreamReader(GetGameFile());
                String line = reader.ReadLine();
                String json = "";

                while (line != null)
                {
                    json += line;
                    line = reader.ReadLine();
                }
                reader.Close();

                return System.Text.Json.JsonSerializer.Deserialize<PlayData>(json);
            }
            catch
            {
                return null;
            }
        }

        public static string GetGameFile()
        {
            string filename = Directory.GetCurrentDirectory();
            filename += @"\TicTacToe.json";

            return filename;
        }
    }
}
