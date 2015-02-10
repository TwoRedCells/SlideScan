using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using RedCell.Devices;

namespace RedCell.App.Graphics.SlideScan
{
    public partial class Test : Form
    {
        private string[] _isos = new string[0];
        private string[] _apertures = new string[0];
        private string[] _shutters = new string[0];
        private string[] _exposures = new string[0];

        public Test()
        {
            InitializeComponent();
            try { RelayBoard.Initialize(); }
            catch (Exception ex)
            {
                SlideProjectorGroupBox.Enabled = false;
            }
            CameraGroupBox.Enabled = true;
            try 
            { 
                Camera.Initialize();
                LiveView.Initialize(Camera.GetDevice());

                //  Configure ISO slider
                _isos = Camera.GetIsos();
                IsoBar.SetRange(0, _isos.Length - 1);
                IsoBar.Scroll += (sender, e) => IsoLabel.Text = _isos[IsoBar.Value];
                string iso = Camera.GetIso();
                if (iso != null)
                {
                    IsoBar.Value = _isos.ToList().IndexOf(iso);
                    IsoLabel.Text = iso;
                }

                // Configure Aperture slider
                _apertures = Camera.GetApertures();
                ApertureBar.SetRange(0, _apertures.Length - 1);
                ApertureBar.Scroll += (sender, e) => ApertureLabel.Text = _apertures[ApertureBar.Value];
                string aperture = Camera.GetAperture();
                if (aperture != null)
                {
                    ApertureBar.Value = _apertures.ToList().IndexOf(aperture);
                    ApertureLabel.Text = aperture;
                }

                // Configure shutter speed
                _shutters = Camera.GetShutterSpeeds();
                ShutterSpeedBar.SetRange(0, _shutters.Length - 1);
                ShutterSpeedBar.Scroll += (sender, e) => ShutterSpeedLabel.Text = _shutters[ShutterSpeedBar.Value];
                string shutter = Camera.GetShutterSpeed();
                if (shutter != null)
                {
                    ShutterSpeedBar.Value = _shutters.ToList().IndexOf(shutter);
                    ShutterSpeedLabel.Text = shutter;
                }

                // Configure exposure
                _exposures = Camera.GetExposureCompensations();
                ExposureCompensationBar.SetRange(0, _exposures.Length - 1);
                ExposureCompensationBar.Scroll += (sender, e) => ExposureCompensationLabel.Text = _exposures[ExposureCompensationBar.Value];
                string exposure = Camera.GetExposureCompensation();
                if (exposure != null)
                {
                    ExposureCompensationBar.Value = _exposures.ToList().IndexOf(exposure);
                    ShutterSpeedLabel.Text = exposure;
                }
            }
            catch (Exception ex)
            {
                CameraGroupBox.Enabled = false;
            }
        }

        private void CaptureButton_Click(object sender, EventArgs e)
        {
            LiveView.Capture();
        }

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            RelayBoard.Set(RelayNumbers.All, Relaystate.OFF);
            RelayBoard.Set(RelayNumbers.K03, Relaystate.ON);
            Thread.Sleep(1000);
            RelayBoard.Set(RelayNumbers.K03, Relaystate.OFF);
        }

        private void ReverseButton_Click(object sender, EventArgs e)
        {
            RelayBoard.Set(RelayNumbers.All, Relaystate.OFF);
            RelayBoard.Set(RelayNumbers.K01 | RelayNumbers.K02, Relaystate.ON);
            RelayBoard.Set(RelayNumbers.K04, Relaystate.ON);
            Thread.Sleep(1000);
            RelayBoard.Set(RelayNumbers.K04, Relaystate.OFF);
        }

        private void LiveViewButton_Click(object sender, EventArgs e)
        {
            if (LiveView.Running)
            {
                LiveView.Stop();
                LiveViewButton.Text = "Live View";
            }
            else
            {
                LiveView.Start();
                LiveViewButton.Text = "Stop";
            }
        }
    }
}
