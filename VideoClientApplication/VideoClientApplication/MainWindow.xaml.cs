using System;
using System.Collections.Generic;
using System.IO;
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

namespace VideoClientApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool myVideoIsPlaying = false;
        bool myVideoLoaded = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                myVideoLoaded = false;

                // Open document
                string filename = dlg.FileName;

                FileInfo videoFile = new FileInfo(dlg.FileName);

                if (videoFile.Exists)
                {
                    myMediaElement.Source = new Uri(videoFile.FullName);

                    myVideoLoaded = true;
                }
                    
            }
        }

        private void Element_MediaOpened(object sender, EventArgs e)
        {

        }

        private void Element_MediaEnded(object sender, EventArgs e)
        {
            myMediaElement.Stop();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (myVideoLoaded)
            {
                if (myVideoIsPlaying)
                {
                    myMediaElement.Stop();
                    myPlayStopButton.Content = "Play";
                }
                else
                {
                    myMediaElement.Play();
                    myPlayStopButton.Content = "Stop";
                }

                myVideoIsPlaying = !myVideoIsPlaying;
            }
        }
    }
}
