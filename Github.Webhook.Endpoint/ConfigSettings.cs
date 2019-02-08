using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Github.Webhook.Endpoint
{
    public class ConfigSettings
    {
        public string SMTPHost { get; set; }
        public int SMTPPort { get; set; } = 25;
        public bool SMTPUseSSL { get; set; }
        public string SMTPUser { get; set; }
        public string SMTPPassword { get; set; }
        public string AlertEmailFrom { get; set; }
        public string AlertEmailTo { get; set; }
    }
}
