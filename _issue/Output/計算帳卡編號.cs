namespace Vista.DB.Schema
{
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dapper;
using Microsoft.Data.SqlClient;

public class 計算帳卡編號Result 
{
    public int? 帳卡編號 { get; set; }
}

static partial class DBHelperClassExtensions
{
public static List<計算帳卡編號Result> Call計算帳卡編號(this SqlConnection conn)
{
    var dataList = conn.Query<計算帳卡編號Result>("計算帳卡編號",
        commandType: System.Data.CommandType.StoredProcedure).AsList();
    return dataList;
}
}
}

