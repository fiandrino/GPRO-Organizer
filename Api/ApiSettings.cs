using Microsoft.Win32;
using go.Utils;

#nullable disable
namespace go.Api
{
    // Settings for the GPRO API, stored in the same registry key as the other GUI settings.
    public static class ApiSettings
    {
        private const string RegistryPath = "Software\\go\\GUI";
        private const string UseApiName = "UseGproApi";
        private const string TokenName = "GproApiToken";

        // Same key that is used to protect the saved password.
        private const string CipherKey = "phdsp98q4tæqæræosalæx-lkdsvjipo.LKLDUSFÆIREp98 w3rp98y<ÆH æFp9843æiohfp9y<ftg";

        // The choice made by the user in the Settings window.
        public static bool Enabled
        {
            get
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryPath);
                string value = key.GetValue(UseApiName) as string;
                key.Close();

                return value == "Yes";
            }
        }

        // True when the program should call the API: it is enabled and there is a token.
        public static bool UseApi
        {
            get { return Enabled && Token != ""; }
        }

        public static string Token
        {
            get
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryPath);
                string cipherText = key.GetValue(TokenName) as string;
                key.Close();

                if (string.IsNullOrEmpty(cipherText))
                {
                    return "";
                }

                try
                {
                    return EncDec.Decrypt(cipherText, CipherKey);
                }
                catch
                {
                    // A broken value must not stop the program. The user can enter the token again.
                    return "";
                }
            }
        }

        public static void Save(bool useApi, string token)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryPath);

            key.SetValue(UseApiName, useApi ? "Yes" : "No");
            key.SetValue(TokenName, EncDec.Encrypt(token ?? "", CipherKey));
            key.Close();
        }
    }
}
