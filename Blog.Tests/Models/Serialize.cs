namespace Blog.Tests.Models
{
    using Newtonsoft.Json;

    public static class Serialize
    {
        public static string ToJson(this RegistrationUser self) => JsonConvert.SerializeObject(self, Blog.Tests.Converter.Settings);

        public static string ToJson(this Article self) => JsonConvert.SerializeObject(self, Blog.Tests.Converter.Settings);

        public static string ToJson(this ActiveUser self) => JsonConvert.SerializeObject(self, Blog.Tests.Converter.Settings);
    }
}
