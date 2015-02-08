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
    public partial class LiveView : PictureBox
    {
        public ICameraDevice CameraDevice { get; set; }
        private Timer _liveViewTimer = new Timer { Interval = 1000 / 15 };

        public void Initialize()
        {
            _liveViewTimer.Stop();
            _liveViewTimer.Tick += _liveViewTimer_Tick;
            ServiceProvider.Configure();
            if (ServiceProvider.DeviceManager.ConnectToCamera())
            {
                CameraDevice = ServiceProvider.DeviceManager.SelectedCameraDevice;
                CameraDevice.PhotoCaptured += CameraDevice_PhotoCaptured;
                CameraDevice.CameraDisconnected += CameraDevice_CameraDisconnected;
            }
        }

        void CameraDevice_PhotoCaptured(object sender, PhotoCapturedEventArgs e)
        {
            
        }

        public void Capture()
        {
            CameraDevice.CapturePhoto();
        }

        public bool Running
        {
            get
            {
                return _liveViewTimer.Enabled;
            }
        }

        void CameraDevice_CameraDisconnected(object sender, DisconnectCameraEventArgs e)
        {
            MethodInvoker method = _liveViewTimer.Stop;
            if (InvokeRequired)
                BeginInvoke(method);
            else
                method.Invoke();
        }

        void _liveViewTimer_Tick(object sender, EventArgs e)
        {
            GetLiveView();
        }

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

        public async void Start()
        {
            await Task.Run(() => CameraDevice.StartLiveView());
 
            MethodInvoker method = _liveViewTimer.Start;
            if (InvokeRequired)
                BeginInvoke(method);
            else
                method.Invoke();
        }

        public async void Stop()
        {
            _liveViewTimer.Stop();
            await Task.Run(() => CameraDevice.StopLiveView());
        }
    }
}
