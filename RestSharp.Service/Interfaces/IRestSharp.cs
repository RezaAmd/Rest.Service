using RestSharp.Service.Models;
using System.Threading.Tasks;

namespace RestSharp.Service.Interfaces
{
    internal interface IRestSharp
    {
        Task<IRestResponse> RequestAsync(string url, Method method = Method.GET, RestConfig configs = default);
    }
}