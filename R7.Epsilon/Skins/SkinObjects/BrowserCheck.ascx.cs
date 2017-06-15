//
//  BrowserCheck.ascx.cs
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

using R7.Epsilon.Components;

namespace R7.Epsilon.Skins.SkinObjects
{
    public class BrowserCheck : EpsilonSkinObjectBase
    {
        #region Properties

        /// <summary>
        /// Gets or sets the minimum IE major version.
        /// </summary>
        /// <value>The minimum IE major version.</value>
        protected int MinIeVersion { get; set; }
 
        protected bool IsCompatibleBrowser
        {
            get
            {
                // default is compatible
                var compatible = true;

                // check for browser type and version 
                if (EpsilonUrlHelper.IsIeBrowser (Request))
                {
                    compatible = Request.Browser.MajorVersion >= MinIeVersion;
                }

                return compatible;
            }
        }

        #endregion

        protected BrowserCheck ()
        {
            // default value
            MinIeVersion = 9;
        }
    }
}
