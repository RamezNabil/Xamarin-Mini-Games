using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App13
{
    class Class1
    {
        int[,] win = new int[,]
        { {0,1,2},
          {3,4,5},
          {6,7,8},
          {0,3,6},
          {1,4,7},
          {2,5,8},
          {0,4,8},
          {2,4,6}
        };
        public int startingTurn = 0;
        public bool checkWinner(Button[] buttons, Label scorep1, Label scorep2)
        {
            bool gameover = false;
            for (int i = 0; i < 8; i++)
            {
                int a = win[i, 0], b = win[i, 1], c = win[i, 2];
                Button b1 = buttons[a], b2 = buttons[b], b3 = buttons[c];

                if (b1.Text == "" || b2.Text == "" || b3.Text == "")
                    continue;

                if (b1.Text == b2.Text && b2.Text == b3.Text)
                {
                    b1.BackgroundColor = b2.BackgroundColor = b3.BackgroundColor = Color.Aqua;
                    gameover = true;
                    if (startingTurn % 2 == 0)
                    {
                        if (b1.Text == "X")
                        {
                            int s = int.Parse(scorep1.Text);
                            s++;
                            scorep1.Text = s.ToString();
                            ScoreAnimation(scorep1);
                            
                        }
                        else if (b1.Text == "O")
                        {
                            int s = int.Parse(scorep2.Text);
                            s++;
                            scorep2.Text = s.ToString();
                            ScoreAnimation(scorep2);
                        }
                    }
                    else
                    {
                        if (b1.Text == "X")
                        {
                            int s = int.Parse(scorep2.Text);
                            s++;
                            scorep2.Text = s.ToString();
                            ScoreAnimation(scorep2);
                        }
                        else if (b1.Text == "O")
                        {
                            int s = int.Parse(scorep1.Text);
                            s++;
                            scorep1.Text = s.ToString();
                            ScoreAnimation(scorep1);
                        }
                    }
                    startingTurn++;
                    break;
                }
            }
            bool y = true;
            if (!gameover)
            {
                foreach (Button b in buttons)
                {
                    if (b.Text == "")
                    {
                        y = false;
                        break;
                    }
                }
                if (y)
                {
                    gameover = true;
                    startingTurn++;
                }
                return gameover;
            }
            return gameover;
        }



        public void setButton(Button b)
        {
            if (startingTurn % 2 == 0)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
        }

        public void reset(Button[] buts)
        {
            foreach (Button b in buts)
            {
                b.Text = "";
                b.BackgroundColor = Color.Default;
            }
        }

        public void AIplays(Button[] buts)
        {
            while (true)
            {
                Random random = new Random();
                int x = random.Next(9);
                if (buts[x].Text == "")
                {
                    if (startingTurn % 2 == 1) // AI plays X
                    {
                        buts[x].Text = "X";
                    }
                    else  // AI plays O
                    {
                        buts[x].Text = "O";
                    }
                    break;
                }
            }
        }

        public async void ScoreAnimation(Label label)
        {
            label.TextColor = Color.Green;
            label.FontSize = 24;
            await Task.Delay(300);
            label.TextColor = Color.Aqua;
            label.FontSize = 22;
        }
    }
}
