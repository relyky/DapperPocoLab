namespace Vista.DB.Schema
{
using System;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

[Table("SRSM005")]
public class SRSM005 
{
    /// <summary>
    /// 序號
    /// </summary>
    [Computed]
    [Required]
    public int? Seq { get; set; }
    /// <summary>
    /// 身分證號
    /// </summary>
    [Required]
    public string Idno { get; set; }
    /// <summary>
    /// 姓名
    /// </summary>
    [Required]
    public string ChName { get; set; }
    /// <summary>
    /// 公司電話-舊
    /// </summary>
    [Required]
    public string TelO { get; set; }
    /// <summary>
    /// 住家電話-舊
    /// </summary>
    [Required]
    public string TelH { get; set; }
    /// <summary>
    /// 行動電話-舊
    /// </summary>
    [Required]
    public char? GSM { get; set; }
    /// <summary>
    /// 郵區
    /// </summary>
    [Required]
    public string Zip { get; set; }
    /// <summary>
    /// 地址1-舊
    /// </summary>
    [Required]
    public string Addr1 { get; set; }
    /// <summary>
    /// 地址2-舊
    /// </summary>
    [Required]
    public string Addr2 { get; set; }
    /// <summary>
    /// 郵區-新
    /// </summary>
    [Required]
    public string ZipNew { get; set; }
    /// <summary>
    /// 公司電話-新
    /// </summary>
    [Required]
    public string TelONew { get; set; }
    /// <summary>
    /// 住家電話-新
    /// </summary>
    [Required]
    public string TelHNew { get; set; }
    /// <summary>
    /// 行動電話-新
    /// </summary>
    [Required]
    public char? GSMNew { get; set; }
    /// <summary>
    /// 地址1-新

    /// </summary>
    [Required]
    public string Addr1New { get; set; }
    /// <summary>
    /// 地址2-新

    /// </summary>
    [Required]
    public string Addr2New { get; set; }
    /// <summary>
    /// 逾期帳齡
    /// </summary>
    [Required]
    public char? PERIOD_eds { get; set; }
    /// <summary>
    /// 簡訊發送日期
    /// </summary>
    [Required]
    public char? MsgDate { get; set; }
    /// <summary>
    /// 簡訊發送結果
    /// </summary>
    [Required]
    public char? MsgStatus { get; set; }
    /// <summary>
    /// 
    /// </summary>
    [Required]
    public char? BillProcDate { get; set; }
    [Required]
    public char? BillProcID { get; set; }
    [Required]
    public char? AuthProcDate { get; set; }
    [Required]
    public char? AuthProcID { get; set; }
    [Required]
    public string JOCSAlterID { get; set; }
    public string AlterDept { get; set; }
    [Required]
    public char? MarkTSODate { get; set; }
    [Required]
    public char? DataTSODate { get; set; }
    [Required]
    public char? DownloadDate { get; set; }
    [Required]
    public char? GradeTSODate { get; set; }
    [Required]
    public char? DelExportDate { get; set; }
    [Required]
    public char? Acctyymm { get; set; }
    [Required]
    public char? Cycle { get; set; }
    [Required]
    public char? CloseMark { get; set; }
    [Required]
    public char? Status { get; set; }
    [Required]
    public string Note { get; set; }
    /// <summary>
    /// 帳單退回代碼
    /// </summary>
    [Required]
    public char? RetnNo { get; set; }
    /// <summary>
    /// 資料上傳HP日期
    /// </summary>
    [Required]
    public char? UPLOAD_eds_DATE { get; set; }
    /// <summary>
    /// 帳單列印日期
    /// </summary>
    [Required]
    public char? AcctPrintDate { get; set; }

    public void Copy(SRSM005 src)
    {
        this.Seq = src.Seq;
        this.Idno = src.Idno;
        this.ChName = src.ChName;
        this.TelO = src.TelO;
        this.TelH = src.TelH;
        this.GSM = src.GSM;
        this.Zip = src.Zip;
        this.Addr1 = src.Addr1;
        this.Addr2 = src.Addr2;
        this.ZipNew = src.ZipNew;
        this.TelONew = src.TelONew;
        this.TelHNew = src.TelHNew;
        this.GSMNew = src.GSMNew;
        this.Addr1New = src.Addr1New;
        this.Addr2New = src.Addr2New;
        this.PERIOD_eds = src.PERIOD_eds;
        this.MsgDate = src.MsgDate;
        this.MsgStatus = src.MsgStatus;
        this.BillProcDate = src.BillProcDate;
        this.BillProcID = src.BillProcID;
        this.AuthProcDate = src.AuthProcDate;
        this.AuthProcID = src.AuthProcID;
        this.JOCSAlterID = src.JOCSAlterID;
        this.AlterDept = src.AlterDept;
        this.MarkTSODate = src.MarkTSODate;
        this.DataTSODate = src.DataTSODate;
        this.DownloadDate = src.DownloadDate;
        this.GradeTSODate = src.GradeTSODate;
        this.DelExportDate = src.DelExportDate;
        this.Acctyymm = src.Acctyymm;
        this.Cycle = src.Cycle;
        this.CloseMark = src.CloseMark;
        this.Status = src.Status;
        this.Note = src.Note;
        this.RetnNo = src.RetnNo;
        this.UPLOAD_eds_DATE = src.UPLOAD_eds_DATE;
        this.AcctPrintDate = src.AcctPrintDate;
    }

    public SRSM005 Clone()
    {
        return new SRSM005 {
            Seq = this.Seq,
            Idno = this.Idno,
            ChName = this.ChName,
            TelO = this.TelO,
            TelH = this.TelH,
            GSM = this.GSM,
            Zip = this.Zip,
            Addr1 = this.Addr1,
            Addr2 = this.Addr2,
            ZipNew = this.ZipNew,
            TelONew = this.TelONew,
            TelHNew = this.TelHNew,
            GSMNew = this.GSMNew,
            Addr1New = this.Addr1New,
            Addr2New = this.Addr2New,
            PERIOD_eds = this.PERIOD_eds,
            MsgDate = this.MsgDate,
            MsgStatus = this.MsgStatus,
            BillProcDate = this.BillProcDate,
            BillProcID = this.BillProcID,
            AuthProcDate = this.AuthProcDate,
            AuthProcID = this.AuthProcID,
            JOCSAlterID = this.JOCSAlterID,
            AlterDept = this.AlterDept,
            MarkTSODate = this.MarkTSODate,
            DataTSODate = this.DataTSODate,
            DownloadDate = this.DownloadDate,
            GradeTSODate = this.GradeTSODate,
            DelExportDate = this.DelExportDate,
            Acctyymm = this.Acctyymm,
            Cycle = this.Cycle,
            CloseMark = this.CloseMark,
            Status = this.Status,
            Note = this.Note,
            RetnNo = this.RetnNo,
            UPLOAD_eds_DATE = this.UPLOAD_eds_DATE,
            AcctPrintDate = this.AcctPrintDate,
        };
    }
}
}

