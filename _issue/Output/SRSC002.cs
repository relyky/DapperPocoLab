namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("SRSC002")]
public class SRSC002 
{
    [Required]
    public char? Zip { get; set; }
    [Required]
    public string Area { get; set; }
    [Required]
    public string City1 { get; set; }
    [Required]
    public string City2 { get; set; }

    public void Copy(SRSC002 src)
    {
        this.Zip = src.Zip;
        this.Area = src.Area;
        this.City1 = src.City1;
        this.City2 = src.City2;
    }

    public SRSC002 Clone()
    {
        return new SRSC002 {
            Zip = this.Zip,
            Area = this.Area,
            City1 = this.City1,
            City2 = this.City2,
        };
    }
}
}

