using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedCell.Devices;

namespace RedCell.App.Graphics.SlideScan
{
    public class Projector
    {
        private System.Windows.Forms.Timer _timer;
        private bool _lampWasOn = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Projector"/> class.
        /// </summary>
        public Projector()
        {
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns>Task.</returns>
        public async Task Initialize()
        {
            _timer =  new System.Windows.Forms.Timer();
            _timer.Tick += Timer_Elapsed;
            _timer.Interval = 90000;
            await RelayBoard.InitializeAsync();
        }

        /// <summary>
        /// Handles the Elapsed event of the Timer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        async void Timer_Elapsed(object sender, EventArgs e)
        {
            await FanOff(true);
            _timer.Stop();
            _lampWasOn = false;
        }

        public async Task Forward()
        {
            await Task.Run(() =>
                {
                    RelayBoard.Set(RelayNumbers.K01 | RelayNumbers.K02 | RelayNumbers.K04, Relaystate.OFF); // clear all
                    Thread.Sleep(50);
                    RelayBoard.Set(RelayNumbers.K03, Relaystate.ON); // Set direction
                    Thread.Sleep(500);
                    RelayBoard.Set(RelayNumbers.K03, Relaystate.OFF);
                });
        }

        public async Task Reverse()
        {
            await Task.Run(() =>
                {
                    RelayBoard.Set(RelayNumbers.K03, Relaystate.OFF); // clear all
                    Thread.Sleep(20);
                    RelayBoard.Set(RelayNumbers.K01 | RelayNumbers.K02, Relaystate.ON); // Set direction
                    Thread.Sleep(20);
                    RelayBoard.Set(RelayNumbers.K04, Relaystate.ON); // Set direction
                    Thread.Sleep(500);
                    RelayBoard.Set(RelayNumbers.K04, Relaystate.OFF); // clear all
                });
        }

        public async Task FanOn()
        {
            await Task.Run(() =>
            {
                RelayBoard.Set(RelayNumbers.K05, Relaystate.ON);
            });
        }

        public async Task Load()
        {
            await Task.Run(() => RelayBoard.Set(RelayNumbers.K07 | RelayNumbers.K08, Relaystate.OFF));
        }

        public async Task Unload()
        {
            await Task.Run(() => RelayBoard.Set(RelayNumbers.K07 | RelayNumbers.K08, Relaystate.ON));
        }

        public async Task FanOff(bool force = false)
        {
            await Task.Run(() =>
                {
                    if (_lampWasOn && !force)
                        _timer.Start();
                    else
                        RelayBoard.Set(RelayNumbers.K05, Relaystate.OFF);
                });
        }

        public async Task LampOn()
        {
            await FanOn();
            await Task.Run(() =>
                {
                    RelayBoard.Set(RelayNumbers.K06, Relaystate.ON);
                    _lampWasOn = true;
                });
        }

        public async Task LampOff()
        {
            await Task.Run(() =>
            {
                RelayBoard.Set(RelayNumbers.K06, Relaystate.OFF);
                _timer.Start();
            });
        }

    }
}
