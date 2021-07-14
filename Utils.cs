using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DapperPocoLab
{
    class Utils
    {
        public static string JsonSerialize(object obj, bool WriteIndented, bool IncludeFields = false)
        {
            string json = JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // 中文字不編碼
                WriteIndented = WriteIndented,  // 換行與縮排
                IncludeFields = IncludeFields   // 非 Property 欄位
            });

            return json;
        }


        public static string GetNetDataType(string sqlDataTypeName)
        {
            switch (sqlDataTypeName.ToLower())
            {
                case "bigint":
                    return "Int64";
                case "binary":
                    return "Byte[]";
                case "bit":
                    return "bool";
                case "char":
                    return "char";
                case "cursor":
                    return string.Empty;
                case "datetime":
                    return "DateTime";
                case "datetime2":
                    return "DateTime";
                case "decimal":
                    return "Decimal";
                case "float":
                    return "Double";
                case "int":
                    return "int";
                case "money":
                    return "Decimal";
                case "nchar":
                    return "string";
                case "numeric":
                    return "Decimal";
                case "nvarchar":
                    return "string";
                case "real":
                    return "single";
                case "smallint":
                    return "Int16";
                case "text":
                    return "string";
                case "tinyint":
                    return "Byte";
                case "varbinary":
                    return "Byte[]";
                case "xml":
                    return "string";
                case "varchar":
                    return "string";
                case "smalldatetime":
                    return "DateTime";
                case "image":
                    return "byte[]";
                default:
                    return $"{sqlDataTypeName}:not_support"; // not support
                    //return string.Empty;
            }
        }
    }
}
