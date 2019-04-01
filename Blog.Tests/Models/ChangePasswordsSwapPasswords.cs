namespace Blog.Tests.Models
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    partial class SwapPasswordsAfterPasswordChange
    {
        public void SwapPasswords(string userPath)
        {
            string json = File.ReadAllText(userPath);

            var jObject = JObject.Parse(json);

            string currentPassword = jObject["currentPassword"].ToString();

            if (currentPassword == "Dulcy1")
            {
                jObject["currentPassword"] = string.Empty;
                jObject["currentPassword"] = "Dulcy2";
                jObject["newPassword"] = string.Empty;
                jObject["newPassword"] = "Dulcy1";
                jObject["confirmPassword"] = string.Empty;
                jObject["confirmPassword"] = "Dulcy1";
            }
            else if (currentPassword == "Dulcy2")
            {
                jObject["currentPassword"] = string.Empty;
                jObject["currentPassword"] = "Dulcy1";
                jObject["newPassword"] = string.Empty;
                jObject["newPassword"] = "Dulcy2";
                jObject["confirmPassword"] = string.Empty;
                jObject["confirmPassword"] = "Dulcy2";
            }

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(userPath, output);
        }
        
    }
}
