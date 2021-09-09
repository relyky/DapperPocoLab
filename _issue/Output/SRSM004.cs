namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("SRSM004")]
public class SRSM004 
{
    [Required]
    public char? Type { get; set; }
    [Required]
    public string Idno { get; set; }
    [Required]
    public string Ch_Name { get; set; }
    [Required]
    public string Card_No { get; set; }
    [Required]
    public string Acnt_yymm { get; set; }
    [Required]
    public string Apply_Date { get; set; }
    [Required]
    public string Apply_Time { get; set; }
    [Required]
    public string Print_Date { get; set; }
    [Required]
    public string Zip { get; set; }
    [Required]
    public string Addr { get; set; }
    [Required]
    public string Reason { get; set; }

    public void Copy(SRSM004 src)
    {
        this.Type = src.Type;
        this.Idno = src.Idno;
        this.Ch_Name = src.Ch_Name;
        this.Card_No = src.Card_No;
        this.Acnt_yymm = src.Acnt_yymm;
        this.Apply_Date = src.Apply_Date;
        this.Apply_Time = src.Apply_Time;
        this.Print_Date = src.Print_Date;
        this.Zip = src.Zip;
        this.Addr = src.Addr;
        this.Reason = src.Reason;
    }

    public SRSM004 Clone()
    {
        return new SRSM004 {
            Type = this.Type,
            Idno = this.Idno,
            Ch_Name = this.Ch_Name,
            Card_No = this.Card_No,
            Acnt_yymm = this.Acnt_yymm,
            Apply_Date = this.Apply_Date,
            Apply_Time = this.Apply_Time,
            Print_Date = this.Print_Date,
            Zip = this.Zip,
            Addr = this.Addr,
            Reason = this.Reason,
        };
    }
}
}

