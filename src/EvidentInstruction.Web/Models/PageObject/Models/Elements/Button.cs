﻿using EvidentInstruction.Web.Models.PageObject.Models.Abstracts.Elements;

namespace EvidentInstruction.Web.Models.PageObject.Models.Elements
{
    public class Button : BaseClick
    {
        public Button(string name, string locator, bool optional) : base(name, locator, optional) { }
    }
}
