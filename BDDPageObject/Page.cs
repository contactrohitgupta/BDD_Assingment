﻿using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using BDDCore;
namespace BDDPageObject
{
    public static class Page
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            RetryingElementLocator retry = new RetryingElementLocator(BrowserFactory.Driver, TimeSpan.FromSeconds(10));
            //IPageObjectMemberDecorator decor = new DefaultPageObjectMemberDecorator();
            //PageFactory.InitElements(retry.SearchContext, page, decor);
            
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static LoginPage Login
        {
            get { return GetPage<LoginPage>(); }
        }
    }
}


