using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CreateFakeData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating fake data");

            var demoData = Property.FakeData.Generate(100).ToList();

            using(StreamWriter file = File.CreateText(@"C:\Users\ryan\source\repos\CreateFakeData\CreateFakeData\demodata.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, demoData);
            }

            //Console.WriteLine(JsonConvert.SerializeObject(demoData, Formatting.Indented));
        }
    }
}