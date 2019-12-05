//
//  File: EpsilonNodeManipulator.cs
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

using System.Collections.Generic;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Web.DDRMenu;
using R7.Epsilon.Components;
using R7.Epsilon.Skins.SkinObjects;

namespace R7.Epsilon.Menus
{
    public class EpsilonNodeManipulator<TMenu>: INodeManipulator
    {
        readonly ICollection<INodeManipulator> _nodeManipulators;

        public EpsilonNodeManipulator ()
        {
            if (typeof (TMenu) == typeof (PrimaryMenu)) {
                _nodeManipulators = EpsilonConfig.Instance.PrimaryMenu.NodeManipulators;
            }
            else if (typeof (TMenu) == typeof (SecondaryMenu)) {
                _nodeManipulators = EpsilonConfig.Instance.SecondaryMenu.NodeManipulators;
            }
        }

        public EpsilonNodeManipulator (ICollection<INodeManipulator> nodeManipulators)
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
}
