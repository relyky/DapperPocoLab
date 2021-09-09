namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("ExpLog")]
public class ExpLog 
{
    /// <summary>
    /// 流水號
    /// </summary>
    [Key]
    [Required]
    public int SID { get; set; }
    /// <summary>
    /// 發生例外之Class名稱
    /// </summary>
    public string ClassName { get; set; }
    /// <summary>
    /// 發生例外之Method名稱
    /// </summary>
    public string MethodName { get; set; }
    /// <summary>
    /// 錯誤訊息
    /// </summary>
    public string ErrMsg { get; set; }
    /// <summary>
    /// 發生時間
    /// </summary>
    public DateTime? UDate { get; set; }

    public void Copy(ExpLog src)
    {
        this.SID = src.SID;
        this.ClassName = src.ClassName;
        this.MethodName = src.MethodName;
        this.ErrMsg = src.ErrMsg;
        this.UDate = src.UDate;
    }

    public ExpLog Clone()
    {
        return new ExpLog {
            SID = this.SID,
            ClassName = this.ClassName,
            MethodName = this.MethodName,
            ErrMsg = this.ErrMsg,
            UDate = this.UDate,
        };
    }
}
}

