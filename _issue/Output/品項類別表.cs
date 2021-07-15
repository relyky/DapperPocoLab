namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("品項類別表")]
public class 品項類別表 
{
    [ExplicitKey]
    [Required]
    public string 品項類別 { get; set; }
    [Required]
    public string 品項頭碼 { get; set; }
    /// <summary>
    /// 狀態: active,disable;
    /// </summary>
    [Required]
    public string 狀態 { get; set; }

    public void Copy(品項類別表 src)
    {
        this.品項類別 = src.品項類別;
        this.品項頭碼 = src.品項頭碼;
        this.狀態 = src.狀態;
    }

    public 品項類別表 Clone()
    {
        return new 品項類別表 {
            品項類別 = this.品項類別,
            品項頭碼 = this.品項頭碼,
            狀態 = this.狀態,
        };
    }
}
}

