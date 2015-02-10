using System;
using System.Windows.Forms;

namespace RedCell.App.Graphics.SlideScan
{
    /// <summary>
    /// Class Main.
    /// </summary>
    public partial class Main : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
            Globals.Initialize();
        }

        #region Menu Event Handlers
        /// <summary>
        /// Handles the Click event of the FileExitMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FileExitMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the FileNewMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FileNewMenu_Click(object sender, EventArgs e)
        {
            var form = new ScanView();
            Tabby.TabPages.Add(form);
        }

        /// <summary>
        /// Handles the Click event of the FileOpenMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FileOpenMenu_Click(object sender, EventArgs e)
        {
            var di = new OpenFileDialog();
            di.DefaultExt = ".set";
            if(di.ShowDialog() == DialogResult.OK)
            {
                var form = new ScanView();
                form.LoadSet(di.FileName);
                Tabby.TabPages.Add(form);
            }
        }

        /// <summary>
        /// Handles the Click event of the FileSaveMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void FileSaveMenu_Click(object sender, EventArgs e)
        {
            var form = Tabby.TabPages.SelectedTab().Form;
            if (form is ScanView)
                (form as ScanView).SaveSet();
        }

        /// <summary>
        /// Handles the Click event of the EditEditImageMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EditEditImageMenu_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the EditSelectAllMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EditSelectAllMenu_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the EditCopyMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EditCopyMenu_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the EditCutMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EditCutMenu_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the EditPasteMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EditPasteMenu_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the EditDeleteMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EditDeleteMenu_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the ToolsTestMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolsTestMenu_Click(object sender, EventArgs e)
        {
            var form = new Test();
            Tabby.TabPages.Add(form);
        }

        /// <summary>
        /// Handles the Click event of the ToolsScanMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolsScanMenu_Click(object sender, EventArgs e)
        {
            var form = new ScanView();
        }

        /// <summary>
        /// Handles the Click event of the ToolsOptionsMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ToolsOptionsMenu_Click(object sender, EventArgs e)
        {
            var form = new SettingsView();
            form.SettingsData = Globals.Settings;
            form.FormClosing += (fs, fe) =>
            {
                var xml = Globals.Settings.Serialize();
                xml.Save("settings.xml");
            };
            Tabby.TabPages.Add(form);
        }

        /// <summary>
        /// Handles the Click event of the AboutMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void AboutMenu_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the RelaysMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void RelaysMenu_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new Relays();
                Tabby.TabPages.Add(form);
            } 
            catch(TypeLoadException)
            {
                MessageBox.Show("Unable to initialize relay board.\r\nIt looks like FTD2XX_NET.DLL is missing.", "TypeLoadException", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TypeInitializationException)
            {
                MessageBox.Show("Unable to initialize relay board.\r\nDid you install the FTDI driver?\r\nhttp://www.ftdichip.com/Drivers/D2XX.htm", "TypeInitializationException", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
