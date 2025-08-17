using Newtonsoft.Json;
using SeleniumFramework.Models;

namespace SeleniumFramework.Utilities
{
    public class TestDataReader
    {
        public static IEnumerable<T> ReadTestData<T>(string filePath)
        {
            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(jsonData);
        }
        public static IEnumerable<LoginData> GetLoginUserData()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "loginData.json");
            return ReadTestData<LoginData>(filePath);
        }
        public static IEnumerable<RegisterUserdata> GetRegisterUserData()

        {
            var filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData", "registerUserData.json");
            return ReadTestData<RegisterUserdata>(filepath);
        }
    }
}