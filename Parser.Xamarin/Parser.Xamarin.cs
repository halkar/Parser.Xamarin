using System;
using Autofac;
using Parser.Interface;
using Parser.Parsers;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Ioc.Autofac;

namespace Parser
{
    public class App : Application
    {
        public App ()
        {
            // The root page of your application
            MainPage = new global::Parser.MainPage ();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}

