using System.Windows.Forms;

namespace RedCell.App.Graphics.SlideScan
{
    internal partial class SettingsView : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingsView"/> class.
        /// </summary>
        public SettingsView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the settings data.
        /// </summary>
        /// <value>The settings data.</value>
        public object SettingsData
        {
            get { return propertyGrid1.SelectedObject; }
            set { propertyGrid1.SelectedObject = value; }
        }
    }
}
