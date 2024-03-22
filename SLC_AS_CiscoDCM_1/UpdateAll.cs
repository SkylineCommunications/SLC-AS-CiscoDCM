using DCM.DeviceControl_package;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Utils.CiscoDCM.Handling;
using SLC_AS_CiscoDCM_1.GetActiveInputTs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1
{
    public abstract class UpdateAll
    {
        public ApiProcessing Dcm;
        public Element Element;
        public string Username;
        public string Password;
        public string Ip;

        public void Update(ApiProcessing dcm, Element element, string username, string password, string ip)
        {
            Dcm = dcm;
            Element = element;
            Username = username;
            Password = password;
            Ip = ip;
        }

        internal void GetBoardInfo(CiscoDcmModel ciscoDcmModel, IView view)
        {
            if (ciscoDcmModel.BoardInfo.Count() == 0)
            {
                var success = Dcm.GetBoardInfo(Element, out List<BoardInfo_V2_t> boardInfo);
                if (!success)
                {
                    view.Result.Text = "Failed";
                    return;
                }

                ciscoDcmModel.BoardInfo = boardInfo;
            }
        }

        internal void GetAllInputTs(CiscoDcmModel ciscoDcmModel, IView view)
        {
            GetBoardInfo(ciscoDcmModel, view);
            if (ciscoDcmModel.AllInputTs.Count() == 0)
            {
                foreach (var board in ciscoDcmModel.BoardInfo)
                {
                    ApiProcessing.DcmHelper.GetInputTSs(Username, Password, Ip, Convert.ToUInt16(board.BoardNumber), out ApiProcessing.DcmHelper.IPS_InputTS_List_t inputTsList);
                    if (inputTsList.IPS_InputTS_t.Length > 0)
                    {
                        ciscoDcmModel.AllInputTs.AddRange(inputTsList.IPS_InputTS_t);
                    }
                }
            }
        }
    }
}
