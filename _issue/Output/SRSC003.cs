namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("SRSC003")]
public class SRSC003 
{
    [ExplicitKey]
    [Required]
    public char RetnNo { get; set; }
    [Required]
    public char? RetnNote { get; set; }
    [Required]
    public string UpdateDate { get; set; }
    [Required]
    public string UserID { get; set; }

    public void Copy(SRSC003 src)
    {
        this.RetnNo = src.RetnNo;
        this.RetnNote = src.RetnNote;
        this.UpdateDate = src.UpdateDate;
        this.UserID = src.UserID;
    }

    public SRSC003 Clone()
    {
        return new SRSC003 {
            RetnNo = this.RetnNo,
            RetnNote = this.RetnNote,
            UpdateDate = this.UpdateDate,
            UserID = this.UserID,
        };
    }
}
}

