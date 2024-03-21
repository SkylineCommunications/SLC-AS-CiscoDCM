/*
****************************************************************************
*  Copyright (c) 2024,  Skyline Communications NV  All Rights Reserved.    *
****************************************************************************

By using this script, you expressly agree with the usage terms and
conditions set out below.
This script and all related materials are protected by copyrights and
other intellectual property rights that exclusively belong
to Skyline Communications.

A user license granted for this script is strictly for personal use only.
This script may not be used in any way by anyone without the prior
written consent of Skyline Communications. Any sublicensing of this
script is forbidden.

Any modifications to this script by the user are only allowed for
personal use and within the intended purpose of the script,
and will remain the sole responsibility of the user.
Skyline Communications will not be responsible for any damages or
malfunctions whatsoever of the script resulting from a modification
or adaptation by the user.

The content of this script is confidential information.
The user hereby agrees to keep this confidential information strictly
secret and confidential and not to disclose or reveal it, in whole
or in part, directly or indirectly to any person, entity, organization
or administration without the prior written consent of
Skyline Communications.

Any inquiries can be addressed to:

	Skyline Communications NV
	Ambachtenstraat 33
	B-8870 Izegem
	Belgium
	Tel.	: +32 51 31 35 69
	Fax.	: +32 51 31 01 29
	E-mail	: info@skyline.be
	Web		: www.skyline.be
	Contact	: Ben Vandenberghe

****************************************************************************
Revision History:

DATE		VERSION		AUTHOR			COMMENTS

13/03/2024	1.0.0.1		RDM, Skyline	Initial version
****************************************************************************
*/

namespace SLC_AS_CiscoDCM_1
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Skyline.DataMiner.Utils.CiscoDCM.Handling;
    using Skyline.DataMiner.Automation;
    using Skyline.DataMiner.Core.DataMinerSystem.Automation;
    using Skyline.DataMiner.Utils.InteractiveAutomationScript;
    using SLC_AS_CiscoDCM_1.Configuration;
    using SLC_AS_CiscoDCM_1.FirstChoices;
    using SLC_AS_CiscoDCM_1.GetBoardInfo;
    using SLC_AS_CiscoDCM_1.GetInputTs;
    using SLC_AS_CiscoDCM_1.Input;

    /// <summary>
    /// Represents a DataMiner Automation script.
    /// </summary>
    public class Script
    {
        /// <summary>
        /// The script entry point.
        /// </summary>
        /// <param name="engine">Link with SLAutomation process.</param>
        public void Run(Engine engine)
        {
            // engine.ShowUI();
            try
            {
                ApiProcessing dcm;
                Element element;
                CiscoDcmModel model = new CiscoDcmModel();
                var controller = new InteractiveController(engine);
                var configurationView = new ConfigurationView(engine);
                var configurationModel = new ConfigurationModel();
                var configurationPresenter = new ConfigurationPresenter(engine, configurationView, configurationModel);
                var firstChoicesView = new FirstChoicesView(engine);
                var firstChoicesPresenter = new FirstChoicesPresenter(engine, firstChoicesView);
                var getBoardInfoView = new GetBoardInfoView(engine);
                var getBoardInfoController = new GetBoardInfoController(engine, getBoardInfoView);
                var inputView = new InputView(engine);
                var inputPresenter = new InputPresenter(engine, inputView);
                var getInputTsView = new GetInputTsView(engine);
                var getInputTsController = new GetInputTsController(engine, getInputTsView, model);
                configurationPresenter.Next += (sender, e) =>
                {
                    configurationView.SetupLayout();
                    element = e;
                    dcm = new ApiProcessing(engine, configurationView.Username.Text, configurationView.Password.Password, "API Dummy", "API Dummy");
                    if (!dcm.ConnectToApi(configurationView.ElementName.Text, configurationView.ElementIp.Text))
                    {
                        engine.ExitFail("Couldn't connect with the Cisco DCM device");
                    }

                    getBoardInfoController.Update(dcm, element);
                    getInputTsController.Update(dcm, element, configurationView.Username.Text, configurationView.Password.Password, configurationView.ElementIp.Text);
                    controller.ShowDialog(firstChoicesView);
                };
                firstChoicesPresenter.GetBoardInfo += (sender, e) =>
                {
                    controller.ShowDialog(getBoardInfoView);
                };
                firstChoicesPresenter.Input += (sender, e) =>
                {
                    controller.ShowDialog(inputView);
                };
                firstChoicesPresenter.Back += (sender, e) =>
                {
                    controller.ShowDialog(configurationView);
                };
                getBoardInfoController.GetData += (sender, e) =>
                {
                    model.BoardInfo = e;
                };
                getBoardInfoController.Back += (sender, e) =>
                {
                    controller.ShowDialog(firstChoicesView);
                };
                inputPresenter.GetInputTs += (sender, e) =>
                {
                    controller.ShowDialog(getInputTsView);
                };
                inputPresenter.Back += (sender, e) =>
                {
                    controller.ShowDialog(firstChoicesView);
                };
                getInputTsController.Back += (sender, e) =>
                {
                    controller.ShowDialog(inputView);
                };

                controller.Run(configurationView);
            }
            catch (Exception ex)
            {
                engine.GenerateInformation("Error: " + ex.StackTrace);
            }
        }
    }
}