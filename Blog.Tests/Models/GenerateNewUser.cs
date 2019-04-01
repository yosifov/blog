namespace Blog.Tests.Models
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    partial class GenerateNewUser
    {
        public void NewUser(string userPath)
        {
            string json = File.ReadAllText(userPath);

            var jObject = JObject.Parse(json);

            string email = jObject["email"].ToString();

            string username = email.Split('@').ElementAtOrDefault(0);
            int lastdigit = (int)Char.GetNumericValue(username[username.Length - 1]);
            lastdigit++;
            username = username.Remove(username.Length - 1);
            string domain = email.Split('@').ElementAtOrDefault(1);
            string newEmail = username + lastdigit + "@" + domain;

            jObject["email"] = string.Empty;
            jObject["email"] = newEmail;

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jObject, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(userPath, output);
        }
        
    }
}
