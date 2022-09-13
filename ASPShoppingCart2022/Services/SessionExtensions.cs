using Microsoft.AspNetCore.Http;
using Utf8Json;
using Utf8Json.Resolvers;

namespace ASPShoppingCart2022.Services
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession sess, string key, T value)
        {
            JsonSerializer.SetDefaultResolver(StandardResolver.AllowPrivateCamelCase);
            var s = JsonSerializer.ToJsonString(value);
            sess.SetString(key, s);
        }

        public static T Get<T>(this ISession sess, string key)
        {
            var value = sess.GetString(key);
            Console.WriteLine("value");
            if (value == null)
                return default;
            return JsonSerializer.Deserialize<T>(value);
        }
    }
}
