using RestSharp.Service.Models;
using System.Threading.Tasks;

namespace RestSharp.Service
{
    public interface IRestService
    {
        IRestResponse Request(string url, Method method = Method.GET, RestConfig configs = default);
        Task<IRestResponse> RequestAsync(string url, Method method = Method.GET, RestConfig configs = default);
    }
}