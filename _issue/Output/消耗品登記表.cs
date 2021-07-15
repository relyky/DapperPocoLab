namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("消耗品登記表")]
public class 消耗品登記表 
{
    [ExplicitKey]
    [Required]
    public string 帳卡編號 { get; set; }
    [Required]
    public string 品項類別 { get; set; }
    public string 資產編號 { get; set; }
    public DateTime? 購買日期 { get; set; }
    public DateTime? 登記日期 { get; set; }
    public string 其他說明 { get; set; }
    public string 品牌型號 { get; set; }
    public string 產品序號 { get; set; }
    [Required]
    public string 狀態 { get; set; }

    public void Copy(消耗品登記表 src)
    {
        this.帳卡編號 = src.帳卡編號;
        this.品項類別 = src.品項類別;
        this.資產編號 = src.資產編號;
        this.購買日期 = src.購買日期;
        this.登記日期 = src.登記日期;
        this.其他說明 = src.其他說明;
        this.品牌型號 = src.品牌型號;
        this.產品序號 = src.產品序號;
        this.狀態 = src.狀態;
    }

    public 消耗品登記表 Clone()
    {
        return new 消耗品登記表 {
            帳卡編號 = this.帳卡編號,
            品項類別 = this.品項類別,
            資產編號 = this.資產編號,
            購買日期 = this.購買日期,
            登記日期 = this.登記日期,
            其他說明 = this.其他說明,
            品牌型號 = this.品牌型號,
            產品序號 = this.產品序號,
            狀態 = this.狀態,
        };
    }
}
}

