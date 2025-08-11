using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;

namespace FunctionApp1;

public class Functions(IConfiguration configuration)
{
    [Function(nameof(Secret))]
    public IActionResult Secret(
        [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req
    ) => new OkObjectResult(configuration.GetValue<string>("Secret"));
}
