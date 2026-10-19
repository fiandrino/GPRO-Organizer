using go.Utils;
using System;

#nullable disable
namespace go.Api
{
    // Reads one endpoint through the API and converts it, if the API is enabled.
    // Returns null when the API is off or the call failed,
    // so the caller can fall back to the web page.
    public static class ApiFallback
    {
        public static TResult Load<TDto, TResult>(string endpoint, Func<TDto, TResult> map)
            where TResult : class
        {
            if (!ApiSettings.UseApi)
            {
                return null;
            }

            try
            {
                ApiClient client = new ApiClient(ApiSettings.Token);

                return map(client.Get<TDto>(endpoint));
            }
            catch (Exception ex)
            {
                Errlog.AddToLog("GPRO API " + endpoint + " failed, using the web page: " + ex.Message);

                return null;
            }
        }
    }
}
