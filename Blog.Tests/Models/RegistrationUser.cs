namespace Blog.Tests.Models
{
    using Newtonsoft.Json;

    public partial class RegistrationUser
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("confirmPassword")]
        public string ConfirmPassword { get; set; }

        public static RegistrationUser FromJson(string json) => JsonConvert.DeserializeObject<RegistrationUser>(json, Converter.Settings);
    }
}
