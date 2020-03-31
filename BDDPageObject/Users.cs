using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BDDPageObject
{
    [JsonObject]public class Datum
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

    public class Users
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Datum> data { get; set; }
        public Ad ad { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseCode { get; set; }

        public Users MakeGetCall()
        {
            try
            {
                
                    //Making a Get call
                    string strResponseContent = RestApiUtil.ExecuteMethodCall(RestApiUtil.Methods.GET, "https://reqres.in/api/users", null);

                    //converting the Json object
                    JObject objContent = JObject.Parse(strResponseContent);

                    //Converting from Json Object to class object.
                    IList<JToken> results = objContent["Data"].Children().ToList();
                    IList<JToken> users = results[0].Children().ToList();

                //JToken.ToObject is a helper method that uses JsonSerializer internally
                Users user = new Users();
                //user.data = users[0].ToObject<Users>();
                user.ResponseMessage = objContent["ResponseMessage"].ToString();
                user.ResponseCode = objContent["ResponseCode"].ToString();

                return user;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }

}
