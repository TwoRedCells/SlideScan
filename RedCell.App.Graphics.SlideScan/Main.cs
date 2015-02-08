using System;
using System.Windows.Forms;

namespace RedCell.App.Graphics.SlideScan
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Globals.Initialize();
        }

        #region Menu Event Handlers
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
            var form = new SetView();
            Tabby.TabPages.Add(form);

        }

        private void FileOpenMenu_Click(object sender, EventArgs e)
        {

        }

        private void FileSaveMenu_Click(object sender, EventArgs e)
        {

        }

        private void EditEditImageMenu_Click(object sender, EventArgs e)
        {

        }

        private void EditSelectAllMenu_Click(object sender, EventArgs e)
        {

        }

        private void EditCopyMenu_Click(object sender, EventArgs e)
        {

        }

        private void EditCutMenu_Click(object sender, EventArgs e)
        {

        }

        private void EditPasteMenu_Click(object sender, EventArgs e)
        {

        }

        private void EditDeleteMenu_Click(object sender, EventArgs e)
        {

        }

        private void ToolsTestMenu_Click(object sender, EventArgs e)
        {
            var form = new Test();
            Tabby.TabPages.Add(form);
        }

        private void ToolsScanMenu_Click(object sender, EventArgs e)
        {

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

        private void AboutMenu_Click(object sender, EventArgs e)
        {

        }

        private void RelaysMenu_Click(object sender, EventArgs e)
        {
            var form = new Relays();
            Tabby.TabPages.Add(form);
        }
        #endregion
    }
}
