using CameraControl.Devices.Classes;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using CameraControl.Core;
using CameraControl.Core.Classes;
using CameraControl.Devices;

namespace CameraControl.Devices.Example
{
    /// <summary>
    /// Class LiveView.
    /// </summary>
    public partial class LiveView : PictureBox
    {
        private Timer _liveViewTimer = new Timer { Interval = 1000 / 15 };

        /// <summary>
        /// Gets or sets the camera device.
        /// </summary>
        /// <value>The camera device.</value>
        public ICameraDevice CameraDevice { get;  set; }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
        public bool Initialize()
        {
            ServiceProvider.Configure();
            ServiceProvider.DeviceManager.UseExperimentalDrivers = false; // canon
            if (ServiceProvider.DeviceManager.ConnectToCamera())
            {
                CameraDevice = ServiceProvider.DeviceManager.SelectedCameraDevice;
                Initialize(CameraDevice);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Initializes the specified device.
        /// </summary>
        /// <param name="device">The device.</param>
        public void Initialize(ICameraDevice device)
        {
            _liveViewTimer.Stop();
            _liveViewTimer.Tick += _liveViewTimer_Tick;
            CameraDevice = device;
            CameraDevice.PhotoCaptured += CameraDevice_PhotoCaptured;
            CameraDevice.CameraDisconnected += CameraDevice_CameraDisconnected;
        }

        /// <summary>
        /// Handles the PhotoCaptured event of the CameraDevice control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PhotoCapturedEventArgs"/> instance containing the event data.</param>
        void CameraDevice_PhotoCaptured(object sender, PhotoCapturedEventArgs e)
        {
        }

        /// <summary>
        /// Captures this instance.
        /// </summary>
        public void Capture()
        {
            CameraDevice.CapturePhoto();
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="LiveView"/> is running.
        /// </summary>
        /// <value><c>true</c> if running; otherwise, <c>false</c>.</value>
        public bool Running
        {
            get
            {
                return _liveViewTimer.Enabled;
            }
        }

        /// <summary>
        /// Handles the CameraDisconnected event of the CameraDevice control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DisconnectCameraEventArgs"/> instance containing the event data.</param>
        void CameraDevice_CameraDisconnected(object sender, DisconnectCameraEventArgs e)
        {
            MethodInvoker method = _liveViewTimer.Stop;
            if (InvokeRequired)
                BeginInvoke(method);
            else
                method.Invoke();
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

            Image = new Bitmap(new MemoryStream(liveViewData.ImageData,
                                                            liveViewData.ImageDataPosition,
                                                            liveViewData.ImageData.Length -
                                                            liveViewData.ImageDataPosition));
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public async void Start()
        {
            await Task.Run(() => CameraDevice.StartLiveView());
 
            MethodInvoker method = _liveViewTimer.Start;
            if (InvokeRequired)
                BeginInvoke(method);
            else
                method.Invoke();
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
