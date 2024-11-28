using brca.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MovieSystem.Application.Helper
{
    public static class StringsExtensions
    {

        private static readonly object _lockObject = new object();
        private static CultureInfo cultureInfoProvider = CultureInfo.InvariantCulture;
        private const string _symmetricKey = "c14dh4827h4e8475uulg2ea5984x3548";

        public static T ToEnum<T>(this string val) where T : struct, Enum => Enum.Parse<T>(val, true);

        public static T ToEnumWithDefault<T>(this string val, T Default) where T : struct, 
            Enum
        {
            T result;
            return Enum.TryParse<T>(val, true, out result) ? result : Default;
        }





        public static string Trns(this string s) => s;

        public static int? ToIntColor(this string val)
        {
            return !string.IsNullOrEmpty(val) ? new int?(int.Parse(val.TrimStart('#'), NumberStyles.HexNumber)) : new int?();
        }

        public static string[] ToArray(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? value.TrimStart(',').TrimEnd(',').Replace("'", "").Split(',') : new string[0];
        }

        public static string AddOne(this string key)
        {
            if (string.IsNullOrEmpty(key))
                key = "0";
            int result;
            if (!key.StartsWith("0") && int.TryParse(key, out result))
                return (result + 1).ToString();
            key = key.ToUpper();
            int num = key.Length - 1;
            if (num < 0)
                return key;
            if (char.IsNumber(key[num]))
            {
                char ch1 = key[num];
                if (ch1 != '9')
                {
                    char ch2 = (char)((uint)ch1 + 1U);
                    return key.Substring(0, num) + ch2.ToString() + key.Substring(num + 1);
                }
                char ch3 = '0';
                key = key.Substring(0, num).AddOne() + ch3.ToString() + key.Substring(num + 1);
                if (num == 0)
                    key = "1" + key;
                return key;
            }
            char ch4 = key[num];
            switch (ch4)
            {
                case 'Z':
                case 'z':
                    char ch5 = '0';
                    return key.Substring(0, num).AddOne() + ch5.ToString() + key.Substring(num + 1);
                default:
                    char ch6 = (char)((uint)ch4 + 1U);
                    return key.Substring(0, num) + ch6.ToString() + key.Substring(num + 1);
            }
        }

        public static string AddZeroOneToString(this string maxNumber, int paddingLenth = 2)
        {
            return (long.Parse(maxNumber ?? "0") + 1L).ToString().PadLeft(paddingLenth, '0');
        }

        public static double ToDouble(this string obj, double defaultValue = 0.0)
        {
            double result;
            return !double.TryParse(obj, out result) ? defaultValue : result;
        }

        public static int ToInt(this string obj, int defaultValue = 0)
        {
            int result;
            return !int.TryParse(obj, out result) ? defaultValue : result;
        }

        public static short ToShort(this string obj, short defaultValue = 0)
        {
            short result;
            return !short.TryParse(obj, out result) ? defaultValue : result;
        }

        public static double? ToRatioValue(this string rat, double? fromValue)
        {
            if (string.IsNullOrEmpty(rat))
                return new double?(0.0);
            if (!rat.Contains("%"))
                return new double?(StringsExtensions.ToDouble(rat));
            double num = StringsExtensions.ToDouble(rat.Replace("%", "")) / 100.0;
            double? nullable = fromValue;
            return !nullable.HasValue ? new double?() : new double?(num * nullable.GetValueOrDefault());
        }

        public static string ToBase64(this string plainText)
        {
            return string.IsNullOrEmpty(plainText) ? plainText : Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        }

        public static string FromBase64(this string base64EncodedData)
        {
            return string.IsNullOrEmpty(base64EncodedData) ? base64EncodedData : Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));
        }

        public static string Compress(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            MemoryStream memoryStream = new MemoryStream();
            using (GZipStream gzipStream = new GZipStream((Stream)memoryStream, CompressionMode.Compress, true))
                gzipStream.Write(bytes, 0, bytes.Length);
            memoryStream.Position = 0L;
            byte[] numArray1 = new byte[memoryStream.Length];
            memoryStream.Read(numArray1, 0, numArray1.Length);
            byte[] numArray2 = new byte[numArray1.Length + 4];
            Buffer.BlockCopy((Array)numArray1, 0, (Array)numArray2, 4, numArray1.Length);
            Buffer.BlockCopy((Array)BitConverter.GetBytes(bytes.Length), 0, (Array)numArray2, 0, 4);
            return Convert.ToBase64String(numArray2);
        }
        public static string Decompress(this string compressedText)
        {
            if (string.IsNullOrEmpty(compressedText))
                return compressedText;
            byte[] buffer = Convert.FromBase64String(compressedText);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                int int32 = BitConverter.ToInt32(buffer, 0);
                memoryStream.Write(buffer, 4, buffer.Length - 4);
                byte[] numArray = new byte[int32];
                memoryStream.Position = 0L;
                using (GZipStream gzipStream = new GZipStream((Stream)memoryStream, CompressionMode.Decompress))
                {
                    gzipStream.Read(numArray, 0, numArray.Length);
                    return Encoding.UTF8.GetString(numArray);
                }
            }
        }
        public static string Truncate(this string truncatedText, int maxLength)
        {
            if (maxLength < 4)
                maxLength = 4;
            if (maxLength > 1000)
                maxLength = 1000;
            return 
                string.IsNullOrEmpty(truncatedText) || truncatedText.Length <= maxLength ? 
                truncatedText : truncatedText.Substring(0, maxLength - 3) + "...";
        }

        public static string GetUntil(this string text, string stopAt = "-")
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                int length = text.IndexOf(stopAt, StringComparison.Ordinal);
                if (length > 0)
                    return text.Substring(0, length);
            }
            return text;
        }

        public static string AddAnd(ref string s)
        {
            s = s != "" ? s + " AND " : s;
            return s;
        }

        public static string AddAnd(this string s)
        {
            s = s != "" ? s + " AND " : s;
            return s;
        }

        public static string[] split(this string STR, string Splter, StringSplitOptions sop = StringSplitOptions.None)
        {
            return STR.Split(new string[1] { Splter }, sop);
        }

        public static string[] split(this string STR, string[] Splter, StringSplitOptions sop = StringSplitOptions.None)
        {
            return STR.Split(Splter, sop);
        }

        public static double MonthsBetween(DateTime Date1, DateTime Date2)
        {
            return !(Date2 > Date1) ? (double)Date1.Subtract(Date2).Days / (487.0 / 16.0) : (double)Date2.Subtract(Date1).Days / (487.0 / 16.0);
        }

        //public static string Between(this string fld, string val1, string val2)
        //{
        //    return StringsExtensions.MakeBetween(fld, val1, val2);
        //}

        //  public static string MakeBetween(string fld, string val1, string val2)
        //{
        //    string str1 = "";
        //    if (val1.Nz() != "")
        //    {
        //        if (val2.Nz() != "")
        //            str1 = "(" + fld + " Between '" + val1 + "' and '" + val2 + "')";
        //        else if ((val1.IndexOf("*") != -1 || val1.IndexOf("%") != -1) && (val1.IndexOf(",") != -1 || val1.IndexOf("،") != -1))
        //        {
        //            string[] strArray = val1.Split(new char[2]
        //            {
        //                ',',
        //                '،'
        //            });
        //            List<string> values = new List<string>();
        //            foreach (string str2 in strArray)
        //            {
        //                string str3 = "(" + fld + " like '" + str2.Replace('*', '%') + "')";
        //                values.Add(str3);
        //            }
        //            str1 = "(" + string.Join(" or ", (IEnumerable<string>)values) + ")";
        //        }
        //        else if (val1.IndexOf("*") != -1 || val1.IndexOf("?") != -1 || val1.IndexOf("%") != -1 || val1.IndexOf("_") != -1)
        //            str1 = "(" + fld + " like '" + val1.Replace('*', '%') + "')";
        //        else if (val1.IndexOf(",") != -1 || val1.IndexOf("،") != -1)
        //        {
        //            DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 2);
        //            interpolatedStringHandler.AppendLiteral("(");
        //            interpolatedStringHandler.AppendFormatted(fld);
        //            interpolatedStringHandler.AppendLiteral(" in ('");
        //            interpolatedStringHandler.AppendFormatted(val1.split(new string[2]
        //            {
        //    ",",
        //    "،"
        //            }).join("','"));
        //            interpolatedStringHandler.AppendLiteral("'))");
        //            str1 = interpolatedStringHandler.ToStringAndClear();
        //        }
        //        else
        //        {
        //           // "(" + fld + "= '" + val1 + "')";
        //            str1 = StringsExtensions.MakeCondStr(fld, val1);
        //        }
        //    }
        //    else if (val2.Nz() != "")
        //        str1 = "(" + fld + " Between '' and '" + val2 + "')";
        //    return str1;
        //}

        public static string AddOr(ref string s)
        {
            s = s != "" ? s + " OR " : s;
            return s;
        }

        public static string AddOr(this string s)
        {
            s = s != "" ? s + " OR " : s;
            return s;
        }

        public static string MakeCondStr(string fld, string[] arrVal)
        {
            string val1 = string.Join(",", arrVal);
            return StringsExtensions.MakeCondStr(fld, val1);
        }

        public static string MakeCondStr(string fld, string val1)
        {
            StringCollection stringCollection1 = new StringCollection();
            string s = "";
            string str1 = "";
            if (val1 == "")
                return "";
            if (val1.Contains(","))
            {
                StringCollection stringCollection2 = new StringCollection();
                stringCollection1.AddRange(val1.Split(','));
                int count = stringCollection1.Count;
                for (int index = 0; index < count; ++index)
                    s = stringCollection1[index][0] != '+' ? StringsExtensions.AddOr(ref s) + "(" + StringsExtensions.MakeCondStr(fld, stringCollection1[index]) + ")" : StringsExtensions.AddAnd(ref s) + "(" + StringsExtensions.MakeCondStr(fld, stringCollection1[index].Substring(2)) + ")";
                return "(" + s + ")";
            }
            val1 = val1.Replace("*", "%");
            if (val1[0] == '#')
            {
                str1 = " Not ";
                val1 = val1.Substring(2, val1.Length);
            }
            if (val1.EndsWith(" ") & val1 != " ")
            {
                val1 = val1.Remove(val1.Length - 1);
                val1 = val1.Insert(val1.Length, "%");
            }
            if (val1.StartsWith(" ") & val1 != " ")
            {
                val1 = val1.Remove(0, 1);
                val1 = val1.Insert(0, "%");
            }
            string str2;
            switch (val1)
            {
                case "NULL":
                    str2 = "(" + fld + " IS NULL)";
                    break;
                case "NNULL":
                    str2 = "(" + fld + " IS NOT NULL)";
                    break;
                default:
                    if (val1.ToUpper() == "NULLEMPTY")
                    {
                        str2 = "((" + fld + " IS NULL) OR (" + fld + "=''))";
                        break;
                    }
                    if (val1 == "NNULLEMPTY")
                    {
                        str2 = "((" + fld + " IS NOT NULL) AND (" + fld + "<>''))";
                        break;
                    }
                    if (val1.Contains("%") || val1.Contains("?") || val1.Contains("_") || val1.Contains("*"))
                    {
                        str2 = "(" + fld + " like '" + val1 + "')";
                        break;
                    }
                    str2 = "(" + fld + "= '" + val1 + "')";
                    break;
            }
            if (str1 != "")
                str2 = "(" + str1 + str2 + ")";
            return str2;
        }

        public static DateTime GetParsedDateTime(string dateTimeString)
        {
            DateTime result;
            if (!DateTime.TryParseExact(dateTimeString, "dd-MM-yyyy", (IFormatProvider)StringsExtensions.cultureInfoProvider, DateTimeStyles.None, out result))
                DateTime.TryParse(dateTimeString, out result);
            else
                result = new DateTime();
            return result;
        }

        //public static string MakeBetweenDt(this string fld, DateTime? val1, DateTime? val2)
        //{
        //    string fld1 = fld;
        //    DateTime dateTime;
        //    string val1_1;
        //    if (!val1.HasValue)
        //    {
        //        val1_1 = "";
        //    }
        //    else
        //    {
        //        dateTime = val1.Value;
        //        val1_1 = dateTime.ToShortDateString();
        //    }
        //    string val2_1;
        //    if (!val2.HasValue)
        //    {
        //        val2_1 = "";
        //    }
        //    else
        //    {
        //        dateTime = val2.Value;
        //        val2_1 = dateTime.ToShortDateString();
        //    }
        //    return StringsExtensions.MakeBetweenDT(fld1, val1_1, val2_1);
        //}

        //public static string MakeBetweenDt(this string fld, DateTime val1, DateTime val2)
        //{
        //    return StringsExtensions.MakeBetweenDT(fld, val1.ToShortDateString(), val2.ToShortDateString());
        //}

        //public static string MakeBetweenDT(string fld, string val1, string val2)
        //{
        //    string str = "";
        //    if (val1 != "" && val1.Substring(0, 2) != "  ")
        //    {
        //        if (val2.Trim() != "")
        //        {
        //            DateTime parsedDateTime = StringsExtensions.GetParsedDateTime(val2);
        //            DateTime sDt = new DateTime(parsedDateTime.Year, parsedDateTime.Month, parsedDateTime.Day, 23, 59, 59);
        //            str = "(" + fld + " Between " + StringsExtensions.DtSql(val1) + " and " + sDt.ToDtTimSql() + ")";
        //        }
        //        else
        //            str = "(" + fld + "= " + StringsExtensions.DtSql(val1) + ")";
        //    }
        //    else if (val2 != "" && val2.Substring(0, 2) != "  ")
        //    {
        //        DateTime parsedDateTime = StringsExtensions.GetParsedDateTime(val2);
        //        DateTime sDt = new DateTime(parsedDateTime.Year, parsedDateTime.Month, parsedDateTime.Day, 23, 59, 59);
        //        str = "(" + fld + " Between " + StringsExtensions.DtSql("1/1/1900") + " and " + sDt.ToDtTimSql() + ")";
        //    }
        //    return str;
        //}

        //public static string DtSql(string sDT)
        //{
        //    CultureInfo invariantCulture = CultureInfo.InvariantCulture;
        //    CultureInfo provider = new CultureInfo("ar-EG");
        //    if (sDT == "")
        //        return sDT;
        //    DateTime result;
        //    if (!DateTime.TryParseExact(sDT, "dd-MM-yyyy", (IFormatProvider)provider, DateTimeStyles.None, out result))
        //        DateTime.TryParse(sDT, out result);
        //    return result.ToDtSql();
        //}

        public static int DaysBetween(DateTime Date1, DateTime Date2)
        {
            return !(Date1 > Date2) ? (int)(Date2 - Date1).TotalDays : (int)(Date1 - Date2).TotalDays;
        }

        public static string RemoveQuerySpecialCharacters(this string value)
        {
            return value?.Replace("%", "").Replace("*", "").Replace("_", "").Replace("?", "").Replace("#", "").Replace("،", "").Replace(",", "");
        }

        public static bool IsNullOrEmptyOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);

        public static string IsNullOrEmptyOrWhiteSpace(this string str, string returnValue)
        {
            return !string.IsNullOrEmpty(str) && !string.IsNullOrWhiteSpace(str) ? str : returnValue;
        }

        public static string NullIfEmptyOrWhiteSpace(this string str)
        {
            return !str.IsNullOrEmptyOrWhiteSpace() ? str : (string)null;
        }

        public static string ParseSql(this string SQL, Type G = null, object obj = null)
        {
            try
            {
                BindingFlags bindingFlags = BindingFlags.IgnoreCase | BindingFlags.Public;
                BindingFlags bindingAttr = obj != null ? bindingFlags | BindingFlags.Instance : bindingFlags | BindingFlags.Static;
                MatchCollection matchCollection = new Regex("(?<FldNm>{[\\w+]*[\\d+]*[|,:]*\\w+})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Matches(SQL);
                List<string> list1 = ((IEnumerable<FieldInfo>)G.GetFields()).Select<FieldInfo, string>((Func<FieldInfo, string>)(i => i.Name)).ToList<string>();
                List<string> list2 = ((IEnumerable<PropertyInfo>)G.GetProperties()).Select<PropertyInfo, string>((Func<PropertyInfo, string>)(i => i.Name)).ToList<string>();
                List<string> list3 = ((IEnumerable<FieldInfo>)G.GetFields(bindingAttr)).Select<FieldInfo, string>((Func<FieldInfo, string>)(i => i.Name.ToUpper())).ToList<string>();
                List<string> list4 = ((IEnumerable<PropertyInfo>)G.GetProperties(bindingAttr)).Select<PropertyInfo, string>((Func<PropertyInfo, string>)(i => i.Name.ToUpper())).ToList<string>();
                foreach (Group group in matchCollection)
                {
                    foreach (Capture capture in group.Captures)
                    {
                        string name = capture.Value.Replace("{", " ").Replace("}", " ").TrimStart().TrimEnd();
                        try
                        {
                            if (list1.Contains(name))
                            {
                                string newValue = G.GetField(name).GetValue(obj).Nz();
                                SQL = SQL.Replace(capture.Value, newValue);
                            }
                            else if (list2.Contains(name))
                            {
                                string newValue = G.GetProperty(name).GetValue(obj, (object[])null).Nz();
                                SQL = SQL.Replace(capture.Value, newValue);
                            }
                            else if (list3.Contains(name.ToUpper()))
                            {
                                string newValue = G.GetField(name, bindingAttr).GetValue(obj).Nz();
                                SQL = SQL.Replace(capture.Value, newValue);
                            }
                            else if (list4.Contains(name.ToUpper()))
                            {
                                string newValue = G.GetProperty(name, bindingAttr).GetValue(obj, (object[])null).Nz();
                                SQL = SQL.Replace(capture.Value, newValue);
                            }
                        }
                        catch
                        {
                            try
                            {
                                string newValue = G.GetProperty(name).GetValue(obj, (object[])null).Nz();
                                SQL = SQL.Replace(capture.Value, newValue);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            return SQL;
        }

        public static string ParseSql(this string SQL, object obj)
        {
            switch (obj)
            {
                case null:
                    return SQL;
                case DataRow _:
                    return StringsExtensions.ParseSql(SQL, obj as DataRow);
                case DataRowView _:
                    return StringsExtensions.ParseSql(SQL, obj as DataRowView);
                default:
                    Type type = obj.GetType();
                    if ((object)type != null)
                        return SQL.ParseSql(type, obj);
                    try
                    {
                        foreach (Group match in new Regex("(?<FldNm>{[\\w+]*[\\d+]*[|,:]*\\w+})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Matches(SQL))
                        {
                            foreach (Capture capture in match.Captures)
                            {
                                try
                                {
                                    string name = capture.Value.Replace("{", " ").Replace("}", " ").TrimStart().TrimEnd();
                                    string newValue = type.GetField(name).GetValue(obj).Nz();
                                    SQL = SQL.Replace(capture.Value, newValue);
                                }
                                catch
                                {
                                    try
                                    {
                                        string name = capture.Value.Replace("{", " ").Replace("}", " ").TrimStart().TrimEnd();
                                        string newValue = type.GetProperty(name).GetValue(obj, (object[])null).Nz();
                                        SQL = SQL.Replace(capture.Value, newValue);
                                    }
                                    catch
                                    {
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                    return SQL;
            }
        }

        private static string GetValue(Dictionary<string, string> DicVals, string capVal)
        {
            string str1 = capVal.Replace("{", " ").Replace("}", " ").TrimStart().TrimEnd();
            if (str1.Contains(":"))
            {
                string[] strArray = str1.split(":");
                str1 = strArray[0];
                string str2 = strArray[1];
            }
            return DicVals.ContainsKey(str1) ? DicVals[str1].Nz() : capVal;
        }

        public static string ParseSql(this string SQL, DataRowView DR)
        {
            try
            {
                foreach (Group match in new Regex("(?<FldNm>{[\\w+]*[\\d+]*[|,:]*\\w+})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Matches(SQL))
                {
                    foreach (Capture capture in match.Captures)
                    {
                        try
                        {
                            string newValue = StringsExtensions.GetValue(DR.Row, capture.Value);
                            SQL = SQL.Replace(capture.Value, newValue);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
            }
            return SQL;
        }

        public static string ParseSql(this string SQL, DataRow DR)
        {
            try
            {
                foreach (Group match in new Regex("(?<FldNm>{[\\w+]*[\\d+]*[|,:]*\\w+})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Matches(SQL))
                {
                    foreach (Capture capture in match.Captures)
                    {
                        try
                        {
                            string newValue = StringsExtensions.GetValue(DR, capture.Value);
                            SQL = SQL.Replace(capture.Value, newValue);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
            }
            return SQL;
        }

        public static string ParseSql(string SQL, Dictionary<string, string> DicVals)
        {
            try
            {
                foreach (Group match in new Regex("(?<FldNm>{[\\w+]*[\\d+]*[|,:]*\\w+})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Matches(SQL))
                {
                    foreach (Capture capture in match.Captures)
                    {
                        try
                        {
                            string newValue = StringsExtensions.GetValue(DicVals, capture.Value);
                            SQL = SQL.Replace(capture.Value, newValue);
                        }
                        catch
                        {
                        }
                    }
                }
            }
            catch
            {
            }
            return SQL;
        }

        public static string ParseSql(string SQL, Dictionary<string, DataRow> Rows)
        {
            try
            {
                foreach (Group match in new Regex("(?<FldNm>{[\\w+]*[\\d+]*[|,:]*\\w+})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Matches(SQL))
                {
                    foreach (Capture capture in match.Captures)
                    {
                        try
                        {
                            string[] strArray = capture.Value.split("|");
                            if (strArray.Length == 1)
                            {
                                if (Rows.Keys.Contains<string>("0"))
                                {
                                    DataRow row = Rows["0"];
                                    string capVal = capture.Value;
                                    string newValue = StringsExtensions.GetValue(row, capVal);
                                    if (newValue == "")
                                    {
                                        if (row != null)
                                        {
                                            if (row.Table != null)
                                            {
                                                if (!row.Table.Columns.Contains(capVal.TrimStart('{').TrimEnd('}')))
                                                    continue;
                                            }
                                            else
                                                continue;
                                        }
                                        else
                                            continue;
                                    }
                                    SQL = SQL.Replace(capture.Value, newValue);
                                }
                            }
                            else if (strArray.Length == 2)
                            {
                                if (Rows.Keys.Contains<string>(strArray[0].Replace("{", " ").Replace("}", " ").TrimStart().TrimEnd()))
                                {
                                    string newValue = StringsExtensions.GetValue(Rows[strArray[0].Replace("{", " ").Replace("}", " ").TrimStart().TrimEnd()], strArray[1]);
                                    SQL = SQL.Replace(capture.Value, newValue);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }
            catch
            {
            }
            return SQL;
        }

        private static string GetValue(DataRow DR, string capVal)
        {
            string str1 = capVal.Replace("{", " ").Replace("}", " ").TrimStart().TrimEnd();
            if (str1.Contains(":"))
            {
                string[] strArray = str1.split(":");
                str1 = strArray[0];
                string str2 = strArray[1];
            }
            return DR != null && DR.Table != null && DR.Table.Columns.Contains(str1) ? DR[str1].Nz() : capVal;
        }

        public static bool In(this string val, params string[] strings)
        {
            return ((IEnumerable<string>)strings).Any<string>((Func<string, bool>)(s => s == val));
        }

        public static string Encrypt(this string plainText, string key = null)
        {
            lock (StringsExtensions._lockObject)
            {
                if (key == null)
                    key = "c14dh4827h4e8475uulg2ea5984x3548";
                using (Aes aes = Aes.Create())
                {
                    if (aes == null)
                        throw new Exception("Can't create Aes");
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = new byte[16];
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                                streamWriter.Write(plainText);
                            return Convert.ToBase64String(memoryStream.ToArray());
                        }
                    }
                }
            }
        }

        public static string Decrypt(this string cipherText, string key = null)
        {
            lock (StringsExtensions._lockObject)
            {
                if (key == null)
                    key = "c14dh4827h4e8475uulg2ea5984x3548";
                byte[] buffer = Convert.FromBase64String(cipherText);
                using (Aes aes = Aes.Create())
                {
                    if (aes == null)
                        throw new Exception("Can't create Aes");
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = new byte[16];
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (MemoryStream memoryStream = new MemoryStream(buffer))
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                                return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static byte[] AesKey(this string secret) => Encoding.UTF8.GetBytes(secret);

        public static string AesEncrypt(this string cipherText, string secret)
        {
            lock (StringsExtensions._lockObject)
            {
                byte[] key = secret.AesKey();
                return cipherText.AesEncrypt(key);
            }
        }

        public static string AesEncrypt(this string cipherText, byte[] key)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
                aes.Mode = CipherMode.ECB;
                aes.Padding = PaddingMode.PKCS7;
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                            streamWriter.Write(cipherText);
                        return Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
        }

        public static string AddConditionsToSql(this string Sql, string Conditions, string op = "")
        {
            if (Sql.Nz() == "")
                return "";
            if (string.IsNullOrWhiteSpace(Conditions))
                return Sql;
            bool flag = false;
            if (Sql.Contains("<>") || Sql.Contains("1=1"))
            {
                if (op.Nz() == "")
                {
                    if (Sql.Contains("1<>1"))
                    {
                        Sql = Sql.Replace("1<>1", Conditions);
                        flag = true;
                    }
                    else if (Sql.Contains("1=1"))
                    {
                        Sql = Sql.Replace("1=1", Conditions);
                        flag = true;
                    }
                }
                else if (op.Contains("<>"))
                {
                    Sql = Sql.Replace(op, Conditions);
                    flag = true;
                }
            }
            if (!flag)
            {
                Sql = Sql.Replace("  ", " ");
                Sql = Sql.ToUpper();
                op = op == "" ? " AND " : op;
                if (Sql.Contains("UNION"))
                    return Sql;
                int length = Sql.Length;
                int startIndex1 = Sql.IndexOf("ORDER BY");
                int startIndex2 = Sql.IndexOf("GROUP BY");
                int num1 = Sql.LastIndexOf("WHERE");
                int num2 = Sql.LastIndexOf("FROM");
                if (num1 < 0 || num2 > num1)
                {
                    if (startIndex1 < 0 && startIndex2 < 0)
                        Sql = Sql + " WHERE " + Conditions;
                    else if (startIndex2 >= 0)
                        Sql = Sql.Substring(0, startIndex2 - 1) + " WHERE " + Conditions + " " + Sql.Substring(startIndex2);
                    else
                        Sql = Sql.Substring(0, startIndex1 - 1) + " WHERE " + Conditions + " " + Sql.Substring(startIndex1);
                }
                else if (startIndex1 < 0 && startIndex2 < 0)
                    Sql = Sql + op + " (" + Conditions + ")";
                else if (startIndex2 >= 0)
                    Sql = Sql.Substring(0, startIndex2 - 1) + op + Conditions + " " + Sql.Substring(startIndex2);
                else
                    Sql = Sql.Substring(0, startIndex1 - 1) + op + Conditions + " " + Sql.Substring(startIndex1);
            }
            return Sql;
        }

        public static int MonthsBetween(DateTime? fromDate, DateTime? toDate)
        {
            if (!toDate.HasValue || !fromDate.HasValue)
                return 0;
            DateTime? nullable1 = toDate;
            DateTime? nullable2 = fromDate;
            return Convert.ToInt32((nullable1.HasValue & nullable2.HasValue ? (nullable1.GetValueOrDefault() > nullable2.GetValueOrDefault() ? 1 : 0) : 0) != 0 ? Math.Floor((double)toDate.Value.Subtract(fromDate.Value).Days / (487.0 / 16.0)) : Math.Floor((double)fromDate.Value.Subtract(toDate.Value).Days / (487.0 / 16.0)));
        }

        public static string RemoveOrderFromSQL(this string SSql)
        {
            if (SSql.Nz() == "")
                return "";
            SSql = SSql.ToUpper();
            int length = SSql.Length;
            int startIndex = SSql.LastIndexOf("ORDER BY");
            if (startIndex == -1)
                return SSql;
            SSql.IndexOf(")", startIndex);
            int num1 = SSql.LastIndexOf("GROUP BY");
            int num2 = SSql.LastIndexOf("WHERE");
            int num3 = SSql.LastIndexOf("FROM");
            if (num3 > num2)
                ;
            if (num3 > startIndex)
                startIndex = -1;
            if (num3 > num1)
                ;
            if (startIndex > 0)
                SSql = SSql.Remove(startIndex);
            return SSql;
        }

        public static bool ToBool(this string str)
        {
            return !string.IsNullOrWhiteSpace(str) && !(str == "0") && !(str.ToLower() == "false") && (str.ToLower() == "true" || str == "1");
        }

        public static string ToSnakeCase(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;
            StringBuilder stringBuilder = new StringBuilder(text.Length + Math.Min(2, text.Length / 5));
            UnicodeCategory? nullable = new UnicodeCategory?();
            for (int index = 0; index < text.Length; ++index)
            {
                char lower = text[index];
                if (lower == '_')
                {
                    stringBuilder.Append('_');
                    nullable = new UnicodeCategory?();
                }
                else
                {
                    UnicodeCategory unicodeCategory = char.GetUnicodeCategory(lower);
                    switch (unicodeCategory)
                    {
                        case UnicodeCategory.UppercaseLetter:
                        case UnicodeCategory.TitlecaseLetter:
                            if (nullable.GetValueOrDefault() == UnicodeCategory.SpaceSeparator || nullable.GetValueOrDefault() == UnicodeCategory.LowercaseLetter || nullable.GetValueOrDefault() != UnicodeCategory.DecimalDigitNumber && nullable.HasValue && index > 0 && index + 1 < text.Length && char.IsLower(text[index + 1]))
                                stringBuilder.Append('_');
                            lower = char.ToLower(lower, CultureInfo.InvariantCulture);
                            break;
                        case UnicodeCategory.LowercaseLetter:
                        case UnicodeCategory.DecimalDigitNumber:
                            if (nullable.GetValueOrDefault() == UnicodeCategory.SpaceSeparator)
                            {
                                stringBuilder.Append('_');
                                break;
                            }
                            break;
                        default:
                            if (nullable.HasValue)
                            {
                                nullable = new UnicodeCategory?(UnicodeCategory.SpaceSeparator);
                                continue;
                            }
                            continue;
                    }
                    stringBuilder.Append(lower);
                    nullable = new UnicodeCategory?(unicodeCategory);
                }
            }
            return stringBuilder.ToString();
        }

        public static string ToPascalCase(this string value, bool advancedTech)
        {
            if (advancedTech)
            {
                value = value.Replace(".", "").Replace(",", "").Replace("-", "_").Replace("%", "");
                if (Regex.IsMatch(value, "^Tax1_.*", RegexOptions.IgnoreCase) || Regex.IsMatch(value, "^Tax2_.*", RegexOptions.IgnoreCase) || Regex.IsMatch(value, "^Disc1_.*", RegexOptions.IgnoreCase) || Regex.IsMatch(value, "^Disc2_.*", RegexOptions.IgnoreCase) || Regex.IsMatch(value, "^Disc4_.*", RegexOptions.IgnoreCase) || Regex.IsMatch(value, "^Disc4_.*", RegexOptions.IgnoreCase) || Regex.IsMatch(value, "^BGNBAL1.*", RegexOptions.IgnoreCase) || Regex.IsMatch(value, "^INQTY1.*", RegexOptions.IgnoreCase) || Regex.IsMatch(value, "^OUTQTY1.*", RegexOptions.IgnoreCase) || Regex.IsMatch(value, "^RBal1.*", RegexOptions.IgnoreCase))
                {
                    value = Regex.Replace(value, "Tax1_", "Tax1_T", RegexOptions.IgnoreCase);
                    value = Regex.Replace(value, "Tax2_", "Tax2_T", RegexOptions.IgnoreCase);
                    value = Regex.Replace(value, "Disc1_", "Disc1_T", RegexOptions.IgnoreCase);
                    value = Regex.Replace(value, "Disc2_", "Disc2_T", RegexOptions.IgnoreCase);
                    value = Regex.Replace(value, "Disc4_", "Disc4_T", RegexOptions.IgnoreCase);
                    value = !Regex.IsMatch(value, "^BGNBAL1_.*", RegexOptions.IgnoreCase) ? Regex.Replace(value, "RBal1", "RBal1T", RegexOptions.IgnoreCase) : Regex.Replace(value, "RBal1_", "RBal1_T", RegexOptions.IgnoreCase);
                    value = !Regex.IsMatch(value, "^BGNBAL1_.*", RegexOptions.IgnoreCase) ? Regex.Replace(value, "BGNBAL1", "BGNBAL1T", RegexOptions.IgnoreCase) : Regex.Replace(value, "BGNBAL1_", "BGNBAL1_T", RegexOptions.IgnoreCase);
                    value = !Regex.IsMatch(value, "^INQTY1_.*", RegexOptions.IgnoreCase) ? Regex.Replace(value, "INQTY1", "INQTY1T", RegexOptions.IgnoreCase) : Regex.Replace(value, "INQTY1_", "INQTY1_T", RegexOptions.IgnoreCase);
                    value = !Regex.IsMatch(value, "^OUTQTY1_.*", RegexOptions.IgnoreCase) ? Regex.Replace(value, "OUTQTY1", "OUTQTY1T", RegexOptions.IgnoreCase) : Regex.Replace(value, "OUTQTY1_", "OUTQTY1_T", RegexOptions.IgnoreCase);
                }
                string[] strArray = Regex.Split(value, "_");
                for (int index = 0; index < strArray.Length; ++index)
                {
                    if (!string.IsNullOrEmpty(strArray[index]))
                    {
                        if (strArray[index].Equals(strArray[index].ToUpper()))
                            strArray[index] = strArray[index].ToLower();
                        else if (Regex.IsMatch(strArray[index], "[A-Z]{2,}"))
                            strArray[index] = strArray[index].ToLower();
                        char upper = char.ToUpper(strArray[index][0]);
                        strArray[index] = upper.ToString() + strArray[index].Substring(1);
                    }
                }
                return string.Join("", strArray);
            }
            return ((IEnumerable<string>)value.Split(new string[1]
            {
        "_"
            }, StringSplitOptions.RemoveEmptyEntries)).Select<string, string>((Func<string, string>)(s => char.ToUpperInvariant(s[0]).ToString() + s.Substring(1, s.Length - 1))).Aggregate<string, string>(string.Empty, (Func<string, string, string>)((s1, s2) => s1 + s2));
        }

        public static string Random(this string value)
        {
            string str = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] chArray = new char[8];
            System.Random random = new System.Random();
            for (int index = 0; index < chArray.Length; ++index)
                chArray[index] = str[random.Next(str.Length)];
            value = new string(chArray);
            return value;
        }

        //public static string MakeBetweenDtTim(string fld, string val1, string val2)
        //{
        //    CultureInfo invariantCulture = CultureInfo.InvariantCulture;
        //    CultureInfo cultureInfo = new CultureInfo("ar-EG");
        //    string str = "";
        //    if (val1.Nz() != "" && val2.Nz() != "")
        //    {
        //        DateTime parsedDateTime = StringsExtensions.GetParsedDateTime(val1);
        //        DateTime sDt1 = new DateTime(parsedDateTime.Year, parsedDateTime.Month, parsedDateTime.Day);
        //        parsedDateTime = StringsExtensions.GetParsedDateTime(val2);
        //        DateTime sDt2 = new DateTime(parsedDateTime.Year, parsedDateTime.Month, parsedDateTime.Day, 23, 59, 59);
        //        str = "(" + fld + " Between " + sDt1.ToDtTimSql() + " and " + sDt2.ToDtTimSql() + ")";
        //    }
        //    else if (val1.Nz() != "")
        //    {
        //        DateTime parsedDateTime = StringsExtensions.GetParsedDateTime(val1);
        //        DateTime sDt3 = new DateTime(parsedDateTime.Year, parsedDateTime.Month, parsedDateTime.Day);
        //        DateTime sDt4 = new DateTime(parsedDateTime.Year, parsedDateTime.Month, parsedDateTime.Day, 23, 59, 59);
        //        str = "(" + fld + " Between " + sDt3.ToDtTimSql() + " and " + sDt4.ToDtTimSql() + ")";
        //    }
        //    else if (val2.Nz() != "")
        //    {
        //        DateTime parsedDateTime = StringsExtensions.GetParsedDateTime(val2);
        //        DateTime sDt5 = new DateTime(parsedDateTime.Year, parsedDateTime.Month, parsedDateTime.Day);
        //        DateTime sDt6 = new DateTime(parsedDateTime.Year, parsedDateTime.Month, parsedDateTime.Day, 23, 59, 59);
        //        str = "(" + fld + " Between " + sDt5.ToDtTimSql() + " and " + sDt6.ToDtTimSql() + ")";
        //    }
        //    return str;
        //}

    }
}
