using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDCore;

using RestSharp;


namespace BDDPageObject
{
    public class Datum
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }

    public class Ad
    {
        public string company { get; set; }
        public string url { get; set; }
        public string text { get; set; }
    }

    public class RootObject
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Datum> data { get; set; }
        public Ad ad { get; set; }
    
    
        public string ResponseMessage { get; set; }
        public string ResponseCode { get; set; }
        
        public RootObject MakeGetCall()
        {
            try
            {
                //Making a Get call
                IRestResponse strResponse = RestApiUtil.ExecuteMethodCall(RestApiUtil.Methods.GET, "https://reqres.in/api/users", null);

                //Converting from Json Object to class object.
                RootObject user = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(strResponse.Content);
                user.ResponseCode = strResponse.StatusCode.ToString();
                user.ResponseMessage = strResponse.StatusDescription;
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
