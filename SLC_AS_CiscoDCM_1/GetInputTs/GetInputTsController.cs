using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Utils.CiscoDCM.Handling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.GetInputTs
{
    public class GetInputTsController : UpdateAll
    {
        private readonly IEngine _engine;
        private readonly GetInputTsView _getInputTsView;
        private readonly CiscoDcmModel _ciscoDcmModel;

        public GetInputTsController(IEngine engine, GetInputTsView getInputTsView, CiscoDcmModel model)
        {
            _engine = engine;
            _getInputTsView = getInputTsView;
            _ciscoDcmModel = model;

            _getInputTsView.Back.Pressed += Back_Pressed;
            _getInputTsView.GetData.Pressed += GetData_Pressed;
        }

        public event EventHandler<EventArgs> GetData;

        public event EventHandler<EventArgs> Back;

        private void GetData_Pressed(object sender, EventArgs e)
        {
            _ciscoDcmModel.AllInputTs.Clear();
            if (_ciscoDcmModel.BoardInfo == null || _ciscoDcmModel.BoardInfo.Count() == 0)
            {
                var success = Dcm.GetBoardInfo(Element, out List<DCM.DeviceControl_package.BoardInfo_V2_t> boardInfo);
                if (!success)
                {
                    _engine.GenerateInformation("Get Board Info Failed. Element is null: " + (Element == null));
                    _getInputTsView.Result.Text = "Failed";
                    return;
                }

                _ciscoDcmModel.BoardInfo = boardInfo;
            }

            Stopwatch sw = Stopwatch.StartNew();
            foreach (var board in _ciscoDcmModel.BoardInfo)
            {
                ApiProcessing.DcmHelper.GetInputTSs(Username, Password, Ip, Convert.ToUInt16(board.BoardNumber), out ApiProcessing.DcmHelper.IPS_InputTS_List_t inputTsList);
                if (inputTsList.IPS_InputTS_t.Length > 0)
                {
                    _ciscoDcmModel.AllInputTs.AddRange(inputTsList.IPS_InputTS_t);
                }
            }

            sw.Stop();
            _getInputTsView.Result.Text = "Success";
            _getInputTsView.TimeElapsed.Text = sw.Elapsed.TotalSeconds + " s";
            _getInputTsView.NumberOfInputTs.Text = _ciscoDcmModel.AllInputTs.Count.ToString();
            GetData?.Invoke(this, EventArgs.Empty);
        }

        private void Back_Pressed(object sender, EventArgs e)
        {
            Back?.Invoke(this, EventArgs.Empty);
        }
    }
}
