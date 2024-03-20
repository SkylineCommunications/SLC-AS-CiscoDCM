using Skyline.DataMiner.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.GetBoardInfo
{
    public class GetBoardInfoPresenter : UpdateDcmAndElement
    {
        private readonly IEngine _engine;
        private readonly GetBoardInfoView _getBoardInfoView;

        public GetBoardInfoPresenter(IEngine engine, GetBoardInfoView getBoardInfoView)
        {
            _engine = engine;
            _getBoardInfoView = getBoardInfoView;

            _getBoardInfoView.GetData.Pressed += GetData_Pressed;
        }

        public event EventHandler<EventArgs> GetData;

        private void GetData_Pressed(object sender, EventArgs e)
        {
            _engine.GenerateInformation("State DCM: " + (Dcm == null));
            //_dcm.GetBoardInfo(_element, out List<DCM.DeviceControl_package.BoardInfo_V2_t> boardInfo);
            GetData?.Invoke(this, EventArgs.Empty);
        }
    }
}
