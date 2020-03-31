using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDDPageObject;

namespace BDD_Test
{
    public class Test_RestApiMethods
    {
        [Test]
        public void GetUsers()
        {
            RootObject users = RestApiPageFactory.User.MakeGetCall();

            Assert.AreEqual("OK", users.ResponseMessage);
            Assert.AreEqual("OK", users.ResponseCode);
            
        }
        [Test]
        public void Register()
        {
            string strBody = "{\"email\":\"eve.holt@reqres.in\",\"password\":\"pistol\"}";
           
            Registration register = RestApiPageFactory.Register.MakePostCall(strBody);

            Assert.AreEqual("OK", register.ResponseCode);
            Assert.IsNotEmpty(register.token);
            Assert.IsNull(register.error);

        }
        [Test]
        public void UnRegister()
        {
            string strBody = "{\"email\":\"eve.holt@reqres.in\"}";
            Registration register = RestApiPageFactory.Register.MakePostCall(strBody);

            Assert.AreEqual("BadRequest", register.ResponseCode);
            Assert.AreEqual(register.error, "Missing password");

        }
    }
}
