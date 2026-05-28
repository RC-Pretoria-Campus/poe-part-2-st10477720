using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Prog_Poe_Part2
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// This window acts as the startup screen for the chatbot application.
    /// </summary>
    public partial class SplashWindow : Window
    {
        // Constructor for the splash screen window
        public SplashWindow()
        {
            InitializeComponent();
            
         // Plays the welcome voice greeting when the splash screen opens
            playVoiceGreeting();
        }

        // Plays the welcome audio file for the chatbot.
        private void playVoiceGreeting()
        {
            try
            {
                // Create a SoundPlayer object and load the audio file
                SoundPlayer player = new SoundPlayer("audio/welcome.wav");

                player.Load();
                player.Play();
            }
            catch (Exception)
            {
                MessageBox.Show("Voice greeting could not be played.");
            }
        }

        // Opens the main chatbot window when the user clicks the splash screen.
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Create and display the main application window
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
