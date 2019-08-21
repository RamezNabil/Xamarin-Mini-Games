using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App13
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XOPlayerSelection : ContentPage
    {
        public XOPlayerSelection()
        {
            InitializeComponent();
        }

        private void TwoplayerBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new XO2P(p1.Text,p2.Text));
        }

        private void OneplayerBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new XO(p1.Text));
        }
    }
}