using Skyline.DataMiner.Utils.CiscoDCM.Handling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1
{
    public class CiscoDcmModel
    {
        public CiscoDcmModel()
        {
            BoardInfo = new List<DCM.DeviceControl_package.BoardInfo_V2_t>();
            AllInputTs = new List<ApiProcessing.DcmHelper.IPS_InputTS_t>();
            AllInputServices = new Dictionary<string, DCM.DeviceControl_package.IPS_Service_In_t>();
        }

        public List<DCM.DeviceControl_package.BoardInfo_V2_t> BoardInfo { get; set; }

        public List<ApiProcessing.DcmHelper.IPS_InputTS_t> AllInputTs { get; set; }

        public Dictionary<string, DCM.DeviceControl_package.IPS_Service_In_t> AllInputServices { get; set; }
    }
}
