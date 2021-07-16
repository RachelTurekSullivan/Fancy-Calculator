using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FanciestWebCalculator
{
    public static class SessionExtentions
    {

        public static void Set(this ISession session, string key, object value)
        {
            var valueString = JsonConvert.SerializeObject(value);
            session.SetString(key,valueString);
        }
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }

        
    }
}
