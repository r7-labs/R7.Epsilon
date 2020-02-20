//
//  File: EpsilonConfig.cs
//  Project: R7.Epsilon
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2016-2020 Roman M. Yagodin, R7.Labs
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

using System.Collections.Concurrent;
using System.Web.Caching;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Entities.Portals;
using R7.Dnn.Extensions.Configuration;

namespace R7.Epsilon.Components
{
    public static class EpsilonConfig
    {
        static readonly ExtensionYamlConfig<EpsilonPortalConfig> _config;

        static readonly ConcurrentDictionary<int, CacheItemArgs> cacheItemArgs =
            new ConcurrentDictionary<int, CacheItemArgs> ();

        static EpsilonConfig ()
        {
            _config = new ExtensionYamlConfig<EpsilonPortalConfig> ("R7.Epsilon.yml", InitConfig);
        }

        static EpsilonPortalConfig InitConfig (EpsilonPortalConfig portalConfig)
        {
            portalConfig.Menu.LoadNodeManipulators ();
            portalConfig.PrimaryMenu.LoadNodeManipulators ();
            portalConfig.SecondaryMenu.LoadNodeManipulators ();
            portalConfig.BreadcrumbMenu.LoadNodeManipulators ();

            return portalConfig;
        }

        public static EpsilonPortalConfig GetInstance (int portalId)
        {
            return DataCache.GetCachedData<EpsilonPortalConfig> (
                cacheItemArgs.GetOrAdd (portalId,
                    (pid) => new CacheItemArgs ("//r7_Epsilon/config?portalId=" + pid, 60, CacheItemPriority.Normal)),
                (cia) => _config.GetInstance (portalId)
            );
        }

        public static EpsilonPortalConfig Instance => GetInstance (PortalSettings.Current.PortalId);
    }
}
