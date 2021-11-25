# Rest.Service
A .Net service wrapper for RestSharp package for REST request.
### How to use?
In .Net Core:
```
Install-Package Rest.Service
```
Use the following namespace.
```
using RestSharp;
using RestSharp.Service.Interfaces;
```

You just need to inject the ```IRestService``` interface.
For example:
```
public class HomeController : ControllerBase {

  private readonly IRestService restService;
  public HomeController(IRestService _restService) {
    restService = _restService;
  }
  
  [HttpGet]
  public IActionResult Index() {
    var response = restService.Request("google.com");
  }
}
```

Default request is GET, also you can request on other actions e.g.
```
    var response = restService.Request("google.com", HttpMethod.Post);
```
