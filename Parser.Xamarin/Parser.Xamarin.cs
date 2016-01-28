using System;
using Autofac;
using Parser.Interface;
using Parser.Parsers;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Ioc.Autofac;

namespace Parser.Xamarin
{
    public class App : Application
    {
        public App ()
        {
            // The root page of your application
            MainPage = new ContentPage {
                Content = new StackLayout {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            XAlign = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        }
                    }
                }
            };
        }

        protected override void OnStart ()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<EmoticonsParser>().As<IElementParser>();
            builder.RegisterType<LinksParser>().As<IElementParser>();
            builder.RegisterType<MentionsParser>().As<IElementParser>();
            IResolver autofacResolver = new AutofacResolver(builder.Build());
            Resolver.SetResolver(autofacResolver);
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

