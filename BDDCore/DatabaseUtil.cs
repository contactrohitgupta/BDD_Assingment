using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BDDCore

{
    public static class DatabaseUtil
    {
        private static string excelFilePath = ConfigurationManager.AppSettings["ExcelPath"].ToString();

        public static DataTable GetDataFromExcelSheet(string query )
        {
            OleDbConnection con = new OleDbConnection(excelFilePath);
            OleDbCommand cmd = new OleDbCommand(query, con);
            DataTable dt  = new DataTable();
            using (OleDbDataAdapter adptr = new OleDbDataAdapter(cmd))
            {
                con.Open();
                adptr.Fill(dt);
            }
            con.Close();
            return dt;
        }

        public static SqlConnection GetSQLConnection()
        {
            try
            {
                string connetionString = ConfigurationManager.ConnectionStrings["ContentChangeDBConnectionString"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                return cnn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetScanTagActivatedData(string strTransponderIssuer,string strAction,string strHTABarCode,string strRecordCount)
        {
            string connetionString;
           
            connetionString = ConfigurationManager.ConnectionStrings["ContentChangeDBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();

            if (!string.IsNullOrEmpty(strTransponderIssuer) && !string.IsNullOrWhiteSpace(strTransponderIssuer))
            {
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetScanTagActivatedData", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Transponder_Issuer", SqlDbType.VarChar).Value = strTransponderIssuer;
                        cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = strAction;
                        cmd.Parameters.Add("@HTABarCode", SqlDbType.VarChar).Value = strHTABarCode;
                        cmd.Parameters.Add("@RecordCount", SqlDbType.Int).Value = Convert.ToInt32(strRecordCount);

                        da.SelectCommand = cmd;
                        da.Fill(tempTable);
                    }
                }
            }
            
            return tempTable;
        }

        public static DataTable GetScanTagPickedData(string strBoxBarCode)
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["ContentChangeDBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();

            if (!string.IsNullOrEmpty(strBoxBarCode) && !string.IsNullOrWhiteSpace(strBoxBarCode))
            {
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetScanTagPickedData", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@BoxBarCode", SqlDbType.VarChar).Value = strBoxBarCode;
                        

                        da.SelectCommand = cmd;
                        da.Fill(tempTable);
                    }
                }
            }

            return tempTable;
        }

        public static DataTable GetLPRData(string strRentalAgent,string strTollRoad, string strRecordCount)
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["ContentChangeDBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();

            if (!string.IsNullOrEmpty(strRentalAgent) && !string.IsNullOrWhiteSpace(strRentalAgent))
            {
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetLPRData", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@RentalAgent", SqlDbType.VarChar).Value = strRentalAgent;
                        cmd.Parameters.Add("@TollRoad", SqlDbType.VarChar).Value = strTollRoad;
                        cmd.Parameters.Add("@RecordCount", SqlDbType.Int).Value = Convert.ToInt32(strRecordCount);

                        da.SelectCommand = cmd;
                        da.Fill(tempTable);
                    }
                }
            }

            return tempTable;
        }

        public static DataTable GetVioDataEntry(string strRentalAgent,string strState,string strTransportation_Agent,string strPlaza,string strCount)
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["ContentChangeDBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();

            if (!string.IsNullOrEmpty(strRentalAgent) && !string.IsNullOrWhiteSpace(strRentalAgent))
            {
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetVio_DataEntry", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Rental_Agent", SqlDbType.VarChar).Value = strRentalAgent;
                        cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = strState;
                        cmd.Parameters.Add("@Transportation_Agent", SqlDbType.VarChar).Value = strTransportation_Agent;
                        cmd.Parameters.Add("@Plaza", SqlDbType.VarChar).Value = strPlaza;
                        cmd.Parameters.Add("@Count", SqlDbType.VarChar).Value = strCount;

                        da.SelectCommand = cmd;
                        da.Fill(tempTable);
                    }
                }
            }

            return tempTable;
        }

        public static DataTable GetLCustomerReceiptChargData(string strAgentId,  string strRecordCount)
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["HTA_DEV_Scrum03DBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();

            if (!string.IsNullOrEmpty(strAgentId) && !string.IsNullOrWhiteSpace(strAgentId))
            {
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("Customer_Receipts", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@AgentId", SqlDbType.VarChar).Value = strAgentId;
                        cmd.Parameters.Add("@Count", SqlDbType.VarChar).Value = strRecordCount;

                        da.SelectCommand = cmd;
                        da.Fill(tempTable);
                    }
                }
            }

            return tempTable;
        }

        public static DataTable GetLCustomerReceiptCreditData()
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["HTA_DEV_Scrum03DBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();

                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("Customer_Receipts_Credit_Data", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        da.SelectCommand = cmd;
                        da.Fill(tempTable);
                    }
            }

            return tempTable;
        }

        public static DataTable GetLCustomerReplaceChargeData()
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["HTA_DEV_Scrum03DBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();

            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("Customer_Receipts_Replace_charge_Data", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    da.SelectCommand = cmd;
                    da.Fill(tempTable);
                }
            }

            return tempTable;
        }

        public static DataTable GetLCustomerVoidReceiptData(string strAgentId, string strRecordCount)
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["HTA_DEV_Scrum03DBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();

            if (!string.IsNullOrEmpty(strAgentId) && !string.IsNullOrWhiteSpace(strAgentId))
            {
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("Customer_Void_Receipts_Data", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@AgentId", SqlDbType.VarChar).Value = strAgentId;
                        cmd.Parameters.Add("@Count", SqlDbType.VarChar).Value = strRecordCount;

                        da.SelectCommand = cmd;
                        da.Fill(tempTable);
                    }
                }
            }

            return tempTable;
        }

        public static int InsertAutoResultsNotes(string strPid, string strResp1,string strResp2,string strPTransId,string strType)
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["HTA_DEV_Scrum03DBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();
            int noOFRows = 0;
            if (!string.IsNullOrEmpty(strPid) && !string.IsNullOrWhiteSpace(strPid))
            {
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("InsertAutoResultsNotes", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Pid", SqlDbType.VarChar).Value = strPid;
                        cmd.Parameters.Add("@Resp1", SqlDbType.VarChar).Value = strResp1;
                        cmd.Parameters.Add("@Resp2", SqlDbType.VarChar).Value = strResp2;
                        cmd.Parameters.Add("@PTransID", SqlDbType.VarChar).Value = strPTransId;
                        cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = strType;

                        noOFRows=cmd.ExecuteNonQuery();
                    }
                }
            }
            return noOFRows;
        }

        public static int Update_Stampdate()
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["HTA_DEV_Scrum03DBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();
            int noOFRows = 0;
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("Update_Stampdate", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        noOFRows = cmd.ExecuteNonQuery();
                    }
                }
            return noOFRows;
        }

        public static DataTable GetChargeReplaceChargeData()
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["ContentChangeDBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();

           
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetChargeReplaceChargeData", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        da.SelectCommand = cmd;
                        da.Fill(tempTable);
                    }
                }

            return tempTable;
        }

        public static DataTable GetCustomerCreditData()
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["ContentChangeDBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();

            
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetCustomerCreditData", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(tempTable);
                    }
                }

            return tempTable;
        }

        public static DataTable GETAPICallingDetails(string strAPIName, string strAPIMethod)
        {
            try
            {
                string connetionString;

                connetionString = ConfigurationManager.ConnectionStrings["ContentChangeDBConnectionString"].ConnectionString;
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable tempTable = new DataTable();

                if (!string.IsNullOrEmpty(strAPIName) && !string.IsNullOrEmpty(strAPIMethod))
                {
                    using (SqlConnection cnn = new SqlConnection(connetionString))
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand("GETAPICallingDetails", cnn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@APIName", SqlDbType.VarChar).Value = strAPIName;
                            cmd.Parameters.Add("@APIMethod", SqlDbType.VarChar).Value = strAPIMethod;

                            da.SelectCommand = cmd;
                            da.Fill(tempTable);
                        }
                    }
                }

                return tempTable;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public static DataSet GetCustomerLookUpData()
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["ContentChangeDBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dsTempData= new DataSet();

            
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_GetCustomerLookUpData", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand = cmd;
                        da.Fill(dsTempData);
                    }
                }
            

            return dsTempData;
        }
        public static DataTable GetAPIResponseDetails()
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["ContentChangeDBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dtTempData = new DataTable();


            using (SqlConnection cnn = new SqlConnection(connetionString))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("SP_GETAPIResponseDetails", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(dtTempData);
                }
            }


            return dtTempData;
        }
        public static DataTable ExecuteStoredProcedure(string StoredProcedureName, Dictionary<string, string> aryParameters)
        {
            DataTable tempTable = new DataTable();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ContentChangeDBConnectionString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adp = new SqlDataAdapter();
                    DataTable dt = new DataTable();
                    cmd.CommandText = StoredProcedureName;
                    cmd.CommandTimeout = 300;
                    try
                    {
                        if (aryParameters != null)
                        {
                            foreach (var param in aryParameters)
                            {
                                cmd.Parameters.Add(new SqlParameter(param.Key, param.Value));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        
                    }

                    cmd.Connection = con;
                    adp.SelectCommand = cmd;
                    adp.Fill(dt);
                    con.Close();
                    tempTable = dt;
                    return tempTable;
                }
            }
        }

        public static int GetCountBasedOnStatementId(string strStatementID)
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["HTA_DEV_DBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();

            if (!string.IsNullOrEmpty(strStatementID) && !string.IsNullOrWhiteSpace(strStatementID))
            {
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetCustomerPaymentReceipt_SearchbyPaymentID ", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Payment_ID ", SqlDbType.VarChar).Value = strStatementID;

                        da.SelectCommand = cmd;
                        da.Fill(tempTable);
                    }
                }
            }

            return tempTable.Rows.Count;
        }

        public static int GetCountBasedOnPhoneNumber(string strPhoneNumber)
        {
            string connetionString;

            connetionString = ConfigurationManager.ConnectionStrings["HTA_DEV_DBConnectionString"].ConnectionString;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tempTable = new DataTable();

            if (!string.IsNullOrEmpty(strPhoneNumber) && !string.IsNullOrWhiteSpace(strPhoneNumber))
            {
                using (SqlConnection cnn = new SqlConnection(connetionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("usp_GetCustomerPaymentReceipt_SearchbyPhoneNumber  ", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@PhoneNumber ", SqlDbType.VarChar).Value = strPhoneNumber;

                        da.SelectCommand = cmd;
                        da.Fill(tempTable);
                    }
                }
            }

            return tempTable.Rows.Count;
        }
        /*
         // If we need to pass the paramerter
         string[,] aryPara = new string[,]   
{   
      { "@Username", login .UserName } ,   
      { "@Password",login .Password }   
};
// List Of parameter the stored procedure needed.   
DataTable dt = new DataTable();// Date Table That Return required result.  
dt=selectData("spLogin", aryPara); 

        // if no parameter 
 DataTable dt = new DataTable();

// Date Table That Return required result.  
dt=selectData("spLogin", null);
 */


        public static DataTable ExecuteQuery(string queryString)
        {

            DataSet dataset;
            string connetionString = ConfigurationManager.ConnectionStrings["ContentChangeDBConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connetionString);
            try
            {
                //Checking the state of the connection
                if (sqlConnection == null || ((sqlConnection != null && (sqlConnection.State == ConnectionState.Closed ||
                    sqlConnection.State == ConnectionState.Broken))))
                    sqlConnection.Open();

                SqlDataAdapter dataAdaptor = new SqlDataAdapter();
                dataAdaptor.SelectCommand = new SqlCommand(queryString, sqlConnection);
                dataAdaptor.SelectCommand.CommandType = CommandType.Text;

                dataset = new DataSet();
                dataAdaptor.Fill(dataset, "table");
                sqlConnection.Close();
                return dataset.Tables["table"];
            }
            catch (Exception e)
            {
                dataset = null;
                sqlConnection.Close();
               
                return null;
            }
            finally
            {
                sqlConnection.Close();
                dataset = null;
            }


        }





    }
}
