namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("消耗品領用表")]
public class 消耗品領用表 
{
    [Key]
    [Required]
    public int 序號 { get; set; }
    [Required]
    public string 帳卡編號 { get; set; }
    [Required]
    public string 使用者代碼 { get; set; }
    [Required]
    public DateTime 領用日期 { get; set; }
    public DateTime? 繳回日期 { get; set; }
    public string 備註 { get; set; }

    public void Copy(消耗品領用表 src)
    {
        this.序號 = src.序號;
        this.帳卡編號 = src.帳卡編號;
        this.使用者代碼 = src.使用者代碼;
        this.領用日期 = src.領用日期;
        this.繳回日期 = src.繳回日期;
        this.備註 = src.備註;
    }

    public 消耗品領用表 Clone()
    {
        return new 消耗品領用表 {
            序號 = this.序號,
            帳卡編號 = this.帳卡編號,
            使用者代碼 = this.使用者代碼,
            領用日期 = this.領用日期,
            繳回日期 = this.繳回日期,
            備註 = this.備註,
        };
    }
}
}

