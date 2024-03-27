using Skyline.DataMiner.Automation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.Configuration
{
    public class ConfigurationPresenter
    {
        private IEngine _engine;
        private readonly ConfigurationView _configurationView;
        private readonly ConfigurationModel _configurationModel;

        public ConfigurationPresenter(IEngine engine, ConfigurationView configurationView, ConfigurationModel configurationModel)
        {
            _engine = engine;
            _configurationView = configurationView;
            _configurationModel = configurationModel;

            configurationView.Next.Pressed += Next_Pressed;
        }

        public event EventHandler<Element> Next;

        private void Next_Pressed(object sender, EventArgs e)
        {
            _configurationView.showFieldsNotCorrect = false;
            _configurationView.showElementNotFound = false;
            _configurationView.showElementIpDoesntMatch = false;
            _configurationView.SetupLayout();
            if (String.IsNullOrWhiteSpace(_configurationView.Username.Text) ||
                String.IsNullOrWhiteSpace(_configurationView.Password.Password) ||
                String.IsNullOrWhiteSpace(_configurationView.DeviceIp.Text))
            {
                _configurationView.showFieldsNotCorrect = true;
                _configurationView.SetupLayout();
                return;
            }

            if (!String.IsNullOrWhiteSpace(_configurationView.ElementName.Text))
            {
                var element = _engine.FindElement(_configurationView.ElementName.Text);
                if (element == null)
                {
                    _configurationView.showElementNotFound = true;
                    _configurationView.SetupLayout();
                    return;
                }

                if (!element.PollingIP.Contains(_configurationView.DeviceIp.Text))
                {
                    _configurationView.showElementIpDoesntMatch = true;
                    _configurationView.SetupLayout();
                    return;
                }

                Next?.Invoke(this, element);
            }

            Next?.Invoke(this, null);
        }
    }
}
