using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Utils.InteractiveAutomationScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.GetBoardInfo
{
    public class GetBoardInfoView : Dialog
    {
        public readonly Button GetData = new Button("Get Data") { Width = 150 };

        public GetBoardInfoView(IEngine engine) : base(engine)
        {
            Title = "Boards Info";
            SetupLayout();
        }

        public void SetupLayout()
        {
            AddWidget(GetData, 0, 0);
        }
    }
}
