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
    /// </summary>
    public partial class SplashWindow : Window
    {

        public SplashWindow()
        {
            InitializeComponent();

            playVoiceGreeting();
        }

        private void playVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("audio/welcome.wav");

                player.Load();
                player.Play();
            }
            catch (Exception)
            {
                MessageBox.Show("Voice greeting could not be played.");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
