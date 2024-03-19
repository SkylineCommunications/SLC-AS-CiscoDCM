using Skyline.DataMiner.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.GetInputTs
{
    public class GetInputTsPresenter
    {
        private readonly GetInputTsView _getInputTsView;

        public GetInputTsPresenter(IEngine engine, GetInputTsView getInputTsView)
        {
            _getInputTsView = getInputTsView;

            _getInputTsView.Back.Pressed += Back_Pressed;
            _getInputTsView.GetData.Pressed += GetData_Pressed;
        }

        public event EventHandler<EventArgs> GetData;

        public event EventHandler<EventArgs> Back;

        private void GetData_Pressed(object sender, EventArgs e)
        {
            GetData?.Invoke(this, EventArgs.Empty);
        }

        private void Back_Pressed(object sender, EventArgs e)
        {
            Back?.Invoke(this, EventArgs.Empty);
        }
    }
}
