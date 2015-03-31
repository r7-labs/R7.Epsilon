//
// EpsilonSkinObjectBase.cs
//
// Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
// Copyright (c) 2015 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Web.UI;
using DotNetNuke.Common;
using DotNetNuke.UI.Skins;

namespace R7.Epsilon
{
    public class EpsilonSkinObjectBase: SkinObjectBase, ILocalizableControl, IConfigurableControl
    {
        #region ILocalizableControl implementation

        private ControlLocalizer localizer;

        public ControlLocalizer Localizer
        {
            get { return localizer ?? (localizer = new ControlLocalizer (this)); } 
        }

        #endregion

        #region IConfigurableControl implementation

        private EpsilonConfig config;

        public EpsilonConfig Config 
        {
            get { return config ?? (config = EpsilonConfigManager.Instance.GetConfig (PortalSettings.PortalId)); }
        }

        #endregion

        public string HomeTabFullUrl
        {
            get
            {
                return (PortalSettings.HomeTabId != -1) ? 
                    Globals.NavigateURL (PortalSettings.HomeTabId) : Globals.AddHTTP (PortalSettings.PortalAlias.HTTPAlias);
            }
        }
    }
}

