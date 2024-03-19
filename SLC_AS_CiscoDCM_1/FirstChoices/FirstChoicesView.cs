using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Utils.InteractiveAutomationScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.FirstChoices
{
    public class FirstChoicesView : Dialog
    {
        public readonly Button Back = new Button("Back") { Width = 150 };
        public readonly Button GetBoardInfo = new Button("Get Board Info") { Width = 150 };
        public readonly Button Input = new Button("Input") { Width = 150 };

        public FirstChoicesView(IEngine engine) : base(engine)
        {
            Title = "Selection";
            SetupLayout();
        }

        public void SetupLayout()
        {
            Clear();
            AddWidget(GetBoardInfo, 0, 0);
            AddWidget(Input, 1, 0);
            AddWidget(Back, 2, 0);
        }
    }
}
