using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AlonsoLibary
{
	public class SqlHelper
	{
		public static string GenerateSQL_Ins(Dictionary<string,string> record,
									string tableName, 
			out SqlParameter[] parameters) {

				var parameterList = new List<SqlParameter>();
				var sqlTemplate = "INSERT INTO {0}({1}) VALUES({2})";
				var colList = string.Empty;
				var valueList = string.Empty;

				foreach (string columnName in record.Keys) {
					string value = record[columnName];
					if (string.IsNullOrEmpty(value) == true) continue;

					if (string.IsNullOrEmpty(colList) == false) {
						colList += ",";
					}
					colList += columnName;

					if (string.IsNullOrEmpty(valueList) == false)
					{
						valueList += ",";
					}
					valueList += "@" + columnName;

					SqlParameter p = new SqlParameter(columnName, value);
					parameterList.Add(p);
				}

				parameters = parameterList.ToArray();

				return string.Format(sqlTemplate, tableName, colList, valueList);
		}

        public static string GenerateSQL_Update(Dictionary<string, string> record,
                                    string tableName,
            out SqlParameter[] parameters)
        {

            var parameterList = new List<SqlParameter>();
            var sqlTemplate = "Update {0}  set {1}  where ";
            var colList = string.Empty;
          

            foreach (string columnName in record.Keys)
            {
                string value = record[columnName];
                string columnNameParameter = "@"+ columnName;
                if (string.IsNullOrEmpty(value) == true) continue;

                if (string.IsNullOrEmpty(colList) == false)
                {
                    colList += ",";
                }

                colList += string.Concat( value , "=" ,columnNameParameter);


                //if (string.IsNullOrEmpty(valueList) == false)
                //{
                //    valueList += ",";
                //}
                //valueList += "@" + columnName;

                SqlParameter p = new SqlParameter(columnName, value);
                parameterList.Add(p);
            }

            parameters = parameterList.ToArray();

            return string.Format(sqlTemplate, tableName, colList);
        }

    }
}
