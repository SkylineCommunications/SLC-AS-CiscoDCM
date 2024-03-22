using Skyline.DataMiner.Analytics.ChangePoints;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Utils.InteractiveAutomationScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.Input
{
    public class InputView : Dialog
    {
        public readonly Button Back = new Button("Back") { Width = 150 };
        public readonly Button GetInputTs = new Button("Get Input TS") { Width = 150 };
        public readonly Button GetInputServices = new Button("Get Input Services") { Width = 150 };
        public readonly Button GetActiveInputTs = new Button("Get Active Input TS") { Width = 150 };

        public InputView(IEngine engine) : base(engine)
        {
            Title = "Input";
            SetupLayout();
        }

        public void SetupLayout()
        {
            Clear();
            AddWidget(GetInputTs, 0, 0);
            AddWidget(GetActiveInputTs, 1, 0);
            AddWidget(GetInputServices, 2, 0);
            AddWidget(Back, 3, 0);
        }
    }
}
