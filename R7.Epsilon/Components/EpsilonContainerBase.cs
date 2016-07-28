//
// EpsilonContainerBase.cs
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
using DotNetNuke.UI.Containers;
using DotNetNuke.Security.Permissions;
using DotNetNuke.UI.Skins.Controls;
using DotNetNuke.Common;
using DotNetNuke.Security;
using DotNetNuke.Entities.Modules;

namespace R7.Epsilon
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