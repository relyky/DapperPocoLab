namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("SRSM006")]
public class SRSM006 
{
    /// <summary>
    /// 公司統編
    /// </summary>
    [Required]
    public char? account_id { get; set; }
    /// <summary>
    /// 身分證號
    /// </summary>
    [Required]
    public char? idno { get; set; }
    /// <summary>
    /// 空白
    /// </summary>
    public string DEPT_NAME { get; set; }
    /// <summary>
    /// 空白
    /// </summary>
    public char? DEPT_EMPL { get; set; }
    /// <summary>
    /// 空白
    /// </summary>
    public char? CAR_NO { get; set; }
    /// <summary>
    /// 收取對帳單之email
    /// </summary>
    [Required]
    public string EMAIL { get; set; }

    public void Copy(SRSM006 src)
    {
        this.account_id = src.account_id;
        this.idno = src.idno;
        this.DEPT_NAME = src.DEPT_NAME;
        this.DEPT_EMPL = src.DEPT_EMPL;
        this.CAR_NO = src.CAR_NO;
        this.EMAIL = src.EMAIL;
    }

    public SRSM006 Clone()
    {
        return new SRSM006 {
            account_id = this.account_id,
            idno = this.idno,
            DEPT_NAME = this.DEPT_NAME,
            DEPT_EMPL = this.DEPT_EMPL,
            CAR_NO = this.CAR_NO,
            EMAIL = this.EMAIL,
        };
    }
}
}

