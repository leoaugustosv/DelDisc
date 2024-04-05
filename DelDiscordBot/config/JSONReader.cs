using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelDiscordBot.config
{
    //For security reasons with the bot token, it is necessary to create a class to read it and a class to capture its JSON structure
    internal class JSONReader
    {
        public string token { get; set; }
        public string prefix { get; set; }

        public async Task ReadJSON()
        {
            using (StreamReader sr = new StreamReader("config.json"))
            {
               string json = await sr.ReadToEndAsync();
               JSONStructure data = JsonConvert.DeserializeObject <JSONStructure>(json);

               this.token = data.token;
               this.prefix = data.prefix;
            }
        }

    }
    internal sealed class JSONStructure
    {
        public string token { get; set; }
        public string prefix { get; set; }
    }
}
