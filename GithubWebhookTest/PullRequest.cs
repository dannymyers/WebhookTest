using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GithubWebhookTest
{
    public static class PullRequest
    {
        [FunctionName("PullRequest")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("PullRequest Called");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            log.LogInformation("Request Body {Body}", requestBody);
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            return new OkObjectResult(data);
        }
    }
}
