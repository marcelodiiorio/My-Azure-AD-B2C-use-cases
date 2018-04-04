#r "Newtonsoft.Json"

using System;
using System.Net;
using System.Web;
using System.Net.Http.Formatting;
using Newtonsoft.Json;

public static async Task<object> Run(HttpRequestMessage request, TraceWriter log)
{

    log.Info($"Webhook was triggered!");
          
    string requestContentAsString = await request.Content.ReadAsStringAsync();
    dynamic requestContentAsJObject = JsonConvert.DeserializeObject(requestContentAsString);

    //var response = request.CreateResponse(HttpStatusCode.Moved);

    if (requestContentAsJObject.VerifiedEmail != null)
    {
        var VerifiedEmail = ((string) requestContentAsJObject.VerifiedEmail).ToLower();
        if (VerifiedEmail.Contains("hotmail") || VerifiedEmail.Contains("outlook") == true)
            {
                return request.CreateResponse<ResponseContent>(
                    HttpStatusCode.Conflict,
                    new ResponseContent
                    {
                        version = "1.0.0",
                        status = (int) HttpStatusCode.Conflict,
                        userMessage = $"In order to sign-up, go back an select the Microsoft Account option.",
                    },
                    new JsonMediaTypeFormatter(),
                    "application/json");
            }
        else
            {
                return request.CreateResponse(HttpStatusCode.OK); 
                //response.Headers.Location = new Uri("http://www.google.com");
                //return response;              
            }
    }

    if (requestContentAsJObject.VerifiedSignInName != null)
    {
        var VerifiedSignInName = ((string) requestContentAsJObject.VerifiedSignInName).ToLower();
        if (VerifiedSignInName.Contains("hotmail") || VerifiedSignInName.Contains("outlook") == true)
            {
                return request.CreateResponse<ResponseContent>(
                    HttpStatusCode.Conflict,
                    new ResponseContent
                    {
                        version = "1.0.0",
                        status = (int) HttpStatusCode.Conflict,
						//We show a standard message, assuming the IdP button is above the form filled by the user. Of course, it can be customized.
                        userMessage = $"In order to sign-in, please use the Microsoft Account button above.",
                    },
                    new JsonMediaTypeFormatter(),
                    "application/json");
            }
        else
            {
                return request.CreateResponse(HttpStatusCode.OK);
            }
    }
    //response.Headers.Location = new Uri("http://www.google.com");
    //return response;}
    return request.CreateResponse(HttpStatusCode.OK);

}
    
public class ResponseContent
{
    public string version { get; set; }
    public int status { get; set; }
    public string userMessage { get; set; }
}
