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
        public static List<Person> listScoreData;
        public static void MakeJsonFile(Person person)
        {
            ReadJsonFile();
            listScoreData.Add(person);
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
            File.WriteAllText("Data.json", JsonConvert.SerializeObject(listScoreData));
            
        }

        private static void ReadJsonFile()
        {
            listScoreData = File.Exists("Data.json") ? JsonConvert.DeserializeObject<List<Person>>(File.ReadAllText("Data.json")) : new List<Person>();
        }
    }
}
