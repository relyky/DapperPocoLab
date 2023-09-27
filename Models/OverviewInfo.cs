using DocumentFormat.OpenXml.Office.CustomUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperPocoLab.Models;

internal class OverviewInfo
{
  public string DbName { get; set; }
  public string PrintDate { get; set; }

  public List<OverviewItem> ItemList { get; set; }
}

internal class OverviewItem
{
  public string Sn { get; set; }
  public string Name { get; set; }
  public string Desc {  get; set; }
  public string Type { get; set; }
}

//-------------------------------------

internal class RptTableInfo
{
  public string Name { get; set; }
  public string Type { get; set; }
  public string PrintDate { get; set; }

  public List<RptTableField> FieldList { get; set; }
}

internal class RptTableField
{
  public string Sn { get; set; }
  public string Name { get; set; }
  public string Cname { get; set; }
  public string Type { get; set; }
  public string Len { get; set; }
  public string Pk { get; set; }
  public string Default { get; set; }
  public string Nullable { get; set; }
  public string Desc { get; set; }
}