using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperPocoLab
{
    class DBHelper
    {
        public static List<TableInfo> GetTableList(SqlConnection conn)
        {
            string sql = @"SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME != 'sysdiagrams' ";
            var tableList = conn.Query<TableInfo>(sql).ToList();
            return tableList;
        }

        public static List<ColumnInfo> GetColumnList(SqlConnection conn, string tableName, string tableSchema = "dbo")
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
SELECT C.COLUMN_NAME, C.ORDINAL_POSITION, C.TABLE_CATALOG, C.TABLE_SCHEMA, C.TABLE_NAME, C.IS_NULLABLE, C.DATA_TYPE
, IS_IDENTITY = CASE WHEN COLUMNPROPERTY(object_id(C.TABLE_SCHEMA+'.'+C.TABLE_NAME), C.COLUMN_NAME, 'IsIdentity') = 1 THEN 'YES' ELSE 'NO' END
, IS_PK = CASE WHEN PK.CONSTRAINT_TYPE = 'PRIMARY KEY' THEN 'YES' ELSE 'NO' END
, MS_Description = MSDESC.MS_Description
FROM INFORMATION_SCHEMA.COLUMNS C
LEFT JOIN PK ON C.COLUMN_NAME = PK.COLUMN_NAME AND
  C.TABLE_NAME = PK.TABLE_NAME AND
  C.TABLE_SCHEMA = PK.CONSTRAINT_SCHEMA AND
  C.TABLE_CATALOG = PK.CONSTRAINT_CATALOG
LEFT JOIN MSDESC ON C.COLUMN_NAME = MSDESC.COLUMN_NAME AND
  C.TABLE_NAME = MSDESC.TABLE_NAME AND
  C.TABLE_SCHEMA = MSDESC.TABLE_SCHEMA
WHERE C.TABLE_NAME = @tableName
 AND C.TABLE_SCHEMA = @tableSchema
ORDER BY TABLE_NAME, ORDINAL_POSITION ASC ";

            var columnList = conn.Query<ColumnInfo>(sql, new { tableSchema, tableName }).ToList();
            return columnList;
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
    }
}
