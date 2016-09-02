//
//  LayoutChecker.cs
//
//  Author:
//       Roman M. Yagodin <roman.yagodin@gmail.com>
//
//  Copyright (c) 2016 Roman M. Yagodin
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
using System.Linq;
using System.Xml;
using R7.Epsilon.Models;

namespace R7.Epsilon.Components
{
    public static class LayoutValidator
    {
        public static bool IsValid (string layoutMarkup)
        {
            return IsValidXml ("<root>" + layoutMarkup + "</root>") 
                && HasValidPanes (MarkupParser.ParseLayout (layoutMarkup));
        }

        private static bool IsValidXml (string markup)
        {
            try {
                if (!string.IsNullOrEmpty (markup)) {
                    var xmlDoc = new XmlDocument ();
                    xmlDoc.LoadXml (markup);
                    return true;
                }
                return false;
            }
            catch (XmlException) {
                return false;
            }
        }

        private static bool HasValidPanes (Layout layout)
        {
            var hasPanes = false;
            var hasSingleContentPane = false;
            var allPanesDistinct = false;

            // layout contains some panes
            hasPanes = layout.Panes.Count > 0;

            if (hasPanes) {
                // layout contains single ContentPane
                hasSingleContentPane = layout.Panes.SingleOrDefault (p => string.Equals (p.ID, "ContentPane", StringComparison.OrdinalIgnoreCase)) != null;

                // all panes have distinct names
                allPanesDistinct = layout.Panes.Count == layout.Panes.Distinct (new PaneEqualityComparer ()).Count ();
            }

            return hasPanes && hasSingleContentPane && allPanesDistinct;
        }
    }
}
