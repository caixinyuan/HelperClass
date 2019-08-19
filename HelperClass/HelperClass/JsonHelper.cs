using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HelperClass
{
    /// <summary>
    /// 
    /// 来源于开源项目LdCms
    /// 
    /// 
    /// Json操作类
    /// </summary>
   public static class JsonHelper
    {
        public static bool IsJson(this string str)
        {
            try
            {
                Newtonsoft.Json.Linq.JObject.Parse(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static object ToJson(this string json)
        {
            return json == null ? null : Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        }
        public static string ToJson(this object obj)
        {
            var timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, timeConverter);
        }
        public static string ToJson(this object obj, string datetimeformats)
        {
            var timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter { DateTimeFormat = datetimeformats };
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, timeConverter);
        }
        public static T ToObject<T>(this string json)
        {
            return json == null ? default(T) : Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
        public static T ToObject<T>(this object obj)
        {
            string json = obj.ToJson();
            return json == null ? default(T) : Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 转List集合，反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this string json)
        {
            return json == null ? null : Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);
        }

        /// <summary>
        /// json转DataTable
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static DataTable ToTable(this string json)
        {
            return json == null ? null : Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static JObject ToJObject(this string json)
        {
            return json == null ? Newtonsoft.Json.Linq.JObject.Parse("{}") : Newtonsoft.Json.Linq.JObject.Parse(json.Replace("&nbsp;", ""));
        }
    }
}
