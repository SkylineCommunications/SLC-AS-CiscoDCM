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
        public readonly TextBox ElementName;
        public readonly TextBox ElementIp;
        private readonly Label username;
        private readonly Label password;
        private readonly Label elementName;
        private readonly Label elementIp;
        private readonly Button next;

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

            next = new Button("Next")
            {
                
            };

            next.Pressed += Next_Pressed;

            Password = new PasswordBox(true);
            SetupLayout();
        }

        private void Next_Pressed(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void SetupLayout()
        {
            AddWidget(username, 0, 0);
            AddWidget(Username, 0, 1);
            AddWidget(password, 1, 0);
            AddWidget(Password, 1, 1);
            AddWidget(elementName, 2, 0);
            AddWidget(ElementName, 2, 1);
            AddWidget(elementIp, 3, 0);
            AddWidget(ElementIp, 3, 1);
            AddWidget(next, 4, 0, 0, 2);
        }
    }
}
