using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace TableInfoGetter
{
    class Program
    {
        static void Main()
        {
            SqlConnection myConnection = new SqlConnection(\\Connection string here); 

            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            try
            {
                var getAllTableNames = new SqlCommand(GetAllTableNames(), myConnection);
                SqlDataReader tableNameReader = getAllTableNames.ExecuteReader();

                while (tableNameReader.Read())
                {
                    string tableName = tableNameReader["name"] as string;
                    if (DontProcess(tableName))
                        continue;

                    //PrintListOfNewTables(tableName);
                    CreateTableDescriptionFiles(myConnection, tableName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.Read();
        }

        private static string RunStoredProcedure(string tableName, SqlConnection myConnection, Func<string, string> procedureToRun)
        {
            var getInsertStoredProcedures = new SqlCommand(procedureToRun.Invoke(tableName), myConnection);
            SqlDataReader myReader = getInsertStoredProcedures.ExecuteReader();
            StringBuilder insertingStoredProceduresStringBuilder = new StringBuilder();

            while (myReader.Read())
            {
                insertingStoredProceduresStringBuilder.AppendLine(myReader["ROUTINE_NAME"] + "<br/>");
            }

            return insertingStoredProceduresStringBuilder.ToString();
        }

        private static void PrintListOfNewTables(string tableName)
        {
            if(!TableNamesAndDescriptions.tableNameToDescription.ContainsKey(tableName))
                Console.WriteLine(tableName);
        }

        private static void CreateTableDescriptionFiles(SqlConnection myConnection, string tableName)
        {
            if (TableNamesAndDescriptions.tableNameToDescription.ContainsKey(tableName))
            {
                Console.WriteLine("Writing:{0}", tableName);
                File.WriteAllText(string.Format(@"C:\OurTableProcedures\{0}.html", tableName),
                    HTMLTemplate(RunStoredProcedure(tableName, myConnection, delegate { return GetInsertStoredProcedures(tableName); }),
                        RunStoredProcedure(tableName, myConnection, delegate { return GetUpdateStoredProcedures(tableName); }),
                        RunStoredProcedure(tableName, myConnection, delegate { return GetDeleteStoredProcedures(tableName); }), tableName,
                        TableNamesAndDescriptions.tableNameToDescription[tableName]));
            }
            else
            {
                Console.WriteLine("Could not find table in table description dictionary:{0}", tableName);
            }
        }

        /// <summary>
        /// Comment out a first letter if you want to print it out
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public static bool DontProcess(string tableName)
        {
            string lowerCaseTableName = tableName.ToLower();
            switch (lowerCaseTableName[0])
            {
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'g':
                case 'h':
                case 'i':
                case 'j':
                case 'k':
                //case 'l': //Add more specific lab information
                case 'm': //Add more specific migration information
                case 'n': //NEED TO DO THESE STILL
                case 'o': //NEED TO DO THESE STILL
                case 'p': //NEED TO DO THESE STILL
                case 'q': //NEED TO DO THESE STILL
                case 'r': //NEED TO DO THESE STILL
                case 's': //NEED TO DO THESE STILL
                case 't': //NEED TO DO THESE STILL
                case 'u':
                case 'v': //NEED TO DO THESE STILL
                case 'w': //NEED TO DO THESE STILL
                case 'x':
                case 'y':
                case 'z':
                    return true;
            }

            return false;
        }

        public static string HTMLTemplate(string insertingStoredProcedures, string updatingStoredProcedures, string deletingStoredProcedures, string tableName, string description)
        {
            return string.Format("<div><div dir=\"ltr\"><div dir=\"ltr\"><a name=\"Tracking_Details_.28Internal_Only.29\"></a></div><div><h3>What does {2} do?<br></h3>{3}<br><br><h3>Inserting Stored Procedures</h3>{0}<br></div><div><br></div><div><h3>Updating Stored Procedures<br></h3>{1}<br><br></div><div><h3>Deleting Stored Procedures</h3>{4}<br></div><div><br></div><div><hr><h3><a name=\"TOC-Background\"></a>Keywords</h3>{2}, documentation, table, info <br><br></div></div></div><h4><a name=\"TOC-Tracking-Details-Internal-Only-\"></a></h4><a name=\"Tracking_Details_.28Internal_Only.29\"></a>", insertingStoredProcedures, updatingStoredProcedures, tableName, description, deletingStoredProcedures);
        }

        public static string GetAllTableNames()
        {
            return "select name from sys.tables order by Name asc";
        }

        public static string GetInsertStoredProcedures(string tableName)
        {
            StringBuilder sb = new StringBuilder();
                       
            sb.AppendLine("SELECT ROUTINE_NAME, ROUTINE_DEFINITION ");
            sb.AppendLine("FROM INFORMATION_SCHEMA.ROUTINES ");
            sb.AppendLine(string.Format("WHERE ROUTINE_DEFINITION LIKE '%Insert into {0}%' ", tableName));
            sb.AppendLine("AND ROUTINE_TYPE='PROCEDURE'");

            return sb.ToString();
        }

        public static string GetUpdateStoredProcedures(string tableName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ROUTINE_NAME, ROUTINE_DEFINITION");
            sb.AppendLine("FROM INFORMATION_SCHEMA.ROUTINES");
            sb.AppendLine(string.Format("WHERE ROUTINE_DEFINITION like '%Update {0}%'", tableName));
            sb.AppendLine("AND ROUTINE_TYPE='PROCEDURE'");

            return sb.ToString();
        }

        public static string GetDeleteStoredProcedures(string tableName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("SELECT ROUTINE_NAME, ROUTINE_DEFINITION");
            sb.AppendLine("FROM INFORMATION_SCHEMA.ROUTINES");
            sb.AppendLine(string.Format("WHERE ROUTINE_DEFINITION like '%Delete From {0}%'", tableName));
            sb.AppendLine("AND ROUTINE_TYPE='PROCEDURE'");

            return sb.ToString();
        }
    }
}
