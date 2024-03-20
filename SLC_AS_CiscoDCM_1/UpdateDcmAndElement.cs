using Skyline.DataMiner.Utils.CiscoDCM.Handling;
using Skyline.DataMiner.Automation;

namespace SLC_AS_CiscoDCM_1
{
    public abstract class UpdateDcmAndElement
    {
        public ApiProcessing Dcm;
        public Element Element;

        public void Update(ApiProcessing dcm, Element element)
        {
            Dcm = dcm;
            Element = element;
        }
    }
}
