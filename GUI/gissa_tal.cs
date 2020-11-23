using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace random_tal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int randomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        static class gameSession
        {
            public static int attempts = 0;
            public static int number = randomNumber(0, 100);
            public static bool finished = false;
        }

        private void makeGuess(int guess)
        {
            gameSession.attempts++;

            if (guess == gameSession.number)
            {
                outputBox.Text = guess + " är Rätt svar!\n" + "Det tog dig " + gameSession.attempts + " gissningar.";
                // Avsluta spelet, visa replay button
                gameSession.finished = true;
                replayButton.Visible = true;
            }
            else if (guess > gameSession.number)
            {
                outputBox.Text = guess + " är för stort!";
            }
            else if (guess < gameSession.number)
            {
                outputBox.Text = guess + " är för litet!";
            }

        }

        private void guessButton_Click(object sender, EventArgs e)
        {

            if (gameSession.finished)
            {
                return;
            }

            int guess;
            bool validNumber = Int32.TryParse(inputBox.Text, out guess);

            if (!validNumber)
            {
                outputBox.Text = "Ogiltig gissning, försök igen!";
            }
            else if (validNumber)
            {
                makeGuess(guess);
            }
        }

        private void replayButton_Click(object sender, EventArgs e)
        {
            // Starta om spelet
            gameSession.attempts = 0;
            gameSession.number = randomNumber(0, 100);
            gameSession.finished = false;

            // Rensa input & output boxes
            inputBox.Clear();
            outputBox.Clear();

            // Göm replay button
            replayButton.Visible = false;
        }
    }
}
