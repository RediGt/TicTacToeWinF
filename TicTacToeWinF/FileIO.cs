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
        public static void SaveToFile()//GameArea area)
        {
            string jsonString;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            //jsonString = System.Text.Json.JsonSerializer.Serialize(area, options);

            //File.WriteAllText(GetGameFile(), jsonString);
        }

        public static void LFF() //GameArea LoadFromFile()
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

                //return System.Text.Json.JsonSerializer.Deserialize<GameArea>(json);
            }
            catch
            {
                Console.WriteLine("Error loading the game. A new game is created.");
                //return null;
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
