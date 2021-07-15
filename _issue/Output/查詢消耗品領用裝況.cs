namespace Vista.DB.Schema
{
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dapper;
using Microsoft.Data.SqlClient;

public class 查詢消耗品領用裝況Result 
{
    public string 帳卡編號 { get; set; }
    public string 品項類別 { get; set; }
    public string 資產編號 { get; set; }
    public DateTime? 購買日期 { get; set; }
    public DateTime? 登記日期 { get; set; }
    public string 其他說明 { get; set; }
    public string 品牌型號 { get; set; }
    public string 產品序號 { get; set; }
    public string 狀態 { get; set; }
    public int? 序號 { get; set; }
    public string 使用者代碼 { get; set; }
    public string 使用者姓名 { get; set; }
    public DateTime? 領用日期 { get; set; }
    public DateTime? 繳回日期 { get; set; }
    public string 備註 { get; set; }
    public string 領用狀況 { get; set; }
}

public class 查詢消耗品領用裝況Args 
{
    public string 帳卡編號 { get; set; }
    public string 使用者代碼 { get; set; }
    public DateTime? 領用起日 { get; set; }
    public DateTime? 領用訖日 { get; set; }
    public string 領用狀況 { get; set; }
}

static partial class DBHelperClassExtensions
{
public static List<查詢消耗品領用裝況Result> Call查詢消耗品領用裝況(this SqlConnection conn, 查詢消耗品領用裝況Args args)
{
    var sql = @"SELECT * FROM [dbo].[查詢消耗品領用裝況](@帳卡編號,@使用者代碼,@領用起日,@領用訖日,@領用狀況); "; 
    var dataList = conn.Query<查詢消耗品領用裝況Result>(sql, args).AsList();
    return dataList;
}

public static List<查詢消耗品領用裝況Result> Call查詢消耗品領用裝況(this SqlConnection conn, string 帳卡編號, string 使用者代碼, DateTime? 領用起日, DateTime? 領用訖日, string 領用狀況)
{
    var args = new {
        帳卡編號,
        使用者代碼,
        領用起日,
        領用訖日,
        領用狀況,
    };

    var sql = @"SELECT * FROM [dbo].[查詢消耗品領用裝況](@帳卡編號,@使用者代碼,@領用起日,@領用訖日,@領用狀況); "; 
    var dataList = conn.Query<查詢消耗品領用裝況Result>(sql, args).AsList();
    return dataList;
}
}
}

