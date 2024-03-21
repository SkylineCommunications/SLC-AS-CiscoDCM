using Skyline.DataMiner.Automation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.GetBoardInfo
{
    public class GetBoardInfoController : UpdateDcmAndElement
    {
        private readonly IEngine _engine;
        private readonly GetBoardInfoView _getBoardInfoView;

        public GetBoardInfoController(IEngine engine, GetBoardInfoView getBoardInfoView)
        {
            _engine = engine;
            _getBoardInfoView = getBoardInfoView;

            _getBoardInfoView.GetData.Pressed += GetData_Pressed;
            _getBoardInfoView.Back.Pressed += Back_Pressed;
        }

        public event EventHandler<List<DCM.DeviceControl_package.BoardInfo_V2_t>> GetData;
        public event EventHandler<EventArgs> Back;

        private void GetData_Pressed(object sender, EventArgs e)
        {
            Stopwatch watch = Stopwatch.StartNew();
            var success = Dcm.GetBoardInfo(Element, out List<DCM.DeviceControl_package.BoardInfo_V2_t> boardInfo);
            watch.Stop();
            if (success)
            {
                _getBoardInfoView.Result.Text = "Success";
                _getBoardInfoView.TimeElapsed.Text = watch.Elapsed.TotalSeconds + " s";
                _getBoardInfoView.AmountOfBoards.Text = boardInfo.Count.ToString();
            }
            else
            {
                _getBoardInfoView.Result.Text = "Failed";
            }

            GetData?.Invoke(this, boardInfo);
        }

        private void Back_Pressed(object sender, EventArgs e)
        {
            Back?.Invoke(this, EventArgs.Empty);
        }
    }
}
