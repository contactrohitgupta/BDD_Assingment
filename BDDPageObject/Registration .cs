using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDCore;

using RestSharp;
using System.Web.Script.Serialization;

namespace BDDPageObject
{
    public class Registration
    {
        public int id { get; set; }
        public string token { get; set; }
        public string error { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseCode { get; set; }

        public Registration MakePostCall(String strURL,String strBody)
        {
            try
            {
                //Making a Post call
                IRestResponse strResponse = RestApiUtil.ExecuteMethodCall(RestApiUtil.Methods.POST, strURL, strBody);

                //converting the Json object
                Registration regist = Newtonsoft.Json.JsonConvert.DeserializeObject<Registration>(strResponse.Content);
                regist.ResponseMessage = strResponse.StatusDescription.ToString();
                regist.ResponseCode = strResponse.StatusCode.ToString();
                
                return regist;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
