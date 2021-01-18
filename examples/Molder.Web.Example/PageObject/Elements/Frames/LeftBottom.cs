﻿using Molder.Web.Models.PageObject.Attributes;
using Molder.Web.Models.PageObject.Models;
using Molder.Web.Models.PageObject.Models.Elements;

namespace PageObject.Elements.Frames
{
    public class LeftBottom : Frame
    {
        public LeftBottom(string name, string frameName, int? number, string locator, bool optional = false) : base(name, frameName, number, locator, optional) { }

        [Element(Name = "Text", Locator = "/html/body")]
        Div text;
    }
}
