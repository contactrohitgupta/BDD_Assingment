using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDDCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BDDPageObject
{
    public class Registration
    {
        public int id { get; set; }
        public string token { get; set; }
        public string error { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseCode { get; set; }

        public Registration MakePostCall(String strBody)
        {
            try
            {
                //Making a Post call
                string strResponseContent = RestApiUtil.ExecuteMethodCall(RestApiUtil.Methods.POST, "https://reqres.in/api/register", strBody);

                //converting the Json object
                JObject objContent = JObject.Parse(strResponseContent);

                //Converting from Json Object to class object.
                //IList<JToken> results = objContent["Data"].Children().ToList();
                //IList<JToken> users = results[0].Children().ToList();

                //JToken.ToObject is a helper method that uses JsonSerializer internally
                Registration regist = new Registration();
                //user.data = users[0].ToObject<Users>();
                regist.ResponseMessage = objContent["ResponseMessage"].ToString();
                regist.ResponseCode = objContent["ResponseCode"].ToString();
                regist.id =Convert.ToInt32( objContent["id"].ToString());
                regist.token = objContent["token"].ToString();
                regist.error = objContent["error"].ToString();
                return regist;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
