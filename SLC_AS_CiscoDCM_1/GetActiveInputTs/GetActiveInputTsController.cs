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
            GetBoardInfo(_ciscoDcmModel, _getActiveInputTsView);
            /*_ciscoDcmModel.AllInputServices.Clear();
            if (_ciscoDcmModel.BoardInfo.Count() == 0)
            {
                var success = Dcm.GetBoardInfo(Element, out List<BoardInfo_V2_t> boardInfo);
                if (!success)
                {
                    _engine.GenerateInformation("Get Board Info Failed. Element is null: " + (Element == null));
                    _getActiveInputTsView.Result.Text = "Failed";
                    return;
                }

                _ciscoDcmModel.BoardInfo = boardInfo;
            }*/

            /*if (_ciscoDcmModel.AllInputTs == null)

            Stopwatch sw = Stopwatch.StartNew();
            foreach (var inputTs in _ciscoDcmModel.AllInputTs)
            {
                var temp = inputTs.RefIn.ToIPS_RefTS_t();
                Dcm.GetActiveInputTs(Element, temp, 1000, out List<DCM.DeviceControl_package.TSBackup_ActiveTS_t> activeTsList);
            }

            Dcm.GetAllInputServices(Element, Ip, _ciscoDcmModel.BoardInfo.Select(x => Convert.ToString(x.BoardNumber)).ToList(), out Dictionary<string, DCM.DeviceControl_package.IPS_Service_In_t> inputServices);
            sw.Stop();

            _ciscoDcmModel.AllInputServices = inputServices;
            _getActiveInputTsView.Result.Text = "Success";
            _getActiveInputTsView.TimeElapsed.Text = sw.Elapsed.TotalSeconds + " s";
            _getActiveInputTsView.NumberOfInputServices.Text = inputServices.Count.ToString();*/
        }

        private void Back_Pressed(object sender, EventArgs e)
        {
            Back?.Invoke(this, EventArgs.Empty);
        }
    }
}
