using System.Configuration;
using System.Data;
using System.Data.OleDb;


namespace BDD_Test
{
    public class CommonMethods
    {
        public static DataTable GetDataFromExcelSheet(string query)
        {
            string excelFilePath = ConfigurationManager.AppSettings["ExcelPath"].ToString();
            OleDbConnection con = new OleDbConnection(excelFilePath);
            OleDbCommand cmd = new OleDbCommand(query, con);
            DataTable dt = new DataTable();
            using (OleDbDataAdapter adptr = new OleDbDataAdapter(cmd))
            {
                con.Open();
                adptr.Fill(dt);
            }
            con.Close();
            return dt;
        }
    }
}
