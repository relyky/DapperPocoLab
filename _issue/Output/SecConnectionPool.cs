namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("SecConnectionPool")]
public class SecConnectionPool 
{
    [ExplicitKey]
    [Required]
    public string ConnectionID { get; set; }
    public string ServerName { get; set; }
    public string DatabaseName { get; set; }
    public string UID { get; set; }
    public string Password { get; set; }
    public string Remarks { get; set; }

    public void Copy(SecConnectionPool src)
    {
        this.ConnectionID = src.ConnectionID;
        this.ServerName = src.ServerName;
        this.DatabaseName = src.DatabaseName;
        this.UID = src.UID;
        this.Password = src.Password;
        this.Remarks = src.Remarks;
    }

    public SecConnectionPool Clone()
    {
        return new SecConnectionPool {
            ConnectionID = this.ConnectionID,
            ServerName = this.ServerName,
            DatabaseName = this.DatabaseName,
            UID = this.UID,
            Password = this.Password,
            Remarks = this.Remarks,
        };
    }
}
}

