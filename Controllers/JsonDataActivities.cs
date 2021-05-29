using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shooter.Controllers
{
    public class Person
    {
        public string Name;
        public int Score;
    }
    public static class JsonDataActivities
    {
        public static List<Person> ListScoreData;
        public static void MakeJsonFile(Person person)
        {
            ReadJsonFile();
            ListScoreData.Add(person);
            FirstStepToMakeJsonFile();
        }
        public static void FirstStepToMakeJsonFile()
        {
            /*
            using (FileStream fs = new FileStream("ScoreData.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<List<Person>>(fs, listScoreData);
                Console.WriteLine("Data has been saved to file");
            }*/
            File.WriteAllText("Data.json", JsonConvert.SerializeObject(ListScoreData));
            
        }

        public static void ReadJsonFile()
        {
            ListScoreData = File.Exists("Data.json") ? JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText("Data.json")) : new List<Person>();
        }
    }
}
