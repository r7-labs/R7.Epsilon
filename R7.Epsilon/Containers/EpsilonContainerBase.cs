//
//  EpsilonContainerBase.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2015 Roman M. Yagodin
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
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Security;
using DotNetNuke.Security.Permissions;
using DotNetNuke.UI.Containers;

namespace R7.Epsilon.Containers
{
    public class EpsilonContainerBase: Container
    {
        protected override void OnLoad (EventArgs e)
        {
            base.OnLoad (e);
        }

        private bool? _isEditable;

        // Source: https://github.com/dnnsoftware/Dnn.Platform/blob/development/DNN%20Platform/Library/UI/Modules/ModuleInstanceContext.cs
        public bool IsEditable
        {
            get
            {
                ModuleInfo _configuration = null;

                // Perform tri-state switch check to avoid having to perform a security
                // role lookup on every property access (instead caching the result)
                if (_isEditable == null)
                {
                    var blnPreview = (PortalSettings.UserMode == DotNetNuke.Entities.Portals.PortalSettings.Mode.View);
                    if (Globals.IsHostTab (PortalSettings.ActiveTab.TabID))
                    {
                        blnPreview = false;
                    }

                    // get current module info
                    if (_configuration == null)
                    {
                        var moduleIdStr = ID.Replace ("ctr", string.Empty);
                        int moduleId;
                        if (int.TryParse (moduleIdStr, out moduleId))
                        {
                            _configuration = ModuleController.Instance.GetModule (moduleId, PortalSettings.ActiveTab.TabID, false);
                        }
                    }

                    var blnHasModuleEditPermissions = false;
                    if (_configuration != null)
                    {
                        blnHasModuleEditPermissions = ModulePermissionController.HasModuleAccess (
                            SecurityAccessLevel.Edit, "CONTENT", _configuration);
                    }

                    _isEditable = !blnPreview && blnHasModuleEditPermissions;
                }

                return _isEditable.Value;
            }
        }
    }
}