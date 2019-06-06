//
//  Const.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2016 Roman M. Yagodin
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

namespace R7.Epsilon.Components
{
    public static class Const
    {
        public const int HOST_PORTAL_ID = -1;

        public const string LAYOUTS_FOLDER = "Skins\\R7.Epsilon\\Layouts\\";

        public const string LAYOUT_TAB_SETTING_NAME_BASE = "r7_Epsilon_Layout";

        public const string LAYOUT_TAB_SETTING_NAME = LAYOUT_TAB_SETTING_NAME_BASE;

        public const string A11Y_LAYOUT_TAB_SETTING_NAME = LAYOUT_TAB_SETTING_NAME + "_A11y";

        public const string COOKIE_PREFIX = "R7.Epsilon.";

        /// <summary>
        /// Returns layout name prefix which is used in tab settings
        /// </summary>
        /// <returns>The value prefix.</returns>
        /// <param name="portalId">Portal identifier.</param>
        public static string GetSettingValuePrefix (int portalId)
        {
            // [G]lobal and [L]ocal like in SkinSrc or ContainerSrc fields
            return (portalId == HOST_PORTAL_ID) ? "[G]" : "[L]";
        }
    }
}
