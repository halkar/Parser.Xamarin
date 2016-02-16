using System;
using Xamarin.Forms;
using Parser.Interface;
using System.Collections.Generic;
using Parser.Parsers;

namespace Parser
{
    public partial class MainPage : ContentPage
    {
        private readonly IParser _parser = new Parser (new Serializer (), new List<IElementParser> () {
            new EmoticonsParser (),
            new MentionsParser (),
            new LinksParser (new WebsiteTitleRetriever ())
        });

        public MainPage ()
        {
            InitializeComponent ();
        }

        private async void OnParse (object sender, EventArgs e)
        {
            OutputText.Text = await _parser.Parse (MessageText.Text);
        }
    }
}
