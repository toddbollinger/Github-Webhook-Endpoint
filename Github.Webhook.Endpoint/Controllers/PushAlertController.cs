using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Newtonsoft.Json;

namespace Github.Webhook.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushAlertController : ControllerBase
    {
        private readonly IEmailer _emailer;
        public PushAlertController(IEmailer emailer)
        {
            _emailer = emailer;
        }
        // POST api/pushalert
        [HttpGet]
        public ActionResult<DateTime> Get()
        {
            return DateTime.UtcNow;
        }

        // POST api/pushalert
        [HttpPost]
        public void Post([FromBody] PushAlerts.PushAlert pushAlert)
        {
            string subject = $"New {pushAlert?.repository?.name} Commit";
            string body = $"A new {pushAlert?.repository?.name} commit was made by {pushAlert?.head_commit?.author?.name}. Notes:{pushAlert?.head_commit?.message}";
            _emailer.SendEmail(subject, body);
        }

    }
}
