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
            Users users = RestApiPageFactory.User.MakeGetCall();

            Assert.AreEqual("Retrieved Invoice Details Successfully", users.ResponseMessage);
            Assert.AreEqual("200", users.ResponseCode);
            
        }
        [Test]
        public void Register()
        {
            string strBody = "{" + "email" + ":" + "eve.holt@reqres.in" + "," + "password" + ":" + "pistol" + "}";
            Registration register = RestApiPageFactory.Register.MakePostCall(strBody);

            Assert.AreEqual("200", register.ResponseCode);
            Assert.IsNotEmpty(register.token);
            Assert.IsEmpty(register.error);

        }
        [Test]
        public void UnRegister()
        {
            string strBody = "{" + "email" + ":" + "eve.holt@reqres.in"+ "}";
            Registration register = RestApiPageFactory.Register.MakePostCall(strBody);

            Assert.AreEqual("400", register.ResponseCode);
            Assert.IsEmpty(register.token);
            Assert.AreEqual(register.error, "Missing password");

        }
    }
}
