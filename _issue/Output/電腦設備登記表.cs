namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("電腦設備登記表")]
public class 電腦設備登記表 
{
    [ExplicitKey]
    [Required]
    public string 帳卡編號 { get; set; }
    [Required]
    public string 品項類別 { get; set; }
    public string 資產編號 { get; set; }
    public string 品牌型號 { get; set; }
    public string 產品序號 { get; set; }
    public string 年份 { get; set; }
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string 硬碟容量 { get; set; }
    public string 硬碟２容量 { get; set; }
    public DateTime? 購買日期 { get; set; }
    public DateTime? 登記日期 { get; set; }
    public string 管理標籤 { get; set; }
    public string 其他說明 { get; set; }
    [Required]
    public string 狀態 { get; set; }

    public void Copy(電腦設備登記表 src)
    {
        this.帳卡編號 = src.帳卡編號;
        this.品項類別 = src.品項類別;
        this.資產編號 = src.資產編號;
        this.品牌型號 = src.品牌型號;
        this.產品序號 = src.產品序號;
        this.年份 = src.年份;
        this.CPU = src.CPU;
        this.RAM = src.RAM;
        this.硬碟容量 = src.硬碟容量;
        this.硬碟２容量 = src.硬碟２容量;
        this.購買日期 = src.購買日期;
        this.登記日期 = src.登記日期;
        this.管理標籤 = src.管理標籤;
        this.其他說明 = src.其他說明;
        this.狀態 = src.狀態;
    }

    public 電腦設備登記表 Clone()
    {
        return new 電腦設備登記表 {
            帳卡編號 = this.帳卡編號,
            品項類別 = this.品項類別,
            資產編號 = this.資產編號,
            品牌型號 = this.品牌型號,
            產品序號 = this.產品序號,
            年份 = this.年份,
            CPU = this.CPU,
            RAM = this.RAM,
            硬碟容量 = this.硬碟容量,
            硬碟２容量 = this.硬碟２容量,
            購買日期 = this.購買日期,
            登記日期 = this.登記日期,
            管理標籤 = this.管理標籤,
            其他說明 = this.其他說明,
            狀態 = this.狀態,
        };
    }
}
}

