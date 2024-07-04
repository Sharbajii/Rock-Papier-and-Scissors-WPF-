using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Frist_WPF_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private enum GameOption
        {
            Rock,
            Paper,
            Scissors
        }

        private readonly Random random;
        private readonly GameOption[] options;
        private int playerWins;
        private int computerWins;
        private int pcTieHuman;

        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
            options = new GameOption[] { GameOption.Rock, GameOption.Paper, GameOption.Scissors };
            playerWins = 0;
            computerWins = 0;
            pcTieHuman = 0;
        }

        

        private GameOption GetOptionFromButton(Button button)
        {
            switch (button.Content.ToString().ToLower())
            {
                case "rock":
                    return GameOption.Rock;
                case "paper":
                    return GameOption.Paper;
                case "scissors":
                    return GameOption.Scissors;
                default:
                    throw new ArgumentException("Invalid option.");
            }
        }

        private GameOption GetRandomOption()
        {
            return options[random.Next(options.Length)];
        }

        private void DetermineWinner(GameOption userOption, GameOption computerOption)
        {
            if (userOption == computerOption)
            {
                ResultText.Text = "It's a tie!";
                pcTieHuman++;
            }
            else if ((userOption == GameOption.Rock && computerOption == GameOption.Scissors)
                || (userOption == GameOption.Paper && computerOption == GameOption.Rock)
                || (userOption == GameOption.Scissors && computerOption == GameOption.Paper))
            {
                ResultText.Text = "You win!";
                playerWins++;
            }
            else
            {
                ResultText.Text = "Computer wins!";
                computerWins++;
            }
        }

        private void UpdateWinCount()
        {
            PlayerWinsText.Text = $"Player Wins: {playerWins}";
            ComputerWinsText.Text = $"PC Wins: {computerWins}";
            pcTieHumanText.Text = $"Tie: {pcTieHuman}";


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userOption = GetOptionFromButton((Button)sender);
            var computerOption = GetRandomOption();

            DetermineWinner(userOption, computerOption);
            UpdateWinCount();
        }
    }
}

