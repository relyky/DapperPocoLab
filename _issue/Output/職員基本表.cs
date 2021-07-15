namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("職員基本表")]
public class 職員基本表 
{
    [ExplicitKey]
    [Required]
    public string 職員代碼 { get; set; }
    [Required]
    public string 職員姓名 { get; set; }
    /// <summary>
    /// 狀態: active,disable;
    /// </summary>
    [Required]
    public string 狀態 { get; set; }

    public void Copy(職員基本表 src)
    {
        this.職員代碼 = src.職員代碼;
        this.職員姓名 = src.職員姓名;
        this.狀態 = src.狀態;
    }

    public 職員基本表 Clone()
    {
        return new 職員基本表 {
            職員代碼 = this.職員代碼,
            職員姓名 = this.職員姓名,
            狀態 = this.狀態,
        };
    }
}
}

