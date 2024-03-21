using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Utils.CiscoDCM.Handling;
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
    }
}
