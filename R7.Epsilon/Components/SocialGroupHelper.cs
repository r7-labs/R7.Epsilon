//
//  File: SocialGroupHelper.cs
//  Project: R7.Epsilon
//
//  Author: Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2019 Roman M. Yagodin, R7.Labs
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
    public static class SocialGroupHelper
    {
        public static string GetFAIconName (SocialGroupType sgType)
        {
            if (sgType == SocialGroupType.VKontakte) {
                return "vk";
            }

            if (sgType == SocialGroupType.YouTube) {
                return "youtube";
            }

            if (sgType == SocialGroupType.Instagram) {
                return "instagram";
            }

            if (sgType == SocialGroupType.LinkedIn) {
                return "linkedin";
            }

            if (sgType == SocialGroupType.Telegram) {
                return "telegram";
            }

            return sgType.ToString ().ToLowerInvariant () + "-square";
        }

        public static string GetCustomColorStyle (string color)
        {
            if (!string.IsNullOrEmpty (color)) {
                return $"color:{color};";
            }

            return string.Empty;
        }
    }
}
