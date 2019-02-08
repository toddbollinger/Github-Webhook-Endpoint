using System;

namespace Github.Webhook.Endpoint.PushAlerts
{
    public class Commit
    {
        public string id { get; set; }
        public string tree_id { get; set; }
        public bool distinct { get; set; }
        public string message { get; set; }
        public DateTime timestamp { get; set; }
        public string url { get; set; }
        public Author author { get; set; }
        public Committer committer { get; set; }
        public string[] added { get; set; }
        public string[] removed { get; set; }
        public string[] modified { get; set; }
    }
}
