namespace Vista.DB.Schema
{
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dapper;
using Microsoft.Data.SqlClient;

public class 計算資產編號Result 
{
    public string 資產編號 { get; set; }
}

public class 計算資產編號Args 
{
    public string 品項類別 { get; set; }
}

static partial class DBHelperClassExtensions
{
public static List<計算資產編號Result> Call計算資產編號(this SqlConnection conn, 計算資產編號Args args)
{
    var dataList = conn.Query<計算資產編號Result>("計算資產編號", args,
        commandType: System.Data.CommandType.StoredProcedure).AsList();
    return dataList;
}

public static List<計算資產編號Result> Call計算資產編號(this SqlConnection conn, string 品項類別)
{
    var args = new {
        品項類別,
    };

    var dataList = conn.Query<計算資產編號Result>("計算資產編號", args,
        commandType: System.Data.CommandType.StoredProcedure).AsList();
    return dataList;
}
}
}

