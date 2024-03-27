using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Utils.InteractiveAutomationScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.GetActiveInputTs
{
    public class GetActiveInputTsView : Dialog, IView
    {
        public readonly Button Back = new Button("Back") { Width = 150 };
        public readonly Button GetData = new Button("Get Data") { Width = 150 };
        public readonly Label TimeElapsed = new Label(String.Empty);
        public readonly Label NumberOfActiveInputTs = new Label(String.Empty);
        private readonly Label _timeElapsed = new Label("Time elapsed: ");
        private readonly Label _numberOfActiveInputTs = new Label("Number of Active Input TS: ");
        //private Label _result = new Label(String.Empty);

        public GetActiveInputTsView(IEngine engine) : base(engine)
        {
            Result = new Label(String.Empty);
            Title = "Get Active Input TS";
            SetupLayout();
        }

        public Label Result { get; set; }

        public void SetupLayout()
        {
            Clear();
            AddWidget(GetData, 0, 0);
            AddWidget(Result, 1, 0);
            AddWidget(_timeElapsed, 2, 0);
            AddWidget(TimeElapsed, 2, 1);
            AddWidget(_numberOfActiveInputTs, 3, 0);
            AddWidget(NumberOfActiveInputTs, 3, 1);
            AddWidget(Back, 4, 0);
        }
    }
}
