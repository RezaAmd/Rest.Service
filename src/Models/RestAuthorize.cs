using Rest.Service.Extension;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace Rest.Service.Models
{
    public abstract class RestAuthorize
    {
        public abstract string Serialize();
    }

    public class RestBearerAuth : RestAuthorize
    {
        public RestBearerAuth(string token)
        {
            Token = token;
        }
        public string Token { get; set; }

        public override string Serialize()
        {
            return "Bearer " + Token;
        }
    }
    public class RestBasicAuth : RestAuthorize
    {
        public RestBasicAuth(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public override string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    public class RestHawkAuth : RestAuthorize
    {
        public RestHawkAuth(string authId, string authKey, HawkAlgorithm algorithm = HawkAlgorithm.Sha256)
        {
            AuthID = authId;
            AuthKey = authKey;
            Algorithm = algorithm.ToDisplay();
        }
        public string AuthID { get; set; }
        public string AuthKey { get; set; }
        public string Algorithm { get; protected set; }
        public override string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public enum HawkAlgorithm
    {
        [Display(Name = "Sha256")]
        Sha256,
        [Display(Name = "Sha1")]
        Sha1
    }
}