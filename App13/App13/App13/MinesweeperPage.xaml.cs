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
	public partial class MinesweeperPage : ContentPage
	{
        int[,] board = new int[6, 6];
        int numberOFMines = 6;
        Button[,] boardButtons = new Button[6,6];
        List<double> buttonX = new List<double>();
        List<double> buttonY = new List<double>();
        List<string> buttonTEXT = new List<string>();
        public MinesweeperPage(int mines)
        {
            InitializeComponent();
            boardButtons[0, 0] = b0;
            boardButtons[0, 1] = b1;
            boardButtons[0, 2] = b2;
            boardButtons[0, 3] = b3;
            boardButtons[0, 4] = b4;
            boardButtons[0, 5] = b5;
            boardButtons[1, 0] = b6;
            boardButtons[1, 1] = b7;
            boardButtons[1, 2] = b8;
            boardButtons[1, 3] = b9;
            boardButtons[1, 4] = b10;
            boardButtons[1, 5] = b11;
            boardButtons[2, 0] = b12;
            boardButtons[2, 1] = b13;
            boardButtons[2, 2] = b14;
            boardButtons[2, 3] = b15;
            boardButtons[2, 4] = b16;
            boardButtons[2, 5] = b17;
            boardButtons[3, 0] = b18;
            boardButtons[3, 1] = b19;
            boardButtons[3, 2] = b20;
            boardButtons[3, 3] = b21;
            boardButtons[3, 4] = b22;
            boardButtons[3, 5] = b23;
            boardButtons[4, 0] = b24;
            boardButtons[4, 1] = b25;
            boardButtons[4, 2] = b26;
            boardButtons[4, 3] = b27;
            boardButtons[4, 4] = b28;
            boardButtons[4, 5] = b29;
            boardButtons[5, 0] = b30;
            boardButtons[5, 1] = b31;
            boardButtons[5, 2] = b32;
            boardButtons[5, 3] = b33;
            boardButtons[5, 4] = b34;
            boardButtons[5, 5] = b35;
            numberOFMines = mines;
            board = ResetBoard(board);
        }

        private void PlayAgainBTN_Clicked(object sender, EventArgs e)
        {
            gameOverLabel.IsVisible = false;
            playAgainBTN.IsVisible = false;
            score.Text = "0";
            board = ResetBoard(board);
        }

        private void TutorialBTN_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Game Tutorial", "Click into the minefield randomly to expose free space. The numbers displayed show how many bombs are adjacent to that square. Use your math skills and powers of deduction to identify where the bombs must be. Place a flag where you know a bomb to be and open up squares where you think there isn't one.", "OK");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button but = (Button)sender;
            if (but.Image == "flag.png")
            {
                but.Image = null;
                int x = int.Parse(flagBTN.Text);
                x++;
                flagBTN.Text = x.ToString();
            }
            else if (flagBTN.BackgroundColor == Color.Gray)
            {
                if (score.Text == "0")
                {
                    buttonX = new List<double>();
                    buttonY = new List<double>();
                    buttonTEXT = new List<string>();
                    flagBTN.Text = numberOFMines.ToString();
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            boardButtons[i, j].BackgroundColor = Color.LightGray;
                            boardButtons[i, j].Image = null;
                            boardButtons[i, j].FontSize = 1;
                            boardButtons[i, j].Text = "";
                        }
                    }
                    int loc = int.Parse(but.ClassId);
                    int locx, locy;
                    locx = loc / 6;
                    locy = loc % 6;
                    List<int> locxlist = new List<int>();
                    List<int> locylist = new List<int>();
                    int minesToReplace = 0;
                    for (int a = -1; a < 2; a++)
                    {
                        for (int b = -1; b < 2; b++)
                        {
                            int newlocx = locx + a;
                            int newlocy = locy + b;
                            if (newlocx>= 0 && newlocx <= 5 && newlocy>= 0 && newlocy<= 5)
                            {
                                locxlist.Add(newlocx);
                                locylist.Add(newlocy);
                                if (board[newlocx, newlocy] == 1)
                                {
                                    Console.WriteLine("OUTPUT: " + board[newlocx, newlocy]);
                                    board[newlocx, newlocy] = 0;
                                    boardButtons[newlocx, newlocy].TextColor = Color.White;
                                    boardButtons[newlocx, newlocy].FontSize = 1;
                                    boardButtons[newlocx, newlocy].Text = "";
                                    minesToReplace++;
                                }
                            }
                        }
                    }
                    int[,] randomArray =
                    {
                        {1,3,5,2,4,0},
                        {5,0,2,1,3,4},
                        {2,1,3,5,0,4},
                        {4,2,3,0,1,5},
                        {0,5,1,2,4,3},
                        {3,4,1,2,0,5}
                    };
                    Random rand = new Random();
                    int r = rand.Next(6);
                    int r1 = 0, r2 = 0;
                    for(int i=0; i<6; i++)
                    {
                        for(int j=0; j<6; j++)
                        {
                            if(minesToReplace == 0)
                            {
                                goto label1;
                            }
                            bool transform = true;
                            for(int k=0; k<locxlist.Count; k++)
                            {
                                r1 = randomArray[r, i];
                                r2 = randomArray[r, j];
                                if(r1 == locxlist[k] && r2 == locylist[k] || board[r1,r2]==1)
                                {
                                    transform = false;
                                    break;
                                }
                            }
                            if(transform)
                            {
                                board[r1, r2] = 1;
                                minesToReplace--;
                            }
                        }
                    }
                    label1: for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (board[i, j] == 1)
                            {
                                boardButtons[i, j].TextColor = Color.Red;
                                boardButtons[i, j].FontSize = 20;
                            }
                            else
                            {
                                int counter = 0;
                                for (int a = -1; a < 2; a++)
                                {
                                    for (int b = -1; b < 2; b++)
                                    {
                                        if (i + a >= 0 && i + a <= 5 && j + b >= 0 && j + b <= 5)
                                        {
                                            if (board[i + a, j + b] == 1)
                                            {
                                                counter++;
                                            }
                                        }
                                    }
                                }
                                if (counter > 0)
                                {
                                    boardButtons[i, j].Text = counter.ToString();
                                }
                            }
                        }
                    }
                }
                if (but.Image != "flag.png")
                {
                    //but.IsEnabled = false;
                    but.InputTransparent = true;
                    if (but.TextColor == Color.Red)
                    {
                        but.Image = "mine.png";
                        but.BackgroundColor = Color.Red;
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                //boardButtons[i, j].IsEnabled = false;
                                boardButtons[i, j].InputTransparent = true;
                            }
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {

                                if (boardButtons[i, j].TextColor == Color.Red  && boardButtons[i,j] != but)
                                {
                                    await Task.Delay(500);
                                    boardButtons[i, j].Image = "mine.png";
                                    boardButtons[i, j].BackgroundColor = Color.Red;
                                }
                            }
                        }
                        gameOverLabel.IsVisible = true;
                        playAgainBTN.IsVisible = true;
                        gameOverLabel.Text = "GAME OVER";
                        while (true)
                        {
                            gameOverLabel.TextColor = Color.Red;
                            gameOverLabel.FontSize = 20;
                            await Task.Delay(700);
                            gameOverLabel.TextColor = Color.Aqua;
                            gameOverLabel.FontSize = 18;
                            await Task.Delay(700);
                            if (!gameOverLabel.IsVisible)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        for(int i=0; i<buttonX.Count; i++)
                        {
                            if(but.X == buttonX[i] && but.Y == buttonY[i])
                            {
                                but.Text = buttonTEXT[i];
                                break;
                            }
                        }
                        int loc = int.Parse(but.ClassId);
                        int locx, locy;
                        locx = loc / 6;
                        locy = loc % 6;
                        if (but.BackgroundColor == Color.LightGray && but.Text == "")
                        {
                            OpenField(locx, locy);
                            int z = int.Parse(score.Text);
                            z--;
                            score.Text = z.ToString();
                        }
                        but.BackgroundColor = Color.DarkGreen;
                        but.FontSize = 20;
                        int x = int.Parse(score.Text);
                        x++;
                        score.Text = x.ToString();
                        score.TextColor = Color.Green;
                        score.FontSize = 22;
                        await Task.Delay(300);
                        score.TextColor = Color.Aqua;
                        score.FontSize = 18;
                    }
                    if (WinCheck(boardButtons))
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                //boardButtons[i, j].IsEnabled = false;
                                boardButtons[i, j].InputTransparent = true;
                            }
                        }
                        gameOverLabel.IsVisible = true;
                        playAgainBTN.IsVisible = true;
                        gameOverLabel.Text = "YOU WIN!";

                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {

                                if (boardButtons[i, j].TextColor == Color.Red)
                                {
                                    boardButtons[i, j].Image = "mine.png";
                                    boardButtons[i, j].BackgroundColor = Color.Red;
                                }
                            }
                        }
                        while (gameOverLabel.IsVisible)
                        {

                            for (int i = 0; i < 6; i++)
                            {
                                for (int j = 0; j < 6; j++)
                                {

                                    if (boardButtons[i, j].TextColor == Color.Red)
                                    {
                                        boardButtons[i, j].BackgroundColor = Color.Red;
                                    }
                                }
                            }
                            gameOverLabel.TextColor = Color.Green;
                            gameOverLabel.FontSize = 20;
                            await Task.Delay(700);
                            for (int i = 0; i < 6; i++)
                            {
                                for (int j = 0; j < 6; j++)
                                {

                                    if (boardButtons[i, j].TextColor == Color.Red)
                                    {
                                        boardButtons[i, j].BackgroundColor = Color.LightGray;
                                    }
                                }
                            }
                            gameOverLabel.TextColor = Color.Aqua;
                            gameOverLabel.FontSize = 18;
                            await Task.Delay(700);
                        }
                    }
                }
                else
                {
                    but.Image = null;
                    int x = int.Parse(flagBTN.Text);
                    x++;
                    flagBTN.Text = x.ToString();
                }
            }
            else
            {
                if (but.Text != "")
                {
                    buttonX.Add(but.X);
                    buttonY.Add(but.Y);
                    buttonTEXT.Add(but.Text);
                    but.Text = "";
                }
                but.Image = "flag.png";
                int x = int.Parse(flagBTN.Text);
                x--;
                flagBTN.Text = x.ToString();

            }
        }

        private int[,] ResetBoard(int[,] arr)
        {
            int[,] res = arr;
            buttonX = new List<double>();
            buttonY = new List<double>();
            buttonTEXT = new List<string>();
            flagBTN.Text = numberOFMines.ToString();
            for(int i=0; i<6; i++)
            {
                for(int j=0; j<6; j++)
                {
                    arr[i,j] = 0;
                    boardButtons[i, j].InputTransparent = false;
                    boardButtons[i, j].BackgroundColor = Color.LightGray;
                    boardButtons[i, j].TextColor = Color.White;
                    boardButtons[i, j].Image = null;
                    boardButtons[i, j].FontSize = 1;
                    boardButtons[i, j].Text = "";
                }
            }
            Random random = new Random();
            for (int i = 0; i < numberOFMines; i++)
            {
                int x = random.Next(6);
                int y = random.Next(6);
                while (arr[x, y] == 1)
                {
                    x = random.Next(6);
                    y = random.Next(6);
                }
                arr[x, y] = 1;
            }
            for(int i=0; i<6; i++)
            {
                for(int j=0; j<6; j++)
                {
                    if(arr[i,j]==1)
                    {
                        boardButtons[i, j].TextColor = Color.Red;
                        boardButtons[i, j].FontSize = 20;
                    }
                    else
                    {
                        int counter = 0;
                        for(int a=-1; a<2; a++)
                        {
                            for(int b=-1; b<2; b++)
                            {
                                if(i+a>=0 && i+a<=5 && j+b>=0 && j+b<=5)
                                {
                                    if (arr[i + a, j + b] == 1)
                                    {
                                        counter++;
                                    }
                                }
                            }
                        }
                        if(counter>0)
                        {
                            boardButtons[i, j].Text = counter.ToString();
                        }
                    }
                }
            }
            return res;
        }

        private bool WinCheck(Button[,] buttons)
        {
            bool exit = true;
            for(int i=0; i<6; i++)
            {
                for(int j=0; j<6; j++)
                {
                    if(buttons[i,j].BackgroundColor == Color.LightGray && buttons[i,j].TextColor!= Color.Red)
                    {
                        exit = false;
                        break;
                    }
                }
            }
            return exit;
        }

        int flagcounter = 0;
        private void FlagBTN_Clicked(object sender, EventArgs e)
        {
            if (flagcounter % 2 == 0)
            {
                flagBTN.BackgroundColor = Color.DarkGreen;
            }
            else
            {
                flagBTN.BackgroundColor = Color.Gray;
            }
            flagcounter++;
        }

        private void OpenField(int x , int y)
        {
            for (int a = -1; a < 2; a++)
            {
                for (int b = -1; b < 2; b++)
                {
                    int newlocx = x + a;
                    int newlocy = y + b;
                    if (newlocx >= 0 && newlocx <= 5 && newlocy >= 0 && newlocy <= 5)
                    {
                        if(boardButtons[newlocx,newlocy].BackgroundColor == Color.LightGray && boardButtons[newlocx, newlocy].Text == "")
                        {
                            boardButtons[newlocx, newlocy].BackgroundColor = Color.DarkGreen;
                            int s = int.Parse(score.Text);
                            s++;
                            score.Text = s.ToString();
                            boardButtons[newlocx, newlocy].InputTransparent = true;
                            OpenField(newlocx, newlocy);
                        }
                        else if(boardButtons[newlocx, newlocy].BackgroundColor == Color.LightGray)
                        {
                            for (int i = 0; i < buttonX.Count; i++)
                            {
                                if (boardButtons[newlocx,newlocy].X == buttonX[i] && boardButtons[newlocx,newlocy].Y == buttonY[i])
                                {
                                    boardButtons[newlocx,newlocy].Text = buttonTEXT[i];
                                    break;
                                }
                            }
                            boardButtons[newlocx, newlocy].FontSize = 20;
                            boardButtons[newlocx, newlocy].BackgroundColor = Color.DarkGreen;
                            int s = int.Parse(score.Text);
                            s++;
                            score.Text = s.ToString();
                            boardButtons[newlocx, newlocy].InputTransparent = true;
                        }
                    }
                }
            }
        }
    }
}