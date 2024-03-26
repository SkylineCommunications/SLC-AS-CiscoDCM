﻿using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Utils.InteractiveAutomationScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.GetInputServices
{
    public class GetInputServicesView : Dialog, IView
    {
        public readonly Button Back = new Button("Back") { Width = 150 };
        public readonly Button GetData = new Button("Get Data") { Width = 150 };
        public readonly Label TimeElapsed = new Label(String.Empty);
        public readonly Label NumberOfInputServices = new Label(String.Empty);
        private readonly Label _timeElapsed = new Label("Time elapsed: ");
        private readonly Label _numberOfInputServices = new Label("Number of Input Services: ");
        private Label _result = new Label(String.Empty);

        public GetInputServicesView(IEngine engine) : base(engine)
        {
            Title = "Get Input Services";
            SetupLayout();
        }

        public Label Result
        {
            get
            {
                return _result;
            }

            set
            {
                _result = value;
            }
        }

        public void SetupLayout()
        {
            Clear();
            AddWidget(GetData, 0, 0);
            AddWidget(_result, 1, 0);
            AddWidget(_timeElapsed, 2, 0);
            AddWidget(TimeElapsed, 2, 1);
            AddWidget(_numberOfInputServices, 3, 0);
            AddWidget(NumberOfInputServices, 3, 1);
            AddWidget(Back, 4, 0);
        }
    }
}
