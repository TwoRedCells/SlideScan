using System;
using System.IO;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RedCell.App.Graphics.SlideScan
{
    internal static class Globals
    {
        #region Initialization
        static Globals()
        {
            Projector = new Projector();
        }

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

        /// <summary>
        /// Gets the projector.
        /// </summary>
        /// <value>The projector.</value>
        public static Projector Projector { get; private set; }
        #endregion
    }
}
