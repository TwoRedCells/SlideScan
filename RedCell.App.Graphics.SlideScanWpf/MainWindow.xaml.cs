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
using RedCell.Devices;

namespace RedCell.App.Graphics.SlideScan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.FrameworkElement.Initialized" /> event. This method is invoked whenever <see cref="P:System.Windows.FrameworkElement.IsInitialized" /> is set to true internally.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.RoutedEventArgs" /> that contains the event data.</param>
        protected async override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            try
            {
                Globals.Initialize();
                await Globals.Projector.Initialize();
            }
            catch(RelayBoardException)
            {
                LampToggleButton.IsEnabled = false;
                FanToggleButton.IsEnabled = false;
                LoadButton.IsEnabled = false;
            }

            try
            {
                await LiveView.Initialize();
            }
            catch(Exception)
            {

            }
        }

        /// <summary>
        /// Handles the Click event of the LampToggleButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void LampToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (LampToggleButton.IsChecked == true)
            {
                await Globals.Projector.LampOn();
                FanToggleButton.IsChecked = true;
            }
            else
                await Globals.Projector.LampOff();
        }

        /// <summary>
        /// Handles the Click event of the FanToggleButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void FanToggleButton_Click(object sender, RoutedEventArgs e)
        {
            if (FanToggleButton.IsChecked == true)
                await Globals.Projector.FanOn();
            else
                await Globals.Projector.FanOff();
        }

        /// <summary>
        /// Handles the Click event of the ResetRelaysButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void ResetRelaysButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await RelayBoard.InitializeAsync(true);
            }
            catch (RelayBoardException)
            {
                LampToggleButton.IsEnabled = false;
                FanToggleButton.IsEnabled = false;
                LoadButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Handles the Click event of the ResetCameraButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void ResetCameraButton_Click(object sender, RoutedEventArgs e)
        {
            await Camera.Initialize();
        }

        private async void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (FanToggleButton.IsChecked == true)
                await Globals.Projector.Load();
            else
                await Globals.Projector.Unload();
        }

        /// <summary>
        /// Handles the Click event of the LiveViewButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void LiveViewButton_Click(object sender, RoutedEventArgs e)
        {
            LiveView.Stretch = Stretch.Uniform;

            if (LiveViewButton.IsChecked == true)
            {
                LiveView.Start();
                FocusButton.IsChecked = false;
            }
            else
                LiveView.Stop();
        }

        private async void FocusButton_Checked(object sender, RoutedEventArgs e)
        {
            LiveView.Stretch = Stretch.None;

            if (FocusButton.IsChecked == true)
            {
                LiveView.Start();
                LiveViewButton.IsChecked = false;
            }
            else
                LiveView.Stop();
        }

        /// <summary>
        /// Handles the Checked event of the PreviousButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            await Globals.Projector.Forward();
        }

        /// <summary>
        /// Handles the Checked event of the NextButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void NextButton_Click(object sender, RoutedEventArgs e)
        {
            await Globals.Projector.Reverse();
        }

        /// <summary>
        /// Handles the Checked event of the LoadButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void LoadButton_Checked(object sender, RoutedEventArgs e)
        {
            if (LoadButton.IsChecked == true)
                await Globals.Projector.Load();
            else
                await Globals.Projector.Load();
        }

        private void SingleCaptureButton_Click(object sender, RoutedEventArgs e)
        {
            LiveView.Capture();
        }


    }
}
