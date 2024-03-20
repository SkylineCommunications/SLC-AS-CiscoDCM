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
        public readonly Button Back = new Button("Back") { Width = 150 };
        public readonly Label Result = new Label();
        public readonly Label TimeElapsed = new Label();
        public readonly Label AmountOfBoards = new Label();
        private readonly Label _timeElapsed = new Label("Time elapsed: ");
        private readonly Label _amountOfBoards = new Label("Amount of boards: ");

        public GetBoardInfoView(IEngine engine) : base(engine)
        {
            Title = "Boards Info";
            SetupLayout();
        }

        public void SetupLayout()
        {
            AddWidget(GetData, 0, 0);
            AddWidget(Result, 1, 0);
            AddWidget(_timeElapsed, 2, 0);
            AddWidget(TimeElapsed, 2, 1);
            AddWidget(_amountOfBoards, 3, 0);
            AddWidget(AmountOfBoards, 3, 1);
            AddWidget(Back, 4, 0);
        }
    }
}
