using Rest.Service.Models;
using RestSharp.Service.Models;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestSharp.Service
{
    public class RestService : IRestService
    {
        public IRestResponse Request(string url, Method method = Method.GET, RestConfig configs = default)
        {
            try
            {
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(method);
                if (configs != null)
                {
                    #region Header
                    if (configs.Headers != null)
                        foreach (var header in configs.Headers)
                            request.AddHeader(header.Key, header.Value);
                    request.AddHeader("Content-Type", "application/json");

                    // Authorize
                    if (configs.Authorization != null)
                        request.AddHeader("Authorization", "Bearer " + configs.Authorization.ToString());
                    #endregion
                    #region Parameter
                    if (configs.Body != null)
                    {
                        string bodySerialize = JsonSerializer.Serialize(configs.Body);
                        request.AddParameter("application/json", bodySerialize, ParameterType.RequestBody);
                    }
                    foreach (var parameter in configs.Parameters)
                        request.AddParameter(parameter.Key, parameter.Value);
                    #endregion
                }
                return client.Execute(request);
            }
            catch
            {
                //logger.LogError($"Failed to request {url}");
                return default;
            }
        }

        public async Task<IRestResponse> RequestAsync(string url, Method method = Method.GET, RestConfig configs = default)
        {
            try
            {
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(method);
                if (configs != null)
                {
                    #region Header
                    if (configs.Headers != null)
                        foreach (var header in configs.Headers)
                            request.AddHeader(header.Key, header.Value);
                    request.AddHeader("Content-Type", "application/json");
                    // Auth
                    if(configs.Authorization != null)
                        request.AddHeader("Authorization", configs.Authorization.ToString());
                    #endregion
                    #region Parameter
                    if (configs.Body != null)
                    {
                        string bodySerialize = JsonSerializer.Serialize(configs.Body);
                        request.AddParameter("application/json", bodySerialize, ParameterType.RequestBody);
                    }
                    foreach (var parameter in configs.Parameters)
                        request.AddParameter(parameter.Key, parameter.Value);
                    #endregion
                }
                return await client.ExecuteAsync(request);
            }
            catch
            {
                //logger.LogError($"Failed to request {url}");
                return default;
            }
        }
    }
}