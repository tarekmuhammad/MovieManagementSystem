//using brca.Core.Interfaces;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;

#nullable disable
namespace brca.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static string GetMemberDisplayName(this object value, string member)
        {
            Type type = value.GetType();
            FieldInfo field = type.GetField(member);
            if (!(field == (FieldInfo)null))
                return field.GetCustomAttribute<DisplayAttribute>()?.Name;
            PropertyInfo property = type.GetProperty(member);
            if ((object)property == null)
                return (string)null;
            return property.GetCustomAttribute<DisplayAttribute>()?.Name;
        }

        //public static string GetChange<T>(this T oldDm, T newDm)
        //{
        //    Dictionary<string, object> betweenTwoObject = ObjectExtensions.getChangeBetweenTwoObject<T>(oldDm, newDm);
        //    string change = string.Empty;
        //    if (betweenTwoObject.Count > 0)
        //        change = string.Join("|", betweenTwoObject.Select<KeyValuePair<string, object>, string>((Func<KeyValuePair<string, object>, string>)(s =>
        //        {
        //            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 2);
        //            interpolatedStringHandler.AppendFormatted(s.Key);
        //            interpolatedStringHandler.AppendLiteral("::");
        //            interpolatedStringHandler.AppendFormatted<object>(s.Value);
        //            return interpolatedStringHandler.ToStringAndClear();
        //        })));
        //    return change;
        //}

        //public static T SetDeltaValues<T>(this T dm) where T : class, new()
        //{
        //    foreach ((string str, object newValue) in ObjectExtensions.getDeltaValues<T>(dm))
        //        dm.SetValue(str, newValue);
        //    return dm;
        //}

        //public static IEnumerable<string> GetColumnsbyDeltaValues<T>(this T dm) where T : class, new()
        //{
        //    return dm is IHasEditRequest<T> hasEditRequest && !string.IsNullOrEmpty(hasEditRequest.DeltaValues) ? (IEnumerable<string>)((IEnumerable<string>)hasEditRequest.DeltaValues.Split('|')).Select<string, string>((Func<string, string>)(s => s.Split(new string[1]
        //    {
        //"::"
        //    }, StringSplitOptions.None)[0])).ToArray<string>() : (IEnumerable<string>)null;
        //}

        public static bool SetValue(this object obj, string propertyName, object newValue)
        {
            PropertyInfo property = obj.GetType().GetProperty(propertyName);
            if (property == (PropertyInfo)null || !property.CanWrite)
                return false;
            Type type1 = Nullable.GetUnderlyingType(property.PropertyType);
            if ((object)type1 == null)
                type1 = property.PropertyType;
            Type type2 = type1;
            if (property.PropertyType.IsEnum)
            {
                object obj1 = string.IsNullOrEmpty(newValue?.ToString()) ? (object)null : Enum.Parse(type2, newValue.ToString(), true);
                property.SetValue(obj, obj1);
            }
            else if (type2 == typeof(Guid))
            {
                Guid? nullable = string.IsNullOrEmpty(newValue?.ToString()) ? new Guid?() : new Guid?(Guid.Parse(newValue.ToString()));
                property.SetValue(obj, (object)nullable);
            }
            else
            {
                object obj2 = string.IsNullOrEmpty(newValue?.ToString()) ? (object)null : Convert.ChangeType(newValue, type2);
                property.SetValue(obj, obj2);
            }
            return true;
        }

        public static object GetValue(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName)?.GetValue(obj);
        }

        //private static Dictionary<string, object> getChangeBetweenTwoObject<T>(T oldDm, T newDm)
        //{
        //    Dictionary<string, object> betweenTwoObject = new Dictionary<string, object>();
        //    foreach (PropertyInfo property in newDm.GetType().GetProperties())
        //    {
        //        List<string> list = ((IEnumerable<PropertyInfo>)typeof(IsEntity).GetProperties()).Select<PropertyInfo, string>((Func<PropertyInfo, string>)(s => s.Name)).ToList<string>();
        //        list.AddRange(((IEnumerable<PropertyInfo>)typeof(IHasEditRequest<>).GetProperties()).Select<PropertyInfo, string>((Func<PropertyInfo, string>)(s => s.Name)));
        //        if (!list.Contains(property.Name) && !property.GetMethod.IsVirtual && property.GetCustomAttributes(typeof(NotMappedAttribute), false).Length == 0 && oldDm.GetType().GetProperty(property.Name)?.GetValue((object)oldDm)?.ToString() != property.GetValue((object)newDm)?.ToString())
        //            betweenTwoObject.Add(property.Name, oldDm.GetType().GetProperty(property.Name)?.GetValue((object)oldDm));
        //    }
        //    return betweenTwoObject;
        //}

        //private static Dictionary<string, object> getDeltaValues<T>(T dm) where T : class, new()
        //{
        //    Dictionary<string, object> deltaValues = new Dictionary<string, object>();
        //    if (dm is IHasEditRequest<T> hasEditRequest && !string.IsNullOrEmpty(hasEditRequest.DeltaValues))
        //    {
        //        foreach (string str in hasEditRequest.DeltaValues.Split('|'))
        //        {
        //            string[] separator = new string[1] { "::" };
        //            string[] strArray = str.Split(separator, StringSplitOptions.None);
        //            deltaValues.Add(strArray[0], (object)strArray[1]);
        //        }
        //    }
        //    return deltaValues;
        //}

        public static T Clone<T>(this T obj, params string[] withoutPropeties) where T : new()
        {
            T obj1 = new T();
            foreach (PropertyInfo property in obj1.GetType().GetProperties())
            {
                if (!((IEnumerable<string>)withoutPropeties).Contains<string>(property.Name))
                    ((object)obj1).SetValue(property.Name, ((object)obj).GetValue(property.Name));
            }
            return obj1;
        }

        public static T Copy<T>(this object inObj) where T : new()
        {
            T obj = new T();
            foreach (PropertyInfo property1 in obj.GetType().GetProperties())
            {
                PropertyInfo property = property1;
                if (((IEnumerable<PropertyInfo>)inObj.GetType().GetProperties()).Any<PropertyInfo>((Func<PropertyInfo, bool>)(m => m.Name == property.Name)))
                    ((object)obj).SetValue(property.Name, inObj.GetValue(property.Name));
            }
            return obj;
        }

        //public static string SerializeObject(this object obj, bool camelCase = false)
        //{
        //    if (!camelCase)
        //        return JsonConvert.SerializeObject(obj);
        //    JsonSerializerSettings settings = new JsonSerializerSettings()
        //    {
        //        ContractResolver = (IContractResolver)new CamelCasePropertyNamesContractResolver()
        //    };
        //    return JsonConvert.SerializeObject(obj, settings);
        //}

        //public static T DeserializeObject<T>(this string json)
        //{
        //    return JsonConvert.DeserializeObject<T>(json);
        //}

        //public static string GetJsonForReport(this object json)
        //{
        //    string str = JsonConvert.SerializeObject(json).Remove(0, 1);
        //    return str.Remove(str.Length - 1);
        //}

        public static int ToInt(this object obj, int ReturnValue = 0)
        {
            double result = (double)ReturnValue;
            return obj.Nz() == "" || !double.TryParse(obj.Nz("0").Replace("(", "-").Replace(")", ""), out result) ? ReturnValue : (int)result;
        }

        public static double ToDouble(this object obj, double ReturnValue = 0.0)
        {
            double result = ReturnValue;
            if (obj.Nz() == "")
                return ReturnValue;
            return double.TryParse(obj.Nz("0").Replace("(", "-").Replace(")", ""), out result) ? double.Parse(obj.Nz("0").Replace("(", "-").Replace(")", "")) : result;
        }

        public static Decimal? ToDecimal(this object obj, Decimal? ReturnValue = null)
        {
            Decimal result = !ReturnValue.HasValue || !ReturnValue.HasValue ? 0M : ReturnValue.Value;
            if (obj.Nz() == "")
                return ReturnValue;
            return Decimal.TryParse(obj.Nz("0").Replace("(", "-").Replace(")", ""), out result) ? new Decimal?(Decimal.Parse(obj.Nz("0").Replace("(", "-").Replace(")", ""))) : new Decimal?(result);
        }

        public static double? ToDouble(this object obj, double? ReturnValue)
        {
            double result = !ReturnValue.HasValue || !ReturnValue.HasValue ? 0.0 : ReturnValue.Value;
            if (obj.Nz() == "")
                return ReturnValue;
            return double.TryParse(obj.Nz("0").Replace("(", "-").Replace(")", ""), out result) ? new double?(double.Parse(obj.Nz("0").Replace("(", "-").Replace(")", ""))) : new double?(result);
        }

        public static string Nz(this object obj, string value = "")
        {
            return obj == null || obj == DBNull.Value || obj.ToString() == "" ? value : obj.ToString();
        }

        public static DateTime ToDateTime(this object obj, DateTime? Dflt = null)
        {
            DateTime minValue = (DateTime)SqlDateTime.MinValue;
            if (!Dflt.HasValue)
                Dflt = new DateTime?(minValue);
            DateTime result;
            if (!(obj.Nz() != "") || !DateTime.TryParse(obj.Nz(), out result))
                return Dflt.Value;
            if (result >= minValue)
                return DateTime.Parse(obj.Nz());
            DateTime dateTime = DateTime.Parse(obj.Nz());
            return new DateTime(minValue.Year, minValue.Month, minValue.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        }

        public static void SetValues(this object obj, Dictionary<string, string> pairs)
        {
            foreach (PropertyInfo property1 in obj.GetType().GetProperties())
            {
                PropertyInfo property = property1;
                KeyValuePair<string, string> keyValuePair = pairs.FirstOrDefault<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>)(kv => string.Equals(kv.Key, property.Name, StringComparison.OrdinalIgnoreCase)));
                if (keyValuePair.Key != null)
                    property.SetValue(obj, Convert.ChangeType((object)keyValuePair.Value, property.PropertyType));
            }
        }
    }
}
