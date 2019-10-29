//
//  File: EpsilonSkinObjectBase.cs
//  Project: R7.Epsilon
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2014-2019 Roman M. Yagodin, R7.Labs
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Affero General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Affero General Public License for more details.
//
//  You should have received a copy of the GNU Affero General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Web.UI;
using DotNetNuke.Common;
using DotNetNuke.UI.Skins;
using R7.Epsilon.Components;

namespace R7.Epsilon.Skins.SkinObjects
{
    public class EpsilonSkinObjectBase : SkinObjectBase, ILocalizableControl, IConfigurableControl
    {
        #region ILocalizableControl implementation

        private ControlLocalizer localizer;

        public ControlLocalizer Localizer {
            get { return localizer ?? (localizer = new ControlLocalizer (this)); }
        }

        #endregion

        #region IConfigurableControl implementation

        private EpsilonPortalConfig config;

        public EpsilonPortalConfig Config {
            get { return config ?? (config = EpsilonConfig.GetInstance (PortalSettings.PortalId)); }
        }

        #endregion

        public string HomeTabFullUrl {
            get {
                return (PortalSettings.HomeTabId != -1) ?
                    Globals.NavigateURL (PortalSettings.HomeTabId) : Globals.AddHTTP (PortalSettings.PortalAlias.HTTPAlias);
            }
        }

        private EpsilonSkinBase skin;

        public EpsilonSkinBase Skin {
            get {
                if (skin == null) {
                    Control control = this;
                    while (!(control.Parent is EpsilonSkinBase)) {
                        if (control.Parent == null) {
                            return null;
                        }
                        control = control.Parent;
                    }
                    skin = (EpsilonSkinBase) control.Parent;
                }
                return skin;
            }
        }
    }
}

