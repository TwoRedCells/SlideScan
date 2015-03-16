using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
using System.Windows.Threading;
using CameraControl.Devices.Classes;
using CameraControl.Core;
using CameraControl.Core.Classes;
using CameraControl.Devices;

namespace RedCell.App.Graphics.SlideScanWpf
{
    /// <summary>
    /// Interaction logic for LiveView.xaml
    /// </summary>
    public partial class LiveView : UserControl
    {
        public LiveView()
        {
            InitializeComponent();
        }

        private DispatcherTimer _liveViewTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1000 / 15) };

        /// <summary>
        /// Occurs when a photo is captured.
        /// </summary>
        public event PhotoCapturedEventHandler Captured;

        /// <summary>
        /// Occurs when [disconnected].
        /// </summary>
        public event CameraDisconnectedEventHandler Disconnected;

        /// <summary>
        /// Gets or sets the stretch.
        /// </summary>
        /// <value>The stretch.</value>
        public Stretch Stretch
        {
            get { return ImageView.Stretch; }
            set { ImageView.Stretch = value; }
        }

        /// <summary>
        /// Gets or sets the camera device.
        /// </summary>
        /// <value>The camera device.</value>
        public ICameraDevice CameraDevice { get; set; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
        public async Task Initialize()
        {
            await Task.Run(() =>
            {
                ServiceProvider.Configure();
                ServiceProvider.DeviceManager.UseExperimentalDrivers = false;
                if (ServiceProvider.DeviceManager.ConnectToCamera())
                {
                    _liveViewTimer.Stop();
                    _liveViewTimer.Tick += _liveViewTimer_Tick;
                    CameraDevice = ServiceProvider.DeviceManager.SelectedCameraDevice;
                    CameraDevice.PhotoCaptured += CameraDevice_PhotoCaptured;
                    CameraDevice.CameraDisconnected += CameraDevice_CameraDisconnected;
                }
            });
        }

        /// <summary>
        /// Handles the PhotoCaptured event of the CameraDevice control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PhotoCapturedEventArgs"/> instance containing the event data.</param>
        void CameraDevice_PhotoCaptured(object sender, PhotoCapturedEventArgs e)
        {
            try
            {
                e.CameraDevice.IsBusy = true;
                e.Transfer(e.FileName);
                ImageView.Source = new BitmapImage(new Uri(e.FileName));
            }
            finally
            {
                e.CameraDevice.IsBusy = false;
            }

            if (Captured != null)
                Captured(this, e);
        }

        /// <summary>
        /// Captures this instance.
        /// </summary>
        public new void Capture()
        {
            try
            {
                if (Running)
                    Stop();

                CameraDevice.IsBusy = true;
                CameraDevice.CaptureInSdRam = true;
                // prevent use this mode if the camera not support it 
                if (CameraDevice.GetCapability(CapabilityEnum.CaptureInRam))
                    CameraDevice.CaptureInSdRam = false;
                CameraDevice.CapturePhoto();
            }
            finally
            {
                CameraDevice.IsBusy = false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="LiveView"/> is running.
        /// </summary>
        /// <value><c>true</c> if running; otherwise, <c>false</c>.</value>
        public bool Running
        {
            get
            {
                return _liveViewTimer.IsEnabled;
            }
        }

        /// <summary>
        /// Handles the CameraDisconnected event of the CameraDevice control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DisconnectCameraEventArgs"/> instance containing the event data.</param>
        void CameraDevice_CameraDisconnected(object sender, DisconnectCameraEventArgs e)
        {
            Dispatcher.Invoke(_liveViewTimer.Stop);

            if (Disconnected != null)
                Disconnected(this, e);
        }

        /// <summary>
        /// Handles the Tick event of the _liveViewTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void _liveViewTimer_Tick(object sender, EventArgs e)
        {
            GetLiveView();
        }

        /// <summary>
        /// Gets the live view.
        /// </summary>
        public void GetLiveView()
        {
            LiveViewData liveViewData = CameraDevice.GetLiveViewImage();

            if (liveViewData == null || liveViewData.ImageData == null)
                return;

            var image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(liveViewData.ImageData,
                                                            liveViewData.ImageDataPosition,
                                                            liveViewData.ImageData.Length -
                                                            liveViewData.ImageDataPosition);
            image.CacheOption = BitmapCacheOption.OnLoad;
            image.EndInit();
            image.Freeze();
            ImageView.Source = image;
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public async void Start()
        {
            await Task.Run(() => CameraDevice.StartLiveView());
            Dispatcher.Invoke(_liveViewTimer.Start);
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public async void Stop()
        {
            _liveViewTimer.Stop();
            await Task.Run(() => CameraDevice.StopLiveView());
        }
    }
}
