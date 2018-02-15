//
//  EpsilonPortalConfig.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015-2017 Roman M. Yagodin
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Compilation;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.DDRMenu;

namespace R7.Epsilon.Components
{
    public class EpsilonPortalConfig
    {
        #region Portal config properties

        public string SkinCss { get; set; }

        public string SkinA11yCss { get; set; }

        public int FeedbackTabId { get; set; }

        public MenuConfig PrimaryMenu { get; set; }

        public MenuConfig SecondaryMenu { get; set; }

        public string FooterButtonsGroupName { get; set; }

        public AdsenseConfig Adsense { get; set; }

        public bool ShowTerms { get; set; }

        public bool ShowPrivacy { get; set; }

        public int MenuUrlType { get; set; }

        public int MenuMinHeaders { get; set; } = 7;

        public bool UseObrnadzorMicrodata { get; set; }

        public List<SocialNetworkConfig> SocialNetworks { get; set; }

        public AnalyticsConfig Analytics { get; set; }

        #endregion
    }

    public class MenuConfig
    {
        public string NodeSelector { get; set; }

        public string IncludeNodes { get; set; }

        public ICollection<string> NodeManipulatorTypes { get; set; } = new Collection<string> ();

        public ICollection<INodeManipulator> NodeManipulators = new Collection<INodeManipulator> ();

        public void LoadNodeManipulators ()
        {
            foreach (var nodeManipulatorType in NodeManipulatorTypes) {
                try {
                    NodeManipulators.Add (((INodeManipulator) Activator.CreateInstance (BuildManager.GetType (nodeManipulatorType, true, true))));
                }
                catch (Exception ex) {
                    Exceptions.LogException (ex);    
                }
            }
        }
    }

    public class AdsenseConfig
    {
        public string Client { get; set; }

        public string Slot { get; set; }
    }

    // TODO: Rename to SocialNetwork
    public class SocialNetworkConfig
    {
        public string Name { get; set; }

        public string Group { get; set; }

        public bool ShareEnabled { get; set; } = false;

        public bool IsPrimary { get; set; } = false;

        public string ApiId { get; set; } = string.Empty;

        public List<string> Params { get; set; }
    }

    public class AnalyticsConfig
    {
        public bool UseSputnik { get; set; } = false;
    }
}

