using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234238

namespace Guess_The_Number
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        int numberToGuess;
        int attemptsNumber;
        int writtenNumber;

        TextBlock description;
        TextBlock attempts;
        TextBox numberWritten;

        public Game()
        {
            this.InitializeComponent();
            SetControls();
        }

        public void SetControls()
        {
            description = this.FindName("descriptionX") as TextBlock;
            attempts = this.FindName("attemptsX") as TextBlock;
            numberWritten = this.FindName("numberWrittenX") as TextBox;
            attemptsNumber = 0;
            writtenNumber = -1;
            Random random = new Random();
            numberToGuess = random.Next(0, 100);
        }

        private void Verify(object sender, RoutedEventArgs e)
        {
            if (numberWritten.Text == "") {
                numberWritten.Text = "Write here your solution";
                return;
            }

            else
            {
                try {
                    if (Convert.ToInt32(numberWritten.Text) == numberToGuess)
                        Finish();                    
                    if (Convert.ToInt32(numberWritten.Text) < numberToGuess)
                        description.Text = "the number to guess is bigger";
                    if (Convert.ToInt32(numberWritten.Text) > numberToGuess)
                        description.Text = "the number to guess is smaller";
                    Modify();
                }
                catch { }
                
            }
           
        }

        public void Modify()
        {
            attemptsNumber++;
            attempts.Text = "ATTEMPTS: " + attemptsNumber.ToString();
        }

        public void Finish()
        {
            description.Text = "YOU GUESSED THE NUMBER\nWITH " + attemptsNumber.ToString() + " ATTEMPTS";
            description.FontWeight = FontWeights.Medium;
            numberWritten.IsEnabled = false;
        }

    }
}
