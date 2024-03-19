using Skyline.DataMiner.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.FirstChoices
{
    public class FirstChoicesPresenter
    {
        private readonly FirstChoicesView _firstChoicesView;

        public FirstChoicesPresenter(IEngine engine, FirstChoicesView firstChoicesView)
        {
            _firstChoicesView = firstChoicesView;

            _firstChoicesView.Back.Pressed += Back_Pressed;
            _firstChoicesView.Input.Pressed += Input_Pressed;
            _firstChoicesView.GetBoardInfo.Pressed += GetBoardInfo_Pressed;
        }

        public event EventHandler<EventArgs> Back;

        public event EventHandler<EventArgs> Input;

        public event EventHandler<EventArgs> GetBoardInfo;

        private void GetBoardInfo_Pressed(object sender, EventArgs e)
        {
            GetBoardInfo?.Invoke(this, EventArgs.Empty);
        }

        private void Input_Pressed(object sender, EventArgs e)
        {
            Input?.Invoke(this, EventArgs.Empty);
        }

        private void Back_Pressed(object sender, EventArgs e)
        {
            Back?.Invoke(this, EventArgs.Empty);
        }
    }
}
