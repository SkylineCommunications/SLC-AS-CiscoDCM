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
        public bool showFieldsNotCorrect = false;
        public bool showElementNotFound = false;
        public bool showElementIpDoesntMatch = false;
        public readonly TextBox Username;
        public readonly PasswordBox Password;
        public readonly TextBox ElementName;
        public readonly TextBox ElementIp;
        public readonly Button Next;
        private readonly Label username = new Label("Username: ") { MinWidth = 100 };
        private readonly Label password = new Label("Password: ") { MinWidth = 100 };
        private readonly Label elementName = new Label("Element Name: ") { MinWidth = 100 };
        private readonly Label elementIp = new Label("Element IP: ") { MinWidth = 100 };
        private readonly Label fieldsNotCorrect = new Label("Check if all the fields are correctly filled in.") { MinWidth = 200 };
        private readonly Label elementNotFound = new Label("No element could be found with that name.") { MinWidth = 200 };
        private readonly Label elementIpDoesntMatch = new Label("The provided IP doesn't match with the IP of the element.") { MinWidth = 200 };

        public ConfigurationView(IEngine engine) : base(engine)
        {
            Title = "Configuration";
            MinWidth = 300;

            Next = new Button("Next")
            {
                Width = 150,
            };

            Username = new TextBox() { Width = 150 };
            Password = new PasswordBox(true) { Width = 150 };
            ElementName = new TextBox() { Width = 150 };
            ElementIp = new TextBox() { Width = 150 };
            SetupLayout();
        }

        public void SetupLayout()
        {
            Clear();
            AddWidget(username, 0, 0);
            AddWidget(Username, 0, 1);
            AddWidget(password, 1, 0);
            AddWidget(Password, 1, 1);
            AddWidget(elementName, 2, 0);
            AddWidget(ElementName, 2, 1);
            AddWidget(elementIp, 3, 0);
            AddWidget(ElementIp, 3, 1);
            AddWidget(Next, 4, 1, 1, 1);
            if (showFieldsNotCorrect)
            {
                AddWidget(fieldsNotCorrect, 5, 0, 1, 2);
            }

            if (showElementNotFound)
            {
                AddWidget(elementNotFound, 5, 0, 1, 2);
            }

            if (showElementIpDoesntMatch)
            {
                AddWidget(elementIpDoesntMatch, 5, 0, 1, 2);
            }
        }
    }
}
