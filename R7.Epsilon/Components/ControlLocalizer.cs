//
// ControlLocalizer.cs
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
using DotNetNuke.UI.Skins;
using DotNetNuke.Services.Localization;

namespace R7.Epsilon.Components
{
    public class ControlLocalizer
    {
        #region Properties

        public string LocalResourceFile { get; protected set; }

        #endregion

        public ControlLocalizer (Control control)
        {
            // use control base type name, not .ascx one!
            LocalResourceFile = Localization.GetResourceFile (control, control.GetType ().BaseType.Name + ".ascx");

            // skinobjects must use resourses from skin directory
            if (control is SkinObjectBase)
                LocalResourceFile = LocalResourceFile.Replace ("/Controls", string.Empty);
        }

        #region Public methods

        public string GetString (string key)
        {
            return Localization.GetString (key, LocalResourceFile);
        }

        // REVIEW: Remove as unused?
        public string GetString (string key, string defaultKey)
        {
            var localizedValue = GetString (key);

            return !string.IsNullOrWhiteSpace (localizedValue) ? localizedValue : GetString(defaultKey);
        }

        public string SafeGetString (string key, string defaultValue)
        {
            var localizedValue = GetString (key);

            return !string.IsNullOrWhiteSpace (localizedValue) ? localizedValue : defaultValue;
        }

        #endregion
    }
}
