using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Github.Webhook.Endpoint.PushAlerts
{
    public class PushAlert
    {
        public string _ref { get; set; }
        public string before { get; set; }
        public string after { get; set; }
        public bool created { get; set; }
        public bool deleted { get; set; }
        public bool forced { get; set; }
        public string base_ref { get; set; }
        public string compare { get; set; }
        public Commit[] commits { get; set; }
        public Commit head_commit { get; set; }
        public Repository repository { get; set; }
        public Pusher pusher { get; set; }
        public Sender sender { get; set; }
    }
}
