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
        private ApiProcessing _dcm;
        private Element _element;
        private string _username;
        private string _password;
        private string _ip;

        public ApiProcessing Dcm
        {
            get
            {
                return _dcm;
            }

            set
            {
                _dcm = value;
            }
        }

        public Element Element
        {
            get
            {
                return _element;
            }

            set
            {
                _element = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public string Ip
        {
            get
            {
                return _ip;
            }

            set
            {
                _ip = value;
            }
        }

        public void Update(ApiProcessing dcm, Element element, string username, string password, string ip)
        {
            _dcm = dcm;
            _element = element;
            _username = username;
            _password = password;
            _ip = ip;
        }

        internal void GetBoardInfo(CiscoDcmModel ciscoDcmModel, IView view)
        {
            if (ciscoDcmModel.BoardInfo.Count() == 0)
            {
                bool success;
                List<BoardInfo_V2_t> boardInfo;
                if (Element == null)
                {
                    success = Dcm.GetBoardInfo(out boardInfo);
                }
                else
                {
                    success = Dcm.GetBoardInfo(Element, out boardInfo);
                }

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
