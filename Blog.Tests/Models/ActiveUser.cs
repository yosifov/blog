namespace Blog.Tests.Models
{
    using Newtonsoft.Json;

    public partial class ActiveUser
    {
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("currentPassword")]
        public string CurrentPassword { get; set; }

        [JsonProperty("newPassword")]
        public string NewPassword { get; set; }

        [JsonProperty("confirmPassword")]
        public string ConfirmPassword { get; set; }

        public static ActiveUser FromJson(string json) => JsonConvert.DeserializeObject<ActiveUser>(json, Converter.Settings);
    }
}
