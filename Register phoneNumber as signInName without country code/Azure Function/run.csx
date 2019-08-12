#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{

  log.LogInformation("C# HTTP trigger function processed a request.");
  string phoneNumberWithCountryCode = req.Query["phoneNumberWithCountryCode"];
  string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
  dynamic data = JsonConvert.DeserializeObject(requestBody);
  phoneNumberWithCountryCode = phoneNumberWithCountryCode ?? data?.phoneNumberWithCountryCode;

  return phoneNumberWithCountryCode != null
    ? (ActionResult)new OkObjectResult(
      new ResponseContent
      {
        version = "1.0.0",
        status = (int) HttpStatusCode.OK,
        phoneNumberNoCountryCode = phoneNumberWithCountryCode.Substring(phoneNumberWithCountryCode.Length-9)
      })
      : new BadRequestObjectResult("Error");
}

public class ResponseContent
{
    public string version { get;set; }
    public int status { get; set; }
    public string phoneNumberNoCountryCode {get; set; }
}