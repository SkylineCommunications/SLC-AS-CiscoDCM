using Skyline.DataMiner.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.Input
{
    public class InputPresenter
    {
        private readonly InputView _inputView;

        public InputPresenter(IEngine engine, InputView inputView)
        {
            _inputView = inputView;

            _inputView.GetInputTs.Pressed += GetInputTs_Pressed;
            _inputView.GetActiveInputTs.Pressed += GetActiveInputTs_Pressed;
            _inputView.GetInputServices.Pressed += GetInputServices_Pressed;
            _inputView.Back.Pressed += Back_Pressed;
        }

        public event EventHandler<EventArgs> GetInputTs;

        public event EventHandler<EventArgs> GetActiveInputTs;

        public event EventHandler<EventArgs> GetInputServices;

        public event EventHandler<EventArgs> Back;

        private void GetInputTs_Pressed(object sender, EventArgs e)
        {
            GetInputTs?.Invoke(this, EventArgs.Empty);
        }

        private void GetActiveInputTs_Pressed(object sender, EventArgs e)
        {
            GetActiveInputTs?.Invoke(this, EventArgs.Empty);
        }

        private void GetInputServices_Pressed(object sender, EventArgs e)
        {
            GetInputServices?.Invoke(this, EventArgs.Empty);
        }

        private void Back_Pressed(object sender, EventArgs e)
        {
            Back?.Invoke(this, EventArgs.Empty);
        }
    }
}
