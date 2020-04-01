
using NUnit.Framework;
using BDDPageObject;
using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace BDD_Test
{
    public class Test_RestApiMethods
    {
        [Test]
        public void GetUsers()
        {
            DataTable dtUser = CommonMethods.GetDataFromExcelSheet("select * from [User$]");

            RootObject users = RestApiPageFactory.User.MakeGetCall(dtUser.Rows[0]["URL"].ToString());

            Assert.AreEqual(dtUser.Rows[0]["ResponseMessage"].ToString(), users.ResponseMessage);
            Assert.AreEqual(dtUser.Rows[0]["ResponseCode"].ToString(), users.ResponseCode);
            Assert.Greater(users.data.Count,0);
        }
        [Test]
        public void Register()
        {
            DataTable dtRegister = CommonMethods.GetDataFromExcelSheet("select * from [Register$]");

            Registration register = RestApiPageFactory.Register.MakePostCall(dtRegister.Rows[0]["URL"].ToString(), dtRegister.Rows[0]["Body"].ToString());
            Assert.AreEqual(dtRegister.Rows[0]["ResponseCode"].ToString(), register.ResponseCode);
            Assert.IsNotEmpty(register.token);
            Assert.IsNull(register.error);
        }

        [Test]
        public void UnRegister()
        {
            DataTable dtUnRegister = CommonMethods.GetDataFromExcelSheet("select * from [Register$]");

            Registration register = RestApiPageFactory.Register.MakePostCall(dtUnRegister.Rows[1]["URL"].ToString(), dtUnRegister.Rows[1]["Body"].ToString());

            Assert.AreEqual(dtUnRegister.Rows[1]["ResponseCode"].ToString(), register.ResponseCode);
            Assert.AreEqual(register.error, dtUnRegister.Rows[1]["Error"].ToString());
        }
    }
}
