using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using RedCell.Devices;

namespace RedCell.App.Graphics.SlideScan
{
    /// <summary>
    /// Class ScanView.
    /// </summary>
    public partial class ScanView : Form
    {
        private volatile bool _stop;
        private Projector _projector;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScanView"/> class.
        /// </summary>
        public ScanView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Shown" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected async override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Set = new Set();
            FilesGrid.DataSource = Set;

            try
            {
                Camera.Initialize();
                CameraLabel.BackColor = Color.Green;
                LiveView.CameraDevice = Camera.GetDevice();
                LiveView.Initialize();
            }
            catch
            {
                CameraLabel.BackColor = Color.Red;
            }

            try
            {
                _projector = new Projector();
                await _projector.Initialize();
                ProjectorLabel.BackColor = Color.Green;
            }
            catch
            {
                ProjectorLabel.BackColor = Color.Red;
            }
        }

        /// <summary>
        /// Gets or sets the set.
        /// </summary>
        /// <value>The set.</value>
        public Set Set { get; set; }

        private int CurrentIndex
        {
            get { return int.Parse(CurrentSlide.Text); }
            set { CurrentSlide.Text = value.ToString(); }
        }

        /// <summary>
        /// Handles the Validated event of the SetName control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SetName_Validated(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(SetName.Text))
                return;

            Set.Name = SetName.Text;
            Text = Set.Name;
            SetName.ReadOnly = true;
        }

        /// <summary>
        /// Handles the Validated event of the Operator control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Operator_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Operator.Text))
                return;

            Set.Operator = Operator.Text;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void SaveSet()
        {
            string name = Set.Name + ".set";
            var xml = Set.Serialize();
            xml.Save(name);
        }

        /// <summary>
        /// Loads the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        public void LoadSet(string name)
        {
            var xml = XDocument.Load(name);
            Set.Deserialize(xml);
            FilesGrid.DataSource = Set.Filenames;
        }

        /// <summary>
        /// Handles the Click event of the BackButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void BackButton_Click(object sender, EventArgs e)
        {
            await _projector.Reverse();
            CurrentIndex--;
        }

        /// <summary>
        /// Handles the Click event of the ForwardButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void ForwardButton_Click(object sender, EventArgs e)
        {
            await _projector.Forward();
            CurrentIndex++;
        }

        /// <summary>
        /// Handles the Click event of the ManualButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ManualButton_Click(object sender, EventArgs e)
        {
            Camera.Filename = string.Format("{0}_{1:0000}.jpg", Set.Name, CurrentIndex);
            Camera.Capture();
        }

        /// <summary>
        /// Handles the Click event of the AutomaticButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void AutomaticButton_Click(object sender, EventArgs e)
        {
            ManualButton.Enabled = false;
            AutomaticButton.Enabled = false;
            AutomaticButton.Checked = true;
            StopButton.Enabled = true;

            for (int i = 0; i < int.Parse(CarouselSize.Text); i++)
            {
                if (_stop)
                {
                    _stop = false;
                    await _projector.LampOff();
                    await _projector.FanOff();
                    break;
                }

                Camera.Filename = string.Format("{0}_{1:0000}.jpg", Set.Name, CurrentIndex);
                await Camera.CaptureAsync();
                if (BackwardsButton.Checked)
                    await _projector.Reverse();
                else
                    await _projector.Forward();
                Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Handles the Click event of the StopButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void StopButton_Click(object sender, EventArgs e)
        {
            ManualButton.Enabled = true;
            StopButton.Enabled = false;
            AutomaticButton.Enabled = true;
            AutomaticButton.Checked = false;
            _stop = true;
        }

        private async void LampButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void LoadButton_Click(object sender, EventArgs e)
        {
            if (LoadButton.Checked)
                await _projector.Unload();
            else
                await _projector.Load();
        }

        private async void LampButton_Click_1(object sender, EventArgs e)
        {
            if (LampButton.Checked)
                await _projector.LampOn();
            else
            {
                await _projector.LampOff();
                await _projector.FanOff();
            }
        }

        private void CurrentSlide_Validated(object sender, EventArgs e)
        {
        }

        private void CurrentSlide_Validating(object sender, CancelEventArgs e)
        {
            int value;
            if (!int.TryParse(CurrentSlide.Text, out value))
                CurrentSlide.Text = "0";
        }

        private void ManualButton_Click_1(object sender, EventArgs e)
        {
            Camera.Capture();
        }

        private void LiveViewButton_Click(object sender, EventArgs e)
        {
            LiveView.Start();
        }
    }
}
