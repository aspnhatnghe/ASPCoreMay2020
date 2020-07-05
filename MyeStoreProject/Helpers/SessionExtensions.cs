using Microsoft.AspNetCore.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text.Json;

namespace MyeStoreProject.Helpers
{
    public static class SessionExtensions
    {
        public static void SetSession<NN>(this ISession session, string key, NN value)
        {
            var jsonObj = JsonSerializer.Serialize(value);
            session.SetString(key, jsonObj);
        }

        public static NN GetSession<NN>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<NN>(value);
        }
    }
}
