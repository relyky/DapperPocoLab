using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DapperPocoLab
{
  class DBHelper
  {
    public static List<TableInfo> LoadTable(SqlConnection conn)
    {
      string sql = @"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME != 'sysdiagrams' ";
      var tableList = conn.Query<TableInfo>(sql).ToList();
      return tableList;
    }

    public static List<ColumnInfo> LoadTableColumn(SqlConnection conn, string tableName, string tableSchema = "dbo")
    {
      string sql = $@"WITH PK AS (
SELECT TC.CONSTRAINT_CATALOG,TC.CONSTRAINT_SCHEMA,TC.CONSTRAINT_NAME,TC.TABLE_NAME,TC.CONSTRAINT_TYPE, KC.COLUMN_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS TC
INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE KC ON 
	TC.CONSTRAINT_CATALOG = KC.CONSTRAINT_CATALOG AND 
	TC.CONSTRAINT_SCHEMA = KC.CONSTRAINT_SCHEMA AND
	TC.CONSTRAINT_NAME = KC.CONSTRAINT_NAME
WHERE TC.CONSTRAINT_TYPE = 'PRIMARY KEY'
)
, MSDESC AS (
select ss.name [TABLE_SCHEMA], st.name [TABLE_NAME], sc.name [COLUMN_NAME], sep.value [MS_Description]
from sys.tables st
inner join sys.columns sc on st.object_id = sc.object_id
inner join sys.schemas ss on st.schema_id = ss.schema_id
inner join sys.extended_properties sep on 
  st.object_id = sep.major_id and 
  sc.column_id = sep.minor_id and 
  sep.name = 'MS_Description' and 
  sep.value is not null
)
, COMPUTED AS (
select ss.name [TABLE_SCHEMA], st.name [TABLE_NAME], sc.name [COLUMN_NAME]
, sc.is_computed [IS_COMPUTED]
, sc.definition [COMPUTED_DEFINITION]
from sys.tables st
inner join sys.computed_columns sc on st.object_id = sc.object_id
inner join sys.schemas ss on st.schema_id = ss.schema_id
where sc.is_computed = 1
)
SELECT C.COLUMN_NAME, C.ORDINAL_POSITION, C.TABLE_CATALOG, C.TABLE_SCHEMA, C.TABLE_NAME, C.IS_NULLABLE, C.DATA_TYPE
, IS_IDENTITY = CASE WHEN COLUMNPROPERTY(object_id(C.TABLE_SCHEMA+'.'+C.TABLE_NAME), C.COLUMN_NAME, 'IsIdentity') = 1 THEN 'YES' ELSE 'NO' END
, IS_PK = CASE WHEN PK.CONSTRAINT_TYPE = 'PRIMARY KEY' THEN 'YES' ELSE 'NO' END
, MS_Description = MSDESC.MS_Description
, IS_COMPUTED = CASE WHEN COMPUTED.IS_COMPUTED = 1 THEN 'YES' ELSE 'NO' END
, COMPUTED.COMPUTED_DEFINITION
FROM INFORMATION_SCHEMA.COLUMNS C
LEFT JOIN PK ON C.COLUMN_NAME = PK.COLUMN_NAME AND
  C.TABLE_NAME = PK.TABLE_NAME AND
  C.TABLE_SCHEMA = PK.CONSTRAINT_SCHEMA AND
  C.TABLE_CATALOG = PK.CONSTRAINT_CATALOG
LEFT JOIN MSDESC ON C.COLUMN_NAME = MSDESC.COLUMN_NAME AND
  C.TABLE_NAME = MSDESC.TABLE_NAME AND
  C.TABLE_SCHEMA = MSDESC.TABLE_SCHEMA
LEFT JOIN COMPUTED ON C.COLUMN_NAME = COMPUTED.COLUMN_NAME AND
  C.TABLE_NAME = COMPUTED.TABLE_NAME AND
  C.TABLE_SCHEMA = COMPUTED.TABLE_SCHEMA
WHERE C.TABLE_NAME = @tableName
 AND C.TABLE_SCHEMA = @tableSchema
ORDER BY TABLE_NAME, ORDINAL_POSITION ASC ";

      var columnList = conn.Query<ColumnInfo>(sql, new { tableSchema, tableName }).ToList();
      return columnList;
    }

    public static List<RoutineInfo> LoadProcedure(SqlConnection conn)
    {
      string sql1 = @"SELECT SPECIFIC_CATALOG, SPECIFIC_SCHEMA, SPECIFIC_NAME, ROUTINE_TYPE
  FROM INFORMATION_SCHEMA.ROUTINES
 WHERE ROUTINE_TYPE = 'PROCEDURE'
   AND ROUTINE_NAME NOT IN('sp_upgraddiagrams','sp_helpdiagrams','sp_helpdiagramdefinition','sp_creatediagram','sp_renamediagram','sp_alterdiagram','sp_dropdiagram'); ";

      List<RoutineInfo> procedureList = new List<RoutineInfo>();
      foreach (var info in conn.Query<RoutineInfo>(sql1).ToList())
      {
        // parameter info
        info.ParamList = DoLoadParameterInfo(conn, info.SPECIFIC_NAME, info.SPECIFIC_SCHEMA, info.SPECIFIC_CATALOG);

        //// result column info
        //info.ColumnList = conn.Query<ResultColumnInfo>("sp_describe_first_result_set", new { tsql = info.SPECIFIC_NAME },
        //    commandType: System.Data.CommandType.StoredProcedure).ToList();

        // result column info
        info.ColumnList = conn.Query("sp_describe_first_result_set", new { tsql = info.SPECIFIC_NAME },
            commandType: System.Data.CommandType.StoredProcedure).Select(c => new RoutineColumnInfo
            {
              COLUMN_NAME = (string)c.name,
              ORDINAL_POSITION = (int)c.column_ordinal,
              IS_NULLABLE = (bool)c.is_nullable ? "YES" : "NO",
              DATA_TYPE = (string)c.system_type_name
            }).ToList();

        procedureList.Add(info);
      }

      return procedureList;
    }

    public static List<RoutineInfo> LoadTableValuedFunction(SqlConnection conn)
    {
      string sql1 = @"SELECT SPECIFIC_CATALOG, SPECIFIC_SCHEMA, SPECIFIC_NAME, ROUTINE_TYPE
 FROM INFORMATION_SCHEMA.ROUTINES
 WHERE ROUTINE_TYPE = 'FUNCTION'
  AND DATA_TYPE = 'TABLE'; ";

      string sql3 = @"SELECT COLUMN_NAME ,ORDINAL_POSITION ,DATA_TYPE,IS_NULLABLE 
 FROM INFORMATION_SCHEMA.ROUTINE_COLUMNS
 WHERE TABLE_NAME = @SPECIFIC_NAME
  AND TABLE_SCHEMA = @SPECIFIC_SCHEMA
  AND TABLE_CATALOG = @SPECIFIC_CATALOG; ";

      List<RoutineInfo> procedureList = new List<RoutineInfo>();
      foreach (var info in conn.Query<RoutineInfo>(sql1).ToList())
      {
        // parameter info
        info.ParamList = DoLoadParameterInfo(conn, info.SPECIFIC_NAME, info.SPECIFIC_SCHEMA, info.SPECIFIC_CATALOG);

        // result column info
        info.ColumnList = conn.Query<RoutineColumnInfo>(sql3, new { info.SPECIFIC_CATALOG, info.SPECIFIC_SCHEMA, info.SPECIFIC_NAME }).ToList();

        procedureList.Add(info);
      }

      return procedureList;
    }

    /// <summary>
    /// 參考：[Get Column information of a user defined Table Type](https://stackoverflow.com/questions/41904787/get-column-information-of-a-user-defined-table-type)
    /// </summary>
    public static List<TableTypeInfo> LoadTableType(SqlConnection conn)
    {
      string sql = @"SELECT [TABLE_TYPE_NAME] = T.name, [TABLE_TYPE_SCHEMA] = SCHEMA_NAME(T.schema_id) FROM sys.table_types T ";
      var tableList = conn.Query<TableTypeInfo>(sql).ToList();
      return tableList;
    }

    /// <summary>
    /// 參考：[Get Column information of a user defined Table Type](https://stackoverflow.com/questions/41904787/get-column-information-of-a-user-defined-table-type)
    /// </summary>
    public static List<TableTypeColumnInfo> LoadTableTypeColumn(SqlConnection conn, string tableTypeName, string tableTypeSchema = "dbo")
    {
      string sql = @"SELECT [TABLE_TYPE_NAME] = t.name 
,[TABLE_TYPE_SCHEMA] = s.name
,[COLUMN_NAME] = c.name
,[DATA_TYPE] = y.name
,[ORDINAL_POSITION] = c.column_id
,[MAX_LENGTH] = c.max_length
,[PRECISION] = c.precision
,[IS_IDENTITY] = CASE WHEN c.is_identity = 1 THEN 'YES' ELSE 'NO' END
,[IS_NULLABLE] = CASE WHEN c.is_nullable = 1 THEN 'YES' ELSE 'NO' END 
FROM sys.table_types t
INNER JOIN sys.schemas s on t.schema_id = s.schema_id
INNER JOIN sys.columns c on c.object_id = t.type_table_object_id
INNER JOIN sys.types y on y.user_type_id = c.user_type_id
WHERE t.is_user_defined = 1
  AND t.is_table_type = 1
  AND t.name = @tableTypeName
  AND s.name = @tableTypeSchema
ORDER BY [ORDINAL_POSITION] ASC ";

      var columnList = conn.Query<TableTypeColumnInfo>(sql, new { tableTypeName, tableTypeSchema }).ToList();
      return columnList;
    }

    static List<ParameterInfo> DoLoadParameterInfo(SqlConnection conn, string SPECIFIC_NAME, string SPECIFIC_SCHEMA, string SPECIFIC_CATALOG)
    {
      string sql2 = @"SELECT SPECIFIC_CATALOG, SPECIFIC_SCHEMA, SPECIFIC_NAME, ORDINAL_POSITION, PARAMETER_NAME
, [DATA_TYPE] = IIF(DATA_TYPE = 'table type', USER_DEFINED_TYPE_NAME, DATA_TYPE)
, IS_TABLE_TYPE = IIF(DATA_TYPE = 'table type', 'YES', 'NO')
 FROM INFORMATION_SCHEMA.PARAMETERS
 WHERE SPECIFIC_NAME = @SPECIFIC_NAME
  AND SPECIFIC_SCHEMA = @SPECIFIC_SCHEMA
  AND SPECIFIC_CATALOG = @SPECIFIC_CATALOG; ";

      var paramList = conn.Query<ParameterInfo>(sql2, new { SPECIFIC_NAME, SPECIFIC_SCHEMA, SPECIFIC_CATALOG }).AsList();
      return paramList;
    }
  }


  class TableInfo
  {
    public string TABLE_CATALOG { get; set; }
    public string TABLE_SCHEMA { get; set; }
    public string TABLE_NAME { get; set; }
    public string TABLE_TYPE { get; set; }
  }

  class ColumnInfo
  {
    public string COLUMN_NAME { get; set; }
    public string ORDINAL_POSITION { get; set; }
    public string TABLE_CATALOG { get; set; }
    public string TABLE_SCHEMA { get; set; }
    public string TABLE_NAME { get; set; }
    public string DATA_TYPE { get; set; }
    public string IS_NULLABLE { get; set; }
    public string IS_IDENTITY { get; set; }
    public string IS_PK { get; set; }
    public string MS_Description { get; set; }
    public string IS_COMPUTED { get; set; }
    public string COMPUTED_DEFINITION { get; set; }
  }

  class RoutineInfo
  {
    public string SPECIFIC_CATALOG { get; set; }
    public string SPECIFIC_SCHEMA { get; set; }
    public string SPECIFIC_NAME { get; set; }
    public string ROUTINE_TYPE { get; set; }

    public List<ParameterInfo> ParamList { get; set; }
    public List<RoutineColumnInfo> ColumnList { get; set; }
  }

  class ParameterInfo
  {
    public string PARAMETER_NAME { get; set; }
    public int ORDINAL_POSITION { get; set; }
    public string SPECIFIC_CATALOG { get; set; }
    public string SPECIFIC_SCHEMA { get; set; }
    public string PECIFIC_NAME { get; set; }
    public string DATA_TYPE { get; set; }
    public string IS_TABLE_TYPE { get; set; }
  }

  class RoutineColumnInfo
  {
    public string COLUMN_NAME { get; set; }
    public int ORDINAL_POSITION { get; set; }
    public string IS_NULLABLE { get; set; }
    public string DATA_TYPE { get; set; }
  }

  class TableTypeInfo
  {
    public string TABLE_TYPE_NAME { get; set; }
    public string TABLE_TYPE_SCHEMA { get; set; }
  }

  class TableTypeColumnInfo
  {
    public string TABLE_TYPE_NAME { get; set; }
    public string TABLE_TYPE_SCHEMA { get; set; }
    public string COLUMN_NAME { get; set; }
    public string DATA_TYPE { get; set; }
    public string IS_IDENTITY { get; set; }
    public string IS_NULLABLE { get; set; }
    public int ORDINAL_POSITION { get; set; }
    public int MAX_LENGTH { get; set; }
    public int PRECISION { get; set; }
  }

  static class DBHelperClassExtensions
  {
    /// <summary>
    /// 轉換 List<T> 成 DataTable。
    /// for TVP(table value parameter) 參數傳遞
    /// </summary>
    public static DataTable AsDataTable<TTableType>(this List<TTableType> infoList)
    {
      var table = new DataTable();
      var properties = typeof(TTableType).GetRuntimeProperties();

      foreach (var prop in properties)
      {
        table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
      }

      foreach (var info in infoList)
      {
        table.Rows.Add(properties.Select(property => property.GetValue(info)).ToArray());
      }

      return table;
    }

  }

}
