using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DapperPocoLab.Services;

namespace DapperPocoLab
{
  class App
  {
    ///  Injection
    readonly IConfiguration _config;
    //readonly RandomService _randSvc;

    /// 參數
    readonly string connStr;
    readonly string nameSpace;
    readonly string outputFolder;
    readonly string indent;
    readonly string sqlClientLibrary; // "Microsoft.Data.SqlClient" OR "System.Data.SqlClient"

    public App(IConfiguration config)
    {
      _config = config;
      //_randSvc = randSvc;

      //## 取得參數
      connStr = _config.GetConnectionString("DefaultConnection");
      nameSpace = _config["Namespace"];
      outputFolder = _config["OutputFolder"];
      indent = _config["Indent"];
      sqlClientLibrary = _config["SqlClientLibrary"] ?? "Microsoft.Data.SqlClient";
    }

    /// <summary>
    /// 取代原本 Program.Main() 函式的效用。
    /// </summary>
    public void Run(string[] args)
    {
      //Console.WriteLine($"§ 參數");
      //Console.WriteLine($"連線字串：{connStr}");
      //Console.WriteLine($"輸出目錄：{outputFolder}");
      //Console.WriteLine($"縮排字串：{indent}");
      //Console.WriteLine();

      try
      {
        //# 建立輸出目錄
        DirectoryInfo outDir = new DirectoryInfo(outputFolder);
        if (!outDir.Exists) outDir.Create();

        //## 開始產生 POCO classes 
        using (var conn = new SqlConnection(connStr))
        {
          SubGenerateTablePocoCode(conn, outDir);

          SubGenerateProcPocoCode(conn, outDir);

          SubGenerateTableValuedFunctionPocoCode(conn, outDir);
        }

        Console.WriteLine();
        Console.WriteLine("已成功產生 Dapper POCO 程式碼，請檢查輸出目錄。");
      }
      finally
      {
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
      }
    }

    /// <summary>
    /// sub-procedure: 產生 DB Table POCO code.
    /// </summary>
    public void SubGenerateTablePocoCode(SqlConnection conn, DirectoryInfo outDir)
    {
      var tableList = DBHelper.LoadTable(conn);
      tableList.ForEach(table =>
      {
        // Console.WriteLine($"{Utils.JsonSerialize(table, false)}");
        StringBuilder pocoCode = new StringBuilder();

        pocoCode.AppendLine($"namespace {nameSpace}");
        pocoCode.AppendLine("{");
        pocoCode.AppendLine("using System;");
        pocoCode.AppendLine("using System.ComponentModel.DataAnnotations;");
        //pocoCode.AppendLine("using Dapper;");
        pocoCode.AppendLine("using Dapper.Contrib.Extensions;");
        pocoCode.AppendLine("using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;");
        pocoCode.AppendLine();

        pocoCode.AppendLine($"[Table(\"{table.TABLE_NAME}\")]");
        pocoCode.AppendLine($"public class {table.TABLE_NAME} ");
        pocoCode.AppendLine("{");

        var columnList = DBHelper.LoadTableColumn(conn, table.TABLE_NAME);
        columnList.ForEach(col =>
        {
          // Console.WriteLine($"{Utils.JsonSerialize(col, false)}");

          string dataType = Utils.GetNetDataType(col.DATA_TYPE);
          bool isKey = col.IS_PK == "YES";
          bool isIdentity = col.IS_IDENTITY == "YES";
          bool isComputed = col.IS_COMPUTED == "YES";
          //string nullable = (dataType != "string" && col.IS_NULLABLE == "YES") ? "?" : "";
          string nullable = (dataType != "string" && !isKey) ? "?" : ""; // ORM 欄位原則上都是 nullable 不然在 input binding 會很難實作。
          string description = col.MS_Description;

          /// summary
          if (col.MS_Description != null || col.COMPUTED_DEFINITION != null)
          {
            pocoCode.AppendLine($"{indent}/// <summary>");
            if (col.MS_Description != null)
              pocoCode.AppendLine($"{indent}/// {col.MS_Description}");
            if (col.COMPUTED_DEFINITION != null)
              pocoCode.AppendLine($"{indent}/// Computed Definition: {col.COMPUTED_DEFINITION}");
            pocoCode.AppendLine($"{indent}/// </summary>");
          }

          /// Display(Name) := 欄位名稱:欄位說明欄位說明欄位說明欄位說明。
          if (!String.IsNullOrWhiteSpace(col.MS_Description))
          {
            string displayName = col.MS_Description.Split(':', '：', '\r', '\n')[0].Trim();
            pocoCode.AppendLine($"{indent}[Display(Name = \"{displayName}\")]");
          }

          /// Key attribute
          if (isKey && isIdentity)
            pocoCode.AppendLine($"{indent}[Key]");
          if (isKey && !isIdentity)
            pocoCode.AppendLine($"{indent}[ExplicitKey]");
          if (isComputed || (!isKey && isIdentity))
            pocoCode.AppendLine($"{indent}[Computed]");

          /// Required attribute
          if (col.IS_NULLABLE == "NO")
            pocoCode.AppendLine($"{indent}[Required]");

          pocoCode.AppendLine($"{indent}public {dataType}{nullable} {col.COLUMN_NAME} {{ get; set; }}");
        });

        //## 產生Copy函式
        //public void Copy(職員基本表 src)
        //{
        //    this.職員代碼 = src.職員代碼;
        //    this.職員姓名 = src.職員姓名;
        //    this.狀態 = src.狀態;
        //}

        pocoCode.AppendLine();
        pocoCode.AppendLine($"{indent}public void Copy({table.TABLE_NAME} src)");
        pocoCode.AppendLine($"{indent}{{");
        columnList.ForEach(col =>
                  pocoCode.AppendLine($"{indent}{indent}this.{col.COLUMN_NAME} = src.{col.COLUMN_NAME};"));
        pocoCode.AppendLine($"{indent}}}"); // end of: Copy

        //## 產生Clone函式
        //public 職員基本表 Clone()
        //{
        //    return new 職員基本表
        //    {
        //        職員代碼 = this.職員代碼,
        //        職員姓名 = this.職員姓名,
        //        狀態 = this.狀態
        //    };
        //}

        pocoCode.AppendLine();
        pocoCode.AppendLine($"{indent}public {table.TABLE_NAME} Clone()");
        pocoCode.AppendLine($"{indent}{{");
        pocoCode.AppendLine($"{indent}{indent}return new {table.TABLE_NAME} {{");
        columnList.ForEach(col =>
                  pocoCode.AppendLine($"{indent}{indent}{indent}{col.COLUMN_NAME} = this.{col.COLUMN_NAME},"));
        pocoCode.AppendLine($"{indent}{indent}}};");
        pocoCode.AppendLine($"{indent}}}"); // end of: Clone

        //---------------------
        pocoCode.AppendLine("}"); // end of: Class
        pocoCode.AppendLine("}"); // end of: Namespace
        pocoCode.AppendLine();

        //## 一個 Table 一個檔案
        File.WriteAllText(Path.Combine(outDir.FullName, $"{table.TABLE_NAME}.cs"), pocoCode.ToString(), encoding: Encoding.UTF8);
        Console.WriteLine(pocoCode.ToString());
      });

    }

    public void SubGenerateProcPocoCode(SqlConnection conn, DirectoryInfo outDir)
    {
      var procList = DBHelper.LoadProcedure(conn);
      procList.ForEach(proc =>
      {
        Console.WriteLine($"{Utils.JsonSerialize(proc, true, true)}");
        StringBuilder pocoCode = new StringBuilder();

        pocoCode.AppendLine($"namespace {nameSpace}");
        pocoCode.AppendLine("{");
        pocoCode.AppendLine("using System;");
        pocoCode.AppendLine("using System.Collections.Generic;");
        pocoCode.AppendLine("using System.ComponentModel.DataAnnotations;");
        pocoCode.AppendLine("using Dapper;");
        pocoCode.AppendLine($"using {sqlClientLibrary};");
        pocoCode.AppendLine();


        //## Procedure Result Class ------------
        ///public class 計算資產編號Result
        ///{
        ///    public string 資產編號 { get; set; }
        ///}

        pocoCode.AppendLine($"public class {proc.SPECIFIC_NAME}Result ");
        pocoCode.AppendLine("{");
        proc.ColumnList.ForEach(col =>
              {
                string dataType = Utils.GetNetDataType(col.DATA_TYPE);
                string nullable = (dataType != "string" && col.IS_NULLABLE == "YES") ? "?" : "";

                pocoCode.AppendLine($"{indent}public {dataType}{nullable} {col.COLUMN_NAME} {{ get; set; }}");
              });
        pocoCode.AppendLine("}"); // end of: Reslt Column 


        //## Procedure Parameter Class ------------
        ///public class 計算資產編號Args
        ///{
        ///    public string 品項類別 { get; set; }
        ///}

        bool f_NonParam = proc.ParamList.Count <= 0; // 旗標：無輸入參數
        if (!f_NonParam)
        {
          pocoCode.AppendLine();
          pocoCode.AppendLine($"public class {proc.SPECIFIC_NAME}Args ");
          pocoCode.AppendLine("{");
          proc.ParamList.ForEach(arg =>
                {
                  string dataType = Utils.GetNetDataType(arg.DATA_TYPE);

                  pocoCode.AppendLine($"{indent}public {dataType} {arg.PARAMETER_NAME.Substring(1)} {{ get; set; }}");
                });
          pocoCode.AppendLine("}"); // end of: Reslt Column 
        }

        //## Procedure Instance ------------
        ///static partial class DBHelperClassExtensions
        ///{
        ///    public static List<計算資產編號Result> Call計算資產編號(this SqlConnection conn, 計算資產編號Args args)
        ///    {
        ///        var dataList = conn.Query<計算資產編號Result>("計算資產編號", args,
        ///            commandType: System.Data.CommandType.StoredProcedure).AsList();
        ///        return dataList;
        ///    }
        ///}

        pocoCode.AppendLine();
        pocoCode.AppendLine("static partial class DBHelperClassExtensions");
        pocoCode.AppendLine("{");

        if (f_NonParam)
          pocoCode.AppendLine($"public static List<{proc.SPECIFIC_NAME}Result> Call{proc.SPECIFIC_NAME}(this SqlConnection conn, SqlTransaction txn = null)");
        else
          pocoCode.AppendLine($"public static List<{proc.SPECIFIC_NAME}Result> Call{proc.SPECIFIC_NAME}(this SqlConnection conn, {proc.SPECIFIC_NAME}Args args, SqlTransaction txn = null)");

        pocoCode.AppendLine("{");

        if (f_NonParam)
          pocoCode.AppendLine($"{indent}var dataList = conn.Query<{proc.SPECIFIC_NAME}Result>(\"{proc.SPECIFIC_NAME}\",");
        else
          pocoCode.AppendLine($"{indent}var dataList = conn.Query<{proc.SPECIFIC_NAME}Result>(\"{proc.SPECIFIC_NAME}\", args,");

        pocoCode.AppendLine($"{indent}{indent}transaction: txn,");
        pocoCode.AppendLine($"{indent}{indent}commandType: System.Data.CommandType.StoredProcedure");
        pocoCode.AppendLine($"{indent}{indent}).AsList();");
        pocoCode.AppendLine($"{indent}return dataList;");
        //------
        pocoCode.AppendLine("}");

        //## Procedure Instance : method 2 直接帶入參數 ------------
        ///static partial class DBHelperClassExtensions
        ///{
        ///    public static List<計算資產編號Result> Call計算資產編號(this SqlConnection conn, string 品項類別)
        ///    {
        ///         var args = new {
        ///             品項類別
        ///         };   
        /// 
        ///        var dataList = conn.Query<計算資產編號Result>("計算資產編號", args,
        ///            commandType: System.Data.CommandType.StoredProcedure).AsList();
        ///        return dataList;
        ///    }
        ///}

        //※ 無參數狀況下會重複，故不產出。
        if (!f_NonParam)
        {
          pocoCode.AppendLine();
          pocoCode.Append($"public static List<{proc.SPECIFIC_NAME}Result> Call{proc.SPECIFIC_NAME}(this SqlConnection conn");
          proc.ParamList.ForEach(arg =>
                {
                  string dataType = Utils.GetNetDataType(arg.DATA_TYPE);
                  string nullable = (dataType != "string") ? "?" : "";
                  pocoCode.Append($", {dataType}{nullable} {arg.PARAMETER_NAME.Substring(1)}");
                });
          pocoCode.AppendLine(")");
          pocoCode.AppendLine("{");
          pocoCode.AppendLine($"{indent}var args = new {{");
          proc.ParamList.ForEach(arg =>
                {
                  pocoCode.AppendLine($"{indent}{indent}{arg.PARAMETER_NAME.Substring(1)},");
                });
          pocoCode.AppendLine($"{indent}}};");
          pocoCode.AppendLine("");
          pocoCode.AppendLine($"{indent}var dataList = conn.Query<{proc.SPECIFIC_NAME}Result>(\"{proc.SPECIFIC_NAME}\", args,");
          pocoCode.AppendLine($"{indent}{indent}commandType: System.Data.CommandType.StoredProcedure).AsList();");
          pocoCode.AppendLine($"{indent}return dataList;");
          //------
          pocoCode.AppendLine("}");
        }

        //---------------------
        pocoCode.AppendLine("}"); // end of: Procedure Instance 
        pocoCode.AppendLine("}"); // end of: Namespace
        pocoCode.AppendLine();

        //## 一個 Procedure 一個檔案
        File.WriteAllText(Path.Combine(outDir.FullName, $"{proc.SPECIFIC_NAME}.cs"), pocoCode.ToString(), encoding: Encoding.UTF8);
        Console.WriteLine(pocoCode.ToString());
      });

    }

    public void SubGenerateTableValuedFunctionPocoCode(SqlConnection conn, DirectoryInfo outDir)
    {
      var procList = DBHelper.LoadTableValuedFunction(conn);
      procList.ForEach(proc =>
      {
        Console.WriteLine($"{Utils.JsonSerialize(proc, true, true)}");
        StringBuilder pocoCode = new StringBuilder();

        pocoCode.AppendLine($"namespace {nameSpace}");
        pocoCode.AppendLine("{");
        pocoCode.AppendLine("using System;");
        pocoCode.AppendLine("using System.Collections.Generic;");
        pocoCode.AppendLine("using System.ComponentModel.DataAnnotations;");
        pocoCode.AppendLine("using Dapper;");
        pocoCode.AppendLine($"using {sqlClientLibrary};");
        pocoCode.AppendLine();

        //## Procedure Result Class ------------
        ///public class 計算資產編號Result
        ///{
        ///    public string 資產編號 { get; set; }
        ///}

        pocoCode.AppendLine($"public class {proc.SPECIFIC_NAME}Result ");
        pocoCode.AppendLine("{");
        proc.ColumnList.ForEach(col =>
              {
                string dataType = Utils.GetNetDataType(col.DATA_TYPE);
                string nullable = (dataType != "string" && col.IS_NULLABLE == "YES") ? "?" : "";

                pocoCode.AppendLine($"{indent}public {dataType}{nullable} {col.COLUMN_NAME} {{ get; set; }}");
              });
        pocoCode.AppendLine("}"); // end of: Reslt Column 


        //## Procedure Parameter Class ------------
        ///public class 計算資產編號Args
        ///{
        ///    public string 品項類別 { get; set; }
        ///}

        bool f_NonParam = proc.ParamList.Count <= 0; // 旗標：無輸入參數
        if (!f_NonParam)
        {
          pocoCode.AppendLine();
          pocoCode.AppendLine($"public class {proc.SPECIFIC_NAME}Args ");
          pocoCode.AppendLine("{");
          proc.ParamList.ForEach(arg =>
                {
                  string dataType = Utils.GetNetDataType(arg.DATA_TYPE);
                  string nullable = (dataType != "string") ? "?" : "";

                  pocoCode.AppendLine($"{indent}public {dataType}{nullable} {arg.PARAMETER_NAME.Substring(1)} {{ get; set; }}");
                });
          pocoCode.AppendLine("}"); // end of: Reslt Column 
        }

        //## Procedure Instance ------------
        ///static partial class DBHelperClassExtensions
        ///{
        ///    public static List<查詢電腦設備領用裝況Result> Call查詢電腦設備領用裝況(this SqlConnection conn, 查詢電腦設備領用裝況Args args, SqlTransaction txn = null)
        ///    {
        ///        string sql = @"SELECT * FROM [dbo].[查詢電腦設備領用裝況](@帳卡編號,@使用者代碼,@領用起日,@領用訖日,@領用狀況); ";
        ///        var dataList = conn.Query<查詢電腦設備領用裝況Result>(sql, args, txn).AsList();
        ///        return dataList;
        ///    }
        ///}

        pocoCode.AppendLine();
        pocoCode.AppendLine("static partial class DBHelperClassExtensions");
        pocoCode.AppendLine("{");

        pocoCode.AppendLine($"public static List<{proc.SPECIFIC_NAME}Result> Call{proc.SPECIFIC_NAME}(this SqlConnection conn, {proc.SPECIFIC_NAME}Args args, SqlTransaction txn = null)");
        pocoCode.AppendLine("{");

        pocoCode.Append($"{indent}var sql = @\"SELECT * FROM [{proc.SPECIFIC_SCHEMA}].[{proc.SPECIFIC_NAME}](");
        pocoCode.Append(String.Join(",", proc.ParamList.Select(c => c.PARAMETER_NAME)));
        pocoCode.AppendLine($"); \"; ");

        pocoCode.AppendLine($"{indent}var dataList = conn.Query<{proc.SPECIFIC_NAME}Result>(sql, args, txn).AsList();");
        pocoCode.AppendLine($"{indent}return dataList;");
        //------
        pocoCode.AppendLine("}");

        //## Procedure Instance : method 2 直接帶入參數 ------------
        ///static partial class DBHelperClassExtensions
        ///{
        ///    public static List<查詢電腦設備領用裝況Result> Call查詢電腦設備領用裝況(this SqlConnection conn, string 帳卡編號, string 使用者代碼, DateTime? 領用起日, DateTime? 領用訖日, string 領用狀況)
        ///    {
        ///        var args = {
        ///            帳卡編號,使用者代碼,領用起日,領用訖日,領用狀況
        ///        };
        ///        string sql = @"SELECT * FROM [dbo].[查詢電腦設備領用裝況](@帳卡編號,@使用者代碼,@領用起日,@領用訖日,@領用狀況); ";
        ///        var dataList = conn.Query<查詢電腦設備領用裝況Result>(sql, args).AsList();
        ///        return dataList;
        ///    }
        ///}

        //※ 無參數狀況下會重複，故不產出。
        if (!f_NonParam)
        {
          pocoCode.AppendLine();
          pocoCode.Append($"public static List<{proc.SPECIFIC_NAME}Result> Call{proc.SPECIFIC_NAME}(this SqlConnection conn");
          proc.ParamList.ForEach(arg =>
                {
                  string dataType = Utils.GetNetDataType(arg.DATA_TYPE);
                  string nullable = (dataType != "string") ? "?" : "";

                  pocoCode.Append($", {dataType}{nullable} {arg.PARAMETER_NAME.Substring(1)}");
                });
          pocoCode.AppendLine(", SqlTransaction txn = null)");
          pocoCode.AppendLine("{");
          pocoCode.AppendLine($"{indent}var args = new {{");
          proc.ParamList.ForEach(arg =>
                {
                  pocoCode.AppendLine($"{indent}{indent}{arg.PARAMETER_NAME.Substring(1)},");
                });
          pocoCode.AppendLine($"{indent}}};");
          pocoCode.AppendLine();

          pocoCode.Append($"{indent}var sql = @\"SELECT * FROM [{proc.SPECIFIC_SCHEMA}].[{proc.SPECIFIC_NAME}](");
          pocoCode.Append(String.Join(",", proc.ParamList.Select(c => c.PARAMETER_NAME)));
          pocoCode.AppendLine($"); \"; ");

          pocoCode.AppendLine($"{indent}var dataList = conn.Query<{proc.SPECIFIC_NAME}Result>(sql, args, txn).AsList();");
          pocoCode.AppendLine($"{indent}return dataList;");
          //------
          pocoCode.AppendLine("}");
        }

        //---------------------
        pocoCode.AppendLine("}"); // end of: Procedure Instance 
        pocoCode.AppendLine("}"); // end of: Namespace
        pocoCode.AppendLine();

        //## 一個 Procedure 一個檔案
        File.WriteAllText(Path.Combine(outDir.FullName, $"{proc.SPECIFIC_NAME}.cs"), pocoCode.ToString(), encoding: Encoding.UTF8);
        Console.WriteLine(pocoCode.ToString());
      });

    }


  }
}