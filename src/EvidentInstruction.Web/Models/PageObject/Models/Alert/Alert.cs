﻿using EvidentInstruction.Web.Models.PageObject.Models.Alert.Interfaces;
using EvidentInstruction.Web.Models.PageObject.Models.Mediator;
using EvidentInstruction.Web.Models.PageObject.Models.Mediator.Interfaces;
using EvidentInstruction.Web.Models.Providers.Interfaces;
using EvidentInstruction.Web.Models.Settings;
using System;

namespace EvidentInstruction.Web.Models.PageObject.Models.Alert
{
    public class Alert : IAlert
    {
        [ThreadStatic]
        private IMediator _mediator = null;

        [ThreadStatic]
        private IAlertProvider _alertProvider;

        public string Text => _alertProvider.Text;

        public Alert(IDriverProvider driverProvider)
        {
            _mediator = new AlertMediator((driverProvider.Settings as BrowserSetting).ElementTimeout);
            _alertProvider = (IAlertProvider)_mediator.Wait(() => driverProvider.GetAlert());
        }

        public void Accept()
        {
            _alertProvider.SendAccept();
        }

        public void Dismiss()
        {
            _alertProvider.SendDismiss();
        }

        public void SendKeys(string keys)
        {
            _alertProvider.SendKeys(keys);
        }

        public void SetAuth(string login, string password)
        {
            _alertProvider.SetAuth(login, password);
        }
    }
}
