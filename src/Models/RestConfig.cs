using Rest.Service.Models;
using System.Collections.Generic;

namespace RestSharp.Service.Models
{
    public class RestConfig
    {
        #region Constructor
        public RestConfig(RestAuthorize authorization = default, object body = default, Dictionary<string, string> headers = default)
        {
            Headers = new Dictionary<string, string>();
            Parameters = new Dictionary<string, string>();
            Authorization = authorization;
            Body = body;
            Headers = headers;
        }
        #endregion
        public RestAuthorize Authorization { get; set; }
        public object Body { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
    }
}