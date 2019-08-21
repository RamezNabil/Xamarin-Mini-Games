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
	public partial class XO2P : ContentPage
	{
        Button[] Buttons = new Button[9];
        public XO2P(string p1name , string p2name)
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
            p1.Text = p1name;
            p2.Text = p2name;
        }
        private Class2 game = new Class2();

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (!playagain.IsVisible)
            {
                Button temp = (Button)sender;
                if (temp.Text == "")
                {
                    game.setButton((Button)sender);
                    game.turn++;
                    turnIndicator();
                }
                if (game.checkWinner(Buttons, scorep1, scorep2))
                {
                    playagain.IsVisible = true;
                    gameover.IsVisible = true;
                    turnIndicator();
                }
            }
        }

        private void Play_Clicked(object sender, EventArgs e)
        {
            game.reset(Buttons);
            playagain.IsVisible = false;
            gameover.IsVisible = false;
            game.turn = 0;
            turnIndicator();
        }

        private void turnIndicator()
        {
            if ((game.startingTurn + game.turn) % 2 == 0)
            {
                p1.BackgroundColor = Color.Gray;
                p2.BackgroundColor = Color.Black;
            }
            else
            {
                p2.BackgroundColor = Color.Gray;
                p1.BackgroundColor = Color.Black;
            }
        }
    }
}