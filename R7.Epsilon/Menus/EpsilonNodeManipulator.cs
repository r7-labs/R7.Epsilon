//
//  File: EpsilonNodeManipulator.cs
//  Project: R7.Zeta
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

using System.Collections.Generic;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Web.DDRMenu;
using R7.Zeta.Components;
using R7.Zeta.Skins.SkinObjects;

namespace R7.Zeta.Menus
{
    public class EpsilonNodeManipulator: INodeManipulator
    {
        protected IEnumerable<INodeManipulator> _nodeManipulators;

        public EpsilonNodeManipulator (): this (EpsilonConfig.Instance.Menu.GetNodeManipulators ())
        {}

        public EpsilonNodeManipulator (IEnumerable<INodeManipulator> nodeManipulators)
        {
	        _nodeManipulators = nodeManipulators;
        }

        public List<MenuNode> ManipulateNodes (List<MenuNode> nodes, PortalSettings portalSettings)
        {
            if (_nodeManipulators != null) {
                foreach (var nodeManipulator in _nodeManipulators) {
                    nodeManipulator.ManipulateNodes (nodes, portalSettings);
                }
            }
            return nodes;
        }
    }

    public class EpsilonNodeManipulator<TMenu>: EpsilonNodeManipulator
    {
        public EpsilonNodeManipulator ()
        {
            if (typeof (TMenu) == typeof (PrimaryMenu)) {
                if (EpsilonConfig.Instance.PrimaryMenu.NodeManipulators.Count > 0) {
                    _nodeManipulators = EpsilonConfig.Instance.PrimaryMenu.GetNodeManipulators ();
                    return;
                }
            }
            else if (typeof (TMenu) == typeof (SecondaryMenu)) {
                if (EpsilonConfig.Instance.SecondaryMenu.NodeManipulators.Count > 0) {
                    _nodeManipulators = EpsilonConfig.Instance.SecondaryMenu.GetNodeManipulators ();
                    return;
                }
            }
            else if (typeof (TMenu) == typeof (BreadcrumbMenu)) {
                if (EpsilonConfig.Instance.BreadcrumbMenu.NodeManipulators.Count > 0) {
                    _nodeManipulators = EpsilonConfig.Instance.BreadcrumbMenu.GetNodeManipulators ();
                    return;
                }
            }
            _nodeManipulators = EpsilonConfig.Instance.Menu.GetNodeManipulators ();
        }
    }
}
