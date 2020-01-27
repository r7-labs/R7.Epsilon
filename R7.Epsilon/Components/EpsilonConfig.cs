//
//  File: EpsilonConfig.cs
//  Project: R7.Epsilon
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
using System.Collections.Concurrent;
using System.IO;
using System.Web.Caching;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Services.Exceptions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace R7.Epsilon.Components
{
    public static class EpsilonConfig
    {
        #region Singleton implementation

        static readonly ConcurrentDictionary<int, Lazy<EpsilonPortalConfig>> portalConfigs =
            new ConcurrentDictionary<int, Lazy<EpsilonPortalConfig>> ();

        static readonly ConcurrentDictionary<int, CacheItemArgs> cacheItemArgs =
            new ConcurrentDictionary<int, CacheItemArgs> ();

        public static EpsilonPortalConfig Instance => GetInstance (PortalSettings.Current.PortalId);

        public static EpsilonPortalConfig GetInstance (int portalId)
        {
            return DataCache.GetCachedData<EpsilonPortalConfig> (
                cacheItemArgs.GetOrAdd (PortalSettings.Current.PortalId,
                    (pid) => new CacheItemArgs ("//r7_Epsilon/config?portalId=" + pid, 60, CacheItemPriority.Normal)),
                (cia) => LoadPortalConfig (PortalSettings.Current.PortalId)
            );
        }

        private static EpsilonPortalConfig LoadPortalConfig (int portalId)
        {
            var lazyPortalConfig = portalConfigs.GetOrAdd (portalId, newKey =>
                new Lazy<EpsilonPortalConfig> (() => {
                    var portalConfig = default (EpsilonPortalConfig);

                    var portalSettings = new PortalSettings (portalId);
                    var portalConfigFile = Path.Combine (portalSettings.HomeDirectoryMapPath, "R7.Epsilon.yml");
                    try {
                        if (File.Exists (portalConfigFile)) {
                            using (var configReader = new StringReader (File.ReadAllText (portalConfigFile))) {
                                var deserializer = new DeserializerBuilder ().WithNamingConvention (new HyphenatedNamingConvention ()).Build ();
                                portalConfig = deserializer.Deserialize<EpsilonPortalConfig> (configReader);
                            }
                        }
                    }
                    catch (Exception ex) {
                        Exceptions.LogException (ex);
                    }

                    if (portalConfig == null) {
                        portalConfig = new EpsilonPortalConfig ();
                    }

                    portalConfig.Menu.LoadNodeManipulators ();
                    portalConfig.PrimaryMenu.LoadNodeManipulators ();
                    portalConfig.SecondaryMenu.LoadNodeManipulators ();
                    portalConfig.BreadcrumbMenu.LoadNodeManipulators ();

                    return portalConfig;
                })
            );

            return lazyPortalConfig.Value;
        }

        #endregion
    }
}
