using System.Diagnostics;
using System.Security.RightsManagement;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string currentPlayer = "X";
        public string[] board = new string[9];
        public string gameOver = " ";
        public bool versusComputer = false;
        public Button[] buttons = new Button[9];
        

        public MainWindow()
        {
            InitializeComponent();
            buttons = [btn0,btn1,btn2,btn3,btn4,btn5,btn6,btn7,btn8];
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = "\0";   
            }
            btn0.Content = " ";
            btn1.Content = " ";
            btn2.Content = " ";
            btn3.Content = " ";
            btn4.Content = " ";
            btn5.Content = " ";
            btn6.Content = " ";
            btn7.Content = " ";
            btn8.Content = " ";

            btn0.IsEnabled = true;
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            btn5.IsEnabled = true;
            btn6.IsEnabled = true;
            btn7.IsEnabled = true;
            btn8.IsEnabled = true;

            vsComputer.IsEnabled = true;
            versusComputer = false;


            turnIndincator.Text = currentPlayer + "'s turn";
        }

        private void invertButons()
        {
            btn0.IsEnabled = !btn0.IsEnabled;
            btn1.IsEnabled = !btn1.IsEnabled;
            btn2.IsEnabled = !btn2.IsEnabled;
            btn3.IsEnabled = !btn3.IsEnabled;
            btn4.IsEnabled = !btn4.IsEnabled;
            btn5.IsEnabled = !btn5.IsEnabled;
            btn6.IsEnabled = !btn6.IsEnabled;
            btn7.IsEnabled = !btn7.IsEnabled;
            btn8.IsEnabled = !btn8.IsEnabled;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.Content = currentPlayer;
            btn.IsEnabled = false;

            int btnNum = Convert.ToInt16(btn.Tag);

            board[btnNum] = currentPlayer;
            for (int i = 0; i < 9; i++)
            {
                Debug.WriteLine(board[i]);
            }
            
            changeTurn();

            if (versusComputer)
            {
                computerTurn();
                changeTurn ();
            }

            checkwin();

            if (checkwin())
            {

                win();
                if (currentPlayer == "X")
                {
                    if (versusComputer)
                    {
                        turnIndincator.Text = "Computer Wins!";
                    }
                    else
                    {
                        turnIndincator.Text = playerO.Text + " Wins!";
                    }
                    win();
                }
                else
                {

                    turnIndincator.Text = playerX.Text + " Wins!";
                    win();
                }
            }else if (checkDraw())
            {
                turnIndincator.Text = "draw";
                win();
            }
            
        }

        public bool checkDraw()
        {
            changeTurn();
            int count  = 0;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == currentPlayer){
                    count++;
                }
            }

            changeTurn();
            return count == 8;
        }
        private void win()
        {
            btn0.IsEnabled = false;
            btn1.IsEnabled = false;
            btn2.IsEnabled = false;
            btn3.IsEnabled = false;
            btn4.IsEnabled = false;
            btn5.IsEnabled = false;
            btn6.IsEnabled = false;
            btn7.IsEnabled = false;
            btn8.IsEnabled = false;


        }


        private void changeTurn()
        {
            string playerName;

            if (currentPlayer == "X")
            {
                currentPlayer = "O";
                if (versusComputer)
                {
                    playerName = "Computer";
                }
                else
                {
                    playerName = playerO.Text;
                }
                
            }
            else
            {
                currentPlayer = "X";
                playerName = playerX.Text;

            }
            turnIndincator.Text = playerName + "'s turn";
        }

        public bool checkwin()
        {
            changeTurn();
            int count = 0;

            for (int i = 0; i < 9; i+=3)
            {
                if (board[i] == currentPlayer && board[i+1] == currentPlayer && board[i+2] == currentPlayer){
                    changeTurn();
                    return true;
                }
            }


            for(int i = 0; i < 3; i++)
            {
                if (board[i] == currentPlayer && board[i+3] == currentPlayer && board[i+6] == currentPlayer)
                {
                    changeTurn();
                    return true;
                }
            }

            if (board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer)
            {
                changeTurn();
                return true;
            }

            if (board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer)
            {
                changeTurn();
                return true;
            }

            for (int i = 0; i < 9; i++)
            {
                if (board[i] == "\0")
                {
                    count++;
                }
            }

            if (count == 8)
            {
                return false;
            }
            changeTurn();
            return false;


        }

        private void vsComputer_Click(object sender, RoutedEventArgs e)
        {
            resetButton_Click(sender, e);
            vsComputer.IsEnabled = false;
            versusComputer = true;


        }

        private void computerTurn()
        {
            invertButons();
            Random random = new Random();
            while (true)
            {
                int pos = random.Next(0, 9);

                if (board[pos] == " ")
                {
                    buttons[pos].Content = currentPlayer;
                    invertButons();
                    break;
                }
                else
                {
                    continue;
                }

            }

            
        }
    }
}