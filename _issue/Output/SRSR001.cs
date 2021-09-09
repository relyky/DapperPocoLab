namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("SRSR001")]
public class SRSR001 
{
    [ExplicitKey]
    [Required]
    public char Int_Rec { get; set; }
    [Required]
    public string ChName { get; set; }

    public void Copy(SRSR001 src)
    {
        this.Int_Rec = src.Int_Rec;
        this.ChName = src.ChName;
    }

    public SRSR001 Clone()
    {
        return new SRSR001 {
            Int_Rec = this.Int_Rec,
            ChName = this.ChName,
        };
    }
}
}

