namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("SRST002")]
public class SRST002 
{
    [Required]
    public char? IDNO { get; set; }
    [Required]
    public char? ACCT_YYMM { get; set; }
    [Required]
    public char? NAME1 { get; set; }
    [Required]
    public char? ADDR1 { get; set; }
    [Required]
    public char? ADDR2 { get; set; }
    [Required]
    public char? ADDR3 { get; set; }
    [Required]
    public char? TEXT1 { get; set; }
    [Required]
    public char? DETAIL_NUM { get; set; }
    [Required]
    public char? STATUS { get; set; }
    [Required]
    public char? Cycle { get; set; }

    public void Copy(SRST002 src)
    {
        this.IDNO = src.IDNO;
        this.ACCT_YYMM = src.ACCT_YYMM;
        this.NAME1 = src.NAME1;
        this.ADDR1 = src.ADDR1;
        this.ADDR2 = src.ADDR2;
        this.ADDR3 = src.ADDR3;
        this.TEXT1 = src.TEXT1;
        this.DETAIL_NUM = src.DETAIL_NUM;
        this.STATUS = src.STATUS;
        this.Cycle = src.Cycle;
    }

    public SRST002 Clone()
    {
        return new SRST002 {
            IDNO = this.IDNO,
            ACCT_YYMM = this.ACCT_YYMM,
            NAME1 = this.NAME1,
            ADDR1 = this.ADDR1,
            ADDR2 = this.ADDR2,
            ADDR3 = this.ADDR3,
            TEXT1 = this.TEXT1,
            DETAIL_NUM = this.DETAIL_NUM,
            STATUS = this.STATUS,
            Cycle = this.Cycle,
        };
    }
}
}

