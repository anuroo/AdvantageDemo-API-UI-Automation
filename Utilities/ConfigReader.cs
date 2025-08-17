using Newtonsoft.Json.Linq;
namespace SeleniumFramework.Utilities
{
    public static class ConfigReader
    {
        private static readonly JObject configData;
        static ConfigReader()
        {
            string jsonPath = Path.Combine(AppContext.BaseDirectory, "appsettings.json");
            string json = File.ReadAllText(jsonPath);
            configData = JObject.Parse(json);
        }
        public static string Get(string key) => configData[key]?.ToString();
    }
       
}