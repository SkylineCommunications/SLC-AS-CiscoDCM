using CiscoDcmBulkProcessing.Handling;
using Skyline.DataMiner.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
