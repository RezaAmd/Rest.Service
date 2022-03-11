<div align="center">
  <p>
    <a href="https://www.nuget.org/packages/Rest.Service/" target="_blank">
      <img src="https://api.nuget.org/v3-flatcontainer/rest.service/1.0.4/icon" width="100px" />
    </a>
  <h1>Rest.Service</h1>
  </p>
  <p>
    <a href="https://www.nuget.org/packages/Rest.Service/" target="_blank"><img src="https://img.shields.io/nuget/v/Rest.Service.svg" alt="NuGet" /></a>
    <a href="https://docs.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-5.0" target="_blank"><img src="https://badgen.net/badge/.net/v5.0/purple"/></a>
    <a href="https://www.nuget.org/packages/Rest.Service" target="_blank"><img src="https://img.shields.io/nuget/dt/Rest.Service"/></a>
  </p>
  <p>Dotnet service wrapper for <a href="https://github.com/restsharp/RestSharp"> RestSharp </a> package for REST request.</p>
</div>

## How to use?
In .Net Core - [NuGet](https://www.nuget.org/packages/Rest.Service):
```
Install-Package Rest.Service
```

## Quick start
For example in c# console:
```
  using RestSharp.Service;
```
```
internal class Program
{
  private static IRestService restService = new RestService();
  
  static void Main(string[] args)
  {
    var response = restService.Request("https://google.com");
      
    Console.WriteLine(response.StatusCode);
  }
}
```
## Configs
Default request is GET, also you can request on other actions (Post, Put, Delete, ...) e.g.
```
    var response = restService.Request("https://google.com", HttpMethod.Post, new()
    {
      Authorization = new RestBearerAuth("JWT_TOKEN"),
      Body = object,
      Headers = new Dictionary<string, string>(),
      Parameters = new Dictionary<string, string>()
    });
```
Supported authentications:
`RestBearerAuth("JWT_TOKEN")`
`RestBasicAuth(username, password)`
`RestHawkAuth(string authId, string authKey, HawkAlgorithm algorithm = HawkAlgorithm.Sha256)`

## How to use in Asp.net?
1- At first, we need config Rest.Service in `startup.cs`:
```
using RestSharp.Service;
```
```
Services.AddRestServices();
```

2- Now to use, do the following:
```
using RestSharp;
using RestSharp.Service.Interfaces;
```
```
public class HomeController : ControllerBase
{

  private readonly IRestService restService;
  
  public HomeController(IRestService _restService)
  {
    restService = _restService;
  }
  
  [HttpGet]
  public IActionResult Index()
  {
    var response = restService.Request("https://google.com"); // GET Request
  }
}
```
