using go.Comms;
using go.Utils;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

#nullable disable
namespace go.Api
{
    // Small client for the GPRO public API.
    // Every request uses the Bearer token taken from the GPRO App / Web App.
    public class ApiClient
    {
        private const string BaseUrl = "https://gpro.net/gb/backend/api/v2/";

        private static readonly HashSet<string> loggedEndpoints = new HashSet<string>();

        private readonly string token;

        public ApiClient(string token)
        {
            this.token = token;
        }

        // Calls one endpoint, for example "Menu" or "office",
        // and converts the JSON answer into the given class.
        public T Get<T>(string endpoint)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseUrl + endpoint);

            request.Method = "GET";
            request.Accept = "application/json";
            request.Headers.Add("Authorization", "Bearer " + this.token);
            request.UserAgent = Communication.AppInfo.UserAgent;
            request.Timeout = 20000;
            request.ReadWriteTimeout = 20000;
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                string json = reader.ReadToEnd();
                T result = JsonConvert.DeserializeObject<T>(json);

                LogFirstSuccess(endpoint);

                return result;
            }
        }

        // Written only when the answer was read correctly, and only once for each endpoint
        // every time the program runs, so the log shows which calls worked without growing.
        private static void LogFirstSuccess(string endpoint)
        {
            string name = endpoint.Split('?')[0];

            if (loggedEndpoints.Add(name))
            {
                Errlog.AddToLog("GPRO API OK: " + name);
            }
        }
    }
}
