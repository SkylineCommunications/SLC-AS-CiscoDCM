using DCM.DeviceControl_package;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Utils.CiscoDCM.Handling;
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
        private readonly IEngine _engine;
        private readonly GetActiveInputTsView _getActiveInputTsView;
        private readonly CiscoDcmModel _ciscoDcmModel;

        public GetActiveInputTsController(IEngine engine, GetActiveInputTsView getActiveInputTsView, CiscoDcmModel ciscoDcmModel)
        {
            _engine = engine;
            _getActiveInputTsView = getActiveInputTsView;
            _ciscoDcmModel = ciscoDcmModel;

            _getActiveInputTsView.Back.Pressed += Back_Pressed;
            _getActiveInputTsView.GetData.Pressed += GetData_Pressed;
        }

        public event EventHandler<EventArgs> GetData;

        public event EventHandler<EventArgs> Back;

        private void GetData_Pressed(object sender, EventArgs e)
        {
            GetAllInputTs(_ciscoDcmModel, _getActiveInputTsView);
            List<TSBackup_ActiveTS_t> allActiveTs = new List<TSBackup_ActiveTS_t>();
            Stopwatch sw = Stopwatch.StartNew();
            _engine.GenerateInformation("Start");
            foreach (var inputTs in _ciscoDcmModel.AllInputTs)
            {
                var temp = inputTs.RefIn.ToIPS_RefTS_t();
                _engine.GenerateInformation("Get Active Input TS " + temp.PhysRef.BoardNr + " " + temp.PhysRef.PortNr + " " + temp.Ref);
                bool success = Dcm.GetActiveInputTs(Element, temp, 0, out List<TSBackup_ActiveTS_t> activeTsList);
                if (!success)
                {
                    _engine.GenerateInformation(temp.PhysRef.BoardNr + " " + temp.PhysRef.PortNr + " " + temp.Ref + " failed.");
                }

                if (activeTsList.Count > 0)
                {
                    allActiveTs.AddRange(activeTsList);
                }
            }

            sw.Stop();
            _getActiveInputTsView.Result.Text = "Success";
            _getActiveInputTsView.TimeElapsed.Text = sw.Elapsed.TotalSeconds + " s";
            _getActiveInputTsView.NumberOfActiveInputTs.Text = allActiveTs.Count.ToString();
        }

        private void Back_Pressed(object sender, EventArgs e)
        {
            Back?.Invoke(this, EventArgs.Empty);
        }
    }
}
