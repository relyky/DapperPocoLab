namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("SystemParameter")]
public class SystemParameter 
{
    /// <summary>
    /// 參數ID
    /// </summary>
    [ExplicitKey]
    [Required]
    public string ParameterID { get; set; }
    /// <summary>
    /// System ID若為空則為Public Parameter，若有值則Private Parameter
    /// </summary>
    public string SystemID { get; set; }
    /// <summary>
    /// 參數值
    /// </summary>
    public string ParameterValue { get; set; }
    /// <summary>
    /// 備註
    /// </summary>
    public string Remarks { get; set; }
    /// <summary>
    /// 建立者
    /// </summary>
    public string Creator { get; set; }
    /// <summary>
    /// 建立日期
    /// </summary>
    public DateTime? CreatedDate { get; set; }
    /// <summary>
    /// 修改者
    /// </summary>
    public string Modifier { get; set; }
    /// <summary>
    /// 修改日期
    /// </summary>
    public DateTime? ModifiedDate { get; set; }

    public void Copy(SystemParameter src)
    {
        this.ParameterID = src.ParameterID;
        this.SystemID = src.SystemID;
        this.ParameterValue = src.ParameterValue;
        this.Remarks = src.Remarks;
        this.Creator = src.Creator;
        this.CreatedDate = src.CreatedDate;
        this.Modifier = src.Modifier;
        this.ModifiedDate = src.ModifiedDate;
    }

    public SystemParameter Clone()
    {
        return new SystemParameter {
            ParameterID = this.ParameterID,
            SystemID = this.SystemID,
            ParameterValue = this.ParameterValue,
            Remarks = this.Remarks,
            Creator = this.Creator,
            CreatedDate = this.CreatedDate,
            Modifier = this.Modifier,
            ModifiedDate = this.ModifiedDate,
        };
    }
}
}

