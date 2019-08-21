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
	public partial class MinesweeperDifficulty : ContentPage
	{
		public MinesweeperDifficulty ()
		{
			InitializeComponent ();
		}

        private void EasyBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MinesweeperPage(6));
        }

        private void MediumBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MinesweeperPage(9));
        }

        private void HardBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MinesweeperPage(12));
        }
    }
}