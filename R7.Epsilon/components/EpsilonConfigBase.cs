//
// EpsilonConfigBase.cs
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
using System.IO;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Common;
using Nini.Config;

namespace R7.Epsilon
{
    public abstract class EpsilonConfigBase
    {
        #region Fields

        protected IConfigSource PortalConfigSource;

        protected IConfig PortalConfig;

        protected string PortalConfigFile;

        protected DateTime LastWriteTimeUtc;

        protected DateTime ValidUntilTimeUtc;

        // protected const int ValidSeconds = 60;

        #endregion

        protected EpsilonConfigBase (int portalId)
        {
            var portalSettings = new PortalSettings (portalId);

            // portal config source
            PortalConfigFile = Path.Combine (portalSettings.HomeDirectoryMapPath, "R7.Epsilon.config");

            if (!File.Exists (PortalConfigFile))
            {
                // copy generic config file to portal folder
                var genericConfigFile = Path.Combine (Globals.HostMapPath, "Skins\\R7.Epsilon\\R7.Epsilon.config");
                File.Copy (genericConfigFile, PortalConfigFile);
            }

            Load ();
        }

        protected void Load ()
        {
            // set last write time
            LastWriteTimeUtc = File.GetLastWriteTimeUtc (PortalConfigFile);
            // ValidUntilTimeUtc = DateTime.UtcNow.AddSeconds (ValidSeconds);

            // get config source
            PortalConfigSource = new DotNetConfigSource (PortalConfigFile);

            // get configs (config sections)
            PortalConfig = PortalConfigSource.Configs ["Portal"];
        }

        /// <summary>
        /// Ensures the config is valid and reload if it's not.
        /// </summary>
        public void EnsureIsValid ()
        {
            // if (DateTime.UtcNow > ValidUntilTimeUtc)
                if (File.GetLastWriteTimeUtc (PortalConfigFile) > LastWriteTimeUtc)
                    Load ();
        }
    }
}

