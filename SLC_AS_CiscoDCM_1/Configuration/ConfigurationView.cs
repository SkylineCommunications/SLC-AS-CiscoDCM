using Microsoft.Win32;
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Utils.InteractiveAutomationScript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLC_AS_CiscoDCM_1.Configuration
{
    public class ConfigurationView : Dialog
    {
        public readonly TextBox Username;
        public readonly PasswordBox Password;
        private readonly Label username;
        private readonly Label password;
        private readonly Label elementName;
        private readonly Label elementIp;

        public ConfigurationView(Engine engine) : base(engine)
        {
            Title = "Configuration";
            username = new Label()
            {
                Text = "Username: ",
            };

            password = new Label()
            {
                Text= "Password: ",
            };

            elementName = new Label()
            {
                Text = "Element Name: ",
            };

            elementIp = new Label()
            {
                Text = "Element IP: ",
            };

            Password = new PasswordBox(true);
            SetupLayout();
        }

        public void SetupLayout()
        {
            AddWidget(username, 0, 0);
            AddWidget(password, 1, 0);
            AddWidget(Password, 1, 1);
            AddWidget(elementName, 2, 0);
            AddWidget(elementIp, 3, 0);
        }
    }
}
