using BDDCore;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDDPageObject
{

    public static class RestApiPageFactory
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            RetryingElementLocator retry = new RetryingElementLocator(BrowserFactory.Driver, TimeSpan.FromSeconds(10));
            IPageObjectMemberDecorator decor = new DefaultPageObjectMemberDecorator();

            return page;
        }
        public static Users User
        {
            get { return GetPage<Users>(); }
        }

        public static Registration Register
        {
            get { return GetPage<Registration>(); }
        }
    }
}
