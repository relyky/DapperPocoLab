using System;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace DapperPocoLab
{
	public class Program
	{
		public static void Main()
		{
			try
			{
				//Generate All Tables
				const string indent = "    ";
				string connStr = "Data Source=RELYNB2;Initial Catalog=MineDB;Integrated Security=True";
				string outputFolder = "Output";

				DirectoryInfo outDir = new DirectoryInfo(outputFolder);
				if (!outDir.Exists) outDir.Create();

				using (var conn = new SqlConnection(connStr))
				{
					var tableList = DBHelper.GetTableList(conn);
					tableList.ForEach(table =>
					{
						// Console.WriteLine($"{Utils.JsonSerialize(table, false)}");
						StringBuilder pocoCode = new StringBuilder();

						pocoCode.AppendLine("using System;");
						pocoCode.AppendLine("using Dapper;");
						pocoCode.AppendLine("using Dapper.Contrib.Extensions;");
						pocoCode.AppendLine();

						pocoCode.AppendLine($"[Table(\"{table.TABLE_NAME}\")]");
						pocoCode.AppendLine($"public class {table.TABLE_NAME} ");
						pocoCode.AppendLine("{");

						var columnList = DBHelper.GetColumnList(conn, table.TABLE_NAME);
						columnList.ForEach(col =>
						{
							// Console.WriteLine($"{Utils.JsonSerialize(col, false)}");

							string dataType = Utils.GetNetDataType(col.DATA_TYPE);
							bool isKey = col.IS_PK == "YES";
							bool isIdentity = col.IS_IDENTITY == "YES";
							string nullable = col.IS_NULLABLE == "YES" ? "?" : "";
							string description = col.MS_Description;

							/// summary
							if (col.MS_Description != null)
							{
								pocoCode.AppendLine($"{indent}/// <summary>");
								pocoCode.AppendLine($"{indent}/// {col.MS_Description}");
								pocoCode.AppendLine($"{indent}/// </summary>");
							}

							/// Key attribute
							if (isKey && isIdentity)
								pocoCode.AppendLine($"{indent}[Key]");
							if (isKey && !isIdentity)
								pocoCode.AppendLine($"{indent}[ExplicitKey]");
							if (!isKey && isIdentity)
								pocoCode.AppendLine($"{indent}[Computed]");

							pocoCode.AppendLine($"{indent}public {dataType} {col.COLUMN_NAME}{nullable} {{ get; set; }}");
						});

						pocoCode.AppendLine("}");
						pocoCode.AppendLine();

						// 一個Table一個檔案
						File.WriteAllText(Path.Combine(outDir.FullName,$"{table.TABLE_NAME}.cs") , pocoCode.ToString(), encoding: Encoding.UTF8);
						Console.WriteLine(pocoCode.ToString());
					});
				}

				Console.WriteLine();
				Console.WriteLine("已成功產生 Dapper POCO classes 程式碼，請檢查輸出目錄。");
			}
			finally 
			{
				Console.WriteLine("Press any key to continue.");
				Console.ReadKey();
			}
		}
	}
}
