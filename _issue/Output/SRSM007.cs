namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("SRSM007")]
public class SRSM007 
{
    /// <summary>
    /// 寄發日期
    /// </summary>
    public char? SEND_DATE { get; set; }
    /// <summary>
    /// 寄發時間
    /// </summary>
    public char? SEND_TIME { get; set; }
    /// <summary>
    /// 公司代號
    /// </summary>
    public char? ACCOUNT_ID { get; set; }
    /// <summary>
    /// 身份證字號
    /// </summary>
    public char? IDNO { get; set; }
    /// <summary>
    /// 帳單年月
    /// </summary>
    public char? ACCT_YYMM { get; set; }
    /// <summary>
    /// email
    /// </summary>
    public string EMAIL { get; set; }
    /// <summary>
    /// 空白
    /// </summary>
    public char? SEND_EMPL { get; set; }

    public void Copy(SRSM007 src)
    {
        this.SEND_DATE = src.SEND_DATE;
        this.SEND_TIME = src.SEND_TIME;
        this.ACCOUNT_ID = src.ACCOUNT_ID;
        this.IDNO = src.IDNO;
        this.ACCT_YYMM = src.ACCT_YYMM;
        this.EMAIL = src.EMAIL;
        this.SEND_EMPL = src.SEND_EMPL;
    }

    public SRSM007 Clone()
    {
        return new SRSM007 {
            SEND_DATE = this.SEND_DATE,
            SEND_TIME = this.SEND_TIME,
            ACCOUNT_ID = this.ACCOUNT_ID,
            IDNO = this.IDNO,
            ACCT_YYMM = this.ACCT_YYMM,
            EMAIL = this.EMAIL,
            SEND_EMPL = this.SEND_EMPL,
        };
    }
}
}

