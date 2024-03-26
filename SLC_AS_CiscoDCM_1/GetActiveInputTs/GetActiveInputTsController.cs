using DCM.DeviceControl_package;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Utils.CiscoDCM.Handling;
using Skyline.DataMiner.Utils.InteractiveAutomationScript;
using SLC_AS_CiscoDCM_1.GetInputServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.GetActiveInputTs
{
    public class GetActiveInputTsController : UpdateAll
    {
        private readonly GetActiveInputTsView _getActiveInputTsView;
        private readonly CiscoDcmModel _ciscoDcmModel;

        public GetActiveInputTsController(GetActiveInputTsView getActiveInputTsView, CiscoDcmModel ciscoDcmModel)
        {
            _getActiveInputTsView = getActiveInputTsView;
            _ciscoDcmModel = ciscoDcmModel;

            _getActiveInputTsView.Back.Pressed += Back_Pressed;
            _getActiveInputTsView.GetData.Pressed += GetData_Pressed;
        }

        public event EventHandler<EventArgs> Back;

        private void GetData_Pressed(object sender, EventArgs e)
        {
            GetAllInputTs(_ciscoDcmModel, _getActiveInputTsView);
            List<TSBackup_ActiveTS_t> allActiveTs = new List<TSBackup_ActiveTS_t>();
            Stopwatch sw = Stopwatch.StartNew();
            bool overalSuccess = false;
            foreach (var inputTs in _ciscoDcmModel.AllInputTs)
            {
                var temp = inputTs.RefIn.ToIPS_RefTS_t();
                List<TSBackup_ActiveTS_t> activeTsList = new List<TSBackup_ActiveTS_t>();
                if (Element == null)
                {
                    overalSuccess |= Dcm.GetActiveInputTs(temp, 0, out activeTsList);
                }
                else
                {
                    overalSuccess |= Dcm.GetActiveInputTs(Element, temp, 0, out activeTsList);
                }

                if (activeTsList.Count > 0)
                {
                    allActiveTs.AddRange(activeTsList);
                }
            }

            sw.Stop();
            _getActiveInputTsView.Result.Text = overalSuccess ? "Success" : "Failed";
            _getActiveInputTsView.TimeElapsed.Text = sw.Elapsed.TotalSeconds + " s";
            _getActiveInputTsView.NumberOfActiveInputTs.Text = allActiveTs.Count.ToString();
        }

        private void Back_Pressed(object sender, EventArgs e)
        {
            Back?.Invoke(this, EventArgs.Empty);
        }
    }
}
