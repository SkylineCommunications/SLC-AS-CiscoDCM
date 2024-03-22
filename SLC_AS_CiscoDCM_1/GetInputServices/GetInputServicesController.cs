using Skyline.DataMiner.Automation;
using SLC_AS_CiscoDCM_1.GetInputTs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.GetInputServices
{
    public class GetInputServicesController : UpdateAll
    {
        private readonly IEngine _engine;
        private readonly GetInputServicesView _getInputServicesView;
        private readonly CiscoDcmModel _ciscoDcmModel;

        public GetInputServicesController(IEngine engine, GetInputServicesView getInputServicesView, CiscoDcmModel ciscoDcmModel)
        {
            _engine = engine;
            _getInputServicesView = getInputServicesView;
            _ciscoDcmModel = ciscoDcmModel;

            _getInputServicesView.Back.Pressed += Back_Pressed;
            _getInputServicesView.GetData.Pressed += GetData_Pressed;
        }

        public event EventHandler<EventArgs> GetData;

        public event EventHandler<EventArgs> Back;

        private void GetData_Pressed(object sender, EventArgs e)
        {
            _ciscoDcmModel.AllInputServices.Clear();
            if (_ciscoDcmModel.BoardInfo == null || _ciscoDcmModel.BoardInfo.Count() == 0)
            {
                var success = Dcm.GetBoardInfo(Element, out List<DCM.DeviceControl_package.BoardInfo_V2_t> boardInfo);
                if (!success)
                {
                    _engine.GenerateInformation("Get Board Info Failed. Element is null: " + (Element == null));
                    _getInputServicesView.Result.Text = "Failed";
                    return;
                }

                _ciscoDcmModel.BoardInfo = boardInfo;
            }

            Stopwatch sw = Stopwatch.StartNew();
            Dcm.GetAllInputServices(Element, Ip, _ciscoDcmModel.BoardInfo.Select(x => Convert.ToString(x.BoardNumber)).ToList(), out Dictionary<string, DCM.DeviceControl_package.IPS_Service_In_t> inputServices);
            sw.Stop();

            _ciscoDcmModel.AllInputServices = inputServices;
            _getInputServicesView.Result.Text = "Success";
            _getInputServicesView.TimeElapsed.Text = sw.Elapsed.TotalSeconds + " s";
            _getInputServicesView.NumberOfInputServices.Text = inputServices.Count.ToString();
        }

        private void Back_Pressed(object sender, EventArgs e)
        {
            Back?.Invoke(this, EventArgs.Empty);
        }
    }
}
