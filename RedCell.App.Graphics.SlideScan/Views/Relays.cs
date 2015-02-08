using System;
using System.Windows.Forms;
using RedCell.Devices;

namespace RedCell.App.Graphics.SlideScan
{
    public partial class Relays : Form
    {
        public Relays()
        {
            InitializeComponent();

            // Initialize controls
            CheckBox[] boxes = { K01, K02, K03, K04, K05, K06, K07, K08, K09, K10, K11, K12, K13, K14, K15, K16, K17, K18, K19, K20, K21, K22, K23, K24, K25, K26, K27, K28, K29, K30, K31, K32};
            RelayNumbers[] relays = { RelayNumbers.K01, RelayNumbers.K02, RelayNumbers.K03, RelayNumbers.K04, RelayNumbers.K05, RelayNumbers.K06, RelayNumbers.K07, RelayNumbers.K08, 
                                        RelayNumbers.K09, RelayNumbers.K10, RelayNumbers.K11, RelayNumbers.K12, RelayNumbers.K13, RelayNumbers.K14, RelayNumbers.K15, RelayNumbers.K16, 
                                        RelayNumbers.K17, RelayNumbers.K18, RelayNumbers.K19, RelayNumbers.K20, RelayNumbers.K21, RelayNumbers.K22, RelayNumbers.K23, RelayNumbers.K24,
                                        RelayNumbers.K25, RelayNumbers.K26, RelayNumbers.K27, RelayNumbers.K28, RelayNumbers.K29, RelayNumbers.K30, RelayNumbers.K31, RelayNumbers.K32 };
            for(int i=0; i<boxes.Length; i++)
            {
                boxes[i].Tag = relays[i];
                boxes[i].CheckedChanged += Relays_CheckedChanged;
            }

            RelayBoard.Initialize();

        }

        void Relays_CheckedChanged(object sender, EventArgs e)
        {
            var box = sender as CheckBox;
            RelayBoard.Set((RelayNumbers)box.Tag, box.Checked ? Relaystate.ON : Relaystate.OFF);
        }
    }
}
