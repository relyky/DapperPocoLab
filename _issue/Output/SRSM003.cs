namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("SRSM003")]
public class SRSM003 
{
    /// <summary>
    /// 請放置"1"
    /// </summary>
    [Required]
    public char? Type { get; set; }
    /// <summary>
    /// 卡友身份證字號
    /// </summary>
    [ExplicitKey]
    [Required]
    public string IdNo { get; set; }
    /// <summary>
    /// 卡友姓名
    /// </summary>
    [Required]
    public string Ch_Name { get; set; }
    /// <summary>
    /// 空白
    /// </summary>
    [ExplicitKey]
    [Required]
    public string Card_No { get; set; }
    /// <summary>
    /// 帳單月份(yyyymm)
    /// </summary>
    [Required]
    public string Acnt_yymm { get; set; }
    /// <summary>
    /// 申請日期(yyyymmdd)
    /// </summary>
    [ExplicitKey]
    [Required]
    public string apply_date { get; set; }
    /// <summary>
    /// 申請時間(hhmmss)
    /// </summary>
    [ExplicitKey]
    [Required]
    public string apply_time { get; set; }
    /// <summary>
    /// 帳單列印日期
    /// </summary>
    [Required]
    public string print_date { get; set; }
    /// <summary>
    /// 帳寄地郵區
    /// </summary>
    [Required]
    public string Zip { get; set; }
    /// <summary>
    /// 帳寄地
    /// </summary>
    [Required]
    public string Addr { get; set; }

    public void Copy(SRSM003 src)
    {
        this.Type = src.Type;
        this.IdNo = src.IdNo;
        this.Ch_Name = src.Ch_Name;
        this.Card_No = src.Card_No;
        this.Acnt_yymm = src.Acnt_yymm;
        this.apply_date = src.apply_date;
        this.apply_time = src.apply_time;
        this.print_date = src.print_date;
        this.Zip = src.Zip;
        this.Addr = src.Addr;
    }

    public SRSM003 Clone()
    {
        return new SRSM003 {
            Type = this.Type,
            IdNo = this.IdNo,
            Ch_Name = this.Ch_Name,
            Card_No = this.Card_No,
            Acnt_yymm = this.Acnt_yymm,
            apply_date = this.apply_date,
            apply_time = this.apply_time,
            print_date = this.print_date,
            Zip = this.Zip,
            Addr = this.Addr,
        };
    }
}
}

