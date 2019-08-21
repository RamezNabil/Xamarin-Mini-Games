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
	public partial class Match : ContentPage
	{
        Button[] buttons = new Button[16];
        bool[] enable = new bool[16];
        Color[] colors = new Color[8];
        Button temp = new Button();
        int state = 0;
		public Match ()
		{
			InitializeComponent ();

            state = 0;
            temp = new Button();

            buttons[0] = b0;
            buttons[1] = b1;
            buttons[2] = b2;
            buttons[3] = b3;
            buttons[4] = b4;
            buttons[5] = b5;
            buttons[6] = b6;
            buttons[7] = b7;
            buttons[8] = b8;
            buttons[9] = b9;
            buttons[10] = b10;
            buttons[11] = b11;
            buttons[12] = b12;
            buttons[13] = b13;
            buttons[14] = b14;
            buttons[15] = b15;

            for(int i=0; i<16; i++)
            {
                enable[i] = true;
            }

            colors[0] = Color.Red;
            colors[1] = Color.Orange;
            colors[2] = Color.Yellow;
            colors[3] = Color.Green;
            colors[4] = Color.Blue;
            colors[5] = Color.Violet;
            colors[6] = Color.DarkCyan;
            colors[7] = Color.Indigo;

            ResetBoard(buttons);
        }

        private void TutorialBTN_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Game Tutorial", "You need to find a match for every square.", "OK");
        }

        private void PlayAgainBTN_Clicked(object sender, EventArgs e)
        {
            ResetBoard(buttons);
            playAgainBTN.IsVisible = false;
            gameOverLabel.IsVisible = false;
            if(gameOverLabel.Text == "Game Over")
            {
                score.Text = "0";
                lifes.Text = "20";
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            but.BackgroundColor = but.TextColor;
            but.IsEnabled = false;
            if(state%2==1)
            {
                Freeze(buttons);
                if(but.TextColor == temp.TextColor)
                {
                    for(int i=0; i<16; i++)
                    {
                        if(buttons[i].TextColor == but.TextColor)
                        {
                            enable[i] = false;
                        }
                    }

                    int x = int.Parse(score.Text);
                    x++;
                    score.Text = x.ToString();
                    score.TextColor = Color.Green;
                    score.FontSize = 20;
                    await Task.Delay(300);
                    score.TextColor = Color.Aqua;
                    score.FontSize = 16;
                }
                else
                {
                    int x = int.Parse(lifes.Text);
                    x--;
                    lifes.Text = x.ToString();
                    lifes.TextColor = Color.Red;
                    lifes.FontSize = 20;
                    await Task.Delay(300);
                    lifes.TextColor = Color.Aqua;
                    lifes.FontSize = 16;
                    but.BackgroundColor = Color.LightGray;
                    await Task.Delay(500);
                    temp.BackgroundColor = Color.LightGray;
                }
                Unfreeze(buttons);
            }
            else
            {
                temp = but;
            }
            state++;
            if(WinCheck(buttons))
            {
                gameOverLabel.Text = "YOU WIN!";
                gameOverLabel.IsVisible = true;
                playAgainBTN.IsVisible = true;
                int x = int.Parse(lifes.Text);
                x += 5;
                lifes.Text = x.ToString();
                while(gameOverLabel.IsVisible)
                {
                    gameOverLabel.TextColor = Color.Green;
                    gameOverLabel.FontSize = 18;
                    await Task.Delay(700);
                    gameOverLabel.TextColor = Color.Aqua;
                    gameOverLabel.FontSize = 16;
                    await Task.Delay(700);
                }
            }
            if(lifes.Text == "0")
            {
                Freeze(buttons);
                gameOverLabel.Text = "Game Over";
                gameOverLabel.IsVisible = true;
                playAgainBTN.IsVisible = true;
                while(gameOverLabel.IsVisible)
                {
                    gameOverLabel.TextColor = Color.Red;
                    gameOverLabel.FontSize = 17;
                    await Task.Delay(700);
                    gameOverLabel.TextColor = Color.Aqua;
                    gameOverLabel.FontSize = 16;
                    await Task.Delay(700);
                }
            }
            
        }

        private void ResetBoard(Button[] arr)
        {
            Random random = new Random();
            for(int i=0; i<16; i++)
            {
                arr[i].TextColor = Color.Default;
                arr[i].BackgroundColor = Color.LightGray;
                enable[i] = true;
            }
            Unfreeze(arr);
            while (true)
            {
                bool exit = true;
                int x = random.Next(16);
                int y = random.Next(16);
                while(y == x)
                {
                    y = random.Next(16);
                }
                int z = random.Next(8);
                if(arr[x].TextColor == Color.Default && arr[y].TextColor == Color.Default)
                {
                    bool apply = true;
                    for(int i=0; i<16; i++)
                    {
                        if(arr[i].TextColor == colors[z])
                        {
                            apply = false;
                            break;
                        }
                    }
                    if (apply)
                    {
                        arr[x].TextColor = colors[z];
                        arr[y].TextColor = colors[z];
                    }
                }
                for(int i=0; i<16; i++)
                {
                    if(arr[i].TextColor == Color.Default)
                    {
                        exit = false;
                        break;
                    }
                }
                if(exit)
                {
                    break;
                }
            }

        }

        private void Freeze(Button[] arr)
        {
            for(int i=0; i<arr.Length; i++)
            {
                arr[i].IsEnabled = false;
            }
        }

        private void Unfreeze(Button[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (enable[i])
                {
                    arr[i].IsEnabled = true;
                }
            }
        }

        private bool WinCheck(Button[]arr)
        {
            bool wins = true;
            for(int i=0; i<arr.Length; i++)
            {
                if(arr[i].BackgroundColor == Color.LightGray)
                {
                    wins = false;
                    break;
                }
            }
            return wins;
        }
    }
}