using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RedCell.App.Graphics.SlideScan
{
    internal static class Globals
    {
        #region Initialization
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public static void Initialize()
        {
            Settings = new Settings();
            try
            {
                var xml = XDocument.Load("settings.xml");
                Settings.Deserialize(xml);
            }
            catch (FileNotFoundException)
            {
                // Do nothing. It doesn't exist yet.
                var xml = Settings.Serialize();
                xml.Save("settings.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load settings: " + ex);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the settings.
        /// </summary>
        /// <value>The settings.</value>
        public static Settings Settings { get; private set; }
        #endregion
    }
}
