using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Github.Webhook.Endpoint
{
    public class EmailerSettings
    {
        public string SMTPHost { get; set; }
        public int SMTPPort { get; set; }
        public string SMTPUser { get; set; }
        public string SMTPPassword { get; set; }
        public bool SMTPUseSSL { get; set; }
        public string EmailFrom { get; set; }
        public string EmailTo { get; set; }
    }
}
