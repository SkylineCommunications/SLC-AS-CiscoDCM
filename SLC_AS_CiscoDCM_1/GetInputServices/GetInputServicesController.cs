using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Utils.CiscoDCM.Handling;
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
        private readonly GetInputServicesView _getInputServicesView;
        private readonly CiscoDcmModel _ciscoDcmModel;

        public GetInputServicesController(GetInputServicesView getInputServicesView, CiscoDcmModel ciscoDcmModel)
        {
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
            GetBoardInfo(_ciscoDcmModel, _getInputServicesView);

            List<ApiProcessing.DcmHelper.IPS_Service_In_t> allServicesList = new List<ApiProcessing.DcmHelper.IPS_Service_In_t>();
            Stopwatch sw = Stopwatch.StartNew();
            foreach (var board in _ciscoDcmModel.BoardInfo)
            {
                ApiProcessing.DcmHelper.GetInputServices(Username, Password, Ip, Convert.ToUInt16(board.BoardNumber), out ApiProcessing.DcmHelper.IPS_ServiceIn_List_t serviceList);
                if (serviceList == null || serviceList.IPS_Service_In_t == null)
                {
                    continue;
                }

                if (serviceList.IPS_Service_In_t.Length > 0)
                {
                    _ciscoDcmModel.AllInputServices.AddRange(serviceList.IPS_Service_In_t);
                }
            }

            sw.Stop();
            _getInputServicesView.Result.Text = "Success";
            _getInputServicesView.TimeElapsed.Text = sw.Elapsed.TotalSeconds + " s";
            _getInputServicesView.NumberOfInputServices.Text = allServicesList.Count.ToString();
        }

        private void Back_Pressed(object sender, EventArgs e)
        {
            Back?.Invoke(this, EventArgs.Empty);
        }
    }
}
