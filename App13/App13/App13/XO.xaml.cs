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
	public partial class XO : ContentPage
	{
        Button[] Buttons = new Button[9];
        public XO(string playername)
        {
            InitializeComponent();

            Buttons[0] = b1;
            Buttons[1] = b2;
            Buttons[2] = b3;

            Buttons[3] = b4;
            Buttons[4] = b5;
            Buttons[5] = b6;

            Buttons[6] = b7;
            Buttons[7] = b8;
            Buttons[8] = b9;

            p1.Text = playername;
        }
        private Class1 game = new Class1();

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!playagain.IsVisible)
            {
                Button temp = (Button)sender;
                if (temp.Text == "")
                {
                    game.setButton((Button)sender);

                    if (game.checkWinner(Buttons, scorep1, scorep2))
                    {
                        playagain.IsVisible = true;
                        gameover.IsVisible = true;
                    }
                    if (!playagain.IsVisible)
                    {
                        game.AIplays(Buttons);
                        if (game.checkWinner(Buttons, scorep1, scorep2))
                        {
                            playagain.IsVisible = true;
                            gameover.IsVisible = true;
                        }
                    }
                }
            }
        }

        private void Play_Clicked(object sender, EventArgs e)
        {
            game.reset(Buttons);
            playagain.IsVisible = false;
            gameover.IsVisible = false;
            if (game.startingTurn % 2 == 1)
            {
                game.AIplays(Buttons);
            }
        }
    }
}