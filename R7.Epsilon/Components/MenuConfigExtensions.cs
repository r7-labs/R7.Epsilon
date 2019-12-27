//
//  File: MenuConfigExtensions.cs
//  Project: R7.Zeta
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2016-2019 Roman M. Yagodin, R7.Labs
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
using System.Linq;
using System.Web.Compilation;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Web.DDRMenu;

namespace R7.Zeta.Components
{
    public static class MenuConfigExtensions
    {
        public static void LoadNodeManipulators (this MenuConfig menuConfig)
        {
            foreach (var nodeManipulatorType in menuConfig.NodeManipulatorTypes) {
                try {
                    menuConfig.NodeManipulators.Add (Activator.CreateInstance (BuildManager.GetType (nodeManipulatorType, true, true)));
                }
                catch (Exception ex) {
                    Exceptions.LogException (ex);
                }
            }
        }

        public static IEnumerable<INodeManipulator> GetNodeManipulators (this MenuConfig menuConfig)
        {
            return menuConfig.NodeManipulators.Cast<INodeManipulator> ();
        }
    }
}
