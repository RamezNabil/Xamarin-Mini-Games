using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App13
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MineBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MinesweeperDifficulty());
        }

        private void MatchBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Match());
            DisplayAlert("Game Tutorial", "You need to find a match for every square.", "OK");
        }

        private void XOBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new XOPlayerSelection());
        }
    }
}
