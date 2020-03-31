using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace BDDCore

{
    public class RestApiUtil
    {
        public enum Methods
        {
            GET,
            PUT,
            POST,
            DELETE
        }

        public static string ExecuteMethodCall(Methods strMethod, DataTable dtCallDetails,bool isPrarmWithURI=false)
        {
            try
            {
                RestClient client = null;
                if (!isPrarmWithURI)
                    client = new RestClient(dtCallDetails.Rows[0]["APIURL"].ToString());
                else
                    client = new RestClient(dtCallDetails.Rows[0]["APIURL"].ToString() + dtCallDetails.Rows[0]["APIParameter"].ToString());

                RestRequest request = null;
                // client.Authenticator = new HttpBasicAuthenticator(username, password);
                switch (strMethod)
                {
                    case Methods.GET:
                        request = new RestRequest(Method.GET);
                        break;
                    case Methods.POST:
                        request = new RestRequest(Method.POST);
                        break;
                    case Methods.PUT:
                        request = new RestRequest(Method.PUT);
                        break;
                    case Methods.DELETE:
                        request = new RestRequest(Method.DELETE);
                        break;
                }

                //Add file for attachement.
                if (dtCallDetails.Rows[0]["FilePath"] != DBNull.Value)
                {
                    string strPath = dtCallDetails.Rows[0]["FilePath"].ToString();
                    request.AddFile(Path.GetFileName(strPath).Split('.')[0], strPath);
                }
                // easily add HTTP Headers
                if (dtCallDetails.Rows[0]["APIHeader"] != DBNull.Value)
                {
                    string[] strHeaders = dtCallDetails.Rows[0]["APIHeader"].ToString().Split('|');
                    foreach (string strHeader in strHeaders)
                    {
                        string strKey = strHeader.Split(':')[0];
                        string strValue = strHeader.Contains("https") ? strHeader.Split(':')[1] + ":" + strHeader.Split(':')[2] : strHeader.Split(':')[1];
                        request.AddHeader(strKey, strValue);
                    }
                }

                //Adding parameter information
                if (!isPrarmWithURI)
                {
                    if (dtCallDetails.Rows[0]["APIParameter"] != DBNull.Value)
                    {
                        string[] strParameters = dtCallDetails.Rows[0]["APIParameter"].ToString().Split('|');
                        foreach (string strParam in strParameters)
                        {
                            string strKey = strParam.Split(':')[0];
                            string strValue = strParam.Split(':')[1];
                            request.AddParameter(strKey, strValue);
                        }
                    }
                }


                //Adding Body
                if (dtCallDetails.Rows[0]["APIBody"] != DBNull.Value)
                    request.AddJsonBody(dtCallDetails.Rows[0]["APIBody"].ToString());

                // execute the requestd
                IRestResponse response = client.Execute(request);
                if(response.Content.Contains("500 - Internal server error."))
                    response = client.Execute(request);

                return response.Content;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public static string ExecuteMethodCall(Methods strMethod, string strURL,string strBody=null)
        {
            try
            {
                RestClient client = null;
                    client = new RestClient(strURL);

                RestRequest request = null;
                // client.Authenticator = new HttpBasicAuthenticator(username, password);
                switch (strMethod)
                {
                    case Methods.GET:
                        request = new RestRequest(Method.GET);
                        break;
                    case Methods.POST:
                        request = new RestRequest(Method.POST);
                        break;
                    case Methods.PUT:
                        request = new RestRequest(Method.PUT);
                        break;
                    case Methods.DELETE:
                        request = new RestRequest(Method.DELETE);
                        break;
                }

                //Adding Body
                if (!string.IsNullOrEmpty(strBody))
                    request.AddJsonBody(strBody.ToString());

                // execute the requestd
                IRestResponse response = client.Execute(request);
                if (response.Content.Contains("500 - Internal server error."))
                    response = client.Execute(request);

                return response.Content;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<T> ExecuteMethodCall<T>(Methods strMethod, DataTable dtCallDetails)
        {
            try
            {
                var client = new RestClient(dtCallDetails.Rows[0]["APIURL"].ToString());
                RestRequest request = null;
                // client.Authenticator = new HttpBasicAuthenticator(username, password);
                switch (strMethod)
                {
                    case Methods.GET:
                        request = new RestRequest(Method.GET);
                        break;
                    case Methods.POST:
                        request = new RestRequest(Method.POST);
                        break;
                    case Methods.PUT:
                        request = new RestRequest(Method.PUT);
                        break;
                    case Methods.DELETE:
                        request = new RestRequest(Method.DELETE);
                        break;
                }

                // easily add HTTP Headers
                if (dtCallDetails.Rows[0]["APIHeader"] != DBNull.Value)
                {
                    string[] strHeaders = dtCallDetails.Rows[0]["APIHeader"].ToString().Split('|');
                    foreach (string strHeader in strHeaders)
                    {
                        string strKey = strHeader.Split(':')[0];
                        string strValue = strHeader.Split(':')[1];
                        request.AddHeader(strKey, strValue);
                    }
                }

                //Adding parameter information
                if (dtCallDetails.Rows[0]["APIParameter"] != DBNull.Value)
                {
                    string[] strParameters = dtCallDetails.Rows[0]["APIParameter"].ToString().Split('|');
                    foreach (string strParam in strParameters)
                    {
                        string strKey = strParam.Split(':')[0];
                        string strValue = strParam.Split(':')[1];
                        request.AddParameter(strKey, strValue);
                    }
                }

                //Adding Body
                if (dtCallDetails.Rows[0]["APIBody"] != DBNull.Value)
                    request.AddJsonBody(dtCallDetails.Rows[0]["APIBody"].ToString());

                // execute the requestd
                IRestResponse response = client.Execute(request);

                JObject objContent = JObject.Parse(response.Content);

                //Converting from Json Object to class object.
                IList<JToken> results = objContent["Data"].Children().ToList();
                IList<JToken> stateModelList = results[0].Children().ToList();
                List<T> lstStateListRetrieve = new List<T>();
                foreach (JToken result in stateModelList[0])
                {
                    // JToken.ToObject is a helper method that uses JsonSerializer internally
                    T data= result.ToObject<T>();
                    //data.ResponseMessage = objContent["ResponseMessage"].ToString();
                    //data.ResponseCode = objContent["ResponseCode"].ToString();
                    lstStateListRetrieve.Add(data);
                }
                return lstStateListRetrieve;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
